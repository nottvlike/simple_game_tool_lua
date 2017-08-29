public class LuaLateUpdateEvent : LuaBaseEvent
{

    void LateUpdate()
    {
        Execute();
    }
}
