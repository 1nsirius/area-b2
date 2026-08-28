// Namespace: 
public class game.ActivityTaskInfo : SprotoTypeBase // TypeDefIndex: 9194
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _state; // 0x20
	private long _value; // 0x28
	private long _max_value; // 0x30

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long state { get; set; }
	public bool HasState { get; }
	public long value { get; set; }
	public bool HasValue { get; }
	public long max_value { get; set; }
	public bool HasMax_value { get; }

	// Methods

	// RVA: 0x2549344 Offset: 0x2549344 VA: 0x2549344
	public long get_id() { }

	// RVA: 0x254934C Offset: 0x254934C VA: 0x254934C
	public void set_id(long value) { }

	// RVA: 0x2549390 Offset: 0x2549390 VA: 0x2549390
	public bool get_HasId() { }

	// RVA: 0x25493C0 Offset: 0x25493C0 VA: 0x25493C0
	public long get_state() { }

	// RVA: 0x25493C8 Offset: 0x25493C8 VA: 0x25493C8
	public void set_state(long value) { }

	// RVA: 0x254940C Offset: 0x254940C VA: 0x254940C
	public bool get_HasState() { }

	// RVA: 0x254943C Offset: 0x254943C VA: 0x254943C
	public long get_value() { }

	// RVA: 0x2549444 Offset: 0x2549444 VA: 0x2549444
	public void set_value(long value) { }

	// RVA: 0x2549488 Offset: 0x2549488 VA: 0x2549488
	public bool get_HasValue() { }

	// RVA: 0x25494B8 Offset: 0x25494B8 VA: 0x25494B8
	public long get_max_value() { }

	// RVA: 0x25494C0 Offset: 0x25494C0 VA: 0x25494C0
	public void set_max_value(long value) { }

	// RVA: 0x2549504 Offset: 0x2549504 VA: 0x2549504
	public bool get_HasMax_value() { }

	// RVA: 0x2549534 Offset: 0x2549534 VA: 0x2549534
	public void .ctor() { }

	// RVA: 0x25495D0 Offset: 0x25495D0 VA: 0x25495D0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2549688 Offset: 0x2549688 VA: 0x2549688 Slot: 5
	protected override void decode() { }

	// RVA: 0x25497E4 Offset: 0x25497E4 VA: 0x25497E4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x25499D0 Offset: 0x25499D0 VA: 0x25499D0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2549C48 Offset: 0x2549C48 VA: 0x2549C48
	private static void .cctor() { }
}
