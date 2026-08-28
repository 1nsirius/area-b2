// Namespace: 
public class client.WeaponSkin : SprotoTypeBase // TypeDefIndex: 9069
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private List<long> _skins; // 0x20

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public List<long> skins { get; set; }
	public bool HasSkins { get; }

	// Methods

	// RVA: 0x2436178 Offset: 0x2436178 VA: 0x2436178
	public long get_id() { }

	// RVA: 0x2436180 Offset: 0x2436180 VA: 0x2436180
	public void set_id(long value) { }

	// RVA: 0x24361C4 Offset: 0x24361C4 VA: 0x24361C4
	public bool get_HasId() { }

	// RVA: 0x24361F4 Offset: 0x24361F4 VA: 0x24361F4
	public List<long> get_skins() { }

	// RVA: 0x24361FC Offset: 0x24361FC VA: 0x24361FC
	public void set_skins(List<long> value) { }

	// RVA: 0x243623C Offset: 0x243623C VA: 0x243623C
	public bool get_HasSkins() { }

	// RVA: 0x243626C Offset: 0x243626C VA: 0x243626C
	public void .ctor() { }

	// RVA: 0x2436308 Offset: 0x2436308 VA: 0x2436308
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24363C0 Offset: 0x24363C0 VA: 0x24363C0 Slot: 5
	protected override void decode() { }

	// RVA: 0x2436498 Offset: 0x2436498 VA: 0x2436498 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x24365B0 Offset: 0x24365B0 VA: 0x24365B0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2436660 Offset: 0x2436660 VA: 0x2436660
	private static void .cctor() { }
}
