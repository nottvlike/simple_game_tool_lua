using UnityEngine;
using SLua;
using System;

public class LuaEventManager
{
    const string GLOBAL_LUA_EVENT_OBJECT = "GlobalLuaEventObject";

    public static void AddCallback(string name, GameObject obj, LuaFunction func)
    {
        if (obj == null)
        {
            Debug.LogError("AddBaseCallback : The first parameter must not be null!");
            return;
        }

        var eventType = GetTypeFrmName(name);
        if (eventType == null)
        {
            Debug.LogError(string.Format("LuaEvent named {0} can not be found!", name));
            return;
        }

        if (obj.GetComponent(eventType) == null)
            obj.AddComponent(eventType);

        var baseCallbackEvent = obj.GetComponent(eventType) as LuaBaseEvent;
        baseCallbackEvent.LuaCallback = func;
    }

    public static void AddGlobalCallback(string name, LuaFunction func)
    {
        var obj = GameObject.Find(GLOBAL_LUA_EVENT_OBJECT);
        if (obj == null)
        {
            obj = new GameObject(GLOBAL_LUA_EVENT_OBJECT);
        }

        AddCallback(name, obj, func);
    }

    static Type GetTypeFrmName(string name)
    {
        Type eventType = null;
        switch (name)
        {
            case "LuaUpdateEvent":
                eventType = typeof(LuaUpdateEvent);
                break;
            case "LuaLateUpdateEvent":
                eventType = typeof(LuaLateUpdateEvent);
                break;
            case "LuaFixedUpdateEvent":
                eventType = typeof(LuaFixedUpdateEvent);
                break;
            case "LuaAnimationEvent":
                eventType = typeof(LuaAnimationEvent);
                break;
            case "LuaCollisionTriggerEvent":
                eventType = typeof(LuaCollisionTriggerEvent);
                break;
            case "LuaCollisionTrigger2DEvent":
                eventType = typeof(LuaCollisionTrigger2DEvent);
                break;
            case "LuaOnDragEvent":
                eventType = typeof(LuaOnDragEvent);
                break;
            case "LuaOnSelectEvent":
                eventType = typeof(LuaOnSelectEvent);
                break;
            case "LuaOnPointerClickEvent":
                eventType = typeof(LuaOnPointerClickEvent);
                break;
        }

        return eventType;
    }
}
