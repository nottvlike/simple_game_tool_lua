using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class UpdateEditor : MonoBehaviour {

    const string TARGET_PATH = "";
    const string UPDATE_PATH = "/Update";

    public static void CopyUpdateFile()
    {
        FileManager.DeleteDirectory(UpdateManager.UpdateTest + UPDATE_PATH);
        List<string> fileList = new List<string>();
        LuaScriptEditor.GetAllScriptFile(Application.dataPath + "/Resources" + UPDATE_PATH, fileList);

        for (int i = 0; i < fileList.Count; ++i)
        {
            //TODO:加密每一个script文件，并拷贝到PersistentDataPath
            var file = fileList[i];
            var targetFile = file.Replace(Application.dataPath + "/Resources", UpdateManager.UpdateTest);
            var content = FileManager.LoadFileWithString(file);
            FileManager.CreateFileWithString(targetFile, LuaScriptEditor.EncryptScript(content));
        }
    }
}
