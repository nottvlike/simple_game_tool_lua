using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_AudioClipFormat : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AudioClipFormat");
		addMember(l,0,"Compressed");
		addMember(l,1,"ADPCM");
		addMember(l,-1,"PCM");
		LuaDLL.lua_pop(l, 1);
	}
}
