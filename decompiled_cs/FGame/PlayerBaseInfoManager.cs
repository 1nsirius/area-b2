namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553FA0 Offset: 0x553FA0 VA: 0x553FA0
public class PlayerBaseInfoManager : BaseSingleton<PlayerBaseInfoManager> // TypeDefIndex: 9929
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x563694 Offset: 0x563694 VA: 0x563694
	private readonly Dictionary<uint, PlayerBaseInfo> <PlayerInfos>k__BackingField; // 0x8

	// Properties
	public Dictionary<uint, PlayerBaseInfo> PlayerInfos { get; }
	public int Count { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x647110 Offset: 0x647110 VA: 0x647110
	// RVA: 0xB6C8F8 Offset: 0xB6C8F8 VA: 0xB6C8F8
	public Dictionary<uint, PlayerBaseInfo> get_PlayerInfos() { }

	// RVA: 0xB6C900 Offset: 0xB6C900 VA: 0xB6C900
	public int get_Count() { }

	// RVA: 0xB6C978 Offset: 0xB6C978 VA: 0xB6C978
	public static void AddOrUpdate(uint uid, string name, uint level, uint iconId, string iconUrl, string fbname, uint rank) { }

	// RVA: 0xB6D380 Offset: 0xB6D380 VA: 0xB6D380
	public static void UpdateIcon(uint uid, uint iconId, string iconUrl) { }

	// RVA: 0xB6D780 Offset: 0xB6D780 VA: 0xB6D780
	public static void UpdateLevel(uint uid, uint level) { }

	// RVA: 0xB6D244 Offset: 0xB6D244 VA: 0xB6D244
	private void Add(PlayerBaseInfo info) { }

	// RVA: 0xB6D1A4 Offset: 0xB6D1A4 VA: 0xB6D1A4
	public PlayerBaseInfo Get(uint uid) { }

	// RVA: 0xB6D8B8 Offset: 0xB6D8B8 VA: 0xB6D8B8
	public void Initialize() { }

	// RVA: 0xB6D8BC Offset: 0xB6D8BC VA: 0xB6D8BC
	public void Remove(uint uid) { }

	// RVA: 0xB6D93C Offset: 0xB6D93C VA: 0xB6D93C
	public void Shutdown() { }

	// RVA: 0xB6D9B4 Offset: 0xB6D9B4 VA: 0xB6D9B4
	public void .ctor() { }
}

} // namespace FGame
