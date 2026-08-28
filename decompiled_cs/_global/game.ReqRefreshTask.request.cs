// Namespace: 
public class game.ReqRefreshTask.request : SprotoTypeBase // TypeDefIndex: 9287
{
	// Fields
	private static int max_field_count; // 0x0
	private long _slot; // 0x18
	private long _daily_task_last_refresh_timeout; // 0x20

	// Properties
	public long slot { get; set; }
	public bool HasSlot { get; }
	public long daily_task_last_refresh_timeout { get; set; }
	public bool HasDaily_task_last_refresh_timeout { get; }

	// Methods

	// RVA: 0x255EEB4 Offset: 0x255EEB4 VA: 0x255EEB4
	public long get_slot() { }

	// RVA: 0x255EEBC Offset: 0x255EEBC VA: 0x255EEBC
	public void set_slot(long value) { }

	// RVA: 0x255EF00 Offset: 0x255EF00 VA: 0x255EF00
	public bool get_HasSlot() { }

	// RVA: 0x255EF30 Offset: 0x255EF30 VA: 0x255EF30
	public long get_daily_task_last_refresh_timeout() { }

	// RVA: 0x255EF38 Offset: 0x255EF38 VA: 0x255EF38
	public void set_daily_task_last_refresh_timeout(long value) { }

	// RVA: 0x255EF7C Offset: 0x255EF7C VA: 0x255EF7C
	public bool get_HasDaily_task_last_refresh_timeout() { }

	// RVA: 0x255EFAC Offset: 0x255EFAC VA: 0x255EFAC
	public void .ctor() { }

	// RVA: 0x255F048 Offset: 0x255F048 VA: 0x255F048
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255F100 Offset: 0x255F100 VA: 0x255F100 Slot: 5
	protected override void decode() { }

	// RVA: 0x255F1DC Offset: 0x255F1DC VA: 0x255F1DC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255F300 Offset: 0x255F300 VA: 0x255F300 Slot: 3
	public override string ToString() { }

	// RVA: 0x255F3B0 Offset: 0x255F3B0 VA: 0x255F3B0
	private static void .cctor() { }
}
