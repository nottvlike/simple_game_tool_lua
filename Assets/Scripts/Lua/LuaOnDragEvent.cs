using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LuaOnDragEvent : LuaBaseEvent, IDragHandler, IEndDragHandler, IBeginDragHandler {

    public void OnBeginDrag(PointerEventData data)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onBeginDrag", data);
        }
    }

    public void OnDrag (PointerEventData data)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onDrag", data);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (_luaFunc != null)
        {
            _luaFunc.call("onEndDrag", data);
        }
    }
}
