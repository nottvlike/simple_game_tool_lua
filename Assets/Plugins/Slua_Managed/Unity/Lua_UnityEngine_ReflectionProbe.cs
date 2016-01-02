using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ReflectionProbe : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe o;
			o=new UnityEngine.ReflectionProbe();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_type(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.type);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_type(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.ReflectionProbeType v;
			checkEnum(l,2,out v);
			self.type=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useMipMap(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useMipMap);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useMipMap(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useMipMap=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hdr(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hdr);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hdr(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.hdr=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_size(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.size);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_size(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.size=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_center(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.center);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_center(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.center=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_nearClipPlane(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.nearClipPlane);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_nearClipPlane(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.nearClipPlane=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_farClipPlane(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.farClipPlane);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_farClipPlane(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.farClipPlane=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowDistance(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shadowDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowDistance(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_resolution(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.resolution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_resolution(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.resolution=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_updateFrequency(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updateFrequency);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_updateFrequency(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.updateFrequency=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullingMask(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cullingMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullingMask(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.cullingMask=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clearFlags(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.clearFlags);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_clearFlags(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.ReflectionProbeClearFlags v;
			checkEnum(l,2,out v);
			self.clearFlags=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_backgroundColor(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.backgroundColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_backgroundColor(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.backgroundColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.mode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mode(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.ReflectionProbeMode v;
			checkEnum(l,2,out v);
			self.mode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bakedTexture(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bakedTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bakedTexture(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.bakedTexture=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_texture(IntPtr l) {
		try {
			UnityEngine.ReflectionProbe self=(UnityEngine.ReflectionProbe)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.texture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ReflectionProbe");
		addMember(l,"type",get_type,set_type,true);
		addMember(l,"useMipMap",get_useMipMap,set_useMipMap,true);
		addMember(l,"hdr",get_hdr,set_hdr,true);
		addMember(l,"size",get_size,set_size,true);
		addMember(l,"center",get_center,set_center,true);
		addMember(l,"nearClipPlane",get_nearClipPlane,set_nearClipPlane,true);
		addMember(l,"farClipPlane",get_farClipPlane,set_farClipPlane,true);
		addMember(l,"shadowDistance",get_shadowDistance,set_shadowDistance,true);
		addMember(l,"resolution",get_resolution,set_resolution,true);
		addMember(l,"updateFrequency",get_updateFrequency,set_updateFrequency,true);
		addMember(l,"cullingMask",get_cullingMask,set_cullingMask,true);
		addMember(l,"clearFlags",get_clearFlags,set_clearFlags,true);
		addMember(l,"backgroundColor",get_backgroundColor,set_backgroundColor,true);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"bakedTexture",get_bakedTexture,set_bakedTexture,true);
		addMember(l,"texture",get_texture,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ReflectionProbe),typeof(UnityEngine.Behaviour));
	}
}
