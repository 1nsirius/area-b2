// Namespace: 
public class game.ReqRefreshTask.response : SprotoTypeBase // TypeDefIndex: 9288
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _cur_refresh_cnt; // 0x20
	private long _daily_task_last_refresh_timeout; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long cur_refresh_cnt { get; set; }
	public bool HasCur_refresh_cnt { get; }
	public long daily_task_last_refresh_timeout { get; set; }
	public bool HasDaily_task_last_refresh_timeout { get; }

	// Methods

	// RVA: 0x255F418 Offset: 0x255F418 VA: 0x255F418
	public long get_errorcode() { }

	// RVA: 0x255F420 Offset: 0x255F420 VA: 0x255F420
	public void set_errorcode(long value) { }

	// RVA: 0x255F464 Offset: 0x255F464 VA: 0x255F464
	public bool get_HasErrorcode() { }

	// RVA: 0x255F494 Offset: 0x255F494 VA: 0x255F494
	public long get_cur_refresh_cnt() { }

	// RVA: 0x255F49C Offset: 0x255F49C VA: 0x255F49C
	public void set_cur_refresh_cnt(long value) { }

	// RVA: 0x255F4E0 Offset: 0x255F4E0 VA: 0x255F4E0
	public bool get_HasCur_refresh_cnt() { }

	// RVA: 0x255F510 Offset: 0x255F510 VA: 0x255F510
	public long get_daily_task_last_refresh_timeout() { }

	// RVA: 0x255F518 Offset: 0x255F518 VA: 0x255F518
	public void set_daily_task_last_refresh_timeout(long value) { }

	// RVA: 0x255F55C Offset: 0x255F55C VA: 0x255F55C
	public bool get_HasDaily_task_last_refresh_timeout() { }

	// RVA: 0x255F58C Offset: 0x255F58C VA: 0x255F58C
	public void .ctor() { }

	// RVA: 0x255F628 Offset: 0x255F628 VA: 0x255F628
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255F6E0 Offset: 0x255F6E0 VA: 0x255F6E0 Slot: 5
	protected override void decode() { }

	// RVA: 0x255F804 Offset: 0x255F804 VA: 0x255F804 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255F98C Offset: 0x255F98C VA: 0x255F98C Slot: 3
	public override string ToString() { }

	// RVA: 0x255FA64 Offset: 0x255FA64 VA: 0x255FA64
	private static void .cctor() { }
}
