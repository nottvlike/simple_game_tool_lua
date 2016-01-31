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
    ResourceLoadStateType _state = ResourceLoadStateType.None;
    bool _isAssetBundle = false;
    bool _isInit = false;

    public ResourceLoadStateType ResourceLoadState 
    {
        set
        {
            _state = value;
            if (_state != ResourceLoadStateType.Loading)
            {
                startSingleLineLoad();
            }
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

    public static ResourceManager getInstance()
    {
        return Instance;
    }

    public void init(string json)
    {
        if (!_isInit)
        {
            _isInit = true;
            if (!LuaManager.DEBUG)
            {
                _isAssetBundle = true;
            }

            loadConfigurationConfig();
            loadAssetBundleConfig();
        }
    }

    void loadConfigurationConfig()
    {
        string config = "";
        if (LuaManager.DEBUG)
        {
            TextAsset text = Resources.Load<TextAsset>(CONFIG_FILE);
            config = text.text;
        }
        else
        {
            config = FileManager.loadFileWithString(LuaManager.getConfigPath() + "/" + CONFIG_FILE + ".txt");
        }

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

    void loadAssetBundleConfig()
    {
        var txt = loadConfigFile(ASSETBUNDLE_CONFIG);
        JsonData jsonData = JsonMapper.ToObject(txt);
        if (jsonData["Prefabs"].IsArray)
        {
            for (int i = 0; i < jsonData["Prefabs"].Count; i++)
            {
                var jsonObj = jsonData["Prefabs"][i];
                var req = new PrefabRequest();
                req.init(jsonObj["PrefabName"].ToString(), jsonObj["PrefabPath"].ToString(), jsonObj["ResourcePath"].ToString(), _isAssetBundle);
                _prefabRequestDict.Add(jsonObj["PrefabName"].ToString(), req);
            }
        }
    }

    public string loadConfigFile(string configName)
    {
        ConfigRequest configReq = null;

        if (!hasConfigRequest(configName, out configReq))
        {
            return "";
        }

        if (LuaManager.DEBUG)
        {
            TextAsset text = Resources.Load<TextAsset>(configReq.ConfigResourcePath);
            return text.text;
        }
        else
        {
            return FileManager.loadFileWithString(LuaManager.getConfigPath() + "/" + configReq.ConfigResourcePath + ".txt");
        }
    }

    //线性载入prefab，牺牲载入时间，保证prefab载入的速度和内存占用
    public void singleLineLoadAsync(string prefabName, LuaFunction func)
    {
        var prefabLoad = new SingleLineResource();
        prefabLoad.PrefabName = prefabName;
        prefabLoad.CallBack = func;
        prefabLoad.Id = Time.realtimeSinceStartup;
        _prefabLoadList.Add(prefabLoad);

        startSingleLineLoad();
    }

    public void loadAssetBundleByPath(string path, string prefabName, LuaFunction func)
    {
        var req = new PrefabRequest();
        req.init(prefabName, path, path, true);

        req.loadAsync(func);
    }

    void startSingleLineLoad()
    {
        if (_prefabLoadList.Count <= 0)
        {
            return;
        }

        if (_state == ResourceLoadStateType.Loading)
        {
            return;
        }

        _state = ResourceLoadStateType.Loading;
        var res = _prefabLoadList[_prefabLoadList.Count - 1];
        loadAsync(res.PrefabName, res.CallBack);

        _prefabLoadList.Remove(res);
    }

    void loadAsync(string prefabName, LuaFunction func)
    {
        PrefabRequest prefabReq = null;
        if (hasPrefabRequest(prefabName, out prefabReq))
        {
            prefabReq.loadAsync(func);
        }
        else
        {
            if (LuaManager.DEBUG)
                Debug.LogError(string.Format("PrefabRequest {0} not found!", prefabName));
        }
    }

    public bool hasPrefabRequest(string prefabName, out PrefabRequest prefabRequest)
    {
        return _prefabRequestDict.TryGetValue(prefabName, out prefabRequest);
    }

    public bool hasConfigRequest(string configName, out ConfigRequest configRequest)
    {
        return _configRequestDict.TryGetValue(configName, out configRequest);
    }

    public void clear()
    {
        //暂时先用foreach,clear毕竟不是很长使用
        foreach (KeyValuePair<string, PrefabRequest> obj in _prefabRequestDict)
        {
            obj.Value.clearPrefab();
        }
    }
}
