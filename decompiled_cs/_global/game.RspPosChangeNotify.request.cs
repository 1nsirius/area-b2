// Namespace: 
public class game.RspPosChangeNotify.request : SprotoTypeBase // TypeDefIndex: 9365
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.RoomPositionInfo> _player_positions; // 0x14

	// Properties
	public List<game.RoomPositionInfo> player_positions { get; set; }
	public bool HasPlayer_positions { get; }

	// Methods

	// RVA: 0x2262B0C Offset: 0x2262B0C VA: 0x2262B0C
	public List<game.RoomPositionInfo> get_player_positions() { }

	// RVA: 0x2262B14 Offset: 0x2262B14 VA: 0x2262B14
	public void set_player_positions(List<game.RoomPositionInfo> value) { }

	// RVA: 0x2262B54 Offset: 0x2262B54 VA: 0x2262B54
	public bool get_HasPlayer_positions() { }

	// RVA: 0x2262B84 Offset: 0x2262B84 VA: 0x2262B84
	public void .ctor() { }

	// RVA: 0x2262C20 Offset: 0x2262C20 VA: 0x2262C20
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2262CD8 Offset: 0x2262CD8 VA: 0x2262CD8 Slot: 5
	protected override void decode() { }

	// RVA: 0x2262DA4 Offset: 0x2262DA4 VA: 0x2262DA4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2262E9C Offset: 0x2262E9C VA: 0x2262E9C Slot: 3
	public override string ToString() { }

	// RVA: 0x2262F2C Offset: 0x2262F2C VA: 0x2262F2C
	private static void .cctor() { }
}
