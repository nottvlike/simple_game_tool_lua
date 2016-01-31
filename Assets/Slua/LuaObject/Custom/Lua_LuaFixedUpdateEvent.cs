using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaFixedUpdateEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaFixedUpdateEvent o;
			o=new LuaFixedUpdateEvent();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaFixedUpdateEvent");
		createTypeMetatable(l,constructor, typeof(LuaFixedUpdateEvent),typeof(LuaBaseEvent));
	}
}
