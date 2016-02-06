using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaManager o;
			o=new LuaManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			LuaManager self=(LuaManager)checkSelf(l);
			self.Init();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetInstance_s(IntPtr l) {
		try {
			var ret=LuaManager.GetInstance();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAssetBundlePath_s(IntPtr l) {
		try {
			var ret=LuaManager.GetAssetBundlePath();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetScriptPath_s(IntPtr l) {
		try {
			var ret=LuaManager.GetScriptPath();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetConfigPath_s(IntPtr l) {
		try {
			var ret=LuaManager.GetConfigPath();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_DEBUG(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,LuaManager.DEBUG);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_DEBUG(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			LuaManager.DEBUG=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaManager");
		addMember(l,Init);
		addMember(l,GetInstance_s);
		addMember(l,GetAssetBundlePath_s);
		addMember(l,GetScriptPath_s);
		addMember(l,GetConfigPath_s);
		addMember(l,"DEBUG",get_DEBUG,set_DEBUG,false);
		createTypeMetatable(l,constructor, typeof(LuaManager),typeof(Singleton<LuaManager>));
	}
}
