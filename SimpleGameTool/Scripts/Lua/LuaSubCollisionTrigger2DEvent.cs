using UnityEngine;
using System.Collections;

public class LuaSubCollisionTrigger2DEvent : LuaBaseEvent
{

    LuaCollisionTrigger2DEvent _mainCollision;

    void Awake()
    {
        _mainCollision = gameObject.GetComponent<LuaCollisionTrigger2DEvent>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_mainCollision)
        {
            _mainCollision.OnTriggerEnter2D(col);
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (_mainCollision)
        {
            _mainCollision.OnTriggerStay2D(col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (_mainCollision)
        {
            _mainCollision.OnTriggerExit2D(col);
        }
    }
}
