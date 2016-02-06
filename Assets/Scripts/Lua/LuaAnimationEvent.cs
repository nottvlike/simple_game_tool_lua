using UnityEngine;
using System.Collections;

public class LuaAnimationEvent : LuaBaseEvent {

	public void PlaySound(int type)
	{
		if (_luaFunc != null) {
			_luaFunc.call("playSound", type);
		}
	}

	public void PlayEffect(int type)
	{
		if (_luaFunc != null) {
			_luaFunc.call("playEffect", type);
		}
	}

	public void Fire(int type)
	{
		if (_luaFunc != null) {
			_luaFunc.call("fire", type);
		}
	}

	public void AddAttackInstance(string name)
	{
		if (_luaFunc != null) {
			_luaFunc.call("addAttackInstance", name);
		}
	}
	
	public void RemoveAttackInstance(string name)
	{
		if (_luaFunc != null) {
			_luaFunc.call("removeAttackInstance", name);
		}
	}

	public void AnimateFinished() {
		if (_luaFunc != null) {
			_luaFunc.call("animateFinished", transform.gameObject);
		}
	}
}
