using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LuaScriptEditor {
    const string TARGET_PATH = "";
    const string SCRIPT_PATH = "/Script";

    [MenuItem("Custom Editor/EncryptScript")]
    static void EncryptScript()
    {
        List<string> fileList = new List<string>();
        GetAllScriptFile(Application.dataPath + "/Resources" + SCRIPT_PATH, fileList);

        string info = "";
        for (int i = 0; i < fileList.Count; ++i)
        {
            //TODO:加密每一个script文件，并拷贝到PersistentDataPath
            var file = fileList[i];
            file = file.Replace(Application.dataPath + "/Resources", "");
            //file = file.Replace("\\", "\\\\");
            //file = file.Replace("/", "\\\\");
            info += "\"" + file + "\"," + "\n";
        }
        FileManager.createFileWithString(UpdateManager.UpdateTest + "/fileList.txt", info);
    }

    //文件夹遍历功能
    static void GetAllScriptFile(string scriptPath, List<string> fileList)
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
                fileList.Add(script);
            }
        }

        var dirs = Directory.GetDirectories(scriptPath);
        foreach (var dir in dirs)
        {
            GetAllScriptFile(dir, fileList);
        }
    }
}
