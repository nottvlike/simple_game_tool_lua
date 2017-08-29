using UnityEngine;

public class LuaCollisionTriggerEvent : LuaBaseEvent
{

    public void OnTriggerEnter(Collider col)
    {
        Execute("onTriggerEnter", col.gameObject);
    }

    public void OnTriggerStay(Collider col)
    {
        Execute("onTriggerStay", col.gameObject);
    }

    public void OnTriggerExit(Collider col)
    {
        Execute("onTriggerExit", col.gameObject);
    }
}
