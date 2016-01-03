#目录
<br/>
<br/>
<br/>

#简介
OpenWorldGame是希望自己在学习unity3d的过程中，慢慢实现一个相对复杂的游戏框架，目前只包含客户端部分。对于这部分，有如下几个要求：

*	游戏主要逻辑使用lua语言实现；
*	支持游戏常用的功能，例如AI，热更新，资源管理;
*	尽量少的使用第三方插件，第三方插件一方面在使用上不自由（无法做自己想做的改动），另一方面需要确定导出lua接口后能否正常工作。

###unity3d版本
Unity3d 5.0.1

###第三方插件：
*	slua : https://github.com/pangweiwei/slua

<br/>
<br/>
#客户端主要功能模块实现及介绍
##Slua模块
unity3d常用的lua插件有slua,ulua和nlua，选择slua的主要原因是官方宣称slua相对于其它插件速度更快（当然并非是lua语言执行的速度，而是lua调用unity3d接口执行的速度），这一点以后会做验证。

先来说下我这段时间使用slua的感受吧，我觉得使用slua导出c#的接口给lua是很方便的，只需要改动下Slua/Editor/CustomExport.cs文件就好了，不但支持自定义接口导出，还支持dll接口导出（这个我倒是没用过）。使用lua最麻烦的地方就在于导出其它语言的接口给lua，slua在这一点上做的非常出色。

####lua常用函数
这里介绍下使用lua时经常用到的一些方法，大部分是网上其它牛人已经实现好了的，转来转去的基本找不到原作者了，不过我会尽量标明引用的出处。

######Class(super)

对于lua中的class实现，有以下几个要求：
*	继承，能够调用父类的方法和字段（这里若想实现private,protected就有些为难了）;
*	new时能够先调用父类的构造函数（当然不仅仅包括两层的继承关系，构造函数也仅是我们虚拟的一个ctor方法）。
*	new时创建一个新的table

出处：http://blog.codingnow.com/cloud/LuaOO/

######createUUID()
出处：http://blog.163.com/chatter@126/blog/static/127665661201501313123285/

####Lua回调系统设计

lua脚本无法想C#那样以组件的形式添加到GameObject上，因此Unity3d里的大部分事件无法监听到。lua回调系统便是为了为了解决这个问题而设计的，主要包含以下几个类：
*	LuaEventManager，用来注册各种unity3d事件，将绑定了luafunction的c#脚本以组件形式添加到gameobject身上；
*	LuaBaseEvent，基类，所有绑定luafunction的C#脚本都需要继承这个类
*	LuaAnimationEvent，AnimationClip可以添加一些回调函数，在播放动画时会调用相应的函数。

<br/>
##行为树模块
####Behavior3介绍
Behavior3是偶然在网上找到一个行为树的代码实现，作者只实现了几个基本的composite,decorators和actions,不过提供了一个web应用来设计行为树，我试了下还是很方便的。
详细信息：https://github.com/behavior3/behavior3editor

####Behavior3lua
作者提供了python和js版本的实现接口，所以我实现了大部分lua版本的接口。
详细信息：https://github.com/nottvlike/behavior3lua

<br/>
##热更新模块（未实现）
