// Namespace: 
public class client.Skin : SprotoTypeBase // TypeDefIndex: 9066
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _timestamp; // 0x20
	private bool _new_flag; // 0x28
	private long _num; // 0x30

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long timestamp { get; set; }
	public bool HasTimestamp { get; }
	public bool new_flag { get; set; }
	public bool HasNew_flag { get; }
	public long num { get; set; }
	public bool HasNum { get; }

	// Methods

	// RVA: 0x24344C0 Offset: 0x24344C0 VA: 0x24344C0
	public long get_id() { }

	// RVA: 0x24344C8 Offset: 0x24344C8 VA: 0x24344C8
	public void set_id(long value) { }

	// RVA: 0x243450C Offset: 0x243450C VA: 0x243450C
	public bool get_HasId() { }

	// RVA: 0x243453C Offset: 0x243453C VA: 0x243453C
	public long get_timestamp() { }

	// RVA: 0x2434544 Offset: 0x2434544 VA: 0x2434544
	public void set_timestamp(long value) { }

	// RVA: 0x2434588 Offset: 0x2434588 VA: 0x2434588
	public bool get_HasTimestamp() { }

	// RVA: 0x24345B8 Offset: 0x24345B8 VA: 0x24345B8
	public bool get_new_flag() { }

	// RVA: 0x24345C0 Offset: 0x24345C0 VA: 0x24345C0
	public void set_new_flag(bool value) { }

	// RVA: 0x2434600 Offset: 0x2434600 VA: 0x2434600
	public bool get_HasNew_flag() { }

	// RVA: 0x2434630 Offset: 0x2434630 VA: 0x2434630
	public long get_num() { }

	// RVA: 0x2434638 Offset: 0x2434638 VA: 0x2434638
	public void set_num(long value) { }

	// RVA: 0x243467C Offset: 0x243467C VA: 0x243467C
	public bool get_HasNum() { }

	// RVA: 0x24346AC Offset: 0x24346AC VA: 0x24346AC
	public void .ctor() { }

	// RVA: 0x2434748 Offset: 0x2434748 VA: 0x2434748
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2434800 Offset: 0x2434800 VA: 0x2434800 Slot: 5
	protected override void decode() { }

	// RVA: 0x2434958 Offset: 0x2434958 VA: 0x2434958 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2434B40 Offset: 0x2434B40 VA: 0x2434B40 Slot: 3
	public override string ToString() { }

	// RVA: 0x2434DB4 Offset: 0x2434DB4 VA: 0x2434DB4
	private static void .cctor() { }
}
