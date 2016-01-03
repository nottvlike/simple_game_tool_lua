using UnityEngine;
using System.Collections;
using SLua;

public class LuaManager : Singleton<LuaManager> {

	LuaSvr _svr;
	LuaTable _self;
	LuaFunction _update;
	bool _isInit = false;

	const string START_SCRIPT = "Game/Main";
	const string UPDATE_FUNCTION = "update";

	// Update is called once per frame
	void Update () {
		if(_update!=null) _update.call(_self);
	}

	public bool IsInit{
		get{
			return _isInit;
		}
	}

	public void init(){
		_isInit = true;

		_svr = new LuaSvr();
		_svr.init(null, () =>
		          {
			_self = (LuaTable)_svr.start(START_SCRIPT);
			_update = (LuaFunction)_self[UPDATE_FUNCTION];
		});
	}
}
