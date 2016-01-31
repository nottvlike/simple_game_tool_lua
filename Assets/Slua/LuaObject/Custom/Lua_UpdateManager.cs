using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UpdateManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UpdateManager o;
			o=new UpdateManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int download(IntPtr l) {
		try {
			UpdateManager self=(UpdateManager)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			UpdateManager.DownloadFileType a3;
			checkEnum(l,4,out a3);
			UpdateManager.OnScriptDownloadFinishedEvent a4;
			LuaDelegation.checkDelegate(l,5,out a4);
			self.download(a1,a2,a3,a4);
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
			var ret=UpdateManager.getInstance();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UpdateTest(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UpdateManager.UpdateTest);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_OnUpdateStateChanged(IntPtr l) {
		try {
			UpdateManager self=(UpdateManager)checkSelf(l);
			UpdateManager.OnUpdateStateChangedEvent v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.OnUpdateStateChanged=v;
			else if(op==1) self.OnUpdateStateChanged+=v;
			else if(op==2) self.OnUpdateStateChanged-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_State(IntPtr l) {
		try {
			UpdateManager self=(UpdateManager)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.State);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_State(IntPtr l) {
		try {
			UpdateManager self=(UpdateManager)checkSelf(l);
			UpdateManager.UpdateFileStateType v;
			checkEnum(l,2,out v);
			self.State=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UpdateManager");
		addMember(l,download);
		addMember(l,getInstance_s);
		addMember(l,"UpdateTest",get_UpdateTest,null,false);
		addMember(l,"OnUpdateStateChanged",null,set_OnUpdateStateChanged,true);
		addMember(l,"State",get_State,set_State,true);
		createTypeMetatable(l,constructor, typeof(UpdateManager),typeof(Singleton<UpdateManager>));
	}
}
