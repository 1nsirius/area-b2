// Namespace: 
public class game.TaskInfo : SprotoTypeBase // TypeDefIndex: 9397
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _compelet_cnt; // 0x20
	private long _cur_slot_idx; // 0x28
	private long _status; // 0x30

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long compelet_cnt { get; set; }
	public bool HasCompelet_cnt { get; }
	public long cur_slot_idx { get; set; }
	public bool HasCur_slot_idx { get; }
	public long status { get; set; }
	public bool HasStatus { get; }

	// Methods

	// RVA: 0x2269E7C Offset: 0x2269E7C VA: 0x2269E7C
	public long get_id() { }

	// RVA: 0x2269E84 Offset: 0x2269E84 VA: 0x2269E84
	public void set_id(long value) { }

	// RVA: 0x2269EC8 Offset: 0x2269EC8 VA: 0x2269EC8
	public bool get_HasId() { }

	// RVA: 0x2269EF8 Offset: 0x2269EF8 VA: 0x2269EF8
	public long get_compelet_cnt() { }

	// RVA: 0x2269F00 Offset: 0x2269F00 VA: 0x2269F00
	public void set_compelet_cnt(long value) { }

	// RVA: 0x2269F44 Offset: 0x2269F44 VA: 0x2269F44
	public bool get_HasCompelet_cnt() { }

	// RVA: 0x2269F74 Offset: 0x2269F74 VA: 0x2269F74
	public long get_cur_slot_idx() { }

	// RVA: 0x2269F7C Offset: 0x2269F7C VA: 0x2269F7C
	public void set_cur_slot_idx(long value) { }

	// RVA: 0x2269FC0 Offset: 0x2269FC0 VA: 0x2269FC0
	public bool get_HasCur_slot_idx() { }

	// RVA: 0x2269FF0 Offset: 0x2269FF0 VA: 0x2269FF0
	public long get_status() { }

	// RVA: 0x2269FF8 Offset: 0x2269FF8 VA: 0x2269FF8
	public void set_status(long value) { }

	// RVA: 0x226A03C Offset: 0x226A03C VA: 0x226A03C
	public bool get_HasStatus() { }

	// RVA: 0x226A06C Offset: 0x226A06C VA: 0x226A06C
	public void .ctor() { }

	// RVA: 0x226A108 Offset: 0x226A108 VA: 0x226A108
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226A1C0 Offset: 0x226A1C0 VA: 0x226A1C0 Slot: 5
	protected override void decode() { }

	// RVA: 0x226A31C Offset: 0x226A31C VA: 0x226A31C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226A508 Offset: 0x226A508 VA: 0x226A508 Slot: 3
	public override string ToString() { }

	// RVA: 0x226A780 Offset: 0x226A780 VA: 0x226A780
	private static void .cctor() { }
}
