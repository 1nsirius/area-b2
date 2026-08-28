// Namespace: 
public class client.ConvertReward : SprotoTypeBase // TypeDefIndex: 9056
{
	// Fields
	private static int max_field_count; // 0x0
	private long _reward_id; // 0x18
	private long _reward_num; // 0x20

	// Properties
	public long reward_id { get; set; }
	public bool HasReward_id { get; }
	public long reward_num { get; set; }
	public bool HasReward_num { get; }

	// Methods

	// RVA: 0x12BC74C Offset: 0x12BC74C VA: 0x12BC74C
	public long get_reward_id() { }

	// RVA: 0x12BC754 Offset: 0x12BC754 VA: 0x12BC754
	public void set_reward_id(long value) { }

	// RVA: 0x12BC794 Offset: 0x12BC794 VA: 0x12BC794
	public bool get_HasReward_id() { }

	// RVA: 0x12BC7C0 Offset: 0x12BC7C0 VA: 0x12BC7C0
	public long get_reward_num() { }

	// RVA: 0x12BC7C8 Offset: 0x12BC7C8 VA: 0x12BC7C8
	public void set_reward_num(long value) { }

	// RVA: 0x12BC808 Offset: 0x12BC808 VA: 0x12BC808
	public bool get_HasReward_num() { }

	// RVA: 0x12BC834 Offset: 0x12BC834 VA: 0x12BC834
	public void .ctor() { }

	// RVA: 0x12BC8CC Offset: 0x12BC8CC VA: 0x12BC8CC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x12BC980 Offset: 0x12BC980 VA: 0x12BC980 Slot: 5
	protected override void decode() { }

	// RVA: 0x12BCA4C Offset: 0x12BCA4C VA: 0x12BCA4C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x12BCB54 Offset: 0x12BCB54 VA: 0x12BCB54 Slot: 3
	public override string ToString() { }

	// RVA: 0x12BCC04 Offset: 0x12BCC04 VA: 0x12BCC04
	private static void .cctor() { }
}
