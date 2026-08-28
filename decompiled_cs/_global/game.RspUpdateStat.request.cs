// Namespace: 
public class game.RspUpdateStat.request : SprotoTypeBase // TypeDefIndex: 9391
{
	// Fields
	private static int max_field_count; // 0x0
	private string _type; // 0x14
	private long _value; // 0x18

	// Properties
	public string type { get; set; }
	public bool HasType { get; }
	public long value { get; set; }
	public bool HasValue { get; }

	// Methods

	// RVA: 0x2268214 Offset: 0x2268214 VA: 0x2268214
	public string get_type() { }

	// RVA: 0x226821C Offset: 0x226821C VA: 0x226821C
	public void set_type(string value) { }

	// RVA: 0x226825C Offset: 0x226825C VA: 0x226825C
	public bool get_HasType() { }

	// RVA: 0x226828C Offset: 0x226828C VA: 0x226828C
	public long get_value() { }

	// RVA: 0x2268294 Offset: 0x2268294 VA: 0x2268294
	public void set_value(long value) { }

	// RVA: 0x22682D8 Offset: 0x22682D8 VA: 0x22682D8
	public bool get_HasValue() { }

	// RVA: 0x2268308 Offset: 0x2268308 VA: 0x2268308
	public void .ctor() { }

	// RVA: 0x22683A4 Offset: 0x22683A4 VA: 0x22683A4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226845C Offset: 0x226845C VA: 0x226845C Slot: 5
	protected override void decode() { }

	// RVA: 0x2268534 Offset: 0x2268534 VA: 0x2268534 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2268650 Offset: 0x2268650 VA: 0x2268650 Slot: 3
	public override string ToString() { }

	// RVA: 0x22686EC Offset: 0x22686EC VA: 0x22686EC
	private static void .cctor() { }
}
