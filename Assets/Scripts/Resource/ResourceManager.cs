//#define RESOURCE_DEBUG

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

public class SingleLineResource {
    public float Id;
    public string PrefabName;
    public LuaFunction CallBack;
}

public class ConfigRequest{
    public string ConfigName;
    public string ConfigPath;
    public string ConfigResourcePath;
}

public class ResourceManager : Singleton<ResourceManager> 
{
    const string ASSETBUNDLE_CONFIG = "AssetBundleConfig";
    const string CONFIG_FILE = "Config/Configuration";

    Dictionary<string, ConfigRequest> _configRequestDict = new Dictionary<string, ConfigRequest>();
	Dictionary<string, PrefabRequest> _prefabRequestDict = new Dictionary<string, PrefabRequest>();
    List<SingleLineResource> _prefabLoadList = new List<SingleLineResource>();
	PrefabRequest _currentPrefabRequest = null;
    ResourceLoadStateType _state = ResourceLoadStateType.None;
    bool _isAssetBundle = false;
    bool _isInit = false;

    public ResourceLoadStateType ResourceLoadState 
    {
        set
        {
            _state = value;
        }
        get { return _state; }
    }

    public Dictionary<string, PrefabRequest> PrefabRequestDict
    {
        get
        {
            return _prefabRequestDict;
        }
    }

    public static ResourceManager GetInstance()
    {
        return Instance;
    }

    public void Init(string json)
    {
        if (!_isInit)
        {
            _isInit = true;
#if RESOURCE_DEBUG
#else
			_isAssetBundle = true;
#endif

            LoadConfigurationConfig();
            LoadAssetBundleConfig();
        }
    }

    void LoadConfigurationConfig()
    {
        string config = "";

		_configRequestDict.Clear ();

#if RESOURCE_DEBUG
		TextAsset text = Resources.Load<TextAsset>(CONFIG_FILE);
		config = text.text;
#elif UNITY_ANDROID
		config = FileManager.LoadFileWithString(CONFIG_FILE + ".txt");
#else 
		config = FileManager.LoadFileWithString(CONFIG_FILE + ".txt");
#endif

        JsonData jsonData = JsonMapper.ToObject(config);
        if (jsonData["Configs"].IsArray)
        {
            for (int i = 0; i < jsonData["Configs"].Count; i++)
            {
                var jsonObj = jsonData["Configs"][i];
                var req = new ConfigRequest();
                req.ConfigName = jsonObj["ConfigName"].ToString();
                req.ConfigPath = jsonObj["ConfigPath"].ToString();
                req.ConfigResourcePath = jsonObj["ResourcePath"].ToString();
                _configRequestDict.Add(jsonObj["ConfigName"].ToString(), req);
            }
        }
    }

    void LoadAssetBundleConfig()
    {
		_prefabRequestDict.Clear ();

        var txt = LoadConfigFile(ASSETBUNDLE_CONFIG);
        JsonData jsonData = JsonMapper.ToObject(txt);
        if (jsonData["Prefabs"].IsArray)
        {
            for (int i = 0; i < jsonData["Prefabs"].Count; i++)
            {
                var jsonObj = jsonData["Prefabs"][i];
				var req = new PrefabRequest();
				req.Init(jsonObj["PrefabName"].ToString(), jsonObj["PrefabPath"].ToString(), jsonObj["ResourcePath"].ToString(), _isAssetBundle);
                _prefabRequestDict.Add(jsonObj["PrefabName"].ToString(), req);
            }
        }
    }

    public string LoadConfigFile(string configName)
    {
        ConfigRequest configReq = null;

        if (!HasConfigRequest(configName, out configReq))
        {
            return "";
        }
#if RESOURCE_DEBUG
		TextAsset text = Resources.Load<TextAsset>(configReq.ConfigResourcePath);
		return text.text;
#elif UNITY_ANDROID
		return FileManager.LoadFileWithString(configReq.ConfigResourcePath + ".txt");
#else
		return FileManager.LoadFileWithString(LuaManager.GetConfigPath() + "/" + configReq.ConfigResourcePath + ".txt");
#endif
    }

	//线性载入prefab，牺牲载入时间，保证prefab载入的速度和内存占用
	public void SingleLineLoad(string prefabName, LuaFunction func)
	{
		var prefabLoad = new SingleLineResource();
		prefabLoad.PrefabName = prefabName;
		prefabLoad.CallBack = func;
		prefabLoad.Id = Time.realtimeSinceStartup;
		_prefabLoadList.Add(prefabLoad);
	}
	
	void  StartSingleLineLoad()
	{
		if (_prefabLoadList.Count <= 0)
		{
			return;
		}
		
		if (_state == ResourceLoadStateType.Loading)
		{
			return;
		}
		
		var res = _prefabLoadList[0];
		PrefabRequest prefabReq = null;
		var prefabName = res.PrefabName;
		var callBack = res.CallBack;
		_prefabLoadList.Remove(res);
		
		if (HasPrefabRequest(prefabName, out prefabReq))
		{
			_state = ResourceLoadStateType.Loading;
			prefabReq.Load(callBack);
		}
		else
		{
			Debug.LogWarning("Couldn't find prefabRequest " + prefabName);
		}
	}

    public bool HasPrefabRequest(string prefabName, out PrefabRequest prefabRequest)
    {
		if (_prefabRequestDict.TryGetValue(prefabName, out prefabRequest)) {
			return true;
		}
		return false;
	}
	
    public bool HasConfigRequest(string configName, out ConfigRequest configRequest)
    {
        return _configRequestDict.TryGetValue(configName, out configRequest);
    }

    public void Clear()
    {
        //暂时先用foreach,clear毕竟不是很长使用
		foreach (KeyValuePair<string, PrefabRequest> obj in _prefabRequestDict)
        {
			obj.Value.ClearPrefab();
        }
    }

	void Update()
	{
		if (_state != ResourceLoadStateType.Loading && _prefabLoadList.Count > 0)
		{
			StartSingleLineLoad();
		}
	}
}
