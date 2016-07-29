using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LuaOnSelectEvent : LuaBaseEvent, ISelectHandler {

    public void OnSelect(BaseEventData data)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onSelect", data);
        }
    }
}
