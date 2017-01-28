using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SLua;

public class ResourceRequest{
    string _resourceName = "";
    string _resourcePath = "";

    LuaFunction _callBack = null;
    GameObject _prefab = null;

    public string ResourceName
    {
        get 
        {
            return _resourceName;
        }
    }

    public string AssetbundlePath
    {
        get 
        {
            return _resourcePath;
        }
    }

    public string ResourcePath
    {
        get 
        {
			return _resourcePath;
        }
    }

    public void Init(string resourceName, string resourcePath)
    {
        _resourceName = resourceName;
        _resourcePath = resourcePath;
    }

	public void Load(LuaFunction func)
	{
		_callBack = func;
		if (_prefab != null)
		{
			LoadFinished();
		}

		//从Resources目录中载入失败的话，就从AssetBundle中载入
		if (!StartLoadResource())
		{
			ResourceManager.Instance.StartCoroutine(StartLoadAssetBundle());
		}
	}

	IEnumerator StartLoadAssetBundle()
	{
		AssetBundle bundle;
		AssetBundleRequest request;
		
		/*
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
#if UNITY_5
			dependency.DependenciesObject.AddRange(bundle.LoadAllAssets());
#else
			dependency.DependenciesObject.AddRange(bundle.LoadAll());
#endif
            dependency.IsLoaded = true;
            bundle.Unload(false);
        }*/

        //载入主assetbundle
		var assetbundlePath = string.Format("{0}{1}/{2}{3}", LuaManager.GetExternalDir(true), ResourceManager.PREFIX_ASSETBUNDLE_PATH
				, _resourcePath, ResourceManager.SUFFIX_ASSETBUNDLE_PATH);
		WWW www = new WWW(assetbundlePath);
		yield return www;
		bundle = www.assetBundle;
		
#if UNITY_5
		request = bundle.LoadAssetAsync<GameObject>(_resourceName);
#else
		request = bundle.LoadAsync(_prefabName, typeof(GameObject));
#endif
		
		yield return request;
		_prefab = request.asset as GameObject;
		bundle.Unload(false);
		
		LoadFinished();
	}
	
	bool StartLoadResource()
	{
		var prefabPath = string.Format("{0}/{1}", ResourceManager.PREFIX_PREFAB_PATH, _resourcePath);
		_prefab = Resources.Load<GameObject>(prefabPath);
		if (_prefab == null)
		{
				return false;
		}

		LoadFinished();
		return true;
	}

	public void LoadFinished()
	{
		if (_prefab == null) 
        {
			Debug.LogWarning(string.Format("Warning : Failed to load prefab {0}", _resourceName));
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
    }

    public void Reset(string resourceName, string resourcePath)
    {
        ClearPrefab();
        Init(resourceName, resourcePath);
    }
}