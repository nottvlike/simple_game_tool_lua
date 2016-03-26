using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CameraMove : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Target(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Target);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Target(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.Target=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Distance(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Distance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Distance(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.Distance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Height(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Height);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Height(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.Height=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_HeightDamping(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.HeightDamping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_HeightDamping(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.HeightDamping=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_RotationDamping(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.RotationDamping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RotationDamping(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.RotationDamping=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CameraMove");
		addMember(l,"Target",get_Target,set_Target,true);
		addMember(l,"Distance",get_Distance,set_Distance,true);
		addMember(l,"Height",get_Height,set_Height,true);
		addMember(l,"HeightDamping",get_HeightDamping,set_HeightDamping,true);
		addMember(l,"RotationDamping",get_RotationDamping,set_RotationDamping,true);
		createTypeMetatable(l,null, typeof(CameraMove),typeof(UnityEngine.MonoBehaviour));
	}
}
