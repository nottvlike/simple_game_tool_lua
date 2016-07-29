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
	static public int GetExternalDir_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			var ret=LuaManager.GetExternalDir(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_L(IntPtr l) {
		try {
			LuaManager self=(LuaManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.L);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaManager");
		addMember(l,Init);
		addMember(l,GetInstance_s);
		addMember(l,GetExternalDir_s);
		addMember(l,"L",get_L,null,true);
		createTypeMetatable(l,constructor, typeof(LuaManager),typeof(Singleton<LuaManager>));
	}
}
