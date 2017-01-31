using UnityEngine;
using System.Collections;
using SLua;

public class GameStart : MonoBehaviour {

	public string StartScriptName = "Update/UpdateTest.txt";

	// Use this for initialization
	void Start () {
		LuaManager.Instance.Init (StartScriptName);
	}
}
