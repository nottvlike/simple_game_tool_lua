using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ToggleGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int NotifyEnabled(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			UnityEngine.UI.Toggle a1;
			checkType(l,2,out a1);
			self.NotifyEnabled(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnregisterToggle(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			UnityEngine.UI.Toggle a1;
			checkType(l,2,out a1);
			self.UnregisterToggle(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegisterToggle(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			UnityEngine.UI.Toggle a1;
			checkType(l,2,out a1);
			self.RegisterToggle(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AnyTogglesActive(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			var ret=self.AnyTogglesActive();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ToggleGroup");
		addMember(l,NotifyEnabled);
		addMember(l,UnregisterToggle);
		addMember(l,RegisterToggle);
		addMember(l,AnyTogglesActive);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ToggleGroup),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
