using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_ResourceManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			ResourceManager o;
			o=new ResourceManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.Init(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadConfigFileByPath(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.LoadConfigFileByPath(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadConfigFile(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.LoadConfigFile(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SingleLineLoad(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			SLua.LuaFunction a2;
			checkType(l,3,out a2);
			self.SingleLineLoad(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSharedDependencies(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			Dependency a2;
			var ret=self.GetSharedDependencies(a1,out a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
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
			var ret=ResourceManager.GetInstance();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ResourceLoadState(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.ResourceLoadState);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ResourceLoadState(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			ResourceLoadStateType v;
			checkEnum(l,2,out v);
			self.ResourceLoadState=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PrefabRequestDict(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.PrefabRequestDict);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SharedAssetbundleDict(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.SharedAssetbundleDict);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"ResourceManager");
		addMember(l,Init);
		addMember(l,LoadConfigFileByPath);
		addMember(l,LoadConfigFile);
		addMember(l,SingleLineLoad);
		addMember(l,GetSharedDependencies);
		addMember(l,Clear);
		addMember(l,GetInstance_s);
		addMember(l,"ResourceLoadState",get_ResourceLoadState,set_ResourceLoadState,true);
		addMember(l,"PrefabRequestDict",get_PrefabRequestDict,null,true);
		addMember(l,"SharedAssetbundleDict",get_SharedAssetbundleDict,null,true);
		createTypeMetatable(l,constructor, typeof(ResourceManager),typeof(Singleton<ResourceManager>));
	}
}
