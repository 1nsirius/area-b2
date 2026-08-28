// Namespace: 
public class game.RspBattleResult.request : SprotoTypeBase // TypeDefIndex: 9319
{
	// Fields
	private static int max_field_count; // 0x0
	private game.RankPlayerResult _rank_result; // 0x14
	private game.BoxResult _box_result; // 0x18

	// Properties
	public game.RankPlayerResult rank_result { get; set; }
	public bool HasRank_result { get; }
	public game.BoxResult box_result { get; set; }
	public bool HasBox_result { get; }

	// Methods

	// RVA: 0x225A288 Offset: 0x225A288 VA: 0x225A288
	public game.RankPlayerResult get_rank_result() { }

	// RVA: 0x225A290 Offset: 0x225A290 VA: 0x225A290
	public void set_rank_result(game.RankPlayerResult value) { }

	// RVA: 0x225A2D0 Offset: 0x225A2D0 VA: 0x225A2D0
	public bool get_HasRank_result() { }

	// RVA: 0x225A300 Offset: 0x225A300 VA: 0x225A300
	public game.BoxResult get_box_result() { }

	// RVA: 0x225A308 Offset: 0x225A308 VA: 0x225A308
	public void set_box_result(game.BoxResult value) { }

	// RVA: 0x225A348 Offset: 0x225A348 VA: 0x225A348
	public bool get_HasBox_result() { }

	// RVA: 0x225A378 Offset: 0x225A378 VA: 0x225A378
	public void .ctor() { }

	// RVA: 0x225A414 Offset: 0x225A414 VA: 0x225A414
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225A4CC Offset: 0x225A4CC VA: 0x225A4CC Slot: 5
	protected override void decode() { }

	// RVA: 0x225A5E8 Offset: 0x225A5E8 VA: 0x225A5E8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225A6F0 Offset: 0x225A6F0 VA: 0x225A6F0 Slot: 3
	public override string ToString() { }

	// RVA: 0x225A75C Offset: 0x225A75C VA: 0x225A75C
	private static void .cctor() { }
}
