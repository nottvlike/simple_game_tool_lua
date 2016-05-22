using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_TcpSocket : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			TcpSocket self=(TcpSocket)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			SLua.LuaFunction a3;
			checkType(l,4,out a3);
			self.Init(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Connect(IntPtr l) {
		try {
			TcpSocket self=(TcpSocket)checkSelf(l);
			self.Connect();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Send(IntPtr l) {
		try {
			TcpSocket self=(TcpSocket)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.Send(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Close(IntPtr l) {
		try {
			TcpSocket self=(TcpSocket)checkSelf(l);
			self.Close();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"TcpSocket");
		addMember(l,Init);
		addMember(l,Connect);
		addMember(l,Send);
		addMember(l,Close);
		createTypeMetatable(l,null, typeof(TcpSocket),typeof(UnityEngine.MonoBehaviour));
	}
}
