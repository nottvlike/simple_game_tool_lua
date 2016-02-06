using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MenuEditor {
    [MenuItem("Custom Editor/BuildAssetBundle")]
    static void BuildAssetBundle()
    {
        Debug.Log("正在打包...");
        AssetBundleEditor.CreateAssetBunldesAll();
        Debug.Log("打包完成...");
    }

    [MenuItem("Custom Editor/BuildScript")]
    static void BuildScript()
    {
        Debug.Log("正在拷贝脚本...");
        LuaScriptEditor.CopyScript();
        Debug.Log("拷贝脚本完成...");
    }

    [MenuItem("Custom Editor/BuildConfig")]
    static void BuildConfig()
    {
        Debug.Log("正在拷贝配置...");
        ConfigEditor.CopyConfig();
        Debug.Log("拷贝配置完成...");
    }

    [MenuItem("Custom Editor/BuildUpdate")]
    static void BuildUpdate()
    {
        Debug.Log("正在拷贝更新逻辑文件...");
        UpdateEditor.CopyUpdateFile();
        Debug.Log("拷贝配置更新逻辑文件...");
    }

    [MenuItem("Custom Editor/GenerateVersionFile")]
    static void GenerateVersionFile()
    {
        Debug.Log("正在生成更新文件...");
        AssetBundleEditor.GenerateVersionContent();
        Debug.Log("生成更新文件完成...");
    }

    [MenuItem("Custom Editor/All")]
    static void All()
    {
        BuildAssetBundle();
        BuildScript();
        BuildConfig();
        BuildUpdate();
        GenerateVersionFile();
    }
}
