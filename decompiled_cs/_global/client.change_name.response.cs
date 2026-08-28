// Namespace: 
public class client.change_name.response : SprotoTypeBase // TypeDefIndex: 9091
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private string _name; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public string name { get; set; }
	public bool HasName { get; }

	// Methods

	// RVA: 0x243AD6C Offset: 0x243AD6C VA: 0x243AD6C
	public long get_errorcode() { }

	// RVA: 0x243AD74 Offset: 0x243AD74 VA: 0x243AD74
	public void set_errorcode(long value) { }

	// RVA: 0x243ADB8 Offset: 0x243ADB8 VA: 0x243ADB8
	public bool get_HasErrorcode() { }

	// RVA: 0x243ADE8 Offset: 0x243ADE8 VA: 0x243ADE8
	public string get_name() { }

	// RVA: 0x243ADF0 Offset: 0x243ADF0 VA: 0x243ADF0
	public void set_name(string value) { }

	// RVA: 0x243AE30 Offset: 0x243AE30 VA: 0x243AE30
	public bool get_HasName() { }

	// RVA: 0x243AE60 Offset: 0x243AE60 VA: 0x243AE60
	public void .ctor() { }

	// RVA: 0x243AEFC Offset: 0x243AEFC VA: 0x243AEFC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243AFB4 Offset: 0x243AFB4 VA: 0x243AFB4 Slot: 5
	protected override void decode() { }

	// RVA: 0x243B08C Offset: 0x243B08C VA: 0x243B08C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243B1A4 Offset: 0x243B1A4 VA: 0x243B1A4 Slot: 3
	public override string ToString() { }

	// RVA: 0x243B238 Offset: 0x243B238 VA: 0x243B238
	private static void .cctor() { }
}
