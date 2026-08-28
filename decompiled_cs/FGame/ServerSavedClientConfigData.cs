namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x55402C Offset: 0x55402C VA: 0x55402C
public class ServerSavedClientConfigData : BaseSingleton<ServerSavedClientConfigData> // TypeDefIndex: 9949
{
	// Fields
	private readonly Dictionary<string, long> mClientConfigDic; // 0x8
	private bool mResetClientConfigDone; // 0xC

	// Methods

	// RVA: 0xB8EFC0 Offset: 0xB8EFC0 VA: 0xB8EFC0
	private void Clear() { }

	// RVA: 0xB8F040 Offset: 0xB8F040 VA: 0xB8F040
	public void ResetClientConfig(client.load_role.response pkt) { }

	// RVA: 0xB8F25C Offset: 0xB8F25C VA: 0xB8F25C
	public static void UpdateClientConfig(string key, long value) { }

	// RVA: 0xB8F544 Offset: 0xB8F544 VA: 0xB8F544
	public static long GetValueByKey(string key) { }

	// RVA: 0xB8F648 Offset: 0xB8F648 VA: 0xB8F648
	public static bool GetResetClientConfigDone() { }

	// RVA: 0xB8F6E8 Offset: 0xB8F6E8 VA: 0xB8F6E8
	public static void ClearSelf() { }

	// RVA: 0xB8F78C Offset: 0xB8F78C VA: 0xB8F78C
	public void .ctor() { }
}

} // namespace FGame
