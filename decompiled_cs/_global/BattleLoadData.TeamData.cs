// Namespace: 
[LuaCallCSharpAttribute] // RVA: 0x55B56C Offset: 0x55B56C VA: 0x55B56C
public class BattleLoadData.TeamData // TypeDefIndex: 10017
{
	// Fields
	public readonly List<BattleLoadData.CharacterData> Members; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56E374 Offset: 0x56E374 VA: 0x56E374
	private readonly BattleTeam <Team>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56E384 Offset: 0x56E384 VA: 0x56E384
	private BattleCamp <Camp>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56E394 Offset: 0x56E394 VA: 0x56E394
	private int <Score>k__BackingField; // 0x14

	// Properties
	public BattleTeam Team { get; }
	public BattleCamp Camp { get; set; }
	public int Score { get; set; }
	public int Count { get; }

	// Methods

	// RVA: 0xF3F094 Offset: 0xF3F094 VA: 0xF3F094
	public void .ctor(BattleTeam team) { }

	[CompilerGeneratedAttribute] // RVA: 0x65CF90 Offset: 0x65CF90 VA: 0x65CF90
	// RVA: 0xF3F274 Offset: 0xF3F274 VA: 0xF3F274
	public BattleTeam get_Team() { }

	[CompilerGeneratedAttribute] // RVA: 0x65CFA0 Offset: 0x65CFA0 VA: 0x65CFA0
	// RVA: 0xF3EB68 Offset: 0xF3EB68 VA: 0xF3EB68
	public BattleCamp get_Camp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65CFB0 Offset: 0x65CFB0 VA: 0x65CFB0
	// RVA: 0xF3EB60 Offset: 0xF3EB60 VA: 0xF3EB60
	public void set_Camp(BattleCamp value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65CFC0 Offset: 0x65CFC0 VA: 0x65CFC0
	// RVA: 0xF3F27C Offset: 0xF3F27C VA: 0xF3F27C
	public int get_Score() { }

	[CompilerGeneratedAttribute] // RVA: 0x65CFD0 Offset: 0x65CFD0 VA: 0x65CFD0
	// RVA: 0xF3F284 Offset: 0xF3F284 VA: 0xF3F284
	public void set_Score(int value) { }

	// RVA: 0xF3EAE0 Offset: 0xF3EAE0 VA: 0xF3EAE0
	public int get_Count() { }

	// RVA: 0xF3EF50 Offset: 0xF3EF50 VA: 0xF3EF50
	public void Clear() { }
}
