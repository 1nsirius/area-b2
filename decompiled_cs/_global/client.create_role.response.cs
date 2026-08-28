// Namespace: 
public class client.create_role.response : SprotoTypeBase // TypeDefIndex: 9097
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _uid; // 0x20
	private string _name; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long uid { get; set; }
	public bool HasUid { get; }
	public string name { get; set; }
	public bool HasName { get; }

	// Methods

	// RVA: 0x243C310 Offset: 0x243C310 VA: 0x243C310
	public long get_errorcode() { }

	// RVA: 0x243C318 Offset: 0x243C318 VA: 0x243C318
	public void set_errorcode(long value) { }

	// RVA: 0x243C35C Offset: 0x243C35C VA: 0x243C35C
	public bool get_HasErrorcode() { }

	// RVA: 0x243C38C Offset: 0x243C38C VA: 0x243C38C
	public long get_uid() { }

	// RVA: 0x243C394 Offset: 0x243C394 VA: 0x243C394
	public void set_uid(long value) { }

	// RVA: 0x243C3D8 Offset: 0x243C3D8 VA: 0x243C3D8
	public bool get_HasUid() { }

	// RVA: 0x243C408 Offset: 0x243C408 VA: 0x243C408
	public string get_name() { }

	// RVA: 0x243C410 Offset: 0x243C410 VA: 0x243C410
	public void set_name(string value) { }

	// RVA: 0x243C450 Offset: 0x243C450 VA: 0x243C450
	public bool get_HasName() { }

	// RVA: 0x243C480 Offset: 0x243C480 VA: 0x243C480
	public void .ctor() { }

	// RVA: 0x243C51C Offset: 0x243C51C VA: 0x243C51C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243C5D4 Offset: 0x243C5D4 VA: 0x243C5D4 Slot: 5
	protected override void decode() { }

	// RVA: 0x243C6F4 Offset: 0x243C6F4 VA: 0x243C6F4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243C870 Offset: 0x243C870 VA: 0x243C870 Slot: 3
	public override string ToString() { }

	// RVA: 0x243C92C Offset: 0x243C92C VA: 0x243C92C
	private static void .cctor() { }
}
