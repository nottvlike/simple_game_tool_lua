using UnityEngine;
using System.Collections;

public class LuaSubCollisionTriggerEvent : LuaBaseEvent {

	LuaCollisionTriggerEvent _mainCollision;
	
	void Awake()
	{
		_mainCollision = gameObject.GetComponent<LuaCollisionTriggerEvent> ();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (_mainCollision)
		{
			_mainCollision.OnTriggerEnter(col);
		}
		
	}
	
	void OnTriggerStay(Collider col)
	{
		if (_mainCollision)
		{
			_mainCollision.OnTriggerStay(col);
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if (_mainCollision)
		{
			_mainCollision.OnTriggerExit(col);
		}
	}
}
