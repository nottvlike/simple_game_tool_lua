using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_AudioLowPassFilter : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AudioLowPassFilter o;
			o=new UnityEngine.AudioLowPassFilter();
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
			UnityEngine.AudioLowPassFilter self=(UnityEngine.AudioLowPassFilter)checkSelf(l);
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
			UnityEngine.AudioLowPassFilter self=(UnityEngine.AudioLowPassFilter)checkSelf(l);
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
	static public int get_lowpassResonaceQ(IntPtr l) {
		try {
			UnityEngine.AudioLowPassFilter self=(UnityEngine.AudioLowPassFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lowpassResonaceQ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lowpassResonaceQ(IntPtr l) {
		try {
			UnityEngine.AudioLowPassFilter self=(UnityEngine.AudioLowPassFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.lowpassResonaceQ=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioLowPassFilter");
		addMember(l,"cutoffFrequency",get_cutoffFrequency,set_cutoffFrequency,true);
		addMember(l,"lowpassResonaceQ",get_lowpassResonaceQ,set_lowpassResonaceQ,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AudioLowPassFilter),typeof(UnityEngine.Behaviour));
	}
}
