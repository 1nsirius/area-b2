// Namespace: 
public class client.use_skin_to_weapons.request : SprotoTypeBase // TypeDefIndex: 9187
{
	// Fields
	private static int max_field_count; // 0x0
	private long _skin_id; // 0x18
	private List<client.WeaponSkinTarget> _targets; // 0x20

	// Properties
	public long skin_id { get; set; }
	public bool HasSkin_id { get; }
	public List<client.WeaponSkinTarget> targets { get; set; }
	public bool HasTargets { get; }

	// Methods

	// RVA: 0x2546C38 Offset: 0x2546C38 VA: 0x2546C38
	public long get_skin_id() { }

	// RVA: 0x2546C40 Offset: 0x2546C40 VA: 0x2546C40
	public void set_skin_id(long value) { }

	// RVA: 0x2546C84 Offset: 0x2546C84 VA: 0x2546C84
	public bool get_HasSkin_id() { }

	// RVA: 0x2546CB4 Offset: 0x2546CB4 VA: 0x2546CB4
	public List<client.WeaponSkinTarget> get_targets() { }

	// RVA: 0x2546CBC Offset: 0x2546CBC VA: 0x2546CBC
	public void set_targets(List<client.WeaponSkinTarget> value) { }

	// RVA: 0x2546CFC Offset: 0x2546CFC VA: 0x2546CFC
	public bool get_HasTargets() { }

	// RVA: 0x2546D2C Offset: 0x2546D2C VA: 0x2546D2C
	public void .ctor() { }

	// RVA: 0x2546DC8 Offset: 0x2546DC8 VA: 0x2546DC8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2546E80 Offset: 0x2546E80 VA: 0x2546E80 Slot: 5
	protected override void decode() { }

	// RVA: 0x2546FA0 Offset: 0x2546FA0 VA: 0x2546FA0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2547100 Offset: 0x2547100 VA: 0x2547100 Slot: 3
	public override string ToString() { }

	// RVA: 0x25471B0 Offset: 0x25471B0 VA: 0x25471B0
	private static void .cctor() { }
}
