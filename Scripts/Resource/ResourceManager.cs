/*
 * 对于一个prefab，将其相关的资源拆分为6个部分
 * 1，texture资源单独打一个assetbundle
 * 2, material资源单独打一个assetbundle
 * 3, shader资源单独打一个assetbundle
 * 4, animator控制器单独打一个assetbundle
 * 5，模型资源单独打一个assetbundle
 * 6，prefab单独打一个assetbundle
 *
 * 1~5称作共享assetbundle（或者依赖assetbundle）
 * 6称作主assetbundle
 * */

using UnityEngine;
using System;
using System.Collections.Generic;
using SLua;
using LitJson;

public enum ResourceLoadStateType {
    None,
    Loading,
    Finished
}

/// <summary>
/// 异步加载资源请求结构体
/// </summary>
public struct AsyncResourceRequest
{
    public float Id;
    public string ResourceName;
    public LuaFunction CallBack;
}

[Serializable]
public struct ConfigInfoList
{
    public List<ConfigInfo> Configs;
}

/// <summary>
/// Configuration里的配置信息
/// </summary>
[Serializable]
public struct ConfigInfo
{
    public string ConfigName;
    public string ConfigPath;
    public string Version;
}

[Serializable]
public struct ResourceInfoList
{
    public List<ResourceInfo> Resources;
}

/// <summary>
/// AssetBundleConfig里的配置信息
/// </summary>
[Serializable]
public struct ResourceInfo
{
    public string ResourceName;
    public string ResourcePath;
    public bool IsFromAssetBundle;
}

public class ResourceManager : Singleton<ResourceManager> 
{
	public string ConfigurationConfig = "Config/ConfigurationTest";
	public string AssetBundleConfig = "AssetBundleConfigTest";

	public const string PREFIX_RESOURCE_PATH = "Prefab";
	public const string PREFIX_ASSETBUNDLE_PATH = "AssetBundle";
	public const string SUFFIX_ASSETBUNDLE_PATH = ".assetbundle";

    Dictionary<string, ConfigInfo> _configInfoDict = new Dictionary<string, ConfigInfo>();
    Dictionary<string, ResourceInfo> _resourceInfoDict = new Dictionary<string, ResourceInfo>();

    Dictionary<string, ResourceRequest> _resourceRequestDict = new Dictionary<string, ResourceRequest>();

    List<AsyncResourceRequest> _asyncResourceRequestList = new List<AsyncResourceRequest>();

    ResourceLoadStateType _resourceLoadState = ResourceLoadStateType.None;
    bool _isInit = false;

    public ResourceLoadStateType ResourceLoadState 
    {
        set
        {
            _resourceLoadState = value;

            if (_resourceLoadState == ResourceLoadStateType.Finished)
                StartLoadAsync();
        }
        get { return _resourceLoadState; }
    }

#if UNITY_EDITOR
    public Dictionary<string, ResourceInfo> ResourceInfoDict
    {
        get
        {
            return _resourceInfoDict;
        }
    }
#endif

    public static ResourceManager GetInstance()
    {
        return Instance;
    }

    public void Init(string prefix)
    {
        if (!_isInit)
        {
            _isInit = true;

            LoadConfigurationConfig(prefix);
            LoadAssetBundleConfig();
        }
    }

    void LoadConfigurationConfig(string prefix)
    {
		_configInfoDict.Clear ();
        var config = LoadConfigFileImmediatly(string.Format("{0}{1}", prefix, ConfigurationConfig));
#if UNITY_5_3 || UNITY_5_4
        var configInfoList = JsonUtility.FromJson<ConfigInfoList>(config);

#else
        var configInfoList = JsonMapper.ToObject<ConfigInfoList>(config);
#endif
        for (var i = 0; i < configInfoList.Configs.Count; i++)
        {
            var configRequest = configInfoList.Configs[i];
            _configInfoDict.Add(configRequest.ConfigName, configRequest);
        }
    }

    void LoadAssetBundleConfig()
    {
		_resourceInfoDict.Clear ();

		var txt = LoadConfigFile(AssetBundleConfig);
		if (txt.Length <= 0)
			return;
#if UNITY_5_3 || UNITY_5_4
        var resourceRequestInfoList = JsonUtility.FromJson<ResourceInfoList>(txt);
#else
        var resourceRequestInfoList = JsonMapper.ToObject<ResourceInfoList>(txt);
#endif
        for (var i = 0; i < resourceRequestInfoList.Resources.Count; i++)
        {
            var resourceInfo = resourceRequestInfoList.Resources[i];
            _resourceInfoDict.Add(resourceInfo.ResourceName, resourceInfo);
        }
    }

    /// <summary>
    /// 通过配置名字读取配置
    /// </summary>
    /// <param name="configName">配置名</param>
    /// <returns></returns>
    public string LoadConfigFile(string configName)
    {
        ConfigInfo configReq;
        if (!_configInfoDict.TryGetValue(configName, out configReq))
        {
            return "";
        }

        return LoadConfigFileImmediatly(configReq.ConfigPath);
    }

    /// <summary>
    /// 直接读取文件
    /// </summary>
    /// <param name="configPath">配置的全路径</param>
    /// <returns></returns>
    string LoadConfigFileImmediatly(string configPath)
    {
        TextAsset text = Resources.Load<TextAsset>(configPath);
        if (text != null)
            return text.text;

        return FileManager.LoadFileWithString(configPath + ".txt");
    }

    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <param name="resourceName"></param>
    /// <returns></returns>
    public GameObject Load(string resourceName)
    {
        if (_resourceLoadState == ResourceLoadStateType.Loading)
        {
            Debug.Log("An resource is loading, Please wait!");
            return null;
        }

        ResourceRequest resourceRequest = null;
        if (_resourceRequestDict.TryGetValue(resourceName, out resourceRequest))
        {
            _resourceLoadState = ResourceLoadStateType.Loading;
            resourceRequest.Load();
        }
        else
        {
            ResourceInfo resourceInfo;
            if (_resourceInfoDict.TryGetValue(resourceName, out resourceInfo))
            {
                resourceRequest = new ResourceRequest();
                resourceRequest.Init(resourceInfo);

                resourceRequest.Load();
            }
            else
            {
                Debug.Log(string.Format("No resource named {0} found!", resourceName));
            }
        }
        return resourceRequest.Resource;
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <param name="resourceName">资源名称</param>
    /// <param name="func">加载成功的回调</param>
	public void LoadAsync(string resourceName, LuaFunction func)
	{
		var resourceRequest = new AsyncResourceRequest();
		resourceRequest.ResourceName = resourceName;
		resourceRequest.CallBack = func;
		resourceRequest.Id = Time.realtimeSinceStartup;
		_asyncResourceRequestList.Add(resourceRequest);

        StartLoadAsync();
	}
	
	void  StartLoadAsync()
	{
		if (_asyncResourceRequestList.Count <= 0)
		{
			return;
		}
		
		if (_resourceLoadState == ResourceLoadStateType.Loading)
		{
			return;
		}
		
		var asyncRequest = _asyncResourceRequestList[0];
		var resourceName = asyncRequest.ResourceName;
		var callBack = asyncRequest.CallBack;
		
        _asyncResourceRequestList.Remove(asyncRequest);

        ResourceRequest resourceRequest = null;
        if (_resourceRequestDict.TryGetValue(resourceName, out resourceRequest))
        {
            _resourceLoadState = ResourceLoadStateType.Loading;
            resourceRequest.LoadAsync(callBack);
        }
        else
        {
            ResourceInfo resourceInfo;
            if (_resourceInfoDict.TryGetValue(resourceName, out resourceInfo))
            {
                resourceRequest = new ResourceRequest();
                resourceRequest.Init(resourceInfo);

                _resourceLoadState = ResourceLoadStateType.Loading;
                resourceRequest.LoadAsync(callBack);
            }
            else
            {
                Debug.Log(string.Format("No resource named {0} found!", resourceName));
            }
        }
    }
}
