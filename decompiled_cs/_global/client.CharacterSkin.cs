// Namespace: 
public class client.CharacterSkin : SprotoTypeBase // TypeDefIndex: 9054
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private List<long> _char_skins; // 0x20
	private List<client.WeaponSkin> _weapon_skins; // 0x24

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public List<long> char_skins { get; set; }
	public bool HasChar_skins { get; }
	public List<client.WeaponSkin> weapon_skins { get; set; }
	public bool HasWeapon_skins { get; }

	// Methods

	// RVA: 0x12BB9F8 Offset: 0x12BB9F8 VA: 0x12BB9F8
	public long get_id() { }

	// RVA: 0x12BBA00 Offset: 0x12BBA00 VA: 0x12BBA00
	public void set_id(long value) { }

	// RVA: 0x12BBA40 Offset: 0x12BBA40 VA: 0x12BBA40
	public bool get_HasId() { }

	// RVA: 0x12BBA6C Offset: 0x12BBA6C VA: 0x12BBA6C
	public List<long> get_char_skins() { }

	// RVA: 0x12BBA74 Offset: 0x12BBA74 VA: 0x12BBA74
	public void set_char_skins(List<long> value) { }

	// RVA: 0x12BBAB0 Offset: 0x12BBAB0 VA: 0x12BBAB0
	public bool get_HasChar_skins() { }

	// RVA: 0x12BBADC Offset: 0x12BBADC VA: 0x12BBADC
	public List<client.WeaponSkin> get_weapon_skins() { }

	// RVA: 0x12BBAE4 Offset: 0x12BBAE4 VA: 0x12BBAE4
	public void set_weapon_skins(List<client.WeaponSkin> value) { }

	// RVA: 0x12BBB20 Offset: 0x12BBB20 VA: 0x12BBB20
	public bool get_HasWeapon_skins() { }

	// RVA: 0x12BBB4C Offset: 0x12BBB4C VA: 0x12BBB4C
	public void .ctor() { }

	// RVA: 0x12BBBE4 Offset: 0x12BBBE4 VA: 0x12BBBE4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x12BBC98 Offset: 0x12BBC98 VA: 0x12BBC98 Slot: 5
	protected override void decode() { }

	// RVA: 0x12BBDEC Offset: 0x12BBDEC VA: 0x12BBDEC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x12BBF88 Offset: 0x12BBF88 VA: 0x12BBF88 Slot: 3
	public override string ToString() { }

	// RVA: 0x12BC060 Offset: 0x12BC060 VA: 0x12BC060
	private static void .cctor() { }
}
