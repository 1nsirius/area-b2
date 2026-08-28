// Namespace: 
public class game.RspPlayersResult.request : SprotoTypeBase // TypeDefIndex: 9363
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.BattlePlayerResult> _results; // 0x14

	// Properties
	public List<game.BattlePlayerResult> results { get; set; }
	public bool HasResults { get; }

	// Methods

	// RVA: 0x226267C Offset: 0x226267C VA: 0x226267C
	public List<game.BattlePlayerResult> get_results() { }

	// RVA: 0x2262684 Offset: 0x2262684 VA: 0x2262684
	public void set_results(List<game.BattlePlayerResult> value) { }

	// RVA: 0x22626C4 Offset: 0x22626C4 VA: 0x22626C4
	public bool get_HasResults() { }

	// RVA: 0x22626F4 Offset: 0x22626F4 VA: 0x22626F4
	public void .ctor() { }

	// RVA: 0x2262790 Offset: 0x2262790 VA: 0x2262790
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2262848 Offset: 0x2262848 VA: 0x2262848 Slot: 5
	protected override void decode() { }

	// RVA: 0x2262914 Offset: 0x2262914 VA: 0x2262914 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2262A0C Offset: 0x2262A0C VA: 0x2262A0C Slot: 3
	public override string ToString() { }

	// RVA: 0x2262A9C Offset: 0x2262A9C VA: 0x2262A9C
	private static void .cctor() { }
}
