public class LuaAnimationEvent : LuaBaseEvent
{
    public void AddBuff(string name)
    {
        Execute("addBuff", name);
    }

    public void RemoveBuff(string name)
    {
        Execute("removeBuff", name);
    }

    public void AnimateFinished()
    {
        Execute("animateFinished", name);
    }
}
