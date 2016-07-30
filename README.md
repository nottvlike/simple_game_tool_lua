#目录
*	[1.前言](#1)
	*	[1.1.Unity3d开发版本](#1.1)
	*	[1.2.第三方插件](#1.2)
*	[2.基本约定](#2)
	*	[2.1.两种开发模式](#2.1)
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
		*	[3.4.1 PoolManager介绍](#3.4.1)
		*	[3.4.2 Assetbundle细化](#3.4.2)
	*	[3.5.Buff系统](#3.5)
	*	[3.6.Mod系统](#3.6)
*	[4.Android支持](#4)
*	[5.后序计划](#4)
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
即Debug和Release模式，通过宏RESOURCE_DEBUG和LOG_DEBUG控制。

RESOURCE_DEBUG设定是否使用Resources.Load()方法载入资源，在AssetBundleEditor.cs和LuaManager.cs文件中都有设置，在AssetBundleEditor.cs设置是因为将prefab打包成为assetbundle时需要使用Resources.Load()载入prefab，我这边第一次打开工程可以正常生成.assetbundle文件，运行几次程序之后，就会有报错，这个稍后修复。

LOG_DEBUG意思是是否开启日志，这个我一般都留着。

因为我没有上传资源文件(例如Resources，Animations，Animators，Models等文件夹)，只上传了.assetbundle文件，所以github上的工程默认就是Release模式。

*	DEBUG:	#define RESOURCE_DEBUG 时开启，使用Resources.Load()加载资源，只能使用Resources目录下的资源；
*	RELEASE:注释LuaManager.cs中的 #define RESOURCE_DEBUG 时开启，使用www加载资源，只能使用LuaManager.GetAssetBundlePath()路径下的资源。

补充下，unity3d不能通过#define来设置全局宏定义（#define 宏只能用在定义宏的那个类里，其它文件的类就是undef的状态），设置全局宏定义的方法倒是还有两种，一个是smcs.rsp或者gmcs.rsp，另一个就是各个平台在playersetting里面设置symbols了，第一种方法我试过不行（应该是我哪里操作错了），第二种我只是在editor里调试用的，playersetting那个对我没用。我这边网速慢就不贴官方的地址了，在本地的unity3d文档里面搜下Platform Dependent Compilation就能够看到官方的介绍了，百度下应该也是可以的。


<h3 id="2.2">2.2	三种路径</h3>

*	Resources路径：未做打包，加密等处理的原始资源，仅在DEBUG模式下使用；
*	GetAssetBundlePath/GetScriptPath/GetConfigPath路径：经过打包，加密处理后的资源，在RELEASE模式下使用，需要先下载；
*	Update路径：热更新地址，目前暂时使用文件系统内的一个文件夹代替

我为了调试方便，将UpdateManager.UpdateTest和GetAssetBundlePath()都设置为Application.streamingAssetsPath，这样在热更时会从Application.streamingAssetsPath获取文件，下载到Application.streamingAssetsPath目录里面，然后再执行。我在mac上面测试没问题，windows具体没有测试过 。

若是不想走热更新流程，将Update/Update.txt中的disableUpdate设置为true就行了，我这边改代码一般会改动Resources目录中的资源，然后自动打包将assetbundle,config,script,update拷贝到Application.streamingAssetsPath再执行，不过你们还是直接修改Application.streamingAssetsPath中的资源吧。

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

<h3 id="3.3">3.3	热更新模块</h3>
使用UpdateManager.cs已经基本实现了本地的热更，http的热更等到有时间我再做进一步的测试。

<h3 id="3.4">3.4 资源管理模块</h3>
资源管理模块现在已经加上了，主要是ResourceManager和PrefabRequest这两个类，资源加载（主要是assetbundle）这个我目前只写了SingleLineLoadAsync(叫线性异步加载也行)，当然我也可以一次加载多个Assetbundle，或者加载一个Assetbundle里的多个prefab,这个后面看需求再添加。

<h4 id="3.4.1">3.4.1	PoolManager介绍</h4>

一种类型的缓存，需要消耗两个list，这还是比较夸张的，所以还是别滥用。

<h4 id="3.4.2">3.4.2	Assetbundle细化</h4>

具体可以看下ResourceManager.cs里面的注释，只是将一个assetbundle细化，粒度更小，当然目前只写了针对5.x以下的依赖打包方式，而且还没有测试过，以后我会先完善5.x以下的打包，再实现5.x以上版本的打包。

<h3 id="3.5">3.5 Buff系统</h3>
战斗相关的buff系统已经加上了，主要包含了这几个方面：

*	Attribute:	基本属性，例如HP,MP,ATK,DEF等，可以看看Attribute.txt里面的定义；
*	Effect:		暂且称为特效，特效主要涉及到属性更改，一个特效一般更改一个到多个属性，看看EffectDeal.txt的实现；
*	Buff:		一个buff一般包含一个到多个effect,看看Script.Base.Buff目录里的文件和buff.txt文件；
*	Skill:		一个技能一般包含一个到多个buff，可以看看SkillDataBase.txt里面的配置文件。

buff都统一放在被施加者身上，例如A对B施法，那么buff放在B身上。

拿一个普通攻击的过程来讲解下战斗吧，当玩家点击攻击按键时，首先播放攻击动画，我在攻击动画里面加了两个帧事件（addBuff和removeBuff），在播放开始时addBuff,在播放结束后removeBuff，模型的拳头上也都加有trigger,若是玩家碰到了其它人，便会接收到这个人的信息，我会查看这个人的信息判断它是否是敌人，如果是则hurt，处理脚本主要是HurtCollision.txt和BuffHandler.txt这两个脚本。

关于监听器，为了方便，我将所有监听器的消息先中转到了root节点，然后才传递到lua脚本里，这样或许有隐含的问题，主要是担心buff计算错了碰撞目前，这个我先想想是否会出问题，以及出了问题怎么处理。

<h3 id="3.6">3.6 Mod系统</h3>
取名为Mod系统其实名不副实，因为一个是2d游戏，一个是3d游戏，而且游戏类型完全不同。只是我懒得在为一个新游戏建立一个同样的架构，因此写了Mod系统将这个2d游戏强行放进来。我确实打算写一个mod系统，具体怎么写我暂时并没有好的想法(肯定是一堆的callback事件),这个2d游戏目前也只能使用Resources.Load加载(所以记得添加RESOURCE_DEBUG宏)，打包出assetbundle这一块我还需要补充和debug。

新添加了一个文件夹Mod,这件事Commit里倒是忘记提了，里面是准备存放各种插件的。

新添加了一个文件夹Common,主要是一些所有mod公共使用的资源，每个mod下面的目录架构其实都是一样的，都有Prefabs,Config,Script这几个目录构成，而且Script目录下的脚本架构也是一样。

<h2 id="4">4. Android支持</h2>
最近两周一直忙着android方面的工作，主要是slua，遇到的问题有两个：

*	StreamAssets中的资源unity3d只支持www异步加载，对于assetbundle还好，对于脚本来说就悲剧了；
*	GameObject.Instantiate第二次执行时奔溃，这是我暂时没解决的问题，slua加入debug标签后，想看看奔溃信息却没有奔溃了；

第一个问题比较简单，android使用java或者jni都可以访问assets目录，我这里用了jni，写了个getAssets()方法传递给了c#，具体可以看下slua里的jni/FileManagerAndroid.cpp和LuaDLL.cs文件
第二个问题，我查了几天，始终没有收获，开始我以为是自己的ResourceManager写的有问题，将ResourceManager改为同步访问后，依旧没有效果。


<h2 id="5">5.	后续计划</h2>

*	补充文档，这始终是一个大头，写文档的同时也能够理清思路
*	完善热更模块
*	完善战斗系统，添加网络模块
*	研究AI和behavior3的AI设计工具
*	多平台目录优化，例如LuaManager.cs中的ScriptDir，ConfigDir和AssetBundleDir可以合并为一个，加入了android后，目录显示的有点乱，该统一优化下了。
