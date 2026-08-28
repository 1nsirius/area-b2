// Namespace: 
public class game.RspRoomPlayerEntered.request : SprotoTypeBase // TypeDefIndex: 9375
{
	// Fields
	private static int max_field_count; // 0x0
	private game.PlayerInfo _player; // 0x14

	// Properties
	public game.PlayerInfo player { get; set; }
	public bool HasPlayer { get; }

	// Methods

	// RVA: 0x2264A74 Offset: 0x2264A74 VA: 0x2264A74
	public game.PlayerInfo get_player() { }

	// RVA: 0x2264A7C Offset: 0x2264A7C VA: 0x2264A7C
	public void set_player(game.PlayerInfo value) { }

	// RVA: 0x2264ABC Offset: 0x2264ABC VA: 0x2264ABC
	public bool get_HasPlayer() { }

	// RVA: 0x2264AEC Offset: 0x2264AEC VA: 0x2264AEC
	public void .ctor() { }

	// RVA: 0x2264B88 Offset: 0x2264B88 VA: 0x2264B88
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2264C40 Offset: 0x2264C40 VA: 0x2264C40 Slot: 5
	protected override void decode() { }

	// RVA: 0x2264D0C Offset: 0x2264D0C VA: 0x2264D0C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2264DBC Offset: 0x2264DBC VA: 0x2264DBC Slot: 3
	public override string ToString() { }

	// RVA: 0x2264E24 Offset: 0x2264E24 VA: 0x2264E24
	private static void .cctor() { }
}
