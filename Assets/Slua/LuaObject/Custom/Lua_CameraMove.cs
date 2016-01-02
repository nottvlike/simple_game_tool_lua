using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CameraMove : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setTarget(IntPtr l) {
		try {
			CameraMove self=(CameraMove)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.setTarget(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CameraMove");
		addMember(l,setTarget);
		createTypeMetatable(l,null, typeof(CameraMove),typeof(UnityEngine.MonoBehaviour));
	}
}
