using UnityEngine;
using System.Collections;
using SLua;

public class GameStart : MonoBehaviour {

	LuaSvr _svr;
	LuaTable _self;
	LuaFunction _update;
	LuaFunction _fixUpdate;

	public GameObject Axe;

	// Use this for initialization
	void Start () {

		_svr = new LuaSvr();
		_svr.init(null, () =>
		         {
			_self = (LuaTable)_svr.start("Game/Main");
			_fixUpdate = (LuaFunction)_self["fixedUpdate"];
			_update = (LuaFunction)_self["update"];
		});
	}
	
	// Update is called once per frame
	void Update () {
		if(_update!=null) _update.call(_self);
	}

	void FixedUpdate(){
		if (_fixUpdate != null) {
			_fixUpdate.call(_self);		
		}
	}
}
