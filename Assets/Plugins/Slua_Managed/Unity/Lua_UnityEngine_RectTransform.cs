using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_RectTransform : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.RectTransform o;
			o=new UnityEngine.RectTransform();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLocalCorners(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector3[] a1;
			checkType(l,2,out a1);
			self.GetLocalCorners(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetWorldCorners(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector3[] a1;
			checkType(l,2,out a1);
			self.GetWorldCorners(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rect(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_anchorMin(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.anchorMin);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_anchorMin(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.anchorMin=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_anchorMax(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.anchorMax);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_anchorMax(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.anchorMax=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_anchoredPosition(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.anchoredPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_anchoredPosition(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.anchoredPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sizeDelta(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sizeDelta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sizeDelta(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.sizeDelta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pivot(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pivot);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pivot(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.pivot=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_offsetMin(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.offsetMin);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_offsetMin(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.offsetMin=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_offsetMax(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.offsetMax);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_offsetMax(IntPtr l) {
		try {
			UnityEngine.RectTransform self=(UnityEngine.RectTransform)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.offsetMax=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.RectTransform");
		addMember(l,GetLocalCorners);
		addMember(l,GetWorldCorners);
		addMember(l,"rect",get_rect,null,true);
		addMember(l,"anchorMin",get_anchorMin,set_anchorMin,true);
		addMember(l,"anchorMax",get_anchorMax,set_anchorMax,true);
		addMember(l,"anchoredPosition",get_anchoredPosition,set_anchoredPosition,true);
		addMember(l,"sizeDelta",get_sizeDelta,set_sizeDelta,true);
		addMember(l,"pivot",get_pivot,set_pivot,true);
		addMember(l,"offsetMin",get_offsetMin,set_offsetMin,true);
		addMember(l,"offsetMax",get_offsetMax,set_offsetMax,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.RectTransform),typeof(UnityEngine.Transform));
	}
}
