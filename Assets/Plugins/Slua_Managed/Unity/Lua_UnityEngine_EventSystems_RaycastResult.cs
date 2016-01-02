using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_RaycastResult : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult o;
			o=new UnityEngine.EventSystems.RaycastResult();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			self.Clear();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_module(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.module);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_module(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.EventSystems.BaseRaycaster v;
			checkType(l,2,out v);
			self.module=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_distance(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.distance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_distance(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.distance=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_index(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.index);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_index(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.index=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_go(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.go);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_go(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.go=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isValid(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isValid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.RaycastResult");
		addMember(l,Clear);
		addMember(l,"module",get_module,set_module,true);
		addMember(l,"distance",get_distance,set_distance,true);
		addMember(l,"index",get_index,set_index,true);
		addMember(l,"go",get_go,set_go,true);
		addMember(l,"isValid",get_isValid,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EventSystems.RaycastResult),typeof(System.ValueType));
	}
}
