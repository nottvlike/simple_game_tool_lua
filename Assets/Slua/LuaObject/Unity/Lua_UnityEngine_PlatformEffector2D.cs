using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_PlatformEffector2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D o;
			o=new UnityEngine.PlatformEffector2D();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_oneWay(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.oneWay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_oneWay(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.oneWay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sideFriction(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sideFriction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sideFriction(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.sideFriction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sideBounce(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sideBounce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sideBounce(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.sideBounce=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sideAngleVariance(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sideAngleVariance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sideAngleVariance(IntPtr l) {
		try {
			UnityEngine.PlatformEffector2D self=(UnityEngine.PlatformEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.sideAngleVariance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PlatformEffector2D");
		addMember(l,"oneWay",get_oneWay,set_oneWay,true);
		addMember(l,"sideFriction",get_sideFriction,set_sideFriction,true);
		addMember(l,"sideBounce",get_sideBounce,set_sideBounce,true);
		addMember(l,"sideAngleVariance",get_sideAngleVariance,set_sideAngleVariance,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlatformEffector2D),typeof(UnityEngine.Effector2D));
	}
}
