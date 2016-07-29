using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_PoolManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			PoolManager o;
			o=new PoolManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CloneGameObject(IntPtr l) {
		try {
			PoolManager self=(PoolManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Object a2;
			checkType(l,3,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,4,out a3);
			UnityEngine.Quaternion a4;
			checkType(l,5,out a4);
			var ret=self.CloneGameObject(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReleaseGameObject(IntPtr l) {
		try {
			PoolManager self=(PoolManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			UnityEngine.Object a2;
			checkType(l,3,out a2);
			self.ReleaseGameObject(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			PoolManager self=(PoolManager)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetInstance_s(IntPtr l) {
		try {
			var ret=PoolManager.GetInstance();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"PoolManager");
		addMember(l,CloneGameObject);
		addMember(l,ReleaseGameObject);
		addMember(l,Clear);
		addMember(l,GetInstance_s);
		createTypeMetatable(l,constructor, typeof(PoolManager));
	}
}
