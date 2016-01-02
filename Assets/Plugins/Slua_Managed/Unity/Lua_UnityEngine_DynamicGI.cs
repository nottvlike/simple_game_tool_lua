using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_DynamicGI : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.DynamicGI o;
			o=new UnityEngine.DynamicGI();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetIndirectScale_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			UnityEngine.DynamicGI.SetIndirectScale(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetEmissive_s(IntPtr l) {
		try {
			UnityEngine.Renderer a1;
			checkType(l,1,out a1);
			UnityEngine.Color a2;
			checkType(l,2,out a2);
			System.Int32 a3;
			checkType(l,3,out a3);
			UnityEngine.DynamicGI.SetEmissive(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateMaterials_s(IntPtr l) {
		try {
			UnityEngine.Renderer a1;
			checkType(l,1,out a1);
			UnityEngine.DynamicGI.UpdateMaterials(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateEnvironment_s(IntPtr l) {
		try {
			UnityEngine.DynamicGI.UpdateEnvironment();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_synchronousMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.DynamicGI.synchronousMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_synchronousMode(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.DynamicGI.synchronousMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.DynamicGI");
		addMember(l,SetIndirectScale_s);
		addMember(l,SetEmissive_s);
		addMember(l,UpdateMaterials_s);
		addMember(l,UpdateEnvironment_s);
		addMember(l,"synchronousMode",get_synchronousMode,set_synchronousMode,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.DynamicGI));
	}
}
