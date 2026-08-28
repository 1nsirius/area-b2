// Namespace: 
public class game.RspBattleInfo.request : SprotoTypeBase // TypeDefIndex: 9315
{
	// Fields
	private static int max_field_count; // 0x0
	private long _map_id; // 0x18
	private long _mode_id; // 0x20
	private long _battle_id; // 0x28
	private string _ip_port; // 0x30
	private string _token; // 0x34
	private long _guide_id; // 0x38
	private game.BattleTeamInfo _my_team; // 0x40
	private game.BattleTeamInfo _other_team; // 0x44

	// Properties
	public long map_id { get; set; }
	public bool HasMap_id { get; }
	public long mode_id { get; set; }
	public bool HasMode_id { get; }
	public long battle_id { get; set; }
	public bool HasBattle_id { get; }
	public string ip_port { get; set; }
	public bool HasIp_port { get; }
	public string token { get; set; }
	public bool HasToken { get; }
	public long guide_id { get; set; }
	public bool HasGuide_id { get; }
	public game.BattleTeamInfo my_team { get; set; }
	public bool HasMy_team { get; }
	public game.BattleTeamInfo other_team { get; set; }
	public bool HasOther_team { get; }

	// Methods

	// RVA: 0x2258C28 Offset: 0x2258C28 VA: 0x2258C28
	public long get_map_id() { }

	// RVA: 0x2258C30 Offset: 0x2258C30 VA: 0x2258C30
	public void set_map_id(long value) { }

	// RVA: 0x2258C74 Offset: 0x2258C74 VA: 0x2258C74
	public bool get_HasMap_id() { }

	// RVA: 0x2258CA4 Offset: 0x2258CA4 VA: 0x2258CA4
	public long get_mode_id() { }

	// RVA: 0x2258CAC Offset: 0x2258CAC VA: 0x2258CAC
	public void set_mode_id(long value) { }

	// RVA: 0x2258CF0 Offset: 0x2258CF0 VA: 0x2258CF0
	public bool get_HasMode_id() { }

	// RVA: 0x2258D20 Offset: 0x2258D20 VA: 0x2258D20
	public long get_battle_id() { }

	// RVA: 0x2258D28 Offset: 0x2258D28 VA: 0x2258D28
	public void set_battle_id(long value) { }

	// RVA: 0x2258D6C Offset: 0x2258D6C VA: 0x2258D6C
	public bool get_HasBattle_id() { }

	// RVA: 0x2258D9C Offset: 0x2258D9C VA: 0x2258D9C
	public string get_ip_port() { }

	// RVA: 0x2258DA4 Offset: 0x2258DA4 VA: 0x2258DA4
	public void set_ip_port(string value) { }

	// RVA: 0x2258DE4 Offset: 0x2258DE4 VA: 0x2258DE4
	public bool get_HasIp_port() { }

	// RVA: 0x2258E14 Offset: 0x2258E14 VA: 0x2258E14
	public string get_token() { }

	// RVA: 0x2258E1C Offset: 0x2258E1C VA: 0x2258E1C
	public void set_token(string value) { }

	// RVA: 0x2258E5C Offset: 0x2258E5C VA: 0x2258E5C
	public bool get_HasToken() { }

	// RVA: 0x2258E8C Offset: 0x2258E8C VA: 0x2258E8C
	public long get_guide_id() { }

	// RVA: 0x2258E94 Offset: 0x2258E94 VA: 0x2258E94
	public void set_guide_id(long value) { }

	// RVA: 0x2258ED8 Offset: 0x2258ED8 VA: 0x2258ED8
	public bool get_HasGuide_id() { }

	// RVA: 0x2258F08 Offset: 0x2258F08 VA: 0x2258F08
	public game.BattleTeamInfo get_my_team() { }

	// RVA: 0x2258F10 Offset: 0x2258F10 VA: 0x2258F10
	public void set_my_team(game.BattleTeamInfo value) { }

	// RVA: 0x2258F50 Offset: 0x2258F50 VA: 0x2258F50
	public bool get_HasMy_team() { }

	// RVA: 0x2258F80 Offset: 0x2258F80 VA: 0x2258F80
	public game.BattleTeamInfo get_other_team() { }

	// RVA: 0x2258F88 Offset: 0x2258F88 VA: 0x2258F88
	public void set_other_team(game.BattleTeamInfo value) { }

	// RVA: 0x2258FC8 Offset: 0x2258FC8 VA: 0x2258FC8
	public bool get_HasOther_team() { }

	// RVA: 0x2258FF8 Offset: 0x2258FF8 VA: 0x2258FF8
	public void .ctor() { }

	// RVA: 0x2259094 Offset: 0x2259094 VA: 0x2259094
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225914C Offset: 0x225914C VA: 0x225914C Slot: 5
	protected override void decode() { }

	// RVA: 0x22593CC Offset: 0x22593CC VA: 0x22593CC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2259718 Offset: 0x2259718 VA: 0x2259718 Slot: 3
	public override string ToString() { }

	// RVA: 0x2259AE0 Offset: 0x2259AE0 VA: 0x2259AE0
	private static void .cctor() { }
}
