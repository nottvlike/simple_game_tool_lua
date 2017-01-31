using UnityEngine;
using System.Collections;
using System.Text;
using SLua;

public class LuaManager : Singleton<LuaManager> {

	LuaSvr l;
	StringBuilder _sb = new StringBuilder();

	string _startScriptName = "";

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
#if UNITY_ANDROID
		return "jar:file://" + Application.dataPath + "/!/assets/";
#endif

		if (hasPrefix)
		{
			return string.Format("file:///{0}/StreamingAssets/" + Application.dataPath);
		}
		return string.Format("{0}/StreamingAssets/", Application.dataPath);
	}

	public void Init(string startScriptName = "")
	{
		_startScriptName = startScriptName;

		LuaState.loaderDelegate += LoaderDelegate;

		l = new LuaSvr();
		l.init(null, Complete, LuaSvrFlag.LSF_EXTLIB);
		DontDestroyOnLoad(this);
	}
	
	void Complete()
	{
		l.start(_startScriptName.Replace(".txt", ""));
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
