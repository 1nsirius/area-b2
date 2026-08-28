// Namespace: 
public class game.RspChooseMap.request : SprotoTypeBase // TypeDefIndex: 9335
{
	// Fields
	private static int max_field_count; // 0x0
	private long _map_id; // 0x18
	private long _mode_id; // 0x20

	// Properties
	public long map_id { get; set; }
	public bool HasMap_id { get; }
	public long mode_id { get; set; }
	public bool HasMode_id { get; }

	// Methods

	// RVA: 0x225CACC Offset: 0x225CACC VA: 0x225CACC
	public long get_map_id() { }

	// RVA: 0x225CAD4 Offset: 0x225CAD4 VA: 0x225CAD4
	public void set_map_id(long value) { }

	// RVA: 0x225CB18 Offset: 0x225CB18 VA: 0x225CB18
	public bool get_HasMap_id() { }

	// RVA: 0x225CB48 Offset: 0x225CB48 VA: 0x225CB48
	public long get_mode_id() { }

	// RVA: 0x225CB50 Offset: 0x225CB50 VA: 0x225CB50
	public void set_mode_id(long value) { }

	// RVA: 0x225CB94 Offset: 0x225CB94 VA: 0x225CB94
	public bool get_HasMode_id() { }

	// RVA: 0x225CBC4 Offset: 0x225CBC4 VA: 0x225CBC4
	public void .ctor() { }

	// RVA: 0x225CC60 Offset: 0x225CC60 VA: 0x225CC60
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225CD18 Offset: 0x225CD18 VA: 0x225CD18 Slot: 5
	protected override void decode() { }

	// RVA: 0x225CDF4 Offset: 0x225CDF4 VA: 0x225CDF4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225CF18 Offset: 0x225CF18 VA: 0x225CF18 Slot: 3
	public override string ToString() { }

	// RVA: 0x225CFC8 Offset: 0x225CFC8 VA: 0x225CFC8
	private static void .cctor() { }
}
