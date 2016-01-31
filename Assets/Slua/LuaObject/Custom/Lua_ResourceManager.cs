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
	static public int init(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.init(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int loadConfigFile(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.loadConfigFile(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int singleLineLoadAsync(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			SLua.LuaFunction a2;
			checkType(l,3,out a2);
			self.singleLineLoadAsync(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int loadAssetBundleByPath(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			SLua.LuaFunction a3;
			checkType(l,4,out a3);
			self.loadAssetBundleByPath(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int hasPrefabRequest(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			PrefabRequest a2;
			var ret=self.hasPrefabRequest(a1,out a2);
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
	static public int hasConfigRequest(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			ConfigRequest a2;
			var ret=self.hasConfigRequest(a1,out a2);
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
	static public int clear(IntPtr l) {
		try {
			ResourceManager self=(ResourceManager)checkSelf(l);
			self.clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getInstance_s(IntPtr l) {
		try {
			var ret=ResourceManager.getInstance();
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
	static public void reg(IntPtr l) {
		getTypeTable(l,"ResourceManager");
		addMember(l,init);
		addMember(l,loadConfigFile);
		addMember(l,singleLineLoadAsync);
		addMember(l,loadAssetBundleByPath);
		addMember(l,hasPrefabRequest);
		addMember(l,hasConfigRequest);
		addMember(l,clear);
		addMember(l,getInstance_s);
		addMember(l,"ResourceLoadState",get_ResourceLoadState,set_ResourceLoadState,true);
		addMember(l,"PrefabRequestDict",get_PrefabRequestDict,null,true);
		createTypeMetatable(l,constructor, typeof(ResourceManager),typeof(Singleton<ResourceManager>));
	}
}
