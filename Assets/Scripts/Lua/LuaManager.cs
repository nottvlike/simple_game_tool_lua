using UnityEngine;
using System.Collections;
using System.Text;
using SLua;

public class LuaManager : Singleton<LuaManager> {

	public static bool DEBUG = false;
	
	LuaSvr l;
	StringBuilder _sb = new StringBuilder();
	const string START_SCRIPT = "Update/Update.txt";
	
	public static LuaManager getInstance()
	{
		return Instance;
	}
	
	public static string getAssetBundlePath()
	{
		if(!DEBUG)
		{
			return Application.persistentDataPath;
		}
		return "";
	}
	
	public static string getScriptPath()
	{
		return getAssetBundlePath();
	}
	
	public static string getConfigPath()
	{
		return getAssetBundlePath();
	}
	
	public void init()
	{
		if (!DEBUG)
		{
			LuaState.loaderDelegate += loaderDelegate;
		}
		
		l = new LuaSvr();
		l.init(null, complete, false);
		DontDestroyOnLoad(this);
	}
	
	void complete()
	{
		if (DEBUG) {
			l.start(START_SCRIPT.Replace(".txt", ""));
		} else {
			UpdateManager.Instance.download (
				string.Format ("file:///{0}/{1}", UpdateManager.UpdateTest, START_SCRIPT),
				string.Format ("{0}/{1}", getScriptPath (), START_SCRIPT),
				UpdateManager.DownloadFileType.TypeText,
				loadLuaString);
		}
	}
	
	void loadLuaString(string str)
	{
		l.startDoString(str);
	}
	
	byte[] loaderDelegate(string filePath)
	{
		byte[] list = null;
		
		_sb.Remove(0, _sb.Length);
		_sb.Append(getScriptPath());
		_sb.Append("/");
		_sb.Append(filePath);
		_sb = _sb.Replace('.', '/');
		_sb.Append(".txt");
		
		FileManager.loadFileWithBytes(_sb.ToString(), out list);
		if(list != null)
		{
			return list;
		}
		return null;
	}
}
