using UnityEngine;
using System.Collections;

public class LuaFixedUpdateEvent : LuaBaseEvent {

	void FixedUpdate(){
		if (_luaFunc != null) {
			_luaFunc.call();
		}
	}
}
