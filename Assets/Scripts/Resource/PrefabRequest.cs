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

    public void LoadAsync(LuaFunction func)
    {
		_callBack = func;
		if (_callBack != null && _prefab != null)
        {
			LoadFinished ();
            return;
        }

        if (_isAssetBundle)
        {
			ResourceManager.Instance.StartCoroutine(StartLoadAssetBundleAsync());
		}
		else
        {
			ResourceManager.Instance.StartCoroutine(StartLoadResourceAsync());
        }
    }

    IEnumerator StartLoadAssetBundleAsync()
    {
        AssetBundle bundle;
        AssetBundleRequest request;

        string filepath = LuaManager.GetAssetBundlePath() + _assetBundlePath;

        WWW www = new WWW("file://" + filepath);
        yield return www;
        bundle = www.assetBundle;
        request = bundle.LoadAsync(_prefabName, typeof(GameObject));
        yield return request;
        _prefab = request.asset as GameObject;
        bundle.Unload(false);

		LoadFinished ();
	}
	
	IEnumerator StartLoadResourceAsync()
    {
        var obj = Resources.Load<GameObject>(_resourcePath);
		yield return new WaitForEndOfFrame ();

		LoadFinished ();
	}

	public void LoadFinished()
	{
		if (_callBack != null && _prefab != null) 
		{
			_callBack.call (_prefab);
			_callBack = null;
		} 
		else 
		{
			Debug.LogWarning(string.Format("Warning : Failed to load prefab {0}", _prefabName));
			_callBack = null;
		}

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
