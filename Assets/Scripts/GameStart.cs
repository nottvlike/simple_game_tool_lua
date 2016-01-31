using UnityEngine;
using System.Collections;
using SLua;

public class GameStart : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		LuaManager.Instance.init ();
	}
}
