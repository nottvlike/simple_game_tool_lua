#if UNITY_5
using UnityEngine.EventSystems;

public class LuaOnDragEvent : LuaBaseEvent, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    public void OnBeginDrag(PointerEventData data)
    {
        Execute("onBeginDrag", data);
    }

    public void OnDrag(PointerEventData data)
    {
        Execute("onDrag", data);
    }

    public void OnEndDrag(PointerEventData data)
    {
        Execute("onEndDrag", data);
    }
}
#else
public class LuaOnDragEvent : LuaBaseEvent 
{
}
#endif
