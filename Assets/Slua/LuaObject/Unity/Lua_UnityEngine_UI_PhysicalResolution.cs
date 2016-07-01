using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_PhysicalResolution : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_unit(IntPtr l) {
		try {
			UnityEngine.UI.PhysicalResolution self=(UnityEngine.UI.PhysicalResolution)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.unit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_unit(IntPtr l) {
		try {
			UnityEngine.UI.PhysicalResolution self=(UnityEngine.UI.PhysicalResolution)checkSelf(l);
			UnityEngine.UI.PhysicalResolution.Unit v;
			checkEnum(l,2,out v);
			self.unit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultDPI(IntPtr l) {
		try {
			UnityEngine.UI.PhysicalResolution self=(UnityEngine.UI.PhysicalResolution)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultDPI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultDPI(IntPtr l) {
		try {
			UnityEngine.UI.PhysicalResolution self=(UnityEngine.UI.PhysicalResolution)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.defaultDPI=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.PhysicalResolution");
		addMember(l,"unit",get_unit,set_unit,true);
		addMember(l,"defaultDPI",get_defaultDPI,set_defaultDPI,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.PhysicalResolution),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
