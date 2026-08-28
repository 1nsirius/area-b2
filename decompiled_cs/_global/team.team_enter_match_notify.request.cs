// Namespace: 
public class team.team_enter_match_notify.request : SprotoTypeBase // TypeDefIndex: 9495
{
	// Fields
	private static int max_field_count; // 0x0
	private long _estimated_time; // 0x18
	private long _start_ts; // 0x20

	// Properties
	public long estimated_time { get; set; }
	public bool HasEstimated_time { get; }
	public long start_ts { get; set; }
	public bool HasStart_ts { get; }

	// Methods

	// RVA: 0xD79394 Offset: 0xD79394 VA: 0xD79394
	public long get_estimated_time() { }

	// RVA: 0xD7939C Offset: 0xD7939C VA: 0xD7939C
	public void set_estimated_time(long value) { }

	// RVA: 0xD793E0 Offset: 0xD793E0 VA: 0xD793E0
	public bool get_HasEstimated_time() { }

	// RVA: 0xD79410 Offset: 0xD79410 VA: 0xD79410
	public long get_start_ts() { }

	// RVA: 0xD79418 Offset: 0xD79418 VA: 0xD79418
	public void set_start_ts(long value) { }

	// RVA: 0xD7945C Offset: 0xD7945C VA: 0xD7945C
	public bool get_HasStart_ts() { }

	// RVA: 0xD7948C Offset: 0xD7948C VA: 0xD7948C
	public void .ctor() { }

	// RVA: 0xD79528 Offset: 0xD79528 VA: 0xD79528
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD795E0 Offset: 0xD795E0 VA: 0xD795E0 Slot: 5
	protected override void decode() { }

	// RVA: 0xD796BC Offset: 0xD796BC VA: 0xD796BC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD797E0 Offset: 0xD797E0 VA: 0xD797E0 Slot: 3
	public override string ToString() { }

	// RVA: 0xD79890 Offset: 0xD79890 VA: 0xD79890
	private static void .cctor() { }
}
