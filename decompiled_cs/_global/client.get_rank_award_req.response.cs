// Namespace: 
public class client.get_rank_award_req.response : SprotoTypeBase // TypeDefIndex: 9106
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _reward_id; // 0x20
	private long _reward_num; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long reward_id { get; set; }
	public bool HasReward_id { get; }
	public long reward_num { get; set; }
	public bool HasReward_num { get; }

	// Methods

	// RVA: 0x243E07C Offset: 0x243E07C VA: 0x243E07C
	public long get_errorcode() { }

	// RVA: 0x243E084 Offset: 0x243E084 VA: 0x243E084
	public void set_errorcode(long value) { }

	// RVA: 0x243E0C8 Offset: 0x243E0C8 VA: 0x243E0C8
	public bool get_HasErrorcode() { }

	// RVA: 0x243E0F8 Offset: 0x243E0F8 VA: 0x243E0F8
	public long get_reward_id() { }

	// RVA: 0x243E100 Offset: 0x243E100 VA: 0x243E100
	public void set_reward_id(long value) { }

	// RVA: 0x243E144 Offset: 0x243E144 VA: 0x243E144
	public bool get_HasReward_id() { }

	// RVA: 0x243E174 Offset: 0x243E174 VA: 0x243E174
	public long get_reward_num() { }

	// RVA: 0x243E17C Offset: 0x243E17C VA: 0x243E17C
	public void set_reward_num(long value) { }

	// RVA: 0x243E1C0 Offset: 0x243E1C0 VA: 0x243E1C0
	public bool get_HasReward_num() { }

	// RVA: 0x243E1F0 Offset: 0x243E1F0 VA: 0x243E1F0
	public void .ctor() { }

	// RVA: 0x243E28C Offset: 0x243E28C VA: 0x243E28C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243E344 Offset: 0x243E344 VA: 0x243E344 Slot: 5
	protected override void decode() { }

	// RVA: 0x243E468 Offset: 0x243E468 VA: 0x243E468 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243E5F0 Offset: 0x243E5F0 VA: 0x243E5F0 Slot: 3
	public override string ToString() { }

	// RVA: 0x243E6C8 Offset: 0x243E6C8 VA: 0x243E6C8
	private static void .cctor() { }
}
