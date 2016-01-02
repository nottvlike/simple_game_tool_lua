using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_InputField : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnFocus(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.OnFocus();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnLostFocus(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.OnLostFocus();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MoveTextEnd(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.MoveTextEnd(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MoveTextStart(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.MoveTextStart(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScreenToLocal(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			var ret=self.ScreenToLocal(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCharacterIndexFromPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			var ret=self.GetCharacterIndexFromPosition(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnUpdateSelected(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnUpdateSelected(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Rebuild(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.CanvasUpdate a1;
			checkEnum(l,2,out a1);
			self.Rebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerClick(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerClick(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDeselect(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnDeselect(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSubmit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSubmit(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inputType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.inputType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_inputType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.InputType v;
			checkEnum(l,2,out v);
			self.inputType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_keyboardType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.keyboardType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_keyboardType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.TouchScreenKeyboardType v;
			checkEnum(l,2,out v);
			self.keyboardType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_validation(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.validation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_validation(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.Validation v;
			checkEnum(l,2,out v);
			self.validation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_characterLimit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.characterLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_characterLimit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.characterLimit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_multiLine(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.multiLine);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_multiLine(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.multiLine=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_activeTextColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.activeTextColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_activeTextColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.activeTextColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onSubmit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onSubmit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onSubmit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.SubmitEvent v;
			checkType(l,2,out v);
			self.onSubmit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onValidateInput(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.OnValidateInput v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onValidateInput=v;
			else if(op==1) self.onValidateInput+=v;
			else if(op==2) self.onValidateInput-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectionColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectionColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectionColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.selectionColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_value(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.value);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_value(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.value=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.InputField");
		addMember(l,OnFocus);
		addMember(l,OnLostFocus);
		addMember(l,MoveTextEnd);
		addMember(l,MoveTextStart);
		addMember(l,ScreenToLocal);
		addMember(l,GetCharacterIndexFromPosition);
		addMember(l,OnDrag);
		addMember(l,OnPointerDown);
		addMember(l,OnUpdateSelected);
		addMember(l,Rebuild);
		addMember(l,OnPointerClick);
		addMember(l,OnDeselect);
		addMember(l,OnSubmit);
		addMember(l,"inputType",get_inputType,set_inputType,true);
		addMember(l,"keyboardType",get_keyboardType,set_keyboardType,true);
		addMember(l,"validation",get_validation,set_validation,true);
		addMember(l,"characterLimit",get_characterLimit,set_characterLimit,true);
		addMember(l,"multiLine",get_multiLine,set_multiLine,true);
		addMember(l,"activeTextColor",get_activeTextColor,set_activeTextColor,true);
		addMember(l,"onSubmit",get_onSubmit,set_onSubmit,true);
		addMember(l,"onValidateInput",null,set_onValidateInput,true);
		addMember(l,"selectionColor",get_selectionColor,set_selectionColor,true);
		addMember(l,"value",get_value,set_value,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.InputField),typeof(UnityEngine.UI.Selectable));
	}
}
