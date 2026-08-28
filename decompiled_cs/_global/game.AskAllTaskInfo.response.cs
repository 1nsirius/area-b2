// Namespace: 
public class game.AskAllTaskInfo.response : SprotoTypeBase // TypeDefIndex: 9198
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

	// RVA: 0x254A45C Offset: 0x254A45C VA: 0x254A45C
	public List<game.TaskInfo> get_tasks_info() { }

	// RVA: 0x254A464 Offset: 0x254A464 VA: 0x254A464
	public void set_tasks_info(List<game.TaskInfo> value) { }

	// RVA: 0x254A4A4 Offset: 0x254A4A4 VA: 0x254A4A4
	public bool get_HasTasks_info() { }

	// RVA: 0x254A4D4 Offset: 0x254A4D4 VA: 0x254A4D4
	public long get_cur_refresh_cnt() { }

	// RVA: 0x254A4DC Offset: 0x254A4DC VA: 0x254A4DC
	public void set_cur_refresh_cnt(long value) { }

	// RVA: 0x254A520 Offset: 0x254A520 VA: 0x254A520
	public bool get_HasCur_refresh_cnt() { }

	// RVA: 0x254A550 Offset: 0x254A550 VA: 0x254A550
	public long get_daily_task_last_refresh_timeout() { }

	// RVA: 0x254A558 Offset: 0x254A558 VA: 0x254A558
	public void set_daily_task_last_refresh_timeout(long value) { }

	// RVA: 0x254A59C Offset: 0x254A59C VA: 0x254A59C
	public bool get_HasDaily_task_last_refresh_timeout() { }

	// RVA: 0x254A5CC Offset: 0x254A5CC VA: 0x254A5CC
	public void .ctor() { }

	// RVA: 0x254A668 Offset: 0x254A668 VA: 0x254A668
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254A720 Offset: 0x254A720 VA: 0x254A720 Slot: 5
	protected override void decode() { }

	// RVA: 0x254A888 Offset: 0x254A888 VA: 0x254A888 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254AA50 Offset: 0x254AA50 VA: 0x254AA50 Slot: 3
	public override string ToString() { }

	// RVA: 0x254AB28 Offset: 0x254AB28 VA: 0x254AB28
	private static void .cctor() { }
}
