using UnityEngine.EventSystems;

public class LuaOnPointerClickEvent : LuaBaseEvent, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Execute("onClick", null);
    }
}
