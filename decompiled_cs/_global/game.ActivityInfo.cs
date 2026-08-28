// Namespace: 
public class game.ActivityInfo : SprotoTypeBase // TypeDefIndex: 9193
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private bool _is_in_time; // 0x20
	private List<game.ActivityTaskInfo> _tasks; // 0x24
	private List<game.ActivityValue> _values; // 0x28

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public bool is_in_time { get; set; }
	public bool HasIs_in_time { get; }
	public List<game.ActivityTaskInfo> tasks { get; set; }
	public bool HasTasks { get; }
	public List<game.ActivityValue> values { get; set; }
	public bool HasValues { get; }

	// Methods

	// RVA: 0x254897C Offset: 0x254897C VA: 0x254897C
	public long get_id() { }

	// RVA: 0x2548984 Offset: 0x2548984 VA: 0x2548984
	public void set_id(long value) { }

	// RVA: 0x25489C8 Offset: 0x25489C8 VA: 0x25489C8
	public bool get_HasId() { }

	// RVA: 0x25489F8 Offset: 0x25489F8 VA: 0x25489F8
	public bool get_is_in_time() { }

	// RVA: 0x2548A00 Offset: 0x2548A00 VA: 0x2548A00
	public void set_is_in_time(bool value) { }

	// RVA: 0x2548A40 Offset: 0x2548A40 VA: 0x2548A40
	public bool get_HasIs_in_time() { }

	// RVA: 0x2548A70 Offset: 0x2548A70 VA: 0x2548A70
	public List<game.ActivityTaskInfo> get_tasks() { }

	// RVA: 0x2548A78 Offset: 0x2548A78 VA: 0x2548A78
	public void set_tasks(List<game.ActivityTaskInfo> value) { }

	// RVA: 0x2548AB8 Offset: 0x2548AB8 VA: 0x2548AB8
	public bool get_HasTasks() { }

	// RVA: 0x2548AE8 Offset: 0x2548AE8 VA: 0x2548AE8
	public List<game.ActivityValue> get_values() { }

	// RVA: 0x2548AF0 Offset: 0x2548AF0 VA: 0x2548AF0
	public void set_values(List<game.ActivityValue> value) { }

	// RVA: 0x2548B30 Offset: 0x2548B30 VA: 0x2548B30
	public bool get_HasValues() { }

	// RVA: 0x2548B60 Offset: 0x2548B60 VA: 0x2548B60
	public void .ctor() { }

	// RVA: 0x2548BFC Offset: 0x2548BFC VA: 0x2548BFC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2548CB4 Offset: 0x2548CB4 VA: 0x2548CB4 Slot: 5
	protected override void decode() { }

	// RVA: 0x2548E58 Offset: 0x2548E58 VA: 0x2548E58 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254907C Offset: 0x254907C VA: 0x254907C Slot: 3
	public override string ToString() { }

	// RVA: 0x25492DC Offset: 0x25492DC VA: 0x25492DC
	private static void .cctor() { }
}
