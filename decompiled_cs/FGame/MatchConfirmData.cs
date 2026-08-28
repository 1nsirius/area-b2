namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553F1C Offset: 0x553F1C VA: 0x553F1C
public class MatchConfirmData : BaseSingleton<MatchConfirmData> // TypeDefIndex: 9920
{
	// Fields
	private readonly List<MatchConfirmData.PlayerData> mOtherTeam; // 0x8
	private readonly List<MatchConfirmData.PlayerData> mSelfTeam; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x563584 Offset: 0x563584 VA: 0x563584
	private int <ConfirmedCont>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x563594 Offset: 0x563594 VA: 0x563594
	private long <EndTime>k__BackingField; // 0x18

	// Properties
	public int Count { get; }
	public int OtherTeamSize { get; }
	public int SelfTeamSize { get; }
	public int ConfirmedCont { get; set; }
	public long EndTime { get; set; }

	// Methods

	// RVA: 0xF59BFC Offset: 0xF59BFC VA: 0xF59BFC
	public int get_Count() { }

	// RVA: 0xF59C98 Offset: 0xF59C98 VA: 0xF59C98
	public int get_OtherTeamSize() { }

	// RVA: 0xF59C20 Offset: 0xF59C20 VA: 0xF59C20
	public int get_SelfTeamSize() { }

	[CompilerGeneratedAttribute] // RVA: 0x646EF0 Offset: 0x646EF0 VA: 0x646EF0
	// RVA: 0xF59D10 Offset: 0xF59D10 VA: 0xF59D10
	public int get_ConfirmedCont() { }

	[CompilerGeneratedAttribute] // RVA: 0x646F00 Offset: 0x646F00 VA: 0x646F00
	// RVA: 0xF59D18 Offset: 0xF59D18 VA: 0xF59D18
	private void set_ConfirmedCont(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646F10 Offset: 0x646F10 VA: 0x646F10
	// RVA: 0xF59D20 Offset: 0xF59D20 VA: 0xF59D20
	public long get_EndTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x646F20 Offset: 0x646F20 VA: 0x646F20
	// RVA: 0xF59D28 Offset: 0xF59D28 VA: 0xF59D28
	private void set_EndTime(long value) { }

	// RVA: 0xF59D38 Offset: 0xF59D38 VA: 0xF59D38
	public void AddTeamMember(uint uid, uint iconId, string iconUrl, bool isConfirm, bool selfTeam) { }

	// RVA: 0xF4AA5C Offset: 0xF4AA5C VA: 0xF4AA5C
	public void Clear() { }

	// RVA: 0xF59E78 Offset: 0xF59E78 VA: 0xF59E78
	public void Confirm(uint uid) { }

	// RVA: 0xF5A278 Offset: 0xF5A278 VA: 0xF5A278
	public MatchConfirmData.PlayerData GetDataByIndex(int index, bool selfTeam) { }

	// RVA: 0xF5A34C Offset: 0xF5A34C VA: 0xF5A34C
	public void Reset(long endTime) { }

	// RVA: 0xF5A404 Offset: 0xF5A404 VA: 0xF5A404
	public void ResetFromPkt(team.match_success_notify.request pkt) { }

	// RVA: 0xF59D7C Offset: 0xF59D7C VA: 0xF59D7C
	private static void Add2Team(uint uid, uint iconId, string iconUrl, bool isConfirm, List<MatchConfirmData.PlayerData> team) { }

	// RVA: 0xF5A28C Offset: 0xF5A28C VA: 0xF5A28C
	private static MatchConfirmData.PlayerData GetFromList(List<MatchConfirmData.PlayerData> list, int index) { }

	// RVA: 0xF5A118 Offset: 0xF5A118 VA: 0xF5A118
	private static bool TryGetPlayerDataFromTeam(uint uid, List<MatchConfirmData.PlayerData> team, out MatchConfirmData.PlayerData item, out int index) { }

	// RVA: 0xF5ABC4 Offset: 0xF5ABC4 VA: 0xF5ABC4
	public void .ctor() { }
}

} // namespace FGame
