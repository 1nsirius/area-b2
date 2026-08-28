// Namespace: 
public class game.ReqUserGuide.request : SprotoTypeBase // TypeDefIndex: 9303
{
	// Fields
	private static int max_field_count; // 0x0
	private long _guide_id; // 0x18
	private long _battle_zone; // 0x20

	// Properties
	public long guide_id { get; set; }
	public bool HasGuide_id { get; }
	public long battle_zone { get; set; }
	public bool HasBattle_zone { get; }

	// Methods

	// RVA: 0x225644C Offset: 0x225644C VA: 0x225644C
	public long get_guide_id() { }

	// RVA: 0x2256454 Offset: 0x2256454 VA: 0x2256454
	public void set_guide_id(long value) { }

	// RVA: 0x2256498 Offset: 0x2256498 VA: 0x2256498
	public bool get_HasGuide_id() { }

	// RVA: 0x22564C8 Offset: 0x22564C8 VA: 0x22564C8
	public long get_battle_zone() { }

	// RVA: 0x22564D0 Offset: 0x22564D0 VA: 0x22564D0
	public void set_battle_zone(long value) { }

	// RVA: 0x2256514 Offset: 0x2256514 VA: 0x2256514
	public bool get_HasBattle_zone() { }

	// RVA: 0x2256544 Offset: 0x2256544 VA: 0x2256544
	public void .ctor() { }

	// RVA: 0x22565E0 Offset: 0x22565E0 VA: 0x22565E0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2256698 Offset: 0x2256698 VA: 0x2256698 Slot: 5
	protected override void decode() { }

	// RVA: 0x2256774 Offset: 0x2256774 VA: 0x2256774 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2256898 Offset: 0x2256898 VA: 0x2256898 Slot: 3
	public override string ToString() { }

	// RVA: 0x2256948 Offset: 0x2256948 VA: 0x2256948
	private static void .cctor() { }
}
