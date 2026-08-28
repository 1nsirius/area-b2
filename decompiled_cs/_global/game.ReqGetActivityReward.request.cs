// Namespace: 
public class game.ReqGetActivityReward.request : SprotoTypeBase // TypeDefIndex: 9255
{
	// Fields
	private static int max_field_count; // 0x0
	private long _activity_id; // 0x18
	private long _task_id; // 0x20

	// Properties
	public long activity_id { get; set; }
	public bool HasActivity_id { get; }
	public long task_id { get; set; }
	public bool HasTask_id { get; }

	// Methods

	// RVA: 0x2559F9C Offset: 0x2559F9C VA: 0x2559F9C
	public long get_activity_id() { }

	// RVA: 0x2559FA4 Offset: 0x2559FA4 VA: 0x2559FA4
	public void set_activity_id(long value) { }

	// RVA: 0x2559FE8 Offset: 0x2559FE8 VA: 0x2559FE8
	public bool get_HasActivity_id() { }

	// RVA: 0x255A018 Offset: 0x255A018 VA: 0x255A018
	public long get_task_id() { }

	// RVA: 0x255A020 Offset: 0x255A020 VA: 0x255A020
	public void set_task_id(long value) { }

	// RVA: 0x255A064 Offset: 0x255A064 VA: 0x255A064
	public bool get_HasTask_id() { }

	// RVA: 0x255A094 Offset: 0x255A094 VA: 0x255A094
	public void .ctor() { }

	// RVA: 0x255A130 Offset: 0x255A130 VA: 0x255A130
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255A1E8 Offset: 0x255A1E8 VA: 0x255A1E8 Slot: 5
	protected override void decode() { }

	// RVA: 0x255A2C4 Offset: 0x255A2C4 VA: 0x255A2C4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255A3E8 Offset: 0x255A3E8 VA: 0x255A3E8 Slot: 3
	public override string ToString() { }

	// RVA: 0x255A498 Offset: 0x255A498 VA: 0x255A498
	private static void .cctor() { }
}
