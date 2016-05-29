#define LOG_DEBUG
//#define RESOURCE_DEBUG

using UnityEngine;
using System.Collections;
using System.Text;
using SLua;

public class LuaManager : Singleton<LuaManager> {

	LuaSvr l;
	StringBuilder _sb = new StringBuilder();
	const string START_SCRIPT = "Update/Update.txt";
	
	public static LuaManager GetInstance()
	{
		return Instance;
	}
	
	public static string GetAssetBundlePath()
	{
#if RESOURCE_DEBUG
		return "";
#elif UNITY_EDITOR
		return Application.streamingAssetsPath + "/";
#else
		return "jar:file://" + Application.dataPath + "/!/assets/";
#endif
	}
	
	public static string GetScriptPath()
	{
		return GetAssetBundlePath();
	}
	
	public static string GetConfigPath()
	{
		return GetAssetBundlePath();
	}
	
	public void Init()
	{
#if RESOURCE_DEBUG
#else
		LuaState.loaderDelegate += LoaderDelegate;
#endif
		
		l = new LuaSvr();
		l.init(null, Complete, false);
		DontDestroyOnLoad(this);
	}
	
	void Complete()
	{
#if RESOURCE_DEBUG
		l.start(START_SCRIPT.Replace(".txt", ""));
#else
		UpdateManager.Instance.Download (
#if UNITY_EDITOR
			string.Format ("file:///{0}/{1}", UpdateManager.UpdateTest, START_SCRIPT),
#else
			string.Format ("{0}/{1}", "jar:file://" + Application.dataPath + "/!/assets", START_SCRIPT),
#endif
			string.Format ("{0}/{1}", GetScriptPath (), START_SCRIPT),
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
		//_sb.Append(GetScriptPath());
		//_sb.Append("/");
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
