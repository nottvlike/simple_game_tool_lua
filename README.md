#目录
*	[1.前言](#1)
	*	[1.1.Unity3d开发版本](#1.1)
	*	[1.2.第三方插件](#1.2)
*	[2.基本约定](#2)
	*	[2.1.两中开发模式](#2.1)
	*	[2.2.三个路径](*2.2)
	*	[2.3.四类资源文件夹](*2.3)
*	[3.主要模块介绍](#3)
	*	[3.1.Slua模块](#3.1)
		*	[3.1.1 lua常用函数介绍](#3.1.1)
		*	[3.1.2 lua回调系统设计](#3.1.2)
	*	[3.2.行为树模块](#3.2)
		*	[3.2.1 Behavior3介绍](#3.2.1)
		*	[3.2.2 Behavior3lua](#3.2.2)
	*	[3.3.热更新模块](#3.3)
	*	[3.4.资源管理模块](#3.4)	
*	[4.后序计划](#4)
<br/>

<h2 id="1">1.	前言</h2>

OpenWorldGame是希望自己在学习unity3d的过程中，慢慢实现一个相对复杂的游戏框架，目前只包含客户端部分。对于这部分，有如下几个要求：

*	游戏主要逻辑使用lua语言实现；
*	支持游戏常用的功能，例如AI，热更新，资源管理;
*	尽量少的使用第三方插件，第三方插件一方面在使用上不自由（无法做自己想做的改动），另一方面需要确定导出lua接口后能否正常工作。

---- 更新于2016年1月31日:

加了热更新和资源管理的代码，虽然还是个大demo，不过也总算有一点样子了，热更新只在文件系统内做了一些测试，还没有涉及到网络这一块，以后会加上网络模块然后先测试下内网更新，东西还很粗糙，还有很多地方比较混乱，先慢慢补下文档。

---- 更新于2016年2月5日
在研究了公司的动作游戏代码之后，才产生了这套代码，其中目前还没有公司代码的影子，因为改用lua实现之后，很多结构都要发生变化，也因为我将部分模块按照自己的想法重新设计了。
这份代码是试验品或者称之为demo这样的东西，只是为了验证自己的想法，因此只要求能够实现基本功能，以后会做的，只有优化下代码这一步。

<h3 id="1.1">1.1	Unity3d版本</h3>

Unity3d 5.0.1

<h3 id="1.2">1.2	第三方插件</h3>
*	slua : https://github.com/pangweiwei/slua

<h2 id="2">2.	基本约定</h2>
<h3 id="2.1">2.1	两种开发模式</h3>
区别目前仅在资源读取和是否有log这两个方面，开关是LuaManager.DEBUG:

*	DEBUG:	LuaManager.DEBUG = true时开启，使用Resources.Load()加载资源，只能使用Resources目录下的资源；
*	RELEASE:	LuaManager.DEBUG = false时开启，使用www加载资源，只能使用persistentDataPath路径下的资源。

<h3 id="2.2">2.2	三种路径</h3>

*	Resources路径：未做打包，加密等处理的原始资源，仅在DEBUG模式下使用；
*	persistentDataPath路径：经过打包，加密处理后的资源，在RELEASE模式下使用，需要先下载；
*	Update路径：热更新地址，目前暂时使用文件系统内的一个文件夹代替

<h3 id="2.3">2.3 四类资源文件夹</h3>

*	Prefab/AssetBundle：	在debug开发模式是Prefab文件夹，而在release模式下是AssetBundle文件夹
*	Config：		保存配置文件
*	Script：		lua脚本文件夹
*	Update：		提供热更新功能的Lua代码

<h2 id="3">3.	主要功能模块介绍</h2>
<h3 id="3.1">3.1	Slua模块</h3>

unity3d常用的lua插件有slua,ulua和nlua，选择slua的主要原因是官方宣称slua相对于其它插件速度更快（当然并非是lua语言执行的速度，而是lua调用unity3d接口执行的速度），这一点以后会做验证。

先来说下我这段时间使用slua的感受吧，我觉得使用slua导出c#的接口给lua是很方便的，只需要改动下Slua/Editor/CustomExport.cs文件就好了，不但支持自定义接口导出，还支持dll接口导出（这个我倒是没用过）。使用lua最麻烦的地方就在于导出其它语言的接口给lua，slua在这一点上做的非常出色。

<h4 id="3.1.1">3.1.1	lua常用函数</h4>

这里介绍下使用lua时经常用到的一些方法，大部分是网上其它牛人已经实现好了的，转来转去的基本找不到原作者了，不过我会尽量标明引用的出处。

######Class(super)

对于lua中的class实现，有以下几个要求：
*	继承，能够调用父类的方法和字段（这里若想实现private,protected就有些为难了）;
*	new时能够先调用父类的构造函数（当然不仅仅包括两层的继承关系，构造函数也仅是我们虚拟的一个ctor方法）。
*	new时创建一个新的table

出处：http://blog.codingnow.com/cloud/LuaOO/

----更新于2016年1月31日：

Class()这个功能现在使用的是quick-cocos2d-x框架里的版本，更改的原因在于前一个Class()函数无法很好的解决继承问题，

######createUUID()

出处：http://blog.163.com/chatter@126/blog/static/127665661201501313123285/

<h4 id="3.1.2">3.1.2	Lua回调系统设计</h4>

lua脚本无法像C#那样以组件的形式添加到GameObject上，因此Unity3d里的大部分事件无法监听到。lua回调系统便是为了为了解决这个问题而设计的，主要包含以下几个类：

*	LuaEventManager，用来注册各种unity3d事件，将绑定了luafunction的c#脚本以组件形式添加到gameobject身上；
*	LuaBaseEvent，基类，所有绑定luafunction的C#脚本都需要继承这个类
*	LuaAnimationEvent，AnimationClip可以添加一些回调函数，在播放动画时会调用相应的函数。

<h3 id="3.2">3.2	行为树模块</h3>

<h4 id="3.2.1">3.2.1	Behavior3介绍</h4>

Behavior3是偶然在网上找到一个行为树的代码实现，作者只实现了几个基本的composite,decorators和actions,不过提供了一个web应用来设计行为树，我试了下还是很方便的。

详细信息：https://github.com/behavior3/behavior3editor

<h4 id="3.2.2">3.2.2	Behavior3lua</h4>

作者提供了python和js版本的实现接口，所以我实现了大部分lua版本的接口。

详细信息：https://github.com/nottvlike/behavior3lua

<h3 id="3.3">3.3	热更新模块（稍后添加）</h3>

<h3 id="3.4">3.4 资源管理模块</h3>

<h2 id="4">4.	后序计划</h2>

*	补充文档，这始终是一个大头，写文档的同时也能够理清思路
*	完善热更，资源管理功能，添加网络模块
*	研究AI和behavior3的AI设计工具