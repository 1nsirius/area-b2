// Namespace: 
public class game.ActivityValue : SprotoTypeBase // TypeDefIndex: 9195
{
	// Fields
	private static int max_field_count; // 0x0
	private string _key; // 0x14
	private long _value1; // 0x18

	// Properties
	public string key { get; set; }
	public bool HasKey { get; }
	public long value1 { get; set; }
	public bool HasValue1 { get; }

	// Methods

	// RVA: 0x2549CB0 Offset: 0x2549CB0 VA: 0x2549CB0
	public string get_key() { }

	// RVA: 0x2549CB8 Offset: 0x2549CB8 VA: 0x2549CB8
	public void set_key(string value) { }

	// RVA: 0x2549CF8 Offset: 0x2549CF8 VA: 0x2549CF8
	public bool get_HasKey() { }

	// RVA: 0x2549D28 Offset: 0x2549D28 VA: 0x2549D28
	public long get_value1() { }

	// RVA: 0x2549D30 Offset: 0x2549D30 VA: 0x2549D30
	public void set_value1(long value) { }

	// RVA: 0x2549D74 Offset: 0x2549D74 VA: 0x2549D74
	public bool get_HasValue1() { }

	// RVA: 0x2549DA4 Offset: 0x2549DA4 VA: 0x2549DA4
	public void .ctor() { }

	// RVA: 0x2549E40 Offset: 0x2549E40 VA: 0x2549E40
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2549EF8 Offset: 0x2549EF8 VA: 0x2549EF8 Slot: 5
	protected override void decode() { }

	// RVA: 0x2549FD0 Offset: 0x2549FD0 VA: 0x2549FD0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254A0EC Offset: 0x254A0EC VA: 0x254A0EC Slot: 3
	public override string ToString() { }

	// RVA: 0x254A188 Offset: 0x254A188 VA: 0x254A188
	private static void .cctor() { }
}
