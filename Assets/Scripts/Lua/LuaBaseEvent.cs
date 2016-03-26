using UnityEngine;
using System.Collections;
using SLua;

public class LuaBaseEvent : MonoBehaviour
{

    protected LuaFunction _luaFunc;
    protected string _messageName;

    public LuaFunction LuaCallback
    {
        set
        {
            if (_luaFunc == null)
            {
                _luaFunc = value;
            }
            else
            {
#if LOG_DEBUG
                Debug.LogWarning("LuaCallback has been registered!");
#endif
            }
        }
    }
}