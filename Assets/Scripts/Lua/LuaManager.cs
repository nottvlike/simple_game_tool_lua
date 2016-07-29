using UnityEngine;
using System.Collections;
using System.Text;
using SLua;

public class LuaManager : Singleton<LuaManager> {

	LuaSvr l;
	StringBuilder _sb = new StringBuilder();
	const string START_SCRIPT = "Update/Update.txt";

    public LuaSvr L
    {
        get 
        {
            return l;
        }
    }

	public static LuaManager GetInstance()
	{
		return Instance;
	}
	
	public static string GetExternalDir(bool hasPrefix = false)
	{
#if UNITY_EDITOR
    #if RESOURCE_DEBUG
		return "";
    #endif
#else
    #if UNITY_ANDROID
		return "jar:file://" + Application.dataPath + "/!/assets/";
    #endif
#endif
        if (hasPrefix)
        {
            return "file:///" + Application.dataPath + "/StreamingAssets" + "/";
        }
        return Application.dataPath + "/StreamingAssets" + "/";
	}

	public void Init()
	{
#if !RESOURCE_DEBUG
		LuaState.loaderDelegate += LoaderDelegate;
#endif
        ModManager.Instance.Init();

		l = new LuaSvr();
		l.init(null, Complete, LuaSvrFlag.LSF_EXTLIB);
		DontDestroyOnLoad(this);
	}
	
	void Complete()
	{
        //若是载入了独立mod，则无需再执行本地游戏逻辑了
        if (ModManager.Instance.LoadMod())
            return;

#if RESOURCE_DEBUG
		l.start(START_SCRIPT.Replace(".txt", ""));
#else
		UpdateManager.Instance.Download (
			string.Format ("{0}/{1}", GetExternalDir(true), START_SCRIPT),
			"",
			UpdateManager.DownloadFileType.TypeText,
			LoadLuaString,
			false);
#endif
	}
	
	void LoadLuaString(string str)
	{
        l.startDoString(str);
	}
	
	byte[] LoaderDelegate(string filePath)
	{
		byte[] list = null;
		
		_sb.Remove(0, _sb.Length);
		_sb.Append(filePath);
		_sb = _sb.Replace('.', '/');
		_sb.Append(".txt");

		FileManager.LoadFileWithBytes(_sb.ToString(), out list);
		if(list != null)
		{
			return list;
		}
		return null;
	}
}
