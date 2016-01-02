using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_SurfaceEffector2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SurfaceEffector2D o;
			o=new UnityEngine.SurfaceEffector2D();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_speed(IntPtr l) {
		try {
			UnityEngine.SurfaceEffector2D self=(UnityEngine.SurfaceEffector2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.speed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_speed(IntPtr l) {
		try {
			UnityEngine.SurfaceEffector2D self=(UnityEngine.SurfaceEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.speed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SurfaceEffector2D");
		addMember(l,"speed",get_speed,set_speed,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SurfaceEffector2D),typeof(UnityEngine.Effector2D));
	}
}
