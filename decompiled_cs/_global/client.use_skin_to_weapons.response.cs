// Namespace: 
public class client.use_skin_to_weapons.response : SprotoTypeBase // TypeDefIndex: 9188
{
	// Fields
	private static int max_field_count; // 0x0
	private long _skin_id; // 0x18
	private List<client.WeaponSkinTarget> _failed_targets; // 0x20

	// Properties
	public long skin_id { get; set; }
	public bool HasSkin_id { get; }
	public List<client.WeaponSkinTarget> failed_targets { get; set; }
	public bool HasFailed_targets { get; }

	// Methods

	// RVA: 0x2547218 Offset: 0x2547218 VA: 0x2547218
	public long get_skin_id() { }

	// RVA: 0x2547220 Offset: 0x2547220 VA: 0x2547220
	public void set_skin_id(long value) { }

	// RVA: 0x2547264 Offset: 0x2547264 VA: 0x2547264
	public bool get_HasSkin_id() { }

	// RVA: 0x2547294 Offset: 0x2547294 VA: 0x2547294
	public List<client.WeaponSkinTarget> get_failed_targets() { }

	// RVA: 0x254729C Offset: 0x254729C VA: 0x254729C
	public void set_failed_targets(List<client.WeaponSkinTarget> value) { }

	// RVA: 0x25472DC Offset: 0x25472DC VA: 0x25472DC
	public bool get_HasFailed_targets() { }

	// RVA: 0x254730C Offset: 0x254730C VA: 0x254730C
	public void .ctor() { }

	// RVA: 0x25473A8 Offset: 0x25473A8 VA: 0x25473A8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2547460 Offset: 0x2547460 VA: 0x2547460 Slot: 5
	protected override void decode() { }

	// RVA: 0x2547580 Offset: 0x2547580 VA: 0x2547580 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x25476E0 Offset: 0x25476E0 VA: 0x25476E0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2547790 Offset: 0x2547790 VA: 0x2547790
	private static void .cctor() { }
}
