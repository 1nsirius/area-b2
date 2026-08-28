// Namespace: 
public class game.ReqJoinRoom.request : SprotoTypeBase // TypeDefIndex: 9263
{
	// Fields
	private static int max_field_count; // 0x0
	private long _room_id; // 0x18
	private long _battle_zone; // 0x20

	// Properties
	public long room_id { get; set; }
	public bool HasRoom_id { get; }
	public long battle_zone { get; set; }
	public bool HasBattle_zone { get; }

	// Methods

	// RVA: 0x255BF1C Offset: 0x255BF1C VA: 0x255BF1C
	public long get_room_id() { }

	// RVA: 0x255BF24 Offset: 0x255BF24 VA: 0x255BF24
	public void set_room_id(long value) { }

	// RVA: 0x255BF68 Offset: 0x255BF68 VA: 0x255BF68
	public bool get_HasRoom_id() { }

	// RVA: 0x255BF98 Offset: 0x255BF98 VA: 0x255BF98
	public long get_battle_zone() { }

	// RVA: 0x255BFA0 Offset: 0x255BFA0 VA: 0x255BFA0
	public void set_battle_zone(long value) { }

	// RVA: 0x255BFE4 Offset: 0x255BFE4 VA: 0x255BFE4
	public bool get_HasBattle_zone() { }

	// RVA: 0x255C014 Offset: 0x255C014 VA: 0x255C014
	public void .ctor() { }

	// RVA: 0x255C0B0 Offset: 0x255C0B0 VA: 0x255C0B0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255C168 Offset: 0x255C168 VA: 0x255C168 Slot: 5
	protected override void decode() { }

	// RVA: 0x255C244 Offset: 0x255C244 VA: 0x255C244 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255C368 Offset: 0x255C368 VA: 0x255C368 Slot: 3
	public override string ToString() { }

	// RVA: 0x255C418 Offset: 0x255C418 VA: 0x255C418
	private static void .cctor() { }
}
