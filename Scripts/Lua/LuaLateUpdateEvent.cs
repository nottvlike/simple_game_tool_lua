using UnityEngine;
using System.Collections;

public class LuaLateUpdateEvent : LuaBaseEvent {

	void LateUpdate() {
		if (_luaFunc != null) {
			_luaFunc.call();
		}
	}
}
