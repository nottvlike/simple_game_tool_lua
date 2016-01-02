using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_RenderMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RenderMode");
		addMember(l,0,"Overlay");
		addMember(l,1,"OverlayCamera");
		addMember(l,2,"World");
		LuaDLL.lua_pop(l, 1);
	}
}
