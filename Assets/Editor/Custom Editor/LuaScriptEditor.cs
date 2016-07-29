using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LuaScriptEditor {
    const string TARGET_PATH = "";
    const string SCRIPT_PATH = "/Script";

    public static void CopyScript()
    {
        FileManager.DeleteDirectory(UpdateManager.UpdateTest + SCRIPT_PATH);
        List<string> fileList = new List<string>();
        GetAllScriptFile(Application.dataPath + "/Resources" + SCRIPT_PATH, fileList);

        for (int i = 0; i < fileList.Count; ++i)
        {
            //TODO:加密每一个script文件，并拷贝到PersistentDataPath
            var file = fileList[i];
            var targetFile = file.Replace(Application.dataPath + "/Resources", UpdateManager.UpdateTest);
            var content = FileManager.LoadFileWithString(file);
            FileManager.CreateFileWithString(targetFile, EncryptScript(content));
        }
    }

    public static void GenerateScriptVersionContent(out UpdateModuleMessage assetBundle)
    {
        assetBundle = new UpdateModuleMessage();
        int assetSize = 0;

        string generate = "\tScripts = {\n";
        List<string> fileList = new List<string>();
        GetAllScriptFile(Application.dataPath + "/Resources" + SCRIPT_PATH, fileList);

        for (int i = 0; i < fileList.Count; ++i)
        {
            //TODO:加密每一个script文件，并拷贝到PersistentDataPath
            var file = fileList[i];
            byte[] fileContent = null;
            FileManager.LoadFileWithBytes(file, out fileContent);
            var size = FileManager.GetFileSize(FileSizeUnitType.Type_Kb, fileContent.Length);
            generate += "\t\t{\n";
            generate += "\t\t\tname=\"" + file.Replace(Application.dataPath + "/Resources/", "") + "\"" + ",\n";
            generate += "\t\t\tsize=" + Mathf.Ceil(size) + ",\n";
            generate += "\t\t},\n";
            assetSize += (int)Mathf.Ceil(size);
        }

        generate += "\t},\n";
        assetBundle.Content = generate;
        assetBundle.Size = assetSize;
    }

    public static string EncryptScript(string content)
    {
        //TODO：加密脚本
        return content;
    }

    //文件夹遍历功能
    public static void GetAllScriptFile(string scriptPath, List<string> fileList)
    {
        if (!Directory.Exists(scriptPath))
        {
            return;
        }

        var scripts = Directory.GetFiles(scriptPath);
        foreach (var script in scripts)
        {
            var suffix = script.Substring(script.Length - 5, 5);
            if (suffix != ".meta")
            {
                fileList.Add(script.Replace('\\', '/'));
            }
        }

        var dirs = Directory.GetDirectories(scriptPath);
        foreach (var dir in dirs)
        {
            GetAllScriptFile(dir, fileList);
        }
    }
}
