// Namespace: 
public class game.CommonBattleResult : SprotoTypeBase // TypeDefIndex: 9207
{
	// Fields
	private static int max_field_count; // 0x0
	private long _my_win_times; // 0x18
	private long _enemy_win_times; // 0x20
	private List<long> _winners_rank; // 0x28
	private List<game.BattlePlayerResult> _players_result; // 0x2C
	private game.PlayerLevelUpResult _players_levelup; // 0x30
	private long _combat_type; // 0x38
	private long _guide_id; // 0x40
	private long _add_exp; // 0x48
	private long _add_gold; // 0x50

	// Properties
	public long my_win_times { get; set; }
	public bool HasMy_win_times { get; }
	public long enemy_win_times { get; set; }
	public bool HasEnemy_win_times { get; }
	public List<long> winners_rank { get; set; }
	public bool HasWinners_rank { get; }
	public List<game.BattlePlayerResult> players_result { get; set; }
	public bool HasPlayers_result { get; }
	public game.PlayerLevelUpResult players_levelup { get; set; }
	public bool HasPlayers_levelup { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }
	public long guide_id { get; set; }
	public bool HasGuide_id { get; }
	public long add_exp { get; set; }
	public bool HasAdd_exp { get; }
	public long add_gold { get; set; }
	public bool HasAdd_gold { get; }

	// Methods

	// RVA: 0x255061C Offset: 0x255061C VA: 0x255061C
	public long get_my_win_times() { }

	// RVA: 0x2550624 Offset: 0x2550624 VA: 0x2550624
	public void set_my_win_times(long value) { }

	// RVA: 0x2550668 Offset: 0x2550668 VA: 0x2550668
	public bool get_HasMy_win_times() { }

	// RVA: 0x2550698 Offset: 0x2550698 VA: 0x2550698
	public long get_enemy_win_times() { }

	// RVA: 0x25506A0 Offset: 0x25506A0 VA: 0x25506A0
	public void set_enemy_win_times(long value) { }

	// RVA: 0x25506E4 Offset: 0x25506E4 VA: 0x25506E4
	public bool get_HasEnemy_win_times() { }

	// RVA: 0x2550714 Offset: 0x2550714 VA: 0x2550714
	public List<long> get_winners_rank() { }

	// RVA: 0x255071C Offset: 0x255071C VA: 0x255071C
	public void set_winners_rank(List<long> value) { }

	// RVA: 0x255075C Offset: 0x255075C VA: 0x255075C
	public bool get_HasWinners_rank() { }

	// RVA: 0x255078C Offset: 0x255078C VA: 0x255078C
	public List<game.BattlePlayerResult> get_players_result() { }

	// RVA: 0x2550794 Offset: 0x2550794 VA: 0x2550794
	public void set_players_result(List<game.BattlePlayerResult> value) { }

	// RVA: 0x25507D4 Offset: 0x25507D4 VA: 0x25507D4
	public bool get_HasPlayers_result() { }

	// RVA: 0x2550804 Offset: 0x2550804 VA: 0x2550804
	public game.PlayerLevelUpResult get_players_levelup() { }

	// RVA: 0x255080C Offset: 0x255080C VA: 0x255080C
	public void set_players_levelup(game.PlayerLevelUpResult value) { }

	// RVA: 0x255084C Offset: 0x255084C VA: 0x255084C
	public bool get_HasPlayers_levelup() { }

	// RVA: 0x255087C Offset: 0x255087C VA: 0x255087C
	public long get_combat_type() { }

	// RVA: 0x2550884 Offset: 0x2550884 VA: 0x2550884
	public void set_combat_type(long value) { }

	// RVA: 0x25508C8 Offset: 0x25508C8 VA: 0x25508C8
	public bool get_HasCombat_type() { }

	// RVA: 0x25508F8 Offset: 0x25508F8 VA: 0x25508F8
	public long get_guide_id() { }

	// RVA: 0x2550900 Offset: 0x2550900 VA: 0x2550900
	public void set_guide_id(long value) { }

	// RVA: 0x2550944 Offset: 0x2550944 VA: 0x2550944
	public bool get_HasGuide_id() { }

	// RVA: 0x2550974 Offset: 0x2550974 VA: 0x2550974
	public long get_add_exp() { }

	// RVA: 0x255097C Offset: 0x255097C VA: 0x255097C
	public void set_add_exp(long value) { }

	// RVA: 0x25509C0 Offset: 0x25509C0 VA: 0x25509C0
	public bool get_HasAdd_exp() { }

	// RVA: 0x25509F0 Offset: 0x25509F0 VA: 0x25509F0
	public long get_add_gold() { }

	// RVA: 0x25509F8 Offset: 0x25509F8 VA: 0x25509F8
	public void set_add_gold(long value) { }

	// RVA: 0x2550A3C Offset: 0x2550A3C VA: 0x2550A3C
	public bool get_HasAdd_gold() { }

	// RVA: 0x2550A6C Offset: 0x2550A6C VA: 0x2550A6C
	public void .ctor() { }

	// RVA: 0x2550B08 Offset: 0x2550B08 VA: 0x2550B08
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2550BC0 Offset: 0x2550BC0 VA: 0x2550BC0 Slot: 5
	protected override void decode() { }

	// RVA: 0x2550E7C Offset: 0x2550E7C VA: 0x2550E7C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2551280 Offset: 0x2551280 VA: 0x2551280 Slot: 3
	public override string ToString() { }

	// RVA: 0x2551714 Offset: 0x2551714 VA: 0x2551714
	private static void .cctor() { }
}
