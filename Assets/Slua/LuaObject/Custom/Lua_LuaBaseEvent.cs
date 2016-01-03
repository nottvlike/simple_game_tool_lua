using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaBaseEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int register(IntPtr l) {
		try {
			LuaBaseEvent self=(LuaBaseEvent)checkSelf(l);
			self.register();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_LuaCallback(IntPtr l) {
		try {
			LuaBaseEvent self=(LuaBaseEvent)checkSelf(l);
			SLua.LuaFunction v;
			checkType(l,2,out v);
			self.LuaCallback=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaBaseEvent");
		addMember(l,register);
		addMember(l,"LuaCallback",null,set_LuaCallback,true);
		createTypeMetatable(l,null, typeof(LuaBaseEvent),typeof(UnityEngine.MonoBehaviour));
	}
}
