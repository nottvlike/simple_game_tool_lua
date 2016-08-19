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
#if UNITY_ANDROID && !UNITY_EDITOR
		return "jar:file://" + Application.dataPath + "/!/assets/";
#endif

        if (hasPrefix)
        {
            return "file:///" + Application.dataPath + "/StreamingAssets" + "/";
        }
        return Application.dataPath + "/StreamingAssets" + "/";
	}

	public void Init()
	{
		LuaState.loaderDelegate += LoaderDelegate;

		l = new LuaSvr();
		l.init(null, Complete, LuaSvrFlag.LSF_EXTLIB);
		DontDestroyOnLoad(this);
	}
	
	void Complete()
	{
		l.start(START_SCRIPT.Replace(".txt", ""));
	}
	
	byte[] LoaderDelegate(string filePath)
	{
		byte[] list = null;
		
        _sb.Remove(0, _sb.Length);
		_sb.Append(filePath);
		_sb = _sb.Replace('.', '/');

        var text = Resources.Load<TextAsset>(_sb.ToString());
        if (text != null)
        {
            return text.bytes;
        }

		_sb.Append(".txt");
		FileManager.LoadFileWithBytes(_sb.ToString(), out list);
		if(list != null)
		{
			return list;
		}
		return null;
	}
}
