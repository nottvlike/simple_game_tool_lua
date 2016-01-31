using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaCollisionTrigger2DEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaCollisionTrigger2DEvent o;
			o=new LuaCollisionTrigger2DEvent();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaCollisionTrigger2DEvent");
		createTypeMetatable(l,constructor, typeof(LuaCollisionTrigger2DEvent),typeof(LuaBaseEvent));
	}
}
