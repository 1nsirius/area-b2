// Namespace: 
public class client.change_name.request : SprotoTypeBase // TypeDefIndex: 9090
{
	// Fields
	private static int max_field_count; // 0x0
	private string _name; // 0x14

	// Properties
	public string name { get; set; }
	public bool HasName { get; }

	// Methods

	// RVA: 0x243A994 Offset: 0x243A994 VA: 0x243A994
	public string get_name() { }

	// RVA: 0x243A99C Offset: 0x243A99C VA: 0x243A99C
	public void set_name(string value) { }

	// RVA: 0x243A9DC Offset: 0x243A9DC VA: 0x243A9DC
	public bool get_HasName() { }

	// RVA: 0x243AA0C Offset: 0x243AA0C VA: 0x243AA0C
	public void .ctor() { }

	// RVA: 0x243AAA8 Offset: 0x243AAA8 VA: 0x243AAA8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243AB60 Offset: 0x243AB60 VA: 0x243AB60 Slot: 5
	protected override void decode() { }

	// RVA: 0x243ABDC Offset: 0x243ABDC VA: 0x243ABDC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243AC8C Offset: 0x243AC8C VA: 0x243AC8C Slot: 3
	public override string ToString() { }

	// RVA: 0x243AD04 Offset: 0x243AD04 VA: 0x243AD04
	private static void .cctor() { }
}
