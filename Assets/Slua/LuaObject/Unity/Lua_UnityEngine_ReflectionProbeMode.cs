using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ReflectionProbeMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ReflectionProbeMode");
		addMember(l,0,"Baked");
		addMember(l,2,"Custom");
		LuaDLL.lua_pop(l, 1);
	}
}
