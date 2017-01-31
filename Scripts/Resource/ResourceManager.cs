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
using System.Collections;
using System.Collections.Generic;
using SLua;
using LitJson;

public enum ResourceLoadStateType {
    None,
    Loading,
    Finished
}

/*
 * 线性加载资源请求结构体
 * */
public class SingleLineResource : BaseObject {
    public float Id;
    public string PrefabName;
    public LuaFunction CallBack;

	public override void Reset()
	{
		Id = 0;
		PrefabName = "";
		CallBack = null;
	}
}

public class Dependency
{
    public bool IsLoaded;
    public string PrefabName;
    public string PrefabPath;
    public string AssetbundlePath;
    public List<Object> DependenciesObject;
}

public class ConfigRequest {
    public string ConfigName;
    public string ConfigResourcePath;
}

public class ResourceManager : Singleton<ResourceManager> 
{
	public string ConfigurationConfig = "Config/ConfigurationTest";
	public string AssetBundleConfig = "AssetBundleConfigTest";

	public const string PREFIX_PREFAB_PATH = "Prefab";
	public const string PREFIX_ASSETBUNDLE_PATH = "AssetBundle";
	public const string SUFFIX_ASSETBUNDLE_PATH = ".assetbundle";

    Dictionary<string, ConfigRequest> _configRequestDict = new Dictionary<string, ConfigRequest>();
	Dictionary<string, ResourceRequest> _resourceRequestDict = new Dictionary<string, ResourceRequest>();
    Dictionary<string, Dependency> _sharedAssetbundleDict = new Dictionary<string, Dependency>();
    List<SingleLineResource> _prefabLoadRequestList = new List<SingleLineResource>();

    ResourceLoadStateType _state = ResourceLoadStateType.None;
    bool _isInit = false;

    public ResourceLoadStateType ResourceLoadState 
    {
        set
        {
            _state = value;

            if (_state == ResourceLoadStateType.Finished)
                StartSingleLineLoad();
        }
        get { return _state; }
    }

#if UNITY_EDITOR
    public Dictionary<string, ResourceRequest> PrefabRequestDict
    {
        get
        {
            return _resourceRequestDict;
        }
    }

    public Dictionary<string, Dependency> SharedAssetbundleDict
    {
        get
        {
            return _sharedAssetbundleDict;
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
        string config = "";

		_configRequestDict.Clear ();
        config = LoadConfigFileByPath(string.Format("{0}{1}", prefix, ConfigurationConfig));

        JsonData jsonData = JsonMapper.ToObject(config);
        if (jsonData["Configs"].IsArray)
        {
            for (int i = 0; i < jsonData["Configs"].Count; i++)
            {
                var configInfo = jsonData["Configs"][i];

                var request = new ConfigRequest();
                request.ConfigName = configInfo["ConfigName"].ToString();
                request.ConfigResourcePath = configInfo["ResourcePath"].ToString();
                _configRequestDict.Add(configInfo["ConfigName"].ToString(), request);
            }
        }
    }

    void LoadAssetBundleConfig()
    {
		_resourceRequestDict.Clear ();

		var txt = LoadConfigFile(AssetBundleConfig);
		if (txt.Length <= 0)
			return;

		JsonData jsonData = JsonMapper.ToObject(txt);
		for (int i = 0; i < jsonData["Resources"].Count; i++)
		{
			var prefabInfo = jsonData["Resources"][i];
			var resourceName = prefabInfo["ResourceName"].ToString();
			var resourcePath = prefabInfo["ResourcePath"].ToString();

			var request = new ResourceRequest();
			request.Init(resourceName, resourcePath);
			_resourceRequestDict.Add(resourceName, request);
		}
    }

    public string LoadConfigFileByPath(string configPath)
    {
        TextAsset text = Resources.Load<TextAsset>(configPath);
        if (text != null)
            return text.text;

		return FileManager.LoadFileWithString(configPath + ".txt");
    }

    public string LoadConfigFile(string configName)
    {
        ConfigRequest configReq = null;

        if (!_configRequestDict.TryGetValue(configName, out configReq))
        {
            return "";
        }

        return LoadConfigFileByPath(configReq.ConfigResourcePath);
    }

	//线性载入prefab，牺牲载入时间，保证prefab载入的速度和内存占用
	public void SingleLineLoad(string prefabName, LuaFunction func)
	{
		var prefabLoad = PoolManager.GetInstance().Get<SingleLineResource>("SingleLineResource");
		prefabLoad.PrefabName = prefabName;
		prefabLoad.CallBack = func;
		prefabLoad.Id = Time.realtimeSinceStartup;
		_prefabLoadRequestList.Add(prefabLoad);

        StartSingleLineLoad();
	}
	
	void  StartSingleLineLoad()
	{
		if (_prefabLoadRequestList.Count <= 0)
		{
			return;
		}
		
		if (_state == ResourceLoadStateType.Loading)
		{
			return;
		}
		
		var request = _prefabLoadRequestList[0];
		var prefabName = request.PrefabName;
		var callBack = request.CallBack;
		
        _prefabLoadRequestList.Remove(request);
		PoolManager.GetInstance().ReleaseObject<SingleLineResource> ("SingleLineResource", request);

        ResourceRequest prefabRequest = null;
        if (_resourceRequestDict.TryGetValue(prefabName, out prefabRequest))
		{
			_state = ResourceLoadStateType.Loading;
			prefabRequest.Load(callBack);
		}
		else
		{
			Debug.LogWarning("Couldn't find prefabRequest " + prefabName);
		}
	}

    public bool GetSharedDependencies(string name, out Dependency dependency)
    {
        if (_sharedAssetbundleDict.TryGetValue(name, out dependency))
        {
            return true;
        }

        Debug.LogWarning("Could not found the share dependency " + name);
        return false;
    }

    public void Clear()
    {
        //暂时先用foreach,clear毕竟不是很长使用
		foreach (KeyValuePair<string, ResourceRequest> obj in _resourceRequestDict)
        {
			obj.Value.ClearPrefab();
        }
    }
}
