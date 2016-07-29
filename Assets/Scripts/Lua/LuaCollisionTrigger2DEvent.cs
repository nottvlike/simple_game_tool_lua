using UnityEngine;
using System.Collections;

public class LuaCollisionTrigger2DEvent : LuaBaseEvent {

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onTriggerEnter2D", col.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onTriggerStay2D", col.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onTriggerExit2D", col.gameObject);
        }
    }
}
