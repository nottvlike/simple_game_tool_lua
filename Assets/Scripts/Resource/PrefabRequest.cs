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
	SingleLineResource _res = null;

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

    public void LoadAsync(SingleLineResource res)
    {
		_res = res;
		if (_res.CallBack != null && _prefab != null)
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
		ResourceManager.Instance.RemovePrefabLoadList (_res);

		if (_res.CallBack != null && _prefab != null) 
		{
			_res.CallBack.call (_prefab);
			_res = null;
		} 
		else 
		{
			Debug.LogWarning(string.Format("Warning : Failed to load prefab {0}", _res.PrefabName));
			_res = null;
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
