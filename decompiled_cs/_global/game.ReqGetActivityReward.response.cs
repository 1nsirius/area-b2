// Namespace: 
public class game.ReqGetActivityReward.response : SprotoTypeBase // TypeDefIndex: 9256
{
	// Fields
	private static int max_field_count; // 0x0
	private long _activity_id; // 0x18
	private long _task_id; // 0x20
	private long _errorcode; // 0x28

	// Properties
	public long activity_id { get; set; }
	public bool HasActivity_id { get; }
	public long task_id { get; set; }
	public bool HasTask_id { get; }
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }

	// Methods

	// RVA: 0x255A500 Offset: 0x255A500 VA: 0x255A500
	public long get_activity_id() { }

	// RVA: 0x255A508 Offset: 0x255A508 VA: 0x255A508
	public void set_activity_id(long value) { }

	// RVA: 0x255A54C Offset: 0x255A54C VA: 0x255A54C
	public bool get_HasActivity_id() { }

	// RVA: 0x255A57C Offset: 0x255A57C VA: 0x255A57C
	public long get_task_id() { }

	// RVA: 0x255A584 Offset: 0x255A584 VA: 0x255A584
	public void set_task_id(long value) { }

	// RVA: 0x255A5C8 Offset: 0x255A5C8 VA: 0x255A5C8
	public bool get_HasTask_id() { }

	// RVA: 0x255A5F8 Offset: 0x255A5F8 VA: 0x255A5F8
	public long get_errorcode() { }

	// RVA: 0x255A600 Offset: 0x255A600 VA: 0x255A600
	public void set_errorcode(long value) { }

	// RVA: 0x255A644 Offset: 0x255A644 VA: 0x255A644
	public bool get_HasErrorcode() { }

	// RVA: 0x255A674 Offset: 0x255A674 VA: 0x255A674
	public void .ctor() { }

	// RVA: 0x255A710 Offset: 0x255A710 VA: 0x255A710
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255A7C8 Offset: 0x255A7C8 VA: 0x255A7C8 Slot: 5
	protected override void decode() { }

	// RVA: 0x255A8EC Offset: 0x255A8EC VA: 0x255A8EC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255AA74 Offset: 0x255AA74 VA: 0x255AA74 Slot: 3
	public override string ToString() { }

	// RVA: 0x255AB4C Offset: 0x255AB4C VA: 0x255AB4C
	private static void .cctor() { }
}
