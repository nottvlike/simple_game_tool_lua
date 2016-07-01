using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_FileManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			FileManager o;
			o=new FileManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateDirectory_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			FileManager.CreateDirectory(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsFileExist_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=FileManager.IsFileExist(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsDirectoryExist_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=FileManager.IsDirectoryExist(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateFileWithString_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			FileManager.CreateFileWithString(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateFileWithBytes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkArray(l,2,out a2);
			System.Int32 a3;
			checkType(l,3,out a3);
			FileManager.CreateFileWithBytes(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadFileWithBytes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			FileManager.LoadFileWithBytes(a1,out a2);
			pushValue(l,true);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadFileWithString_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=FileManager.LoadFileWithString(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DeleteFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			FileManager.DeleteFile(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DeleteDirectory_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			FileManager.DeleteDirectory(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetFileSize_s(IntPtr l) {
		try {
			FileSizeUnitType a1;
			checkEnum(l,1,out a1);
			System.Int64 a2;
			checkType(l,2,out a2);
			var ret=FileManager.GetFileSize(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"FileManager");
		addMember(l,CreateDirectory_s);
		addMember(l,IsFileExist_s);
		addMember(l,IsDirectoryExist_s);
		addMember(l,CreateFileWithString_s);
		addMember(l,CreateFileWithBytes_s);
		addMember(l,LoadFileWithBytes_s);
		addMember(l,LoadFileWithString_s);
		addMember(l,DeleteFile_s);
		addMember(l,DeleteDirectory_s);
		addMember(l,GetFileSize_s);
		createTypeMetatable(l,constructor, typeof(FileManager));
	}
}
