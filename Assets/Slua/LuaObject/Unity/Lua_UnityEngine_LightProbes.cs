using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_LightProbes : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LightProbes o;
			o=new UnityEngine.LightProbes();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetInterpolatedLightProbe(IntPtr l) {
		try {
			UnityEngine.LightProbes self=(UnityEngine.LightProbes)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Renderer a2;
			checkType(l,3,out a2);
			System.Single[] a3;
			checkArray(l,4,out a3);
			self.GetInterpolatedLightProbe(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_positions(IntPtr l) {
		try {
			UnityEngine.LightProbes self=(UnityEngine.LightProbes)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.positions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_coefficients(IntPtr l) {
		try {
			UnityEngine.LightProbes self=(UnityEngine.LightProbes)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.coefficients);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_coefficients(IntPtr l) {
		try {
			UnityEngine.LightProbes self=(UnityEngine.LightProbes)checkSelf(l);
			System.Single[] v;
			checkArray(l,2,out v);
			self.coefficients=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_count(IntPtr l) {
		try {
			UnityEngine.LightProbes self=(UnityEngine.LightProbes)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.count);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cellCount(IntPtr l) {
		try {
			UnityEngine.LightProbes self=(UnityEngine.LightProbes)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cellCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.LightProbes");
		addMember(l,GetInterpolatedLightProbe);
		addMember(l,"positions",get_positions,null,true);
		addMember(l,"coefficients",get_coefficients,set_coefficients,true);
		addMember(l,"count",get_count,null,true);
		addMember(l,"cellCount",get_cellCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LightProbes),typeof(UnityEngine.Object));
	}
}
