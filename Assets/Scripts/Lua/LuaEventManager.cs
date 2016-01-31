using UnityEngine;
using System.Collections;
using SLua;

public class LuaEventManager{

	static void addBaseCallback<T>(GameObject obj, LuaFunction func) where T : LuaBaseEvent
	{
		if(obj.GetComponent<T>() == null)
			obj.AddComponent<T>();
		obj.GetComponent<T>().LuaCallback = func;
	}
	
	public static void addFixedUpdateEvent(GameObject obj, LuaFunction func) 
	{
		addBaseCallback<LuaFixedUpdateEvent>(obj, func);
	}
	
	public static void addUpdateEvent(GameObject obj, LuaFunction func)
	{
		addBaseCallback<LuaUpdateEvent>(obj, func);
	}
	
	public static void addAnimationEvent(GameObject obj, LuaFunction func)
	{
		addBaseCallback<LuaAnimationEvent>(obj, func);
	}
	
	public static void addCollisionTrigger2DEvent(GameObject obj, LuaFunction func)
	{
		addBaseCallback<LuaCollisionTrigger2DEvent>(obj, func);
	}
}
