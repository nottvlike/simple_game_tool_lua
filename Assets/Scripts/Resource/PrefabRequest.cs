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

    public void init(string prefabName, string prefabPath, string resourcePath, bool isAssetBundle)
    {
        _prefabName = prefabName;
        _assetBundlePath = prefabPath;
        _resourcePath = resourcePath;
        _isAssetBundle = isAssetBundle;
    }

    public void loadAsync(LuaFunction func)
    {
        if (func != null && _prefab != null)
        {
            func.call(_prefab);
            return;
        }

        if (_isAssetBundle)
        {
            ResourceManager.Instance.StartCoroutine(startLoadAssetBundleAsync(func));
        }
        else
        {
			startLoadResourceAsync(func);
        }
    }

    IEnumerator startLoadAssetBundleAsync(LuaFunction func)
    {
        AssetBundle bundle;
        AssetBundleRequest request;

        string filepath = LuaManager.getAssetBundlePath() + _assetBundlePath;

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

    void startLoadResourceAsync(LuaFunction func)
    {
        var obj = Resources.Load<GameObject>(_resourcePath);

		if (func != null && obj != null)
        {
			func.call(obj);
        }
	}

    public void clearPrefab()
    {
        if (_prefab != null)
        {
            _prefab = null;
        }
    }

    public void reset(string prefabName, string prefabPath, string resourcePath, bool isAssetBundle)
    {
        clearPrefab();
        init(prefabName, prefabPath, resourcePath, isAssetBundle);
    }
}
