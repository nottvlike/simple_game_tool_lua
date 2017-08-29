using UnityEngine;

public class LuaCollisionTrigger2DEvent : LuaBaseEvent
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        Execute("onTriggerEnter2D", col.gameObject);
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        Execute("onTriggerStay2D", col.gameObject);
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        Execute("onTriggerExit2D", col.gameObject);
    }
}
