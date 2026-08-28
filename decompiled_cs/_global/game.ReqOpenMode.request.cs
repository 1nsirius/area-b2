// Namespace: 
public class game.ReqOpenMode.request : SprotoTypeBase // TypeDefIndex: 9275
{
	// Fields
	private static int max_field_count; // 0x0
	private long _mode_id; // 0x18
	private long _battle_zone; // 0x20

	// Properties
	public long mode_id { get; set; }
	public bool HasMode_id { get; }
	public long battle_zone { get; set; }
	public bool HasBattle_zone { get; }

	// Methods

	// RVA: 0x255D3FC Offset: 0x255D3FC VA: 0x255D3FC
	public long get_mode_id() { }

	// RVA: 0x255D404 Offset: 0x255D404 VA: 0x255D404
	public void set_mode_id(long value) { }

	// RVA: 0x255D448 Offset: 0x255D448 VA: 0x255D448
	public bool get_HasMode_id() { }

	// RVA: 0x255D478 Offset: 0x255D478 VA: 0x255D478
	public long get_battle_zone() { }

	// RVA: 0x255D480 Offset: 0x255D480 VA: 0x255D480
	public void set_battle_zone(long value) { }

	// RVA: 0x255D4C4 Offset: 0x255D4C4 VA: 0x255D4C4
	public bool get_HasBattle_zone() { }

	// RVA: 0x255D4F4 Offset: 0x255D4F4 VA: 0x255D4F4
	public void .ctor() { }

	// RVA: 0x255D590 Offset: 0x255D590 VA: 0x255D590
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255D648 Offset: 0x255D648 VA: 0x255D648 Slot: 5
	protected override void decode() { }

	// RVA: 0x255D724 Offset: 0x255D724 VA: 0x255D724 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255D848 Offset: 0x255D848 VA: 0x255D848 Slot: 3
	public override string ToString() { }

	// RVA: 0x255D8F8 Offset: 0x255D8F8 VA: 0x255D8F8
	private static void .cctor() { }
}
