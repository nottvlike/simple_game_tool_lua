using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_AudioHighPassFilter : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter o;
			o=new UnityEngine.AudioHighPassFilter();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cutoffFrequency(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cutoffFrequency);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cutoffFrequency(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.cutoffFrequency=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_highpassResonaceQ(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.highpassResonaceQ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_highpassResonaceQ(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.highpassResonaceQ=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioHighPassFilter");
		addMember(l,"cutoffFrequency",get_cutoffFrequency,set_cutoffFrequency,true);
		addMember(l,"highpassResonaceQ",get_highpassResonaceQ,set_highpassResonaceQ,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AudioHighPassFilter),typeof(UnityEngine.Behaviour));
	}
}
