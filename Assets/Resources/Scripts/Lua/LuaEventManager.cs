using UnityEngine;
using System.Collections;
using SLua;

public class LuaEventManager{

	public static void addBaseCallback<T>(GameObject obj, LuaFunction func) where T: LuaBaseEvent {
		obj.AddComponent<T> ();
		obj.GetComponent<T> ().LuaCallback = func;
	}

	public static void addAnimCallback(GameObject obj, LuaFunction func){
		addBaseCallback<LuaAnimationEvent> (obj, func);
	}
}
