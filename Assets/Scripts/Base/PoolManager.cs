using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BaseObject
{
    public abstract void Reset();
}

public class PoolObject
{
	List<BaseObject> _cachedObjectList = new List<BaseObject>();
	List<BaseObject> _unusedObjectList = new List<BaseObject>();
	
	public PoolObject()
	{
		_cachedObjectList = new List<BaseObject>();
		_unusedObjectList = new List<BaseObject>();
	}
	
	public T New<T>() where T : BaseObject, new()
	{
		T t = null;
		if (_unusedObjectList.Count > 0)
		{
			t = (T)_unusedObjectList[0];
			_unusedObjectList.Remove(t);
			_cachedObjectList.Add(t);
		}
		else
		{
			t = new T();
			_cachedObjectList.Add(t);
		}
		return t;
	}
	
	public bool Release<T>(T t) where T : BaseObject, new()
	{
		if(_cachedObjectList.Remove(t))
		{
			t.Reset();
			_unusedObjectList.Add(t);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		_unusedObjectList.Clear ();
	}
}

public class PoolGameObject
{
	List<UnityEngine.Object> _cachedGameObjectList = new List<UnityEngine.Object>();
	List<UnityEngine.Object> _unusedGameObjectList = new List<UnityEngine.Object>();
	
	public UnityEngine.Object Clone(UnityEngine.Object obj, Vector3 vec, Quaternion qua)
	{
		if (_unusedGameObjectList.Count > 0)
		{
			UnityEngine.Object cachedObj = _unusedGameObjectList[0];
			_unusedGameObjectList.Remove(cachedObj);
			_cachedGameObjectList.Add(cachedObj);
			((GameObject)cachedObj).SetActive(true);
			((GameObject)cachedObj).transform.position = vec;
			((GameObject)cachedObj).transform.rotation = qua;
			return cachedObj;
		}
		else
		{
			UnityEngine.Object cachedObj = GameObject.Instantiate(obj, vec, qua);
			_cachedGameObjectList.Add(cachedObj);
			return cachedObj;
		}  
	}
	
	public bool Release(UnityEngine.Object obj)
	{
        ((GameObject)obj).SetActive(false);
        ((GameObject)obj).transform.position = Vector3.zero;
        _unusedGameObjectList.Add(obj);
		
        if (_cachedGameObjectList.Remove(obj))
		{
			return true;
		}
		return false;
	}

	public void Clear()
	{
		for(int i = 0; i < _unusedGameObjectList.Count; ++i)
		{
			GameObject.Destroy(_unusedGameObjectList[i]);
		}
		_unusedGameObjectList.Clear ();
	}
}

public class PoolManager
{
	Dictionary<string, PoolObject> _dictionaryObject = new Dictionary<string, PoolObject>();
	Dictionary<string, PoolGameObject> _dictionaryGameObject = new Dictionary<string, PoolGameObject>();
	
	static PoolManager _poolManager = null;
	
	public static PoolManager GetInstance()
	{
		if (_poolManager == null)
		{
			_poolManager = new PoolManager();
		}
		return _poolManager;
	}
	
	public T Get<T>(string name) where T : BaseObject, new()
	{
		PoolObject obj = null;
		if (!_dictionaryObject.TryGetValue(name, out obj))
		{
			obj = new PoolObject();
			_dictionaryObject.Add(name, obj);
		}
		return obj.New<T>();
	}
	
	public void ReleaseObject<T>(string name, T t) where T : BaseObject, new()
	{
		PoolObject obj = null;
		if (_dictionaryObject.TryGetValue(name, out obj))
		{
			if (!obj.Release<T>(t))
			{
				Debug.LogWarning(string.Format("PoolManager Release Object {0} Failed!", name));
			}
		}
		else
		{
			Debug.LogWarning(string.Format("PoolManager Can't find PoolObject {0} by the key {1}!", t.GetType().ToString(), name));
		}
	}
	
	public UnityEngine.Object CloneGameObject(string name, UnityEngine.Object obj, Vector3 vec, Quaternion qua)
	{
		PoolGameObject gameObj = null;
		if (!_dictionaryGameObject.TryGetValue(name, out gameObj))
		{
			gameObj = new PoolGameObject();
			_dictionaryGameObject.Add(name, gameObj);
		}
		return gameObj.Clone(obj, vec, qua);
	}
	
	public void ReleaseGameObject(string name, UnityEngine.Object obj)
	{
		PoolGameObject gameObj = null;
		if (_dictionaryGameObject.TryGetValue(name, out gameObj))
		{
			if (!gameObj.Release(obj))
			{
				Debug.LogWarning(string.Format("PoolManager Release PoolGameObject {0} Failed!", name));
			}
		}
		else
		{
			Debug.LogWarning(string.Format("PoolManager Can't find PoolGameObject by the name {1}!", name));
		}
	}

	public void Clear()
	{
		List<string> objectList = new List<string>(_dictionaryObject.Keys);
		for (int i = 0; i < objectList.Count; i++)
		{
			_dictionaryObject[objectList[i]].Clear();
		}

		List<string> gameObjectList = new List<string> (_dictionaryGameObject.Keys);
		for (int i = 0; i < gameObjectList.Count; i++)
		{
			_dictionaryObject[gameObjectList[i]].Clear();
		}
	}
}