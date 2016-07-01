using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_ScrollRect : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsActive(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			var ret=self.IsActive();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnEndDrag(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnEndDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_content(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.content);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_content(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.content=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontal(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.horizontal);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontal(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.horizontal=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_vertical(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vertical);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_vertical(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.vertical=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_movementType(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.movementType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_movementType(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.UI.ScrollRect.MovementType v;
			checkEnum(l,2,out v);
			self.movementType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_elasticity(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.elasticity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_elasticity(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.elasticity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_intertia(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.intertia);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_intertia(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.intertia=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_decelerationRate(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.decelerationRate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_decelerationRate(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.decelerationRate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontalScrollbar(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.horizontalScrollbar);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontalScrollbar(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.UI.Scrollbar v;
			checkType(l,2,out v);
			self.horizontalScrollbar=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verticalScrollbar(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.verticalScrollbar);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verticalScrollbar(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.UI.Scrollbar v;
			checkType(l,2,out v);
			self.verticalScrollbar=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_normalizedPosition(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.normalizedPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_normalizedPosition(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.normalizedPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontalNormalizedPosition(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.horizontalNormalizedPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontalNormalizedPosition(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.horizontalNormalizedPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verticalNormalizedPosition(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.verticalNormalizedPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verticalNormalizedPosition(IntPtr l) {
		try {
			UnityEngine.UI.ScrollRect self=(UnityEngine.UI.ScrollRect)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.verticalNormalizedPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ScrollRect");
		addMember(l,IsActive);
		addMember(l,OnBeginDrag);
		addMember(l,OnEndDrag);
		addMember(l,OnDrag);
		addMember(l,"content",get_content,set_content,true);
		addMember(l,"horizontal",get_horizontal,set_horizontal,true);
		addMember(l,"vertical",get_vertical,set_vertical,true);
		addMember(l,"movementType",get_movementType,set_movementType,true);
		addMember(l,"elasticity",get_elasticity,set_elasticity,true);
		addMember(l,"intertia",get_intertia,set_intertia,true);
		addMember(l,"decelerationRate",get_decelerationRate,set_decelerationRate,true);
		addMember(l,"horizontalScrollbar",get_horizontalScrollbar,set_horizontalScrollbar,true);
		addMember(l,"verticalScrollbar",get_verticalScrollbar,set_verticalScrollbar,true);
		addMember(l,"normalizedPosition",get_normalizedPosition,set_normalizedPosition,true);
		addMember(l,"horizontalNormalizedPosition",get_horizontalNormalizedPosition,set_horizontalNormalizedPosition,true);
		addMember(l,"verticalNormalizedPosition",get_verticalNormalizedPosition,set_verticalNormalizedPosition,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ScrollRect),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
