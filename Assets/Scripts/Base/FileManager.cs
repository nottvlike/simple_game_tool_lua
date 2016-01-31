using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
 

public class FileManager {

    public static void createDirectory(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    public static bool isFileExist(string fullPath)
    {
        return File.Exists(fullPath);
    }

    public static bool isDirectoryExist(string fullPath)
    {
        return Directory.Exists(fullPath);
    }

    /**
    * path：文件创建目录
    *  info：写入的内容
    */
    public static void createFileWithString(string path, string info)
    {
   	  //文件流信息
        StreamWriter sw;
        FileInfo t = new FileInfo(path);

        createDirectory(System.IO.Path.GetDirectoryName(path));

        if(!t.Exists)
        {
      	    //如果此文件不存在则创建
      	    sw = t.CreateText();
        }
	    else
	    {
	  	    //如果此文件存在则删除
            File.Delete(path);
            sw = t.CreateText();
	    }
	    //以行的形式写入信息
        sw.Write(info);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }

    /**
    * path：文件创建目录
    *  info：写入的内容
    */
    public static void createFileWithBytes(string path, byte[] info, int length)
    {
        //文件流信息
        Stream sw;
        FileInfo t = new FileInfo(path);

        createDirectory(System.IO.Path.GetDirectoryName(path));

        if (!t.Exists)
        {
            //如果此文件不存在则创建
            sw = t.Create();
        }
        else
        {
            //如果此文件存在则删除
            File.Delete(path);
            sw = t.Create();
        }
        //以行的形式写入信息
        //sw.WriteLine(info);
        sw.Write(info, 0, length);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }

   /**
    * path：读取文件的路径
    * content：读取文件的内容
    */
   public static void loadFileWithBytes(string path, out byte[] content)
   {
   		//使用流的形式读取
       content = null;
        StreamReader sr =null;
		try{
			sr = File.OpenText(path);
		}catch(Exception e)
		{
			//路径与名称未找到文件则直接返回空
            if (LuaManager.DEBUG)
                Debug.Log("Failed to open file " + path + " Error : " + e.Message);
			return;
		}
        string line = sr.ReadToEnd();
        content = System.Text.Encoding.UTF8.GetBytes(line);
		//关闭流
		sr.Close();
   		//销毁流
   		sr.Dispose();
   }

   /**
    * path：读取文件的路径
    * content：读取文件的内容
    */
   public static string loadFileWithString(string path)
   {
       //使用流的形式读取
       string content = null;
       StreamReader sr = null;
       try
       {
           sr = File.OpenText(path);
       }
       catch (Exception e)
       {
           //路径与名称未找到文件则直接返回空
           if (LuaManager.DEBUG)
               Debug.Log("Failed to open file " + path + " Error : " + e.Message);
           return "";
       }
       content = sr.ReadToEnd();
       //关闭流
       sr.Close();
       //销毁流
       sr.Dispose();

       return content;
   }  

  /**
   * path：删除文件的路径
   */
   public static void deleteFile(string path)
   {
       FileInfo t = new FileInfo(path);
       if (t.Exists)
       {
           File.Delete(path);
       }
   } 
}
