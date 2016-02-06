using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaEventManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaEventManager o;
			o=new LuaEventManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddFixedUpdateEvent_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			SLua.LuaFunction a2;
			checkType(l,2,out a2);
			LuaEventManager.AddFixedUpdateEvent(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddUpdateEvent_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			SLua.LuaFunction a2;
			checkType(l,2,out a2);
			LuaEventManager.AddUpdateEvent(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddAnimationEvent_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			SLua.LuaFunction a2;
			checkType(l,2,out a2);
			LuaEventManager.AddAnimationEvent(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddCollisionTrigger2DEvent_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			SLua.LuaFunction a2;
			checkType(l,2,out a2);
			LuaEventManager.AddCollisionTrigger2DEvent(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaEventManager");
		addMember(l,AddFixedUpdateEvent_s);
		addMember(l,AddUpdateEvent_s);
		addMember(l,AddAnimationEvent_s);
		addMember(l,AddCollisionTrigger2DEvent_s);
		createTypeMetatable(l,constructor, typeof(LuaEventManager));
	}
}
