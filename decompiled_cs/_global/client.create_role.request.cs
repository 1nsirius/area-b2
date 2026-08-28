// Namespace: 
public class client.create_role.request : SprotoTypeBase // TypeDefIndex: 9096
{
	// Fields
	private static int max_field_count; // 0x0
	private string _name; // 0x14
	private string _icon_url; // 0x18

	// Properties
	public string name { get; set; }
	public bool HasName { get; }
	public string icon_url { get; set; }
	public bool HasIcon_url { get; }

	// Methods

	// RVA: 0x243BC24 Offset: 0x243BC24 VA: 0x243BC24
	public string get_name() { }

	// RVA: 0x243BC2C Offset: 0x243BC2C VA: 0x243BC2C
	public void set_name(string value) { }

	// RVA: 0x243BC6C Offset: 0x243BC6C VA: 0x243BC6C
	public bool get_HasName() { }

	// RVA: 0x243BC9C Offset: 0x243BC9C VA: 0x243BC9C
	public string get_icon_url() { }

	// RVA: 0x243BCA4 Offset: 0x243BCA4 VA: 0x243BCA4
	public void set_icon_url(string value) { }

	// RVA: 0x243BCE4 Offset: 0x243BCE4 VA: 0x243BCE4
	public bool get_HasIcon_url() { }

	// RVA: 0x243BD14 Offset: 0x243BD14 VA: 0x243BD14
	public void .ctor() { }

	// RVA: 0x243BDB0 Offset: 0x243BDB0 VA: 0x243BDB0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243BE68 Offset: 0x243BE68 VA: 0x243BE68 Slot: 5
	protected override void decode() { }

	// RVA: 0x243BF30 Offset: 0x243BF30 VA: 0x243BF30 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243C038 Offset: 0x243C038 VA: 0x243C038 Slot: 3
	public override string ToString() { }

	// RVA: 0x243C2A8 Offset: 0x243C2A8 VA: 0x243C2A8
	private static void .cctor() { }
}
