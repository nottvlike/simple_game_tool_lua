using UnityEngine;
using System.Collections;
using SLua;

public class ResourceRequest{

    ResourceInfo _resourceInfo;

    LuaFunction _callBack = null;
    GameObject _resource = null;

    public ResourceInfo ResourceInfo
    {
        get
        {
            return _resourceInfo;
        }
    }

    public GameObject Resource
    {
        get
        {
            return _resource;
        }
    }

    public void Init(ResourceInfo resourceInfo)
    {
        _resourceInfo = resourceInfo;
    }

    public void Init(string resourceName, string resourcePath, bool isFromAssetBundle)
    {
        _resourceInfo.ResourceName = resourceName;
        _resourceInfo.ResourcePath = resourcePath;
        _resourceInfo.IsFromAssetBundle = isFromAssetBundle;
    }

	public void LoadAsync(LuaFunction func)
	{
		_callBack = func;
		if (_resource != null)
		{
			LoadFinished();
		}

		if (_resourceInfo.IsFromAssetBundle)
        {
            ResourceManager.Instance.StartCoroutine(LoadAssetBundleAsync());
        }
        else
        {
            ResourceManager.Instance.StartCoroutine(LoadResourceAsync());
        }
	}

	IEnumerator LoadAssetBundleAsync()
	{
		AssetBundle bundle;
		AssetBundleRequest request;

        //载入assetbundle
		var assetbundlePath = string.Format("{0}{1}/{2}{3}", LuaManager.GetExternalDir(true), ResourceManager.PREFIX_ASSETBUNDLE_PATH
				, _resourceInfo.ResourcePath, ResourceManager.SUFFIX_ASSETBUNDLE_PATH);
		WWW www = new WWW(assetbundlePath);
		yield return www;
		bundle = www.assetBundle;

        //载入prefab
#if UNITY_5
        request = bundle.LoadAssetAsync<GameObject>(_resourceInfo.ResourceName);
#else
		request = bundle.LoadAsync(_prefabName, typeof(GameObject));
#endif
		
		yield return request;
		_resource = request.asset as GameObject;
		bundle.Unload(false);
		
		LoadFinished();
	}

    IEnumerator LoadResourceAsync()
	{
		var resourcePath = string.Format("{0}/{1}", ResourceManager.PREFIX_RESOURCE_PATH, _resourceInfo.ResourcePath);
		var resourceRequest = Resources.LoadAsync<GameObject>(resourcePath);
        yield return resourceRequest;
        _resource = resourceRequest.asset as GameObject;

		LoadFinished();
	}

    public void Load()
    {
        _callBack = null;
        if (_resource != null)
        {
            LoadFinished();
        }

        if (_resourceInfo.IsFromAssetBundle)
        {
            LoadFromAssetBundle();
        }
        else
        {
            LoadFromResource();
        }
    }

    public void LoadFromAssetBundle()
    {
        var assetbundlePath = string.Format("{0}{1}/{2}{3}", LuaManager.GetExternalDir(), ResourceManager.PREFIX_ASSETBUNDLE_PATH
        , _resourceInfo.ResourcePath, ResourceManager.SUFFIX_ASSETBUNDLE_PATH);
        byte[] assetBundleContent = null;
        FileManager.LoadFileWithBytes(assetbundlePath, out assetBundleContent);

        var bundle = AssetBundle.LoadFromMemory(assetBundleContent);
#if UNITY_5
        _resource = bundle.LoadAsset<GameObject>(_resourceInfo.ResourceName);
#else
        _resource = bundle.Load<GameObject>(_resourceInfo.ResourceName);
#endif
        bundle.Unload(true);

        LoadFinished();
    }

    public void LoadFromResource()
    {
        _resource = Resources.Load<GameObject>(_resourceInfo.ResourceName);

        LoadFinished();
    }

	public void LoadFinished()
	{
		if (_resource == null) 
        {
			Debug.LogWarning(string.Format("Warning : Failed to load prefab {0}", _resourceInfo.ResourceName));
			ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
			return;
		}

		if (_callBack == null) 
		{
			ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
			return;
		}

		_callBack.call (_resource);
		_callBack = null;

		ResourceManager.Instance.ResourceLoadState = ResourceLoadStateType.Finished;
	}
}