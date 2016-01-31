using UnityEngine;
using System.Collections;

public class LuaCollisionTrigger2DEvent : LuaBaseEvent {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("OnTriggerEnter2D", col);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("OnTriggerStay2D", col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("OnTriggerExit2D", col);
        }
    }
}
