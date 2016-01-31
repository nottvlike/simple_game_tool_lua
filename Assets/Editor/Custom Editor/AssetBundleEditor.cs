using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AssetBundleCustom {

    static Dictionary<string, List<string>> _assetBundleDict = new Dictionary<string,List<string>>();
    static Dictionary<string, int> _assetBundleCrc = new Dictionary<string, int>();

    [MenuItem("Custom Editor/Create AssetBunldes Selected")]
    static void CreateAssetBunldesSelected()
    {
        //获取在Project视图中选择的所有游戏对象
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        if (SelectedAsset.Length > 0)
        {
            BuildAssetBundle(SelectedAsset[0].name + ".assetbundle", SelectedAsset);
        }
    }

    [MenuItem("Custom Editor/CreateAssetBunldesAll")]
    static void CreateAssetBunldesAll()
    {
		var isDebug = LuaManager.DEBUG;
		LuaManager.DEBUG = true;

        InitAssetBundleDict();
        _assetBundleCrc.Clear();
        foreach (KeyValuePair<string, List<string>> obj in _assetBundleDict)
        {
            var fullPath = UpdateManager.UpdateTest + "/" + obj.Key;
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            if (obj.Value.Count > 0)
            {
                Object[] resources = new Object[obj.Value.Count];
                for (int i = 0; i < obj.Value.Count; ++i)
                {
                    resources[i] = Resources.Load(obj.Value[i]);
                }

                BuildAssetBundle(fullPath, resources);
            }
        }

		LuaManager.DEBUG = isDebug;
    }

    static void BuildAssetBundle(string path, Object[] resources)
    {
        BuildTarget buildTarget = BuildTarget.Android;

        FileManager.createDirectory(System.IO.Path.GetDirectoryName(path));

        if (BuildPipeline.BuildAssetBundle(null, resources, path, 
            BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.UncompressedAssetBundle, buildTarget))
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
        ResourceManager.Instance.init("");
        var _prefabDict = ResourceManager.Instance.PrefabRequestDict;

        foreach (KeyValuePair<string, PrefabRequest> obj in _prefabDict)
        {
            var target = obj.Value.AssetBundlePath;
            var resource = obj.Value.ResourcePath;

            List<string> resourceList = null;
            if (_assetBundleDict.TryGetValue(target, out resourceList))
            {
                resourceList.Add(resource);
            }
            else
            {
                resourceList = new List<string>();
                resourceList.Add(resource);
                _assetBundleDict.Add(target, resourceList);
            }
        }
    }
}
