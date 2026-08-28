// Namespace: 
public class game.RspSyncChangedTaskInfo.request : SprotoTypeBase // TypeDefIndex: 9383
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.TaskInfo> _tasks_info; // 0x14
	private long _cur_refresh_cnt; // 0x18
	private long _daily_task_last_refresh_timeout; // 0x20

	// Properties
	public List<game.TaskInfo> tasks_info { get; set; }
	public bool HasTasks_info { get; }
	public long cur_refresh_cnt { get; set; }
	public bool HasCur_refresh_cnt { get; }
	public long daily_task_last_refresh_timeout { get; set; }
	public bool HasDaily_task_last_refresh_timeout { get; }

	// Methods

	// RVA: 0x22667EC Offset: 0x22667EC VA: 0x22667EC
	public List<game.TaskInfo> get_tasks_info() { }

	// RVA: 0x22667F4 Offset: 0x22667F4 VA: 0x22667F4
	public void set_tasks_info(List<game.TaskInfo> value) { }

	// RVA: 0x2266834 Offset: 0x2266834 VA: 0x2266834
	public bool get_HasTasks_info() { }

	// RVA: 0x2266864 Offset: 0x2266864 VA: 0x2266864
	public long get_cur_refresh_cnt() { }

	// RVA: 0x226686C Offset: 0x226686C VA: 0x226686C
	public void set_cur_refresh_cnt(long value) { }

	// RVA: 0x22668B0 Offset: 0x22668B0 VA: 0x22668B0
	public bool get_HasCur_refresh_cnt() { }

	// RVA: 0x22668E0 Offset: 0x22668E0 VA: 0x22668E0
	public long get_daily_task_last_refresh_timeout() { }

	// RVA: 0x22668E8 Offset: 0x22668E8 VA: 0x22668E8
	public void set_daily_task_last_refresh_timeout(long value) { }

	// RVA: 0x226692C Offset: 0x226692C VA: 0x226692C
	public bool get_HasDaily_task_last_refresh_timeout() { }

	// RVA: 0x226695C Offset: 0x226695C VA: 0x226695C
	public void .ctor() { }

	// RVA: 0x22669F8 Offset: 0x22669F8 VA: 0x22669F8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2266AB0 Offset: 0x2266AB0 VA: 0x2266AB0 Slot: 5
	protected override void decode() { }

	// RVA: 0x2266C18 Offset: 0x2266C18 VA: 0x2266C18 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2266DE0 Offset: 0x2266DE0 VA: 0x2266DE0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2266EB8 Offset: 0x2266EB8 VA: 0x2266EB8
	private static void .cctor() { }
}
