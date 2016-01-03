using UnityEngine;
using System.Collections;

public class LuaAnimationEvent : LuaBaseEvent {

	void Awake(){
		_messageName = "onAnimationFinished";
	}

	public void register() {

	}

	public void onAnimationFinished() {
		if (_luaFunc != null) {
			_luaFunc.call();
		}
	}
}
