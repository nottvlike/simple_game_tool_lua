using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public enum FileSizeUnitType
{
	Type_b,
	Type_Kb,
	Type_Mb,
	Type_Gb
}

public class FileManager {
	
	public static void CreateDirectory(string directory)
	{
		if (!IsDirectoryExist(directory))
		{
			Directory.CreateDirectory(directory);
		}
	}
	
	public static bool IsFileExist(string fullPath)
	{
		return File.Exists(fullPath);
	}
	
	public static bool IsDirectoryExist(string fullPath)
	{
		return Directory.Exists(fullPath);
	}
	
	/**
    * path：文件创建目录
    *  info：写入的内容
    */
	public static void CreateFileWithString(string path, string info)
	{
		//文件流信息
		StreamWriter sw;
		FileInfo t = new FileInfo(path);
		
		CreateDirectory(System.IO.Path.GetDirectoryName(path));
		
		if(!t.Exists)
		{
			//如果此文件不存在则创建
			sw = t.CreateText();
		}
		else
		{
			//如果此文件存在则删除
			File.Delete(path);
			sw = t.CreateText();
		}
		//以行的形式写入信息
		sw.Write(info);
		//关闭流
		sw.Close();
		//销毁流
		sw.Dispose();
	}
	
	/**
    * path：文件创建目录
    *  info：写入的内容
    */
	public static void CreateFileWithBytes(string path, byte[] info, int length)
	{
		//文件流信息
		Stream sw;
		FileInfo t = new FileInfo(path);
		CreateDirectory(System.IO.Path.GetDirectoryName(path));
		
		if (!t.Exists)
		{
			//如果此文件不存在则创建
			sw = t.Create();
		}
		else
		{
			//如果此文件存在则删除
			File.Delete(path);
			sw = t.Create();
		}
		//以行的形式写入信息
		//sw.WriteLine(info);
		sw.Write(info, 0, length);
		//关闭流
		sw.Close();
		//销毁流
		sw.Dispose();
	}
	
	/**
    * path：读取文件的路径
    * content：读取文件的内容
    */
	public static void LoadFileWithBytes(string path, out byte[] content)
	{
		content = null;

#if UNITY_ANDROID && !UNITY_EDITOR
		int size = 0;
		IntPtr p = IntPtr.Zero;
		LuaInterface.LuaDLL.getAsset(path, out p, out size);
		if (p != IntPtr.Zero)
		{
			content = new byte[size];
			Marshal.Copy(p, content, 0, size);
			LuaInterface.LuaDLL.freeObj(p);
		}
		else
		{
			Debug.Log(string.Format("Read file {0} failed", path));
		}

		return;
#else
		//使用流的形式读取
		StreamReader sr =null;
		try{
			string filepath = LuaManager.GetExternalDir() + path;
			sr = File.OpenText(filepath);
		}catch(Exception e)
		{
			//路径与名称未找到文件则直接返回空
			Debug.Log("Failed to open file " + LuaManager.GetExternalDir() + path + " Error : " + e.Message);
			return;
		}
		string line = sr.ReadToEnd();
		content = System.Text.Encoding.UTF8.GetBytes(line);
		//content = System.Text.Encoding.Unicode.GetBytes (line);
		//关闭流
		sr.Close();
		//销毁流
		sr.Dispose();
#endif
	}
	
	/**
    * path：读取文件的路径
    * content：读取文件的内容
    */
	public static string LoadFileWithString(string path)
	{
#if UNITY_ANDROID && !UNITY_EDITOR
		int size = 0;
		IntPtr p = IntPtr.Zero;
		LuaInterface.LuaDLL.getAsset(path, out p, out size);
		if (p != IntPtr.Zero)
		{
			byte[] content = new byte[size];
			Marshal.Copy(p, content, 0, size);
			LuaInterface.LuaDLL.freeObj(p);
			Debug.Log("path is " + path + " size is " + size + " data " + content.ToString());
			return System.Text.Encoding.UTF8.GetString(content);
		}
		else
		{
			Debug.Log(string.Format("Read file {0} failed", path));
		}
		
		return "";
#else
		//使用流的形式读取
		string content = null;
		StreamReader sr = null;
		try
		{
			string filepath = LuaManager.GetExternalDir() + path;
			sr = File.OpenText(filepath);
		}
		catch (Exception e)
		{
			//路径与名称未找到文件则直接返回空
			Debug.Log("Failed to open file " + LuaManager.GetExternalDir() + path + " Error : " + e.Message);
			return "";
		}
		content = sr.ReadToEnd();
		//关闭流
		sr.Close();
		//销毁流
		sr.Dispose();
		return content;
#endif
	}  
	
	/**
   * path：删除文件的路径
   */
	public static void DeleteFile(string path)
	{
		if (IsFileExist(path))
		{
			File.Delete(path);
		}
	}
	
	public static void DeleteDirectory(string directoryPath)
	{
		if (IsDirectoryExist(directoryPath))
		{
			Directory.Delete(directoryPath, true);
		}
	}
	
	public static float GetFileSize(FileSizeUnitType sizeType, long size)
	{
		long baseValue = 1;
		switch (sizeType)
		{
		case FileSizeUnitType.Type_b:
			break;
		case FileSizeUnitType.Type_Kb:
			baseValue = 1024;
			break;
		case FileSizeUnitType.Type_Mb:
			baseValue = 1024 * 1024;
			break;
		case FileSizeUnitType.Type_Gb:
			baseValue = 1024 * 1024 * 1024;
			break;
		default:
			break;
		}
		
		return (float)size / baseValue;
	}
}
