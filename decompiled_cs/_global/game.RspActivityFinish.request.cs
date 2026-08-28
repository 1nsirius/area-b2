// Namespace: 
public class game.RspActivityFinish.request : SprotoTypeBase // TypeDefIndex: 9309
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

	// RVA: 0x2257BB8 Offset: 0x2257BB8 VA: 0x2257BB8
	public long get_activity_id() { }

	// RVA: 0x2257BC0 Offset: 0x2257BC0 VA: 0x2257BC0
	public void set_activity_id(long value) { }

	// RVA: 0x2257C04 Offset: 0x2257C04 VA: 0x2257C04
	public bool get_HasActivity_id() { }

	// RVA: 0x2257C34 Offset: 0x2257C34 VA: 0x2257C34
	public long get_task_id() { }

	// RVA: 0x2257C3C Offset: 0x2257C3C VA: 0x2257C3C
	public void set_task_id(long value) { }

	// RVA: 0x2257C80 Offset: 0x2257C80 VA: 0x2257C80
	public bool get_HasTask_id() { }

	// RVA: 0x2257CB0 Offset: 0x2257CB0 VA: 0x2257CB0
	public void .ctor() { }

	// RVA: 0x2257D4C Offset: 0x2257D4C VA: 0x2257D4C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2257E04 Offset: 0x2257E04 VA: 0x2257E04 Slot: 5
	protected override void decode() { }

	// RVA: 0x2257EE0 Offset: 0x2257EE0 VA: 0x2257EE0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2258004 Offset: 0x2258004 VA: 0x2258004 Slot: 3
	public override string ToString() { }

	// RVA: 0x22580B4 Offset: 0x22580B4 VA: 0x22580B4
	private static void .cctor() { }
}
