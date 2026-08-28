// Namespace: 
public class game.RspChooseCharacter.request : SprotoTypeBase // TypeDefIndex: 9333
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _character_id; // 0x20
	private long _primary_weapon_id; // 0x28
	private List<long> _skin; // 0x30

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long character_id { get; set; }
	public bool HasCharacter_id { get; }
	public long primary_weapon_id { get; set; }
	public bool HasPrimary_weapon_id { get; }
	public List<long> skin { get; set; }
	public bool HasSkin { get; }

	// Methods

	// RVA: 0x225C178 Offset: 0x225C178 VA: 0x225C178
	public long get_uid() { }

	// RVA: 0x225C180 Offset: 0x225C180 VA: 0x225C180
	public void set_uid(long value) { }

	// RVA: 0x225C1C4 Offset: 0x225C1C4 VA: 0x225C1C4
	public bool get_HasUid() { }

	// RVA: 0x225C1F4 Offset: 0x225C1F4 VA: 0x225C1F4
	public long get_character_id() { }

	// RVA: 0x225C1FC Offset: 0x225C1FC VA: 0x225C1FC
	public void set_character_id(long value) { }

	// RVA: 0x225C240 Offset: 0x225C240 VA: 0x225C240
	public bool get_HasCharacter_id() { }

	// RVA: 0x225C270 Offset: 0x225C270 VA: 0x225C270
	public long get_primary_weapon_id() { }

	// RVA: 0x225C278 Offset: 0x225C278 VA: 0x225C278
	public void set_primary_weapon_id(long value) { }

	// RVA: 0x225C2BC Offset: 0x225C2BC VA: 0x225C2BC
	public bool get_HasPrimary_weapon_id() { }

	// RVA: 0x225C2EC Offset: 0x225C2EC VA: 0x225C2EC
	public List<long> get_skin() { }

	// RVA: 0x225C2F4 Offset: 0x225C2F4 VA: 0x225C2F4
	public void set_skin(List<long> value) { }

	// RVA: 0x225C334 Offset: 0x225C334 VA: 0x225C334
	public bool get_HasSkin() { }

	// RVA: 0x225C364 Offset: 0x225C364 VA: 0x225C364
	public void .ctor() { }

	// RVA: 0x225C400 Offset: 0x225C400 VA: 0x225C400
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225C4B8 Offset: 0x225C4B8 VA: 0x225C4B8 Slot: 5
	protected override void decode() { }

	// RVA: 0x225C610 Offset: 0x225C610 VA: 0x225C610 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225C7F0 Offset: 0x225C7F0 VA: 0x225C7F0 Slot: 3
	public override string ToString() { }

	// RVA: 0x225CA5C Offset: 0x225CA5C VA: 0x225CA5C
	private static void .cctor() { }
}
