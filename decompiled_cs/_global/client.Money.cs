// Namespace: 
public class client.Money : SprotoTypeBase // TypeDefIndex: 9064
{
	// Fields
	private static int max_field_count; // 0x0
	private string _money_type; // 0x14
	private long _money; // 0x18

	// Properties
	public string money_type { get; set; }
	public bool HasMoney_type { get; }
	public long money { get; set; }
	public bool HasMoney { get; }

	// Methods

	// RVA: 0x2433654 Offset: 0x2433654 VA: 0x2433654
	public string get_money_type() { }

	// RVA: 0x243365C Offset: 0x243365C VA: 0x243365C
	public void set_money_type(string value) { }

	// RVA: 0x243369C Offset: 0x243369C VA: 0x243369C
	public bool get_HasMoney_type() { }

	// RVA: 0x24336CC Offset: 0x24336CC VA: 0x24336CC
	public long get_money() { }

	// RVA: 0x24336D4 Offset: 0x24336D4 VA: 0x24336D4
	public void set_money(long value) { }

	// RVA: 0x2433718 Offset: 0x2433718 VA: 0x2433718
	public bool get_HasMoney() { }

	// RVA: 0x2433748 Offset: 0x2433748 VA: 0x2433748
	public void .ctor() { }

	// RVA: 0x24337E4 Offset: 0x24337E4 VA: 0x24337E4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243389C Offset: 0x243389C VA: 0x243389C Slot: 5
	protected override void decode() { }

	// RVA: 0x2433974 Offset: 0x2433974 VA: 0x2433974 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2433A90 Offset: 0x2433A90 VA: 0x2433A90 Slot: 3
	public override string ToString() { }

	// RVA: 0x2433B2C Offset: 0x2433B2C VA: 0x2433B2C
	private static void .cctor() { }
}
