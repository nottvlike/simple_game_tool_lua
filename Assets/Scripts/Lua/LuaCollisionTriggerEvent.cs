using UnityEngine;
using System.Collections;

public class LuaCollisionTriggerEvent : LuaBaseEvent {

    public void OnTriggerEnter(Collider col)
    {
		if (_luaFunc != null) {
			_luaFunc.call("onTriggerEnter", col.gameObject);		
		}
    }

    public void OnTriggerStay(Collider col)
    {
		if (_luaFunc != null) {
			_luaFunc.call("onTriggerStay", col.gameObject);		
		}
    }

    public void OnTriggerExit(Collider col)
    {
		if (_luaFunc != null) {
			_luaFunc.call("onTriggerExit", col.gameObject);		
		}
    }
}
