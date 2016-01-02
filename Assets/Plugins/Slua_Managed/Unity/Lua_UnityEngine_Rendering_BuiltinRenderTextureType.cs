using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Rendering_BuiltinRenderTextureType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Rendering.BuiltinRenderTextureType");
		addMember(l,0,"None");
		addMember(l,1,"CurrentActive");
		addMember(l,2,"CurrentTarget");
		addMember(l,3,"Depth");
		addMember(l,4,"DepthNormals");
		addMember(l,8,"PrepassNormalsSpec");
		addMember(l,11,"GBuffer0");
		addMember(l,12,"GBuffer1");
		addMember(l,13,"GBuffer2");
		addMember(l,14,"GBuffer3");
		LuaDLL.lua_pop(l, 1);
	}
}
