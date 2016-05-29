using UnityEngine;
using System.Collections;
using System.Text;
using SLua;

[SerializeField]
public class PrefabRequest{
    string _prefabName = "";
    string _assetBundlePath = "";
    string _resourcePath = "";
    GameObject _prefab = null;
    bool _isAssetBundle = false;
	LuaFunction _callBack = null;

    public string PrefabName
    {
        get 
        {
            return _prefabName;
        }
    }

    public string AssetBundlePath
    {
        get 
        {
            return _assetBundlePath;
        }
    }

    public string ResourcePath
    {
        get 
        {
            return _resourcePath;
        }
    }

    public void Init(string prefabName, string prefabPath, string resourcePath, bool isAssetBundle)
    {
        _prefabName = prefabName;
        _assetBundlePath = prefabPath;
        _resourcePath = resourcePath;
        _isAssetBundle = isAssetBundle;
    }

	public void Load(LuaFunction func)
	{
		_callBack = func;
		if (_callBack != null && _prefab != null)
		{
			LoadFinished();
		}
		
		if (_isAssetBundle)
		{
			ResourceManager.Instance.StartCoroutine(StartLoadAssetBundle());
		}
		else
		{
			StartLoadResource();
		}
	}

	IEnumerator StartLoadAssetBundle()
	{
		AssetBundle bundle;
		AssetBundleRequest request;
		
		string filepath = "";

#if UNITY_ANDROID && !UNITY_EDITOR
		filepath = LuaManager.GetScriptPath () + _assetBundlePath;
#else
		filepath = "file://" +LuaManager.GetScriptPath() + _assetBundlePath;
#endif
		WWW www = new WWW(filepath);
		yield return www;
		bundle = www.assetBundle;

		request = bundle.LoadAsync(_prefabName, typeof(GameObject));
		yield return request;
		_prefab = request.asset as GameObject;
		bundle.Unload(false);
		
		LoadFinished();
	}
	
	void StartLoadResource()
	{
		_prefab = Resources.Load<GameObject>(_resourcePath);
		LoadFinished();
	}

	public void LoadFinished()
	{
		if (_prefab == null) {
			Debug.LogWarning(string.Format("Warning : Failed to load prefab {0}", _prefabName));
			ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
			return;
		}

		if (_callBack == null) 
		{
			ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
			return;
		}

		_callBack.call (_prefab);
		_callBack = null;

		ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
	}

    public void ClearPrefab()
    {
        if (_prefab != null)
        {
            _prefab = null;
        }
    }

    public void Reset(string prefabName, string prefabPath, string resourcePath, bool isAssetBundle)
    {
        ClearPrefab();
        Init(prefabName, prefabPath, resourcePath, isAssetBundle);
    }
}
