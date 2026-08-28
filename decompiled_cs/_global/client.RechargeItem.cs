// Namespace: 
public class client.RechargeItem : SprotoTypeBase // TypeDefIndex: 9065
{
	// Fields
	private static int max_field_count; // 0x0
	private string _product_id; // 0x14
	private long _base_currency; // 0x18
	private long _bonus_currency; // 0x20
	private bool _is_double; // 0x28

	// Properties
	public string product_id { get; set; }
	public bool HasProduct_id { get; }
	public long base_currency { get; set; }
	public bool HasBase_currency { get; }
	public long bonus_currency { get; set; }
	public bool HasBonus_currency { get; }
	public bool is_double { get; set; }
	public bool HasIs_double { get; }

	// Methods

	// RVA: 0x2433B94 Offset: 0x2433B94 VA: 0x2433B94
	public string get_product_id() { }

	// RVA: 0x2433B9C Offset: 0x2433B9C VA: 0x2433B9C
	public void set_product_id(string value) { }

	// RVA: 0x2433BDC Offset: 0x2433BDC VA: 0x2433BDC
	public bool get_HasProduct_id() { }

	// RVA: 0x2433C0C Offset: 0x2433C0C VA: 0x2433C0C
	public long get_base_currency() { }

	// RVA: 0x2433C14 Offset: 0x2433C14 VA: 0x2433C14
	public void set_base_currency(long value) { }

	// RVA: 0x2433C58 Offset: 0x2433C58 VA: 0x2433C58
	public bool get_HasBase_currency() { }

	// RVA: 0x2433C88 Offset: 0x2433C88 VA: 0x2433C88
	public long get_bonus_currency() { }

	// RVA: 0x2433C90 Offset: 0x2433C90 VA: 0x2433C90
	public void set_bonus_currency(long value) { }

	// RVA: 0x2433CD4 Offset: 0x2433CD4 VA: 0x2433CD4
	public bool get_HasBonus_currency() { }

	// RVA: 0x2433D04 Offset: 0x2433D04 VA: 0x2433D04
	public bool get_is_double() { }

	// RVA: 0x2433D0C Offset: 0x2433D0C VA: 0x2433D0C
	public void set_is_double(bool value) { }

	// RVA: 0x2433D4C Offset: 0x2433D4C VA: 0x2433D4C
	public bool get_HasIs_double() { }

	// RVA: 0x2433D7C Offset: 0x2433D7C VA: 0x2433D7C
	public void .ctor() { }

	// RVA: 0x2433E18 Offset: 0x2433E18 VA: 0x2433E18
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2433ED0 Offset: 0x2433ED0 VA: 0x2433ED0 Slot: 5
	protected override void decode() { }

	// RVA: 0x2434024 Offset: 0x2434024 VA: 0x2434024 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2434204 Offset: 0x2434204 VA: 0x2434204 Slot: 3
	public override string ToString() { }

	// RVA: 0x2434458 Offset: 0x2434458 VA: 0x2434458
	private static void .cctor() { }
}
