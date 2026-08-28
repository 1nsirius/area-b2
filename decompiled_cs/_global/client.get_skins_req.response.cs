// Namespace: 
public class client.get_skins_req.response : SprotoTypeBase // TypeDefIndex: 9114
{
	// Fields
	private static int max_field_count; // 0x0
	private List<client.Skin> _skins; // 0x14
	private List<client.CharacterSkin> _char_skins; // 0x18

	// Properties
	public List<client.Skin> skins { get; set; }
	public bool HasSkins { get; }
	public List<client.CharacterSkin> char_skins { get; set; }
	public bool HasChar_skins { get; }

	// Methods

	// RVA: 0x243F7D4 Offset: 0x243F7D4 VA: 0x243F7D4
	public List<client.Skin> get_skins() { }

	// RVA: 0x243F7DC Offset: 0x243F7DC VA: 0x243F7DC
	public void set_skins(List<client.Skin> value) { }

	// RVA: 0x243F81C Offset: 0x243F81C VA: 0x243F81C
	public bool get_HasSkins() { }

	// RVA: 0x243F84C Offset: 0x243F84C VA: 0x243F84C
	public List<client.CharacterSkin> get_char_skins() { }

	// RVA: 0x243F854 Offset: 0x243F854 VA: 0x243F854
	public void set_char_skins(List<client.CharacterSkin> value) { }

	// RVA: 0x243F894 Offset: 0x243F894 VA: 0x243F894
	public bool get_HasChar_skins() { }

	// RVA: 0x243F8C4 Offset: 0x243F8C4 VA: 0x243F8C4
	public void .ctor() { }

	// RVA: 0x243F960 Offset: 0x243F960 VA: 0x243F960
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243FA18 Offset: 0x243FA18 VA: 0x243FA18 Slot: 5
	protected override void decode() { }

	// RVA: 0x243FB34 Offset: 0x243FB34 VA: 0x243FB34 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243FC90 Offset: 0x243FC90 VA: 0x243FC90 Slot: 3
	public override string ToString() { }

	// RVA: 0x243FF30 Offset: 0x243FF30 VA: 0x243FF30
	private static void .cctor() { }
}
