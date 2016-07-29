using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SLua;

[SerializeField]
public class PrefabRequest{
    string _prefabName = "";
    string _assetBundlePath = "";
    string _prefabPath = "";
    List<string> _dependenciesPath = null;
    LuaFunction _callBack = null;
    GameObject _prefab = null;
    bool _isAssetBundle = false;

    public string PrefabName
    {
        get 
        {
            return _prefabName;
        }
    }

    public string AssetbundlePath
    {
        get 
        {
            return _assetBundlePath;
        }
    }

    public string PrefabPath
    {
        get 
        {
            return _prefabPath;
        }
    }

    public List<string> DependenciesPath
    {
        get
        {
            return _dependenciesPath;
        }
    }

    public void Init(string prefabName, string assetbundlePath, string prefabPath, List<string> dependenciesPath, bool isAssetBundle)
    {
        _prefabName = prefabName;
        _assetBundlePath = assetbundlePath;
        _prefabPath = prefabPath;
        _dependenciesPath = dependenciesPath;
        _isAssetBundle = isAssetBundle;
    }

	public void Load(LuaFunction func)
	{
		_callBack = func;
		if (_prefab != null)
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

        //预先载入共享assetbundle
        for (int i = 0; i < _dependenciesPath.Count; ++i)
        {
            var dependName = _dependenciesPath[i];
            Dependency dependency = null;
            if (!ResourceManager.Instance.GetSharedDependencies(dependName, out dependency) || dependency.IsLoaded)
            {
                continue;
            }

            WWW depend = new WWW(dependency.AssetbundlePath);
            yield return depend;
            bundle = depend.assetBundle;

            //没保存prefab name,所以使用loadall方法，有明显卡顿的话再改
			dependency.DependenciesObject.AddRange(bundle.LoadAllAssets());
            dependency.IsLoaded = true;
            bundle.Unload(false);
        }

        //载入主assetbundle
		string filepath = LuaManager.GetExternalDir(true) + _assetBundlePath;
		WWW www = new WWW(filepath);
		yield return www;
		bundle = www.assetBundle;

		request = bundle.LoadAssetAsync<GameObject>(_prefabName);
		yield return request;
		_prefab = request.asset as GameObject;
		bundle.Unload(false);
		
		LoadFinished();
	}
	
	void StartLoadResource()
	{
		_prefab = Resources.Load<GameObject>(_prefabPath);
		LoadFinished();
	}

	public void LoadFinished()
	{
		if (_prefab == null) 
        {
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
        _prefab = null;
        _callBack = null;
        
        if (_dependenciesPath != null)
        {
            _dependenciesPath.Clear();
            _dependenciesPath = null;
        }
    }

    public void Reset(string prefabName, string prefabPath, string resourcePath, List<string> dependenciesPath,bool isAssetBundle)
    {
        ClearPrefab();
        Init(prefabName, prefabPath, resourcePath, dependenciesPath, isAssetBundle);
    }
}
