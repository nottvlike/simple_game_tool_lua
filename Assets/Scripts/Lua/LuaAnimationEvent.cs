using UnityEngine;
using System.Collections;

public class LuaAnimationEvent : LuaBaseEvent {

	public void playSound(int type)
	{
		if (_luaFunc != null) {
			_luaFunc.call("playSound", type);
		}
	}

	public void playEffect(int type)
	{
		if (_luaFunc != null) {
			_luaFunc.call("playEffect", type);
		}
	}

	public void fire(int type)
	{
		if (_luaFunc != null) {
			_luaFunc.call("fire", type);
		}
	}

	public void addAttackInstance(string name)
	{
		if (_luaFunc != null) {
			_luaFunc.call("addAttackInstance", name);
		}
	}
	
	public void removeAttackInstance(string name)
	{
		if (_luaFunc != null) {
			_luaFunc.call("removeAttackInstance", name);
		}
	}

	public void animateFinished() {
		if (_luaFunc != null) {
			_luaFunc.call("animateFinished", transform.gameObject);
		}
	}
}
