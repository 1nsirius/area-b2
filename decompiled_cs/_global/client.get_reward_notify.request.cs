// Namespace: 
public class client.get_reward_notify.request : SprotoTypeBase // TypeDefIndex: 9111
{
	// Fields
	private static int max_field_count; // 0x0
	private List<client.CommonReward> _rewards; // 0x14
	private long _reward_type; // 0x18

	// Properties
	public List<client.CommonReward> rewards { get; set; }
	public bool HasRewards { get; }
	public long reward_type { get; set; }
	public bool HasReward_type { get; }

	// Methods

	// RVA: 0x243EF84 Offset: 0x243EF84 VA: 0x243EF84
	public List<client.CommonReward> get_rewards() { }

	// RVA: 0x243EF8C Offset: 0x243EF8C VA: 0x243EF8C
	public void set_rewards(List<client.CommonReward> value) { }

	// RVA: 0x243EFCC Offset: 0x243EFCC VA: 0x243EFCC
	public bool get_HasRewards() { }

	// RVA: 0x243EFFC Offset: 0x243EFFC VA: 0x243EFFC
	public long get_reward_type() { }

	// RVA: 0x243F004 Offset: 0x243F004 VA: 0x243F004
	public void set_reward_type(long value) { }

	// RVA: 0x243F048 Offset: 0x243F048 VA: 0x243F048
	public bool get_HasReward_type() { }

	// RVA: 0x243F078 Offset: 0x243F078 VA: 0x243F078
	public void .ctor() { }

	// RVA: 0x243F114 Offset: 0x243F114 VA: 0x243F114
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243F1CC Offset: 0x243F1CC VA: 0x243F1CC Slot: 5
	protected override void decode() { }

	// RVA: 0x243F2EC Offset: 0x243F2EC VA: 0x243F2EC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243F450 Offset: 0x243F450 VA: 0x243F450 Slot: 3
	public override string ToString() { }

	// RVA: 0x243F500 Offset: 0x243F500 VA: 0x243F500
	private static void .cctor() { }
}
