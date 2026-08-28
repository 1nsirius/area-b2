// Namespace: 
public class client.WeaponSkinTarget : SprotoTypeBase // TypeDefIndex: 9070
{
	// Fields
	private static int max_field_count; // 0x0
	private long _char_id; // 0x18
	private long _weapon_id; // 0x20

	// Properties
	public long char_id { get; set; }
	public bool HasChar_id { get; }
	public long weapon_id { get; set; }
	public bool HasWeapon_id { get; }

	// Methods

	// RVA: 0x24366C8 Offset: 0x24366C8 VA: 0x24366C8
	public long get_char_id() { }

	// RVA: 0x24366D0 Offset: 0x24366D0 VA: 0x24366D0
	public void set_char_id(long value) { }

	// RVA: 0x2436714 Offset: 0x2436714 VA: 0x2436714
	public bool get_HasChar_id() { }

	// RVA: 0x2436744 Offset: 0x2436744 VA: 0x2436744
	public long get_weapon_id() { }

	// RVA: 0x243674C Offset: 0x243674C VA: 0x243674C
	public void set_weapon_id(long value) { }

	// RVA: 0x2436790 Offset: 0x2436790 VA: 0x2436790
	public bool get_HasWeapon_id() { }

	// RVA: 0x24367C0 Offset: 0x24367C0 VA: 0x24367C0
	public void .ctor() { }

	// RVA: 0x243685C Offset: 0x243685C VA: 0x243685C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2436914 Offset: 0x2436914 VA: 0x2436914 Slot: 5
	protected override void decode() { }

	// RVA: 0x24369F0 Offset: 0x24369F0 VA: 0x24369F0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2436B18 Offset: 0x2436B18 VA: 0x2436B18 Slot: 3
	public override string ToString() { }

	// RVA: 0x2436BC8 Offset: 0x2436BC8 VA: 0x2436BC8
	private static void .cctor() { }
}
