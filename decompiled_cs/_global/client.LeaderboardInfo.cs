// Namespace: 
public class client.LeaderboardInfo : SprotoTypeBase // TypeDefIndex: 9062
{
	// Fields
	private static int max_field_count; // 0x0
	private string _name; // 0x14
	private long _label1; // 0x18
	private long _label2; // 0x20
	private long _label3; // 0x28

	// Properties
	public string name { get; set; }
	public bool HasName { get; }
	public long label1 { get; set; }
	public bool HasLabel1 { get; }
	public long label2 { get; set; }
	public bool HasLabel2 { get; }
	public long label3 { get; set; }
	public bool HasLabel3 { get; }

	// Methods

	// RVA: 0x24320B4 Offset: 0x24320B4 VA: 0x24320B4
	public string get_name() { }

	// RVA: 0x24320BC Offset: 0x24320BC VA: 0x24320BC
	public void set_name(string value) { }

	// RVA: 0x24320FC Offset: 0x24320FC VA: 0x24320FC
	public bool get_HasName() { }

	// RVA: 0x243212C Offset: 0x243212C VA: 0x243212C
	public long get_label1() { }

	// RVA: 0x2432134 Offset: 0x2432134 VA: 0x2432134
	public void set_label1(long value) { }

	// RVA: 0x2432178 Offset: 0x2432178 VA: 0x2432178
	public bool get_HasLabel1() { }

	// RVA: 0x24321A8 Offset: 0x24321A8 VA: 0x24321A8
	public long get_label2() { }

	// RVA: 0x24321B0 Offset: 0x24321B0 VA: 0x24321B0
	public void set_label2(long value) { }

	// RVA: 0x24321F4 Offset: 0x24321F4 VA: 0x24321F4
	public bool get_HasLabel2() { }

	// RVA: 0x2432224 Offset: 0x2432224 VA: 0x2432224
	public long get_label3() { }

	// RVA: 0x243222C Offset: 0x243222C VA: 0x243222C
	public void set_label3(long value) { }

	// RVA: 0x2432270 Offset: 0x2432270 VA: 0x2432270
	public bool get_HasLabel3() { }

	// RVA: 0x24322A0 Offset: 0x24322A0 VA: 0x24322A0
	public void .ctor() { }

	// RVA: 0x243233C Offset: 0x243233C VA: 0x243233C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24323F4 Offset: 0x24323F4 VA: 0x24323F4 Slot: 5
	protected override void decode() { }

	// RVA: 0x243254C Offset: 0x243254C VA: 0x243254C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2432730 Offset: 0x2432730 VA: 0x2432730 Slot: 3
	public override string ToString() { }

	// RVA: 0x2432984 Offset: 0x2432984 VA: 0x2432984
	private static void .cctor() { }
}
