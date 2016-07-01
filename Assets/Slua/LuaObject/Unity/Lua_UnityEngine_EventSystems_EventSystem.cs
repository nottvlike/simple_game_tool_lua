using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_EventSystem : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateModules(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			self.UpdateModules();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetSelectedGameObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			UnityEngine.EventSystems.BaseEventData a2;
			checkType(l,3,out a2);
			self.SetSelectedGameObject(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RaycastAll(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> a2;
			checkType(l,3,out a2);
			self.RaycastAll(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsPointerOverEventSystemObject(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
				var ret=self.IsPointerOverEventSystemObject();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.IsPointerOverEventSystemObject(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentInputModule(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.currentInputModule);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_firstSelectedObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.firstSelectedObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentSelectedObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.currentSelectedObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lastSelectedObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.EventSystem self=(UnityEngine.EventSystems.EventSystem)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lastSelectedObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.EventSystem");
		addMember(l,UpdateModules);
		addMember(l,SetSelectedGameObject);
		addMember(l,RaycastAll);
		addMember(l,IsPointerOverEventSystemObject);
		addMember(l,"currentInputModule",get_currentInputModule,null,true);
		addMember(l,"firstSelectedObject",get_firstSelectedObject,null,true);
		addMember(l,"currentSelectedObject",get_currentSelectedObject,null,true);
		addMember(l,"lastSelectedObject",get_lastSelectedObject,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.EventSystem),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
