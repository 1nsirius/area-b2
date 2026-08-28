namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x554068 Offset: 0x554068 VA: 0x554068
public class TeamInviteData : BaseSingleton<TeamInviteData> // TypeDefIndex: 9954
{
	// Fields
	private readonly List<uint> mList; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563814 Offset: 0x563814 VA: 0x563814
	private readonly Dictionary<uint, TeamInviteData.Record> <Records>k__BackingField; // 0xC

	// Properties
	public int Count { get; }
	public Dictionary<uint, TeamInviteData.Record> Records { get; }

	// Methods

	// RVA: 0xD93BF4 Offset: 0xD93BF4 VA: 0xD93BF4
	public int get_Count() { }

	[CompilerGeneratedAttribute] // RVA: 0x647400 Offset: 0x647400 VA: 0x647400
	// RVA: 0xD93C6C Offset: 0xD93C6C VA: 0xD93C6C
	public Dictionary<uint, TeamInviteData.Record> get_Records() { }

	// RVA: 0xD93C74 Offset: 0xD93C74 VA: 0xD93C74
	public void Initialize() { }

	// RVA: 0xD93D78 Offset: 0xD93D78 VA: 0xD93D78
	public void Shutdown() { }

	// RVA: 0xD93E7C Offset: 0xD93E7C VA: 0xD93E7C
	public void Clear() { }

	// RVA: 0xD93FD0 Offset: 0xD93FD0 VA: 0xD93FD0
	public TeamInviteData.Record GetByIndex(int index) { }

	// RVA: 0xD94084 Offset: 0xD94084 VA: 0xD94084
	public TeamInviteData.Record GetByUid(uint uid) { }

	// RVA: 0xD94124 Offset: 0xD94124 VA: 0xD94124
	public void OnInvited(uint inviterUid, string roomId, int combatType) { }

	// RVA: 0xD944D0 Offset: 0xD944D0 VA: 0xD944D0
	public void Remove(uint uid) { }

	// RVA: 0xD9467C Offset: 0xD9467C VA: 0xD9467C
	private void OnLobbyDisConnect() { }

	// RVA: 0xD94680 Offset: 0xD94680 VA: 0xD94680
	public void .ctor() { }
}

} // namespace FGame
