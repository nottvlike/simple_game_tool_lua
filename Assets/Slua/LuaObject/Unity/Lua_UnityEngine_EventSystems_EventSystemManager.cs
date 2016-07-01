using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_EventSystemManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddModule_s(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseRaycaster a1;
			checkType(l,1,out a1);
			UnityEngine.EventSystems.EventSystemManager.AddModule(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetModules_s(IntPtr l) {
		try {
			var ret=UnityEngine.EventSystems.EventSystemManager.GetModules();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveModule_s(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseRaycaster a1;
			checkType(l,1,out a1);
			UnityEngine.EventSystems.EventSystemManager.RemoveModule(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentSystem(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.EventSystemManager.currentSystem);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentSystem(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem v;
			checkType(l,2,out v);
			UnityEngine.EventSystems.EventSystemManager.currentSystem=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.EventSystemManager");
		addMember(l,AddModule_s);
		addMember(l,GetModules_s);
		addMember(l,RemoveModule_s);
		addMember(l,"currentSystem",get_currentSystem,set_currentSystem,false);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.EventSystemManager));
	}
}
