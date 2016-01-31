using UnityEngine;
using System.Collections;
using SLua;

public class JoystickManager : Singleton<JoystickManager>
{

    LuaFunction _onKeyDown;
    LuaFunction _onKeyUp;
    bool _isKeyDown = false;
    public enum JoystickEventType : int
    {
        None = 0,
        KeyDown = 1,
        KeyUp = 2
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isKeyDown)
            {
                _isKeyDown = true;
                if (_onKeyDown != null)
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _onKeyDown.call(worldPos);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && _isKeyDown)
        {
            _isKeyDown = false;
            if (_onKeyUp != null)
            {
                _onKeyUp.call(Input.mousePosition);
            }
        }
    }

    public static JoystickManager GetInstance() 
    {
        return Instance;
    }

    public void registerEvent(JoystickEventType type, LuaFunction luaFunc)
    {
        switch(type)
        {
            case JoystickEventType.None:
                break;
            case JoystickEventType.KeyDown:
                if (_onKeyDown == null)
                    _onKeyDown = luaFunc;
                break;
            case JoystickEventType.KeyUp:
                if (_onKeyUp == null)
                    _onKeyUp = luaFunc;
                break;
        }
    }
}
