using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ReferenceResolution : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_resolution(IntPtr l) {
		try {
			UnityEngine.UI.ReferenceResolution self=(UnityEngine.UI.ReferenceResolution)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.resolution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_resolution(IntPtr l) {
		try {
			UnityEngine.UI.ReferenceResolution self=(UnityEngine.UI.ReferenceResolution)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.resolution=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_matchWidthOrHeight(IntPtr l) {
		try {
			UnityEngine.UI.ReferenceResolution self=(UnityEngine.UI.ReferenceResolution)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.matchWidthOrHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_matchWidthOrHeight(IntPtr l) {
		try {
			UnityEngine.UI.ReferenceResolution self=(UnityEngine.UI.ReferenceResolution)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.matchWidthOrHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ReferenceResolution");
		addMember(l,"resolution",get_resolution,set_resolution,true);
		addMember(l,"matchWidthOrHeight",get_matchWidthOrHeight,set_matchWidthOrHeight,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ReferenceResolution),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
