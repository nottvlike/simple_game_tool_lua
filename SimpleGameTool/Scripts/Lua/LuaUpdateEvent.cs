using UnityEngine;
using System.Collections;

public class LuaUpdateEvent : LuaBaseEvent {

	void Update(){
		if (_luaFunc != null) {
			_luaFunc.call();
		}
	}
}
