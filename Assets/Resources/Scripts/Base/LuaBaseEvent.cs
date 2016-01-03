using UnityEngine;
using System.Collections;
using SLua;

public class LuaBaseEvent : MonoBehaviour {

	protected LuaFunction _luaFunc;
	protected string _messageName;

	public LuaFunction LuaCallback{
		set{
			if (_luaFunc == null) {
				_luaFunc = value;
				register ();
			}
			else{
				Debug.LogWarning("LuaCallback has been registered!");
			}
		}
	}

	public virtual void register(){}
}
