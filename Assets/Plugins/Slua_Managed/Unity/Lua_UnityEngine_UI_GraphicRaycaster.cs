using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_GraphicRaycaster : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Raycast(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> a2;
			checkType(l,3,out a2);
			self.Raycast(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ignoreReversedGraphics(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreReversedGraphics);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ignoreReversedGraphics(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ignoreReversedGraphics=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_blockingObjects(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.blockingObjects);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_blockingObjects(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			UnityEngine.UI.GraphicRaycaster.BlockingObjects v;
			checkEnum(l,2,out v);
			self.blockingObjects=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_priority(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.priority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventCamera(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eventCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultPriority(IntPtr l) {
		try {
			UnityEngine.UI.GraphicRaycaster self=(UnityEngine.UI.GraphicRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.GraphicRaycaster");
		addMember(l,Raycast);
		addMember(l,"ignoreReversedGraphics",get_ignoreReversedGraphics,set_ignoreReversedGraphics,true);
		addMember(l,"blockingObjects",get_blockingObjects,set_blockingObjects,true);
		addMember(l,"priority",get_priority,null,true);
		addMember(l,"eventCamera",get_eventCamera,null,true);
		addMember(l,"defaultPriority",get_defaultPriority,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.GraphicRaycaster),typeof(UnityEngine.EventSystems.BaseRaycaster));
	}
}
