using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaAnimationEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaAnimationEvent o;
			o=new LuaAnimationEvent();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int register(IntPtr l) {
		try {
			LuaAnimationEvent self=(LuaAnimationEvent)checkSelf(l);
			self.register();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onAnimationFinished(IntPtr l) {
		try {
			LuaAnimationEvent self=(LuaAnimationEvent)checkSelf(l);
			self.onAnimationFinished();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaAnimationEvent");
		addMember(l,register);
		addMember(l,onAnimationFinished);
		createTypeMetatable(l,constructor, typeof(LuaAnimationEvent),typeof(LuaBaseEvent));
	}
}
