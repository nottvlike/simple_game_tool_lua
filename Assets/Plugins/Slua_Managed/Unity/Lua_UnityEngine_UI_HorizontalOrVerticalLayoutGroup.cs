using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_HorizontalOrVerticalLayoutGroup : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spacing(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spacing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_spacing(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spacing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.HorizontalOrVerticalLayoutGroup");
		addMember(l,"spacing",get_spacing,set_spacing,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup),typeof(UnityEngine.UI.LayoutGroup));
	}
}
