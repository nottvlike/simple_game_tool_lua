using UnityEngine;
using System.Collections;

public class LuaAnimationEvent : LuaBaseEvent {

	public void AddBuff(string name)
	{
		if (_luaFunc != null) {
			_luaFunc.call("addBuff", name);
		}
	}
	
	public void RemoveBuff(string name)
	{
		if (_luaFunc != null) {
			_luaFunc.call("removeBuff", name);
		}
	}

	public void AnimateFinished() {
		if (_luaFunc != null) {
			_luaFunc.call("animateFinished", transform.gameObject);
		}
	}
}
