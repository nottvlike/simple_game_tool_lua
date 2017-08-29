using UnityEngine;
using System.Collections.Generic;
using SLua;

public class LuaBaseEvent : MonoBehaviour
{
    protected LuaFunction _luaFunc;
    protected string _messageName;

    public LuaFunction LuaCallback
    {
        set
        {
            _luaFunc = value;
        }
    }

    protected void Execute()
    {
        if (_luaFunc != null)
        {
            _luaFunc.call();
        }
    }

    protected void Execute(object a1, object a2)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call(a1, a2);
        }
    }

    protected void Execute(object a1, object a2, object a3)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call(a1, a2, a3);
        }
    }
}