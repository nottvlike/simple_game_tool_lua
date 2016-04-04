using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaCollisionTriggerEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaCollisionTriggerEvent o;
			o=new LuaCollisionTriggerEvent();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnTriggerEnter(IntPtr l) {
		try {
			LuaCollisionTriggerEvent self=(LuaCollisionTriggerEvent)checkSelf(l);
			UnityEngine.Collider a1;
			checkType(l,2,out a1);
			self.OnTriggerEnter(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnTriggerStay(IntPtr l) {
		try {
			LuaCollisionTriggerEvent self=(LuaCollisionTriggerEvent)checkSelf(l);
			UnityEngine.Collider a1;
			checkType(l,2,out a1);
			self.OnTriggerStay(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnTriggerExit(IntPtr l) {
		try {
			LuaCollisionTriggerEvent self=(LuaCollisionTriggerEvent)checkSelf(l);
			UnityEngine.Collider a1;
			checkType(l,2,out a1);
			self.OnTriggerExit(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaCollisionTriggerEvent");
		addMember(l,OnTriggerEnter);
		addMember(l,OnTriggerStay);
		addMember(l,OnTriggerExit);
		createTypeMetatable(l,constructor, typeof(LuaCollisionTriggerEvent),typeof(LuaBaseEvent));
	}
}
