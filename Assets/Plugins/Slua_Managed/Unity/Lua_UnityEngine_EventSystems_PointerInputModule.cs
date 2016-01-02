using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_PointerInputModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsPointerOverEventSystemObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule self=(UnityEngine.EventSystems.PointerInputModule)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.IsPointerOverEventSystemObject(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_kMouseId(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.PointerInputModule.kMouseId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_kFakeTouchesId(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.PointerInputModule.kFakeTouchesId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.PointerInputModule");
		addMember(l,IsPointerOverEventSystemObject);
		addMember(l,"kMouseId",get_kMouseId,null,false);
		addMember(l,"kFakeTouchesId",get_kFakeTouchesId,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.PointerInputModule),typeof(UnityEngine.EventSystems.BaseInputModule));
	}
}
