using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class LuaOnPointerClickEvent : LuaBaseEvent, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onClick", null);
        }
    }
}
