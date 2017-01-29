using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLua;

public class KeyEvent
{
	public KeyCode Key;
	public LuaFunction Func;
}

public class JoystickManager : Singleton<JoystickManager>
{
	List<KeyEvent> _keyEventList = new List<KeyEvent> ();

    void Update()
    {
		if (_keyEventList.Count > 0) 
		{
			for (int i = 0; i < _keyEventList.Count; ++i)
			{
				var keyEvent = _keyEventList[i];
				if (Input.GetKeyDown (keyEvent.Key))
				{
					keyEvent.Func.call("KeyDown");
				}
				if (Input.GetKeyUp (keyEvent.Key))
				{
					keyEvent.Func.call("KeyUp");
				}
			}
		}
    }

    public static JoystickManager GetInstance() 
    {
        return Instance;
    }

	public void AddKeyEvent (KeyCode key, LuaFunction func)
	{
		var keyEvent = new KeyEvent ();
		keyEvent.Key = key;
		keyEvent.Func = func;
		_keyEventList.Add (keyEvent);
	}

	public void DeleteKeyEvent (KeyCode key)
	{
		for (int i = 0; i < _keyEventList.Count; ++i) 
		{
			var keyEvent = _keyEventList[i];
			if(keyEvent.Key == key)
			{
				_keyEventList.Remove(keyEvent);
				return;
			}
		}
	}
}
