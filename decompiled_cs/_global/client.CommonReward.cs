// Namespace: 
public class client.CommonReward : SprotoTypeBase // TypeDefIndex: 9055
{
	// Fields
	private static int max_field_count; // 0x0
	private long _reward_id; // 0x18
	private long _reward_num; // 0x20
	private client.ConvertReward _convert_reward; // 0x28

	// Properties
	public long reward_id { get; set; }
	public bool HasReward_id { get; }
	public long reward_num { get; set; }
	public bool HasReward_num { get; }
	public client.ConvertReward convert_reward { get; set; }
	public bool HasConvert_reward { get; }

	// Methods

	// RVA: 0x12BC0C8 Offset: 0x12BC0C8 VA: 0x12BC0C8
	public long get_reward_id() { }

	// RVA: 0x12BC0D0 Offset: 0x12BC0D0 VA: 0x12BC0D0
	public void set_reward_id(long value) { }

	// RVA: 0x12BC110 Offset: 0x12BC110 VA: 0x12BC110
	public bool get_HasReward_id() { }

	// RVA: 0x12BC13C Offset: 0x12BC13C VA: 0x12BC13C
	public long get_reward_num() { }

	// RVA: 0x12BC144 Offset: 0x12BC144 VA: 0x12BC144
	public void set_reward_num(long value) { }

	// RVA: 0x12BC184 Offset: 0x12BC184 VA: 0x12BC184
	public bool get_HasReward_num() { }

	// RVA: 0x12BC1B0 Offset: 0x12BC1B0 VA: 0x12BC1B0
	public client.ConvertReward get_convert_reward() { }

	// RVA: 0x12BC1B8 Offset: 0x12BC1B8 VA: 0x12BC1B8
	public void set_convert_reward(client.ConvertReward value) { }

	// RVA: 0x12BC1F4 Offset: 0x12BC1F4 VA: 0x12BC1F4
	public bool get_HasConvert_reward() { }

	// RVA: 0x12BC220 Offset: 0x12BC220 VA: 0x12BC220
	public void .ctor() { }

	// RVA: 0x12BC2B8 Offset: 0x12BC2B8 VA: 0x12BC2B8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x12BC36C Offset: 0x12BC36C VA: 0x12BC36C Slot: 5
	protected override void decode() { }

	// RVA: 0x12BC4C4 Offset: 0x12BC4C4 VA: 0x12BC4C4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x12BC628 Offset: 0x12BC628 VA: 0x12BC628 Slot: 3
	public override string ToString() { }

	// RVA: 0x12BC6E4 Offset: 0x12BC6E4 VA: 0x12BC6E4
	private static void .cctor() { }
}
