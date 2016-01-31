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
	static public int createDirectory_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			FileManager.createDirectory(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isFileExist_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=FileManager.isFileExist(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isDirectoryExist_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=FileManager.isDirectoryExist(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int createFileWithString_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			FileManager.createFileWithString(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int createFileWithBytes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkType(l,2,out a2);
			System.Int32 a3;
			checkType(l,3,out a3);
			FileManager.createFileWithBytes(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int loadFileWithBytes_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			FileManager.loadFileWithBytes(a1,out a2);
			pushValue(l,true);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int loadFileWithString_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=FileManager.loadFileWithString(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int deleteFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			FileManager.deleteFile(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"FileManager");
		addMember(l,createDirectory_s);
		addMember(l,isFileExist_s);
		addMember(l,isDirectoryExist_s);
		addMember(l,createFileWithString_s);
		addMember(l,createFileWithBytes_s);
		addMember(l,loadFileWithBytes_s);
		addMember(l,loadFileWithString_s);
		addMember(l,deleteFile_s);
		createTypeMetatable(l,constructor, typeof(FileManager));
	}
}
