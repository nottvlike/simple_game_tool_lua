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
	static public int init(IntPtr l) {
		try {
			LuaManager self=(LuaManager)checkSelf(l);
			self.init();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getInstance_s(IntPtr l) {
		try {
			var ret=LuaManager.getInstance();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getAssetBundlePath_s(IntPtr l) {
		try {
			var ret=LuaManager.getAssetBundlePath();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getScriptPath_s(IntPtr l) {
		try {
			var ret=LuaManager.getScriptPath();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getConfigPath_s(IntPtr l) {
		try {
			var ret=LuaManager.getConfigPath();
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
		addMember(l,init);
		addMember(l,getInstance_s);
		addMember(l,getAssetBundlePath_s);
		addMember(l,getScriptPath_s);
		addMember(l,getConfigPath_s);
		addMember(l,"DEBUG",get_DEBUG,set_DEBUG,false);
		createTypeMetatable(l,constructor, typeof(LuaManager),typeof(Singleton<LuaManager>));
	}
}
