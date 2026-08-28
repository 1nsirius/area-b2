// Namespace: 
public class game.ReqChooseMap.request : SprotoTypeBase // TypeDefIndex: 9235
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

	// RVA: 0x2556EF8 Offset: 0x2556EF8 VA: 0x2556EF8
	public long get_map_id() { }

	// RVA: 0x2556F00 Offset: 0x2556F00 VA: 0x2556F00
	public void set_map_id(long value) { }

	// RVA: 0x2556F44 Offset: 0x2556F44 VA: 0x2556F44
	public bool get_HasMap_id() { }

	// RVA: 0x2556F74 Offset: 0x2556F74 VA: 0x2556F74
	public long get_mode_id() { }

	// RVA: 0x2556F7C Offset: 0x2556F7C VA: 0x2556F7C
	public void set_mode_id(long value) { }

	// RVA: 0x2556FC0 Offset: 0x2556FC0 VA: 0x2556FC0
	public bool get_HasMode_id() { }

	// RVA: 0x2556FF0 Offset: 0x2556FF0 VA: 0x2556FF0
	public void .ctor() { }

	// RVA: 0x255708C Offset: 0x255708C VA: 0x255708C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2557144 Offset: 0x2557144 VA: 0x2557144 Slot: 5
	protected override void decode() { }

	// RVA: 0x2557220 Offset: 0x2557220 VA: 0x2557220 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2557344 Offset: 0x2557344 VA: 0x2557344 Slot: 3
	public override string ToString() { }

	// RVA: 0x25573F4 Offset: 0x25573F4 VA: 0x25573F4
	private static void .cctor() { }
}
