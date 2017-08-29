#if UNITY_5
using UnityEngine.EventSystems;

public class LuaOnSelectEvent : LuaBaseEvent, ISelectHandler
{
    public void OnSelect(BaseEventData data)
    {
        Execute("onSelect", data);
    }
}
#else
public class LuaOnSelectEvent : LuaBaseEvent {

}
#endif