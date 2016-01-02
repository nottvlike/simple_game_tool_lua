using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Rendering_SphericalHarmonics3 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 o;
			o=new UnityEngine.Rendering.SphericalHarmonics3();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			self.Clear();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddAmbientLight(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			UnityEngine.Color a1;
			checkType(l,2,out a1);
			self.AddAmbientLight(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddDirectionalLight(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Color a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.AddDirectionalLight(a1,a2,a3);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Multiply(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(float),typeof(UnityEngine.Rendering.SphericalHarmonics3))){
				System.Single a1;
				checkType(l,1,out a1);
				UnityEngine.Rendering.SphericalHarmonics3 a2;
				checkValueType(l,2,out a2);
				var ret=a1*a2;
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rendering.SphericalHarmonics3),typeof(float))){
				UnityEngine.Rendering.SphericalHarmonics3 a1;
				checkValueType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				var ret=a1*a2;
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
	static public int op_Addition(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Rendering.SphericalHarmonics3 a2;
			checkValueType(l,2,out a2);
			var ret=a1+a2;
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Rendering.SphericalHarmonics3 a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Rendering.SphericalHarmonics3 a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh0r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh0r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh0r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh0r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh0g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh0g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh0g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh0g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh0b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh0b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh0b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh0b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh1r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh1r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh1r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh1r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh1g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh1g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh1g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh1g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh1b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh1b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh1b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh1b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh2r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh2r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh2r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh2r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh2g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh2g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh2g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh2g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh2b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh2b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh2b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh2b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh3r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh3r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh3r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh3r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh3g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh3g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh3g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh3g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh3b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh3b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh3b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh3b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh4r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh4r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh4r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh4r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh4g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh4g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh4g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh4g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh4b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh4b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh4b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh4b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh5r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh5r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh5r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh5r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh5g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh5g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh5g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh5g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh5b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh5b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh5b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh5b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh6r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh6r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh6r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh6r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh6g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh6g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh6g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh6g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh6b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh6b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh6b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh6b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh7r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh7r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh7r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh7r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh7g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh7g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh7g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh7g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh7b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh7b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh7b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh7b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh8r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh8r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh8r(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh8r=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh8g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh8g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh8g(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh8g=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sh8b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sh8b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sh8b(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.sh8b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getItem(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			var ret = self[v];
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setItem(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonics3 self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			UnityEngine.Vector3 c;
			checkType(l,3,out c);
			self[v]=c;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Rendering.SphericalHarmonics3");
		addMember(l,Clear);
		addMember(l,AddAmbientLight);
		addMember(l,AddDirectionalLight);
		addMember(l,op_Multiply);
		addMember(l,op_Addition);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"sh0r",get_sh0r,set_sh0r,true);
		addMember(l,"sh0g",get_sh0g,set_sh0g,true);
		addMember(l,"sh0b",get_sh0b,set_sh0b,true);
		addMember(l,"sh1r",get_sh1r,set_sh1r,true);
		addMember(l,"sh1g",get_sh1g,set_sh1g,true);
		addMember(l,"sh1b",get_sh1b,set_sh1b,true);
		addMember(l,"sh2r",get_sh2r,set_sh2r,true);
		addMember(l,"sh2g",get_sh2g,set_sh2g,true);
		addMember(l,"sh2b",get_sh2b,set_sh2b,true);
		addMember(l,"sh3r",get_sh3r,set_sh3r,true);
		addMember(l,"sh3g",get_sh3g,set_sh3g,true);
		addMember(l,"sh3b",get_sh3b,set_sh3b,true);
		addMember(l,"sh4r",get_sh4r,set_sh4r,true);
		addMember(l,"sh4g",get_sh4g,set_sh4g,true);
		addMember(l,"sh4b",get_sh4b,set_sh4b,true);
		addMember(l,"sh5r",get_sh5r,set_sh5r,true);
		addMember(l,"sh5g",get_sh5g,set_sh5g,true);
		addMember(l,"sh5b",get_sh5b,set_sh5b,true);
		addMember(l,"sh6r",get_sh6r,set_sh6r,true);
		addMember(l,"sh6g",get_sh6g,set_sh6g,true);
		addMember(l,"sh6b",get_sh6b,set_sh6b,true);
		addMember(l,"sh7r",get_sh7r,set_sh7r,true);
		addMember(l,"sh7g",get_sh7g,set_sh7g,true);
		addMember(l,"sh7b",get_sh7b,set_sh7b,true);
		addMember(l,"sh8r",get_sh8r,set_sh8r,true);
		addMember(l,"sh8g",get_sh8g,set_sh8g,true);
		addMember(l,"sh8b",get_sh8b,set_sh8b,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Rendering.SphericalHarmonics3),typeof(System.ValueType));
	}
}
