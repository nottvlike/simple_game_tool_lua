using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using SLua;

public struct Message
{
	public byte[] Data;
	public bool   IsLast;
};

public class TcpSocket : MonoBehaviour {

	const UInt16 CACHE_SIZE = 4069;
	const int WAIT_OUT_TIME = 5000;

	List<Message> _messageList = new List<Message> ();
	Byte[] _recvBytes = new Byte[CACHE_SIZE];
	Byte[] _header = new Byte[2];
	byte[] _currentMessage;
	UInt16 _currentMessageLength;

	Thread _recvThread;
	Socket _socket;
	string _ip;
	int _port;
	LuaFunction _recvCallback;

	void Destroy()
	{
		_recvThread.Abort ();
		_recvCallback = null;
	}
	
	void OnApplicationQuit()
	{
		if (_recvCallback != null)
			_recvThread.Abort ();
	}

	public void Init(string ip, int port, LuaFunction recvCallback)
	{
		_ip = ip;
		_port = port;
		_recvCallback = recvCallback;

		_socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	}

	public void Connect()
	{
		IPAddress address = IPAddress.Parse (_ip);
		IPEndPoint ipEnterPoint = new IPEndPoint (address, _port);
		IAsyncResult result = _socket.BeginConnect(ipEnterPoint, new AsyncCallback(ConnectSuccess), _socket);

		bool success = result.AsyncWaitHandle.WaitOne (WAIT_OUT_TIME, true);
		if (!success)
		{
			Debug.LogWarning(string.Format ("Connect to {0}:{1} Failed!", _ip, _port));
			Close();
		}
		else
		{
			_recvThread = new Thread(new ThreadStart(Receive));
			_recvThread.IsBackground = true;
			_recvThread.Start();
		}
	}

	void Receive()
	{
		while (true) 
		{
			if (!_socket.Connected)
			{
				_socket.Close();
				break;
			}

			try
			{
				Array.Clear(_recvBytes, 0, _recvBytes.Length);
				int length = _socket.Receive(_recvBytes, _recvBytes.Length, 0);
				if (length <= 0)
				{
					_socket.Close();
					break;
				}
				if (length > 2)
				{
					UpackPackage(_recvBytes, 0);
				}
				else
				{
					Debug.LogWarning("Reveive Bytes is not larger than 2!");
				}
			}
			catch (Exception e)
			{
				Debug.Log (string.Format("Receive Msg Error : {0}! ",e.Message));
			}
		}
	}

	void UpackPackage(Byte[] bytes, UInt16 index)
	{
		while (true) {
			if (_currentMessageLength > 0 && _currentMessageLength < CACHE_SIZE - index)
			{
				Byte[] data = new Byte[_currentMessageLength];
				Array.Copy (bytes, index, data, 0, _currentMessageLength);
				AddMessageToList(data, true);
				index += _currentMessageLength;
				_currentMessageLength = 0;
			}
			else if (_currentMessageLength == 0)
			{
				UInt16 headLengthIndex = (UInt16)(index + 2);
				_header[0] = bytes[index + 1];
				_header[1] = bytes[index];
				UInt16 length = BitConverter.ToUInt16(_header, 0);
				if (length > CACHE_SIZE - headLengthIndex)
				{
					_currentMessageLength = (UInt16)(length - CACHE_SIZE + headLengthIndex);
					Byte[] data = new Byte[CACHE_SIZE - headLengthIndex];
					Array.Copy (bytes, index, data, 0, CACHE_SIZE - headLengthIndex);
					AddMessageToList(data, false);
					break;
				}
				else if (length > 0 && length <= CACHE_SIZE - headLengthIndex)
				{
					Byte[] data = new Byte[length];
					Array.Copy (bytes, headLengthIndex, data, 0, length);
					AddMessageToList(data, true);
					index = (UInt16)(headLengthIndex + length);
				}
				else
				{
					break;
				}
			}
			else if (_currentMessageLength >= CACHE_SIZE - index)
			{
				_currentMessageLength = (UInt16)(_currentMessageLength - CACHE_SIZE + index);
				Byte[] data = new Byte[CACHE_SIZE - index];
				Array.Copy (bytes, index, data, 0, CACHE_SIZE - index);
				AddMessageToList(data, false);
				break;
			}
		}
	}

	public void Send(string str)
	{
		Byte[] msg = System.Text.Encoding.UTF8.GetBytes (str);

		if (!_socket.Connected) 
		{
			_socket.Close();
			return;			
		}

		try
		{
			IAsyncResult result = _socket.BeginSend(msg, 0, msg.Length, SocketFlags.None, new AsyncCallback(SendCallback), _socket);
			bool success = result.AsyncWaitHandle.WaitOne(WAIT_OUT_TIME, true);
			if(!success)
			{
				_socket.Close();
				Debug.Log (string.Format("Send Msg Failed {0} !", str));
			}
		}
		catch
		{
			Debug.Log("send message error" ); 
		}
	}

	void SendCallback(IAsyncResult result)
	{
		//Debug.Log ("Send MSG Success!");
	}

	void AddMessageToList(byte[] data, bool isLast)
	{
		var message = new Message();
		message.Data = data;
		message.IsLast = isLast;
		lock (_messageList)
		{
			// Access thread-sensitive resources.
			_messageList.Add (message);
		}
	}
	
	public void Close()
	{
		if (_socket != null && _socket.Connected) 
		{
			lock (_messageList)
			{
				_messageList.Clear();
			}

			_socket.Shutdown(SocketShutdown.Both);
			_socket.Close();
		}
		_socket = null;
	}

	void ConnectSuccess(IAsyncResult result)
	{
		//Debug.Log ("Connect Success!");
	}

	void Update()
	{
		lock (_messageList)
		{
			if (_messageList.Count > 0) 
			{
				var data = _messageList[0];
				_recvCallback.call(data.Data, data.IsLast);
				_messageList.RemoveAt(0);
			}
		}
	}
}
