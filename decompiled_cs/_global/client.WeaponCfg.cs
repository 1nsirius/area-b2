// Namespace: 
public class client.WeaponCfg : SprotoTypeBase // TypeDefIndex: 9068
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _sight; // 0x20
	private long _barrel; // 0x28
	private long _grip; // 0x30
	private long _under_barrel; // 0x38
	private long _spraying; // 0x40
	private long _pendant; // 0x48

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long sight { get; set; }
	public bool HasSight { get; }
	public long barrel { get; set; }
	public bool HasBarrel { get; }
	public long grip { get; set; }
	public bool HasGrip { get; }
	public long under_barrel { get; set; }
	public bool HasUnder_barrel { get; }
	public long spraying { get; set; }
	public bool HasSpraying { get; }
	public long pendant { get; set; }
	public bool HasPendant { get; }

	// Methods

	// RVA: 0x243535C Offset: 0x243535C VA: 0x243535C
	public long get_id() { }

	// RVA: 0x2435364 Offset: 0x2435364 VA: 0x2435364
	public void set_id(long value) { }

	// RVA: 0x24353A8 Offset: 0x24353A8 VA: 0x24353A8
	public bool get_HasId() { }

	// RVA: 0x24353D8 Offset: 0x24353D8 VA: 0x24353D8
	public long get_sight() { }

	// RVA: 0x24353E0 Offset: 0x24353E0 VA: 0x24353E0
	public void set_sight(long value) { }

	// RVA: 0x2435424 Offset: 0x2435424 VA: 0x2435424
	public bool get_HasSight() { }

	// RVA: 0x2435454 Offset: 0x2435454 VA: 0x2435454
	public long get_barrel() { }

	// RVA: 0x243545C Offset: 0x243545C VA: 0x243545C
	public void set_barrel(long value) { }

	// RVA: 0x24354A0 Offset: 0x24354A0 VA: 0x24354A0
	public bool get_HasBarrel() { }

	// RVA: 0x24354D0 Offset: 0x24354D0 VA: 0x24354D0
	public long get_grip() { }

	// RVA: 0x24354D8 Offset: 0x24354D8 VA: 0x24354D8
	public void set_grip(long value) { }

	// RVA: 0x243551C Offset: 0x243551C VA: 0x243551C
	public bool get_HasGrip() { }

	// RVA: 0x243554C Offset: 0x243554C VA: 0x243554C
	public long get_under_barrel() { }

	// RVA: 0x2435554 Offset: 0x2435554 VA: 0x2435554
	public void set_under_barrel(long value) { }

	// RVA: 0x2435598 Offset: 0x2435598 VA: 0x2435598
	public bool get_HasUnder_barrel() { }

	// RVA: 0x24355C8 Offset: 0x24355C8 VA: 0x24355C8
	public long get_spraying() { }

	// RVA: 0x24355D0 Offset: 0x24355D0 VA: 0x24355D0
	public void set_spraying(long value) { }

	// RVA: 0x2435614 Offset: 0x2435614 VA: 0x2435614
	public bool get_HasSpraying() { }

	// RVA: 0x2435644 Offset: 0x2435644 VA: 0x2435644
	public long get_pendant() { }

	// RVA: 0x243564C Offset: 0x243564C VA: 0x243564C
	public void set_pendant(long value) { }

	// RVA: 0x2435690 Offset: 0x2435690 VA: 0x2435690
	public bool get_HasPendant() { }

	// RVA: 0x24356C0 Offset: 0x24356C0 VA: 0x24356C0
	public void .ctor() { }

	// RVA: 0x243575C Offset: 0x243575C VA: 0x243575C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2435814 Offset: 0x2435814 VA: 0x2435814 Slot: 5
	protected override void decode() { }

	// RVA: 0x2435A18 Offset: 0x2435A18 VA: 0x2435A18 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2435D30 Offset: 0x2435D30 VA: 0x2435D30 Slot: 3
	public override string ToString() { }

	// RVA: 0x2436110 Offset: 0x2436110 VA: 0x2436110
	private static void .cctor() { }
}
