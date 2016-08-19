using UnityEngine;
using System.Collections;
using SLua;

public class LuaEventManager{

	static void AddBaseCallback<T>(GameObject obj, LuaFunction func) where T : LuaBaseEvent
	{
        if (obj == null)
            obj = GameObject.Find("LuaBaseCallback");

        if (obj == null)
            obj = new GameObject("LuaBaseCallback");

		if(obj.GetComponent<T>() == null)
			obj.AddComponent<T>();
		obj.GetComponent<T>().LuaCallback = func;
	}
	
	public static void AddFixedUpdateEvent(GameObject obj, LuaFunction func) 
	{
		AddBaseCallback<LuaFixedUpdateEvent>(obj, func);
	}
	
	public static void AddUpdateEvent(GameObject obj, LuaFunction func)
	{
		AddBaseCallback<LuaUpdateEvent>(obj, func);
	}
	
	public static void AddAnimationEvent(GameObject obj, LuaFunction func)
	{
		AddBaseCallback<LuaAnimationEvent>(obj, func);
	}
	
	public static void AddCollisionTriggerEvent(GameObject obj, LuaFunction func)
	{
		AddBaseCallback<LuaCollisionTriggerEvent>(obj, func);
	}

    public static void AddCollisionTrigger2DEvent(GameObject obj, LuaFunction func)
    {
        AddBaseCallback<LuaCollisionTrigger2DEvent>(obj, func);
    }

    public static void AddOnDragEvent(GameObject obj, LuaFunction func)
    {
        AddBaseCallback<LuaOnDragEvent>(obj, func);
    }

    public static void AddOnSelectEvent(GameObject obj, LuaFunction func)
    {
        AddBaseCallback<LuaOnSelectEvent>(obj, func);
    }
}
