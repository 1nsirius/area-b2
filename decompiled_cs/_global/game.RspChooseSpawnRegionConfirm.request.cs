// Namespace: 
public class game.RspChooseSpawnRegionConfirm.request : SprotoTypeBase // TypeDefIndex: 9337
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _region_id; // 0x20

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long region_id { get; set; }
	public bool HasRegion_id { get; }

	// Methods

	// RVA: 0x225D038 Offset: 0x225D038 VA: 0x225D038
	public long get_uid() { }

	// RVA: 0x225D040 Offset: 0x225D040 VA: 0x225D040
	public void set_uid(long value) { }

	// RVA: 0x225D084 Offset: 0x225D084 VA: 0x225D084
	public bool get_HasUid() { }

	// RVA: 0x225D0B4 Offset: 0x225D0B4 VA: 0x225D0B4
	public long get_region_id() { }

	// RVA: 0x225D0BC Offset: 0x225D0BC VA: 0x225D0BC
	public void set_region_id(long value) { }

	// RVA: 0x225D100 Offset: 0x225D100 VA: 0x225D100
	public bool get_HasRegion_id() { }

	// RVA: 0x225D130 Offset: 0x225D130 VA: 0x225D130
	public void .ctor() { }

	// RVA: 0x225D1CC Offset: 0x225D1CC VA: 0x225D1CC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225D284 Offset: 0x225D284 VA: 0x225D284 Slot: 5
	protected override void decode() { }

	// RVA: 0x225D360 Offset: 0x225D360 VA: 0x225D360 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225D484 Offset: 0x225D484 VA: 0x225D484 Slot: 3
	public override string ToString() { }

	// RVA: 0x225D534 Offset: 0x225D534 VA: 0x225D534
	private static void .cctor() { }
}
