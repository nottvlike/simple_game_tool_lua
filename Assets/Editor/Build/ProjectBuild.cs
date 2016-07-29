using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

class ProjectBuild : Editor{
	
	//在这里找出你当前工程所有的场景文件，假设你只想把部分的scene文件打包 那么这里可以写你的条件判断 总之返回一个字符串数组。
	static string[] GetBuildScenes()
	{
		List<string> names = new List<string>();
		
		foreach(EditorBuildSettingsScene e in EditorBuildSettings.scenes)
		{
			if(e==null)
				continue;
			if(e.enabled)
				names.Add(e.path);
		}
		return names.ToArray();
	}
	
	//得到项目的名称
	public static string projectName
	{
		get
		{ 
			//在这里分析shell传入的参数， 还记得上面我们说的哪个 project-$1 这个参数吗？
			//这里遍历所有参数，找到 project开头的参数， 然后把-符号 后面的字符串返回，
			//这个字符串就是 91 了。。
			foreach(string arg in System.Environment.GetCommandLineArgs()) {
				if(arg.StartsWith("project"))
				{
					return arg.Split("-"[0])[1];
				}
			}
			return "test";
		}
	}
	//shell脚本直接调用这个静态方法
	static void BuildForIPhone()
	{ 
		//打包之前先设置一下 预定义标签， 我建议大家最好 做一些  91 同步推 快用 PP助手一类的标签。 这样在代码中可以灵活的开启 或者关闭 一些代码。
		//因为 这里我是承接 上一篇文章， 我就以sharesdk做例子 ，这样方便大家学习 ，
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "USE_SHARE");
		//这里就是构建xcode工程的核心方法了， 
		//参数1 需要打包的所有场景
		//参数2 需要打包的名子， 这里取到的就是 shell传进来的字符串 91
		//参数3 打包平台
		BuildPipeline.BuildPlayer(GetBuildScenes(), projectName, BuildTarget.iOS, BuildOptions.None);
	}
}