using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/*
 * 记录自动生成assetbundle,config和script热更的内容和大小
 * */
public class UpdateModuleMessage
{
    public string Content;
    public int Size;
}

/*
 * 打包assetbundle所创建的dictionary需要的结构体，保存单个assetbundle所含的prefab信息和依赖列表
 * */
public class AssetBundleRequest
{
	public string Name;
	public int Size;
	public List<string> PrefabList;
    public bool IsShared;
}

public class AssetBundleEditor {

	static Dictionary<string, AssetBundleRequest> _assetBundleDict = new Dictionary<string, AssetBundleRequest>();


#if UNITY_5_3
#else
	static BuildTarget _buildTarget = BuildTarget.Android;
	static BuildAssetBundleOptions _buildOptions = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets;
#endif

    public static void CreateAssetBunldesAll()
    {
        InitAssetBundleDict();

#if UNITY_5_3
		BuildPipeline.BuildAssetBundles(UpdateManager.UpdateTest + "/");
#else
        BuildPipeline.PushAssetDependencies();
        foreach (KeyValuePair<string, AssetBundleRequest> obj in _assetBundleDict)
        {
            var assetbundleName = obj.Key;
            var assetbundleRequest = obj.Value;

            var fullPath = UpdateManager.UpdateTest + "/" + assetbundleName;
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            var prefabList = assetbundleRequest.PrefabList;
            if (prefabList.Count > 0)
            {
                //先将依赖打为assetbundle，与主assetbundle存放同一文件夹
                if (assetbundleRequest.IsShared)
                {
                    Object[] sharedDependencies = new Object[prefabList.Count];
                    for (int i = 0; i < prefabList.Count; ++i)
                    {
                        sharedDependencies[i] = Resources.Load(prefabList[i]);
                    }

                    BuildSharedAssetBundle(fullPath, sharedDependencies);
                    continue;
                }

                //打包主assetbundlle
                Object[] resources = new Object[prefabList.Count];
                for (int i = 0; i < prefabList.Count; ++i)
                {
                    resources[i] = Resources.Load(prefabList[i]);
                }

                BuildAssetBundle(fullPath, resources);
            }
        }
        BuildPipeline.PopAssetDependencies();
#endif
        //刷新编辑器
        AssetDatabase.Refresh();
    }

    /*
     * 自动生成热更内容，即UpdateTest.txt文件
     * */
    public static void GenerateVersionContent()
    {
        var version = "3.1.3";
        var content = "";
        var fileContent = "";
        var fileSize = 0;

        UpdateModuleMessage module = null;
        GenerateAssetBundleVersionContent(out module);
        fileContent += module.Content;
        fileSize += module.Size;

        module = null;
        LuaScriptEditor.GenerateScriptVersionContent(out module);
        fileContent += module.Content;
        fileSize += module.Size;

        module = null;
        ConfigEditor.GenerateConfigVersionContent(out module);
        fileContent += module.Content;
        fileSize += module.Size;

        content += "return {\n";
        content += "\tVersion = \"" + version + "\",\n";
        content += "\tUpdateURL = " + "\"" + UpdateManager.UpdateTest + "\",\n";
        
        content += "\tUpdateSize = " + fileSize + ",\n";
        content += fileContent;

        content += "}\n";

        FileManager.CreateFileWithString(UpdateManager.UpdateTest + "/" + "UpdateTest.txt", content);
    }

    static void GenerateAssetBundleVersionContent(out UpdateModuleMessage assetModule)
    {
        assetModule = new UpdateModuleMessage();

        InitAssetBundleDict();
        string content = "";
        int moduleSize = 0;
        content += "\tPrefabs = {\n";
        foreach (KeyValuePair<string, AssetBundleRequest> obj in _assetBundleDict)
        {
            var fullPath = UpdateManager.UpdateTest + "/" + obj.Key;
            content += "\t\t{\n";
            content += "\t\t\tname=\"" + obj.Key + "\",\n";
			var asset = new FileInfo(fullPath);
			content += "\t\t\tsize=" + Mathf.Ceil(FileManager.GetFileSize(FileSizeUnitType.Type_Kb, asset.Length)) + ",\n";
            content += "\t\t},\n";
			moduleSize += (int)Mathf.Ceil(FileManager.GetFileSize(FileSizeUnitType.Type_Kb, asset.Length));
        }
        content += "\t},\n";
        assetModule.Content = content;
        assetModule.Size = moduleSize;
    }

    static void BuildAssetBundle(string path, Object[] resources)
    {
#if UNITY_5_3
#else
		BuildPipeline.PushAssetDependencies();

		FileManager.CreateDirectory(Path.GetDirectoryName(path));

		if (BuildPipeline.BuildAssetBundle(null, resources, path, _buildOptions, _buildTarget))
		{
		Debug.Log(path + "资源打包成功");
		}
		else
		{
		Debug.Log(path + "资源打包失败");
		}

		BuildPipeline.PopAssetDependencies();
#endif
    }

    static void BuildSharedAssetBundle(string path, Object[] resources)
    {
#if UNITY_5_3
#else
        FileManager.CreateDirectory(System.IO.Path.GetDirectoryName(path));

        if (BuildPipeline.BuildAssetBundle(null, resources, path, _buildOptions, _buildTarget))
        {
            Debug.Log(path + "资源打包成功");
        }
        else
        {
            Debug.Log(path + "资源打包失败");
        }
#endif
    }

    /*
     * 新建一个用于打包assetbundle的dictionary，转换AssetBundleConfig.txt中的prefab信息为新的assetbundle关系
     * 将        prefabName      -->> prefabPath : AssetbundlePath
     * 改为      AssetbundlePath -->> prefabName : prefabPath : prefabPath ...
     * 一个assetbundle可能包含多个prefab
     * */
    static void InitAssetBundleDict()
    {
		ResourceManager.Instance.Init ("");
        var _prefabDict = ResourceManager.Instance.PrefabRequestDict;

		foreach (var obj in _prefabDict)
        {
			var request = obj.Value;
			var assetbundlePath = request.AssetbundlePath;
			var prefabPath = request.PrefabPath;

			AssetBundleRequest assetbundleRequest = null;
			if (_assetBundleDict.TryGetValue(assetbundlePath, out assetbundleRequest))
            {
                //assetbundlePath目录一致，则打到同一个assetbundle中
				assetbundleRequest.PrefabList.Add(prefabPath);
            }
            else
            {
				assetbundleRequest = new AssetBundleRequest();
				assetbundleRequest.Name = request.PrefabName;
				assetbundleRequest.PrefabList = new List<string>();
				assetbundleRequest.PrefabList.Add(prefabPath);
                assetbundleRequest.IsShared = false;
				_assetBundleDict.Add(assetbundlePath, assetbundleRequest);
            }
        }

        var sharedDict = ResourceManager.Instance.SharedAssetbundleDict;
        foreach(var obj in sharedDict)
        {
            var request = obj.Value;

			var assetbundlePath = request.AssetbundlePath;
			var prefabPath = request.PrefabPath;

            AssetBundleRequest assetbundleRequest = null;
            if (_assetBundleDict.TryGetValue(assetbundlePath, out assetbundleRequest))
            {
                //assetbundlePath目录一致，则打到同一个assetbundle中
                assetbundleRequest.PrefabList.Add(prefabPath);
            }
            else
            {
                assetbundleRequest = new AssetBundleRequest();
                assetbundleRequest.Name = request.PrefabName;
                assetbundleRequest.PrefabList = new List<string>();
                assetbundleRequest.PrefabList.Add(prefabPath);
                assetbundleRequest.IsShared = true;
                _assetBundleDict.Add(assetbundlePath, assetbundleRequest);
            }
        }
    }
}
