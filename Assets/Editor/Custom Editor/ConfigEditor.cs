using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ConfigEditor {
    const string TARGET_PATH = "";
    const string CONFIG_PATH = "/Config";

    public static void CopyConfig()
    {
        FileManager.DeleteDirectory(UpdateManager.UpdateTest + CONFIG_PATH);
        List<string> fileList = new List<string>();
        LuaScriptEditor.GetAllScriptFile(Application.dataPath + "/Resources" + CONFIG_PATH, fileList);

        for (int i = 0; i < fileList.Count; ++i)
        {
            //TODO:加密每一个script文件，并拷贝到PersistentDataPath
            var file = fileList[i];
            var targetFile = file.Replace(Application.dataPath + "/Resources", UpdateManager.UpdateTest);
            var content = FileManager.LoadFileWithString(file);
            FileManager.CreateFileWithString(targetFile, LuaScriptEditor.EncryptScript(content));
        }
    }

    public static void GenerateConfigVersionContent(out UpdateModuleMessage assetBundle)
    {
        assetBundle = new UpdateModuleMessage();
        int assetSize = 0;

        string generate = "\tConfigs = {\n";
        List<string> fileList = new List<string>();
        LuaScriptEditor.GetAllScriptFile(Application.dataPath + "/Resources" + CONFIG_PATH, fileList);

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
}
