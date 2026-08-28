// Namespace: 
public class client.recharge_success_notify.request : SprotoTypeBase // TypeDefIndex: 9162
{
	// Fields
	private static int max_field_count; // 0x0
	private string _money_type; // 0x14
	private long _money; // 0x18
	private string _pruduct_id; // 0x20
	private long _amount; // 0x28
	private string _attach_params; // 0x30

	// Properties
	public string money_type { get; set; }
	public bool HasMoney_type { get; }
	public long money { get; set; }
	public bool HasMoney { get; }
	public string pruduct_id { get; set; }
	public bool HasPruduct_id { get; }
	public long amount { get; set; }
	public bool HasAmount { get; }
	public string attach_params { get; set; }
	public bool HasAttach_params { get; }

	// Methods

	// RVA: 0x244A860 Offset: 0x244A860 VA: 0x244A860
	public string get_money_type() { }

	// RVA: 0x244A868 Offset: 0x244A868 VA: 0x244A868
	public void set_money_type(string value) { }

	// RVA: 0x244A8A8 Offset: 0x244A8A8 VA: 0x244A8A8
	public bool get_HasMoney_type() { }

	// RVA: 0x244A8D8 Offset: 0x244A8D8 VA: 0x244A8D8
	public long get_money() { }

	// RVA: 0x244A8E0 Offset: 0x244A8E0 VA: 0x244A8E0
	public void set_money(long value) { }

	// RVA: 0x244A924 Offset: 0x244A924 VA: 0x244A924
	public bool get_HasMoney() { }

	// RVA: 0x244A954 Offset: 0x244A954 VA: 0x244A954
	public string get_pruduct_id() { }

	// RVA: 0x244A95C Offset: 0x244A95C VA: 0x244A95C
	public void set_pruduct_id(string value) { }

	// RVA: 0x244A99C Offset: 0x244A99C VA: 0x244A99C
	public bool get_HasPruduct_id() { }

	// RVA: 0x244A9CC Offset: 0x244A9CC VA: 0x244A9CC
	public long get_amount() { }

	// RVA: 0x244A9D4 Offset: 0x244A9D4 VA: 0x244A9D4
	public void set_amount(long value) { }

	// RVA: 0x244AA18 Offset: 0x244AA18 VA: 0x244AA18
	public bool get_HasAmount() { }

	// RVA: 0x244AA48 Offset: 0x244AA48 VA: 0x244AA48
	public string get_attach_params() { }

	// RVA: 0x244AA50 Offset: 0x244AA50 VA: 0x244AA50
	public void set_attach_params(string value) { }

	// RVA: 0x244AA90 Offset: 0x244AA90 VA: 0x244AA90
	public bool get_HasAttach_params() { }

	// RVA: 0x244AAC0 Offset: 0x244AAC0 VA: 0x244AAC0
	public void .ctor() { }

	// RVA: 0x244AB5C Offset: 0x244AB5C VA: 0x244AB5C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244AC14 Offset: 0x244AC14 VA: 0x244AC14 Slot: 5
	protected override void decode() { }

	// RVA: 0x244AD9C Offset: 0x244AD9C VA: 0x244AD9C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244AFCC Offset: 0x244AFCC VA: 0x244AFCC Slot: 3
	public override string ToString() { }

	// RVA: 0x244B250 Offset: 0x244B250 VA: 0x244B250
	private static void .cctor() { }
}
