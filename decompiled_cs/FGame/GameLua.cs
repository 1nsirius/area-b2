namespace FGame
{

// Namespace: FGame
public static class GameLua // TypeDefIndex: 9961
{
	// Methods

	// RVA: 0xF4117C Offset: 0xF4117C VA: 0xF4117C
	public static object[] DoString(byte[] chunk, string chunkName = "chunk", ILuaTableWrap luaTableWrap) { }

	// RVA: 0xF41248 Offset: 0xF41248 VA: 0xF41248
	public static object[] DoString(string chunk, string chunkName = "chunk", ILuaTableWrap luaTableWrap) { }

	// RVA: 0xF41314 Offset: 0xF41314 VA: 0xF41314
	public static XLuaTableWrap NewTable() { }

	// RVA: 0xF413BC Offset: 0xF413BC VA: 0xF413BC
	public static XLuaTableWrap GetLuaTable(string tableName) { }

	// RVA: 0xF4146C Offset: 0xF4146C VA: 0xF4146C
	public static XLuaFunctionWrap GetGlobalLuaFunction(string key) { }
}

} // namespace FGame
