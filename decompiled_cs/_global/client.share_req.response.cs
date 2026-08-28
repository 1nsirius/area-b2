// Namespace: 
public class client.share_req.response : SprotoTypeBase // TypeDefIndex: 9166
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _share_type; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long share_type { get; set; }
	public bool HasShare_type { get; }

	// Methods

	// RVA: 0x244D144 Offset: 0x244D144 VA: 0x244D144
	public long get_errorcode() { }

	// RVA: 0x244D14C Offset: 0x244D14C VA: 0x244D14C
	public void set_errorcode(long value) { }

	// RVA: 0x244D190 Offset: 0x244D190 VA: 0x244D190
	public bool get_HasErrorcode() { }

	// RVA: 0x244D1C0 Offset: 0x244D1C0 VA: 0x244D1C0
	public long get_share_type() { }

	// RVA: 0x244D1C8 Offset: 0x244D1C8 VA: 0x244D1C8
	public void set_share_type(long value) { }

	// RVA: 0x244D20C Offset: 0x244D20C VA: 0x244D20C
	public bool get_HasShare_type() { }

	// RVA: 0x244D23C Offset: 0x244D23C VA: 0x244D23C
	public void .ctor() { }

	// RVA: 0x244D2D8 Offset: 0x244D2D8 VA: 0x244D2D8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244D390 Offset: 0x244D390 VA: 0x244D390 Slot: 5
	protected override void decode() { }

	// RVA: 0x244D46C Offset: 0x244D46C VA: 0x244D46C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244D590 Offset: 0x244D590 VA: 0x244D590 Slot: 3
	public override string ToString() { }

	// RVA: 0x244D640 Offset: 0x244D640 VA: 0x244D640
	private static void .cctor() { }
}
