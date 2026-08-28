// Namespace: 
public class game.RspRoomStart.request : SprotoTypeBase // TypeDefIndex: 9379
{
	// Fields
	private static int max_field_count; // 0x0
	private long _round; // 0x18
	private long _combat_type; // 0x20
	private long _map_id; // 0x28
	private long _mode_id; // 0x30
	private long _wait_time; // 0x38
	private game.BattleTeamInfo _my_team; // 0x40
	private game.BattleTeamInfo _other_team; // 0x44
	private List<game.SelectCharacterInfo> _my_characters; // 0x48

	// Properties
	public long round { get; set; }
	public bool HasRound { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }
	public long map_id { get; set; }
	public bool HasMap_id { get; }
	public long mode_id { get; set; }
	public bool HasMode_id { get; }
	public long wait_time { get; set; }
	public bool HasWait_time { get; }
	public game.BattleTeamInfo my_team { get; set; }
	public bool HasMy_team { get; }
	public game.BattleTeamInfo other_team { get; set; }
	public bool HasOther_team { get; }
	public List<game.SelectCharacterInfo> my_characters { get; set; }
	public bool HasMy_characters { get; }

	// Methods

	// RVA: 0x2265400 Offset: 0x2265400 VA: 0x2265400
	public long get_round() { }

	// RVA: 0x2265408 Offset: 0x2265408 VA: 0x2265408
	public void set_round(long value) { }

	// RVA: 0x226544C Offset: 0x226544C VA: 0x226544C
	public bool get_HasRound() { }

	// RVA: 0x226547C Offset: 0x226547C VA: 0x226547C
	public long get_combat_type() { }

	// RVA: 0x2265484 Offset: 0x2265484 VA: 0x2265484
	public void set_combat_type(long value) { }

	// RVA: 0x22654C8 Offset: 0x22654C8 VA: 0x22654C8
	public bool get_HasCombat_type() { }

	// RVA: 0x22654F8 Offset: 0x22654F8 VA: 0x22654F8
	public long get_map_id() { }

	// RVA: 0x2265500 Offset: 0x2265500 VA: 0x2265500
	public void set_map_id(long value) { }

	// RVA: 0x2265544 Offset: 0x2265544 VA: 0x2265544
	public bool get_HasMap_id() { }

	// RVA: 0x2265574 Offset: 0x2265574 VA: 0x2265574
	public long get_mode_id() { }

	// RVA: 0x226557C Offset: 0x226557C VA: 0x226557C
	public void set_mode_id(long value) { }

	// RVA: 0x22655C0 Offset: 0x22655C0 VA: 0x22655C0
	public bool get_HasMode_id() { }

	// RVA: 0x22655F0 Offset: 0x22655F0 VA: 0x22655F0
	public long get_wait_time() { }

	// RVA: 0x22655F8 Offset: 0x22655F8 VA: 0x22655F8
	public void set_wait_time(long value) { }

	// RVA: 0x226563C Offset: 0x226563C VA: 0x226563C
	public bool get_HasWait_time() { }

	// RVA: 0x226566C Offset: 0x226566C VA: 0x226566C
	public game.BattleTeamInfo get_my_team() { }

	// RVA: 0x2265674 Offset: 0x2265674 VA: 0x2265674
	public void set_my_team(game.BattleTeamInfo value) { }

	// RVA: 0x22656B4 Offset: 0x22656B4 VA: 0x22656B4
	public bool get_HasMy_team() { }

	// RVA: 0x22656E4 Offset: 0x22656E4 VA: 0x22656E4
	public game.BattleTeamInfo get_other_team() { }

	// RVA: 0x22656EC Offset: 0x22656EC VA: 0x22656EC
	public void set_other_team(game.BattleTeamInfo value) { }

	// RVA: 0x226572C Offset: 0x226572C VA: 0x226572C
	public bool get_HasOther_team() { }

	// RVA: 0x226575C Offset: 0x226575C VA: 0x226575C
	public List<game.SelectCharacterInfo> get_my_characters() { }

	// RVA: 0x2265764 Offset: 0x2265764 VA: 0x2265764
	public void set_my_characters(List<game.SelectCharacterInfo> value) { }

	// RVA: 0x22657A4 Offset: 0x22657A4 VA: 0x22657A4
	public bool get_HasMy_characters() { }

	// RVA: 0x22657D4 Offset: 0x22657D4 VA: 0x22657D4
	public void .ctor() { }

	// RVA: 0x2265870 Offset: 0x2265870 VA: 0x2265870
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2265928 Offset: 0x2265928 VA: 0x2265928 Slot: 5
	protected override void decode() { }

	// RVA: 0x2265BB8 Offset: 0x2265BB8 VA: 0x2265BB8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2265F58 Offset: 0x2265F58 VA: 0x2265F58 Slot: 3
	public override string ToString() { }

	// RVA: 0x226635C Offset: 0x226635C VA: 0x226635C
	private static void .cctor() { }
}
