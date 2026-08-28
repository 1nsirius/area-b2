// Namespace: 
public class game.RspBattleFinalResult.request : SprotoTypeBase // TypeDefIndex: 9313
{
	// Fields
	private static int max_field_count; // 0x0
	private game.CommonBattleResult _common_result; // 0x14
	private game.RankPlayerResult _rank_result; // 0x18
	private game.BoxResult _box_result; // 0x1C

	// Properties
	public game.CommonBattleResult common_result { get; set; }
	public bool HasCommon_result { get; }
	public game.RankPlayerResult rank_result { get; set; }
	public bool HasRank_result { get; }
	public game.BoxResult box_result { get; set; }
	public bool HasBox_result { get; }

	// Methods

	// RVA: 0x22585B4 Offset: 0x22585B4 VA: 0x22585B4
	public game.CommonBattleResult get_common_result() { }

	// RVA: 0x22585BC Offset: 0x22585BC VA: 0x22585BC
	public void set_common_result(game.CommonBattleResult value) { }

	// RVA: 0x22585FC Offset: 0x22585FC VA: 0x22585FC
	public bool get_HasCommon_result() { }

	// RVA: 0x225862C Offset: 0x225862C VA: 0x225862C
	public game.RankPlayerResult get_rank_result() { }

	// RVA: 0x2258634 Offset: 0x2258634 VA: 0x2258634
	public void set_rank_result(game.RankPlayerResult value) { }

	// RVA: 0x2258674 Offset: 0x2258674 VA: 0x2258674
	public bool get_HasRank_result() { }

	// RVA: 0x22586A4 Offset: 0x22586A4 VA: 0x22586A4
	public game.BoxResult get_box_result() { }

	// RVA: 0x22586AC Offset: 0x22586AC VA: 0x22586AC
	public void set_box_result(game.BoxResult value) { }

	// RVA: 0x22586EC Offset: 0x22586EC VA: 0x22586EC
	public bool get_HasBox_result() { }

	// RVA: 0x225871C Offset: 0x225871C VA: 0x225871C
	public void .ctor() { }

	// RVA: 0x22587B8 Offset: 0x22587B8 VA: 0x22587B8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2258870 Offset: 0x2258870 VA: 0x2258870 Slot: 5
	protected override void decode() { }

	// RVA: 0x22589E0 Offset: 0x22589E0 VA: 0x22589E0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2258B40 Offset: 0x2258B40 VA: 0x2258B40 Slot: 3
	public override string ToString() { }

	// RVA: 0x2258BB8 Offset: 0x2258BB8 VA: 0x2258BB8
	private static void .cctor() { }
}
