using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public enum ModCateGoryType
{
    None,
    Helped,
    Standlone
}

public class ModInfo
{
    public string ModName;
    public ModCateGoryType ModType;
    public string ModPath;
    public bool IsSelected;
}

public class ModManager : Singleton<ModManager> {

    const string START_SCRIPT = "Script/Main.txt";
    const string MODINFO_FILE = "Config/ModConfig";
    Dictionary<string, ModInfo> _modInfoDictionary = new Dictionary<string,ModInfo>();
    List<string> _modInfoList = new List<string>();

    public static ModManager GetInstance()
    {
        return Instance;
    }

    public void Init()
    {
        var config = ResourceManager.Instance.LoadConfigFileByPath(MODINFO_FILE);
        if (config.Length <= 0)
        {
            Debug.LogWarning(string.Format("Load config file {0} failed!", MODINFO_FILE));
            return;
        }

        JsonData jsonData = JsonMapper.ToObject(config);
        for (int i = 0; i < jsonData["Mods"].Count; i++)
        {
            var modData = jsonData["Mods"][i];
            var modName = modData["ModName"].ToString();
            var modPath = modData["ModPath"].ToString();
            var modType = modData["ModType"].ToString();

            ModInfo info = new ModInfo();
            info.ModName = modName;
            info.ModPath = modPath;
            info.ModType = (ModCateGoryType)Enum.Parse(typeof(ModCateGoryType), modType, true);
            info.IsSelected = false;
            _modInfoDictionary.Add(info.ModName, info);
        }

        _modInfoList.AddRange(_modInfoDictionary.Keys);

        SelectMod("AITank");
    }

    /*
     * 载入mod，只载入了独立mod
     * */
    public bool LoadMod()
    {
        ModInfo modInfo = null;
        for (int i = 0; i < _modInfoList.Count; ++i)
        {
            var tmpModName = _modInfoList[i];
            modInfo = null;
            if (_modInfoDictionary.TryGetValue(tmpModName, out modInfo))
            {
                if (!modInfo.IsSelected)
                    continue;

                if (modInfo.ModType == ModCateGoryType.Helped)
                {
                    //TODO:添加载入共享mod处理
                    continue;
                }

                var luaSvr = LuaManager.Instance.L;
#if RESOURCE_DEBUG
		        luaSvr.start(string.Format("{0}/{1}", modInfo.ModPath, START_SCRIPT.Replace(".txt", "")));
#else
                var scriptString = FileManager.LoadFileWithString(modInfo.ModPath + "/" + START_SCRIPT);
                luaSvr.startDoString(scriptString);
#endif
                return true;
            }
        }
        return false;
    }

    public void SelectMod(string modName)
    {
        ModInfo modInfo = null;
        if (_modInfoDictionary.TryGetValue(modName, out modInfo))
        {
            modInfo.IsSelected = true;
        }

        //是辅助mod，则无操作
        if (modInfo.ModType == ModCateGoryType.Helped)
            return;

        //是独立mod，则取消选中其它独立mod
        for(int i = 0; i < _modInfoList.Count; ++i)
        {
            var tmpModName = _modInfoList[i];
            modInfo = null;
            if (_modInfoDictionary.TryGetValue(tmpModName, out modInfo))
            {
                if (modInfo.ModType == ModCateGoryType.Helped || modInfo.ModName.CompareTo(modName) == 0)
                    continue;

                modInfo.IsSelected = false;
            }
        }
    }
}
