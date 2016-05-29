#define RESOURCE_DEBUG

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class UpdateModuleMessage
{
    public string Content;
    public int Size;
}

public class AssetBundleRequest
{
	public string Name;
	public int Size;
	public List<string> PrefabList; 
}

public class AssetBundleEditor {

	static Dictionary<string, AssetBundleRequest> _assetBundleDict = new Dictionary<string, AssetBundleRequest>();
    static Dictionary<string, int> _assetBundleCrc = new Dictionary<string, int>();

    public static void CreateAssetBunldesSelected()
    {
        //获取在Project视图中选择的所有游戏对象
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        if (SelectedAsset.Length > 0)
        {
            BuildAssetBundle(SelectedAsset[0].name + ".assetbundle", SelectedAsset);
        }
    }

    public static void CreateAssetBunldesAll()
    {

        InitAssetBundleDict();
        _assetBundleCrc.Clear();
        foreach (KeyValuePair<string, AssetBundleRequest> obj in _assetBundleDict)
        {
            var fullPath = UpdateManager.UpdateTest + "/" + obj.Key;
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            if (obj.Value.PrefabList.Count > 0)
            {
				Object[] resources = new Object[obj.Value.PrefabList.Count];
				for (int i = 0; i < obj.Value.PrefabList.Count; ++i)
                {
					resources[i] = Resources.Load(obj.Value.PrefabList[i]);
                }

                BuildAssetBundle(fullPath, resources);
            }
        }
    }

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
        BuildTarget buildTarget = BuildTarget.Android;
        Debug.Log("BuildAssetBundle " + path);
        FileManager.CreateDirectory(System.IO.Path.GetDirectoryName(path));

        if (BuildPipeline.BuildAssetBundle(null, resources, path, 
											BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, buildTarget))
        {
            Debug.Log(path + "资源打包成功");
        }
        else
        {
            Debug.Log(path + "资源打包失败");
        }

        //刷新编辑器
        AssetDatabase.Refresh();
    }

    static void InitAssetBundleDict()
    {
		ResourceManager.Instance.Init ("");
        var _prefabDict = ResourceManager.Instance.PrefabRequestDict;

		foreach (KeyValuePair<string, PrefabRequest> obj in _prefabDict)
        {
			var objReq = obj.Value;
			var target = objReq.AssetBundlePath;
			var resource = objReq.ResourcePath;

			AssetBundleRequest req = null;
			if (_assetBundleDict.TryGetValue(target, out req))
            {
				req.PrefabList.Add(resource);
            }
            else
            {
				AssetBundleRequest reqAsset = new AssetBundleRequest();
				reqAsset.Name = objReq.PrefabName;
				reqAsset.PrefabList = new List<string>();
				reqAsset.PrefabList.Add(resource);
				_assetBundleDict.Add(target, reqAsset);
            }
        }
    }
}
