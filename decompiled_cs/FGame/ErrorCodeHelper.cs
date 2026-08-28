namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x55407C Offset: 0x55407C VA: 0x55407C
public static class ErrorCodeHelper // TypeDefIndex: 9960
{
	// Fields
	private static Dictionary<int, error_code_table.Record> sErrorCodeMap; // 0x0

	// Properties
	private static Dictionary<int, error_code_table.Record> ErrorCodeMap { get; }

	// Methods

	// RVA: 0xF40B04 Offset: 0xF40B04 VA: 0xF40B04
	private static Dictionary<int, error_code_table.Record> get_ErrorCodeMap() { }

	// RVA: 0xF40CA0 Offset: 0xF40CA0 VA: 0xF40CA0
	public static void HandErrorCode(long errorCode) { }

	[ConditionalAttribute] // RVA: 0x647410 Offset: 0x647410 VA: 0x647410
	// RVA: 0xF410B8 Offset: 0xF410B8 VA: 0xF410B8
	public static void PrintMsg(SprotoTypeBase msg) { }
}

} // namespace FGame
