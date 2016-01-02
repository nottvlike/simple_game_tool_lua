using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_StateMachineBehaviour : LuaObject {
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.StateMachineBehaviour");
		createTypeMetatable(l,null, typeof(UnityEngine.StateMachineBehaviour),typeof(UnityEngine.ScriptableObject));
	}
}
