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
        if (func != null && _prefab != null)
        {
            func.call(_prefab);
            return;
        }

        if (_isAssetBundle)
        {
            ResourceManager.Instance.StartCoroutine(StartLoadAssetBundleAsync(func));
        }
        else
        {
			StartLoadResourceAsync(func);
        }
    }

    IEnumerator StartLoadAssetBundleAsync(LuaFunction func)
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

        if (func != null && _prefab != null)
        {
            func.call(_prefab);
        }
        ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
    }

    void StartLoadResourceAsync(LuaFunction func)
    {
        var obj = Resources.Load<GameObject>(_resourcePath);

		if (func != null && obj != null)
        {
			func.call(obj);
        }
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
