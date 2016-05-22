using System;
using System.Collections.Generic;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static Action<IntPtr>[] GetBindList() {
			Action<IntPtr>[] list= {
				Lua_CameraMove.reg,
				Lua_JoystickManager.reg,
				Lua_LuaBaseEvent.reg,
				Lua_LuaEventManager.reg,
				Lua_LuaFixedUpdateEvent.reg,
				Lua_LuaUpdateEvent.reg,
				Lua_LuaCollisionTriggerEvent.reg,
				Lua_LuaManager.reg,
				Lua_ResourceManager.reg,
				Lua_UpdateManager.reg,
				Lua_FileManager.reg,
				Lua_TcpSocket.reg,
			};
			return list;
		}
	}
}
