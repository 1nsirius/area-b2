// Namespace: 
public class client.query_leaderboard.request : SprotoTypeBase // TypeDefIndex: 9150
{
	// Fields
	private static int max_field_count; // 0x0
	private long _type; // 0x18
	private long _start_index; // 0x20
	private long _end_index; // 0x28
	private long _extra_arg; // 0x30

	// Properties
	public long type { get; set; }
	public bool HasType { get; }
	public long start_index { get; set; }
	public bool HasStart_index { get; }
	public long end_index { get; set; }
	public bool HasEnd_index { get; }
	public long extra_arg { get; set; }
	public bool HasExtra_arg { get; }

	// Methods

	// RVA: 0x24470C8 Offset: 0x24470C8 VA: 0x24470C8
	public long get_type() { }

	// RVA: 0x24470D0 Offset: 0x24470D0 VA: 0x24470D0
	public void set_type(long value) { }

	// RVA: 0x2447114 Offset: 0x2447114 VA: 0x2447114
	public bool get_HasType() { }

	// RVA: 0x2447144 Offset: 0x2447144 VA: 0x2447144
	public long get_start_index() { }

	// RVA: 0x244714C Offset: 0x244714C VA: 0x244714C
	public void set_start_index(long value) { }

	// RVA: 0x2447190 Offset: 0x2447190 VA: 0x2447190
	public bool get_HasStart_index() { }

	// RVA: 0x24471C0 Offset: 0x24471C0 VA: 0x24471C0
	public long get_end_index() { }

	// RVA: 0x24471C8 Offset: 0x24471C8 VA: 0x24471C8
	public void set_end_index(long value) { }

	// RVA: 0x244720C Offset: 0x244720C VA: 0x244720C
	public bool get_HasEnd_index() { }

	// RVA: 0x244723C Offset: 0x244723C VA: 0x244723C
	public long get_extra_arg() { }

	// RVA: 0x2447244 Offset: 0x2447244 VA: 0x2447244
	public void set_extra_arg(long value) { }

	// RVA: 0x2447288 Offset: 0x2447288 VA: 0x2447288
	public bool get_HasExtra_arg() { }

	// RVA: 0x24472B8 Offset: 0x24472B8 VA: 0x24472B8
	public void .ctor() { }

	// RVA: 0x2447354 Offset: 0x2447354 VA: 0x2447354
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244740C Offset: 0x244740C VA: 0x244740C Slot: 5
	protected override void decode() { }

	// RVA: 0x2447568 Offset: 0x2447568 VA: 0x2447568 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2447754 Offset: 0x2447754 VA: 0x2447754 Slot: 3
	public override string ToString() { }

	// RVA: 0x24479CC Offset: 0x24479CC VA: 0x24479CC
	private static void .cctor() { }
}
