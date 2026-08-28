// Namespace: 
public class client.skin_update_notify.request : SprotoTypeBase // TypeDefIndex: 9168
{
	// Fields
	private static int max_field_count; // 0x0
	private List<client.Skin> _skin; // 0x14
	private long _num; // 0x18

	// Properties
	public List<client.Skin> skin { get; set; }
	public bool HasSkin { get; }
	public long num { get; set; }
	public bool HasNum { get; }

	// Methods

	// RVA: 0x244D6B0 Offset: 0x244D6B0 VA: 0x244D6B0
	public List<client.Skin> get_skin() { }

	// RVA: 0x244D6B8 Offset: 0x244D6B8 VA: 0x244D6B8
	public void set_skin(List<client.Skin> value) { }

	// RVA: 0x244D6F8 Offset: 0x244D6F8 VA: 0x244D6F8
	public bool get_HasSkin() { }

	// RVA: 0x244D728 Offset: 0x244D728 VA: 0x244D728
	public long get_num() { }

	// RVA: 0x244D730 Offset: 0x244D730 VA: 0x244D730
	public void set_num(long value) { }

	// RVA: 0x244D774 Offset: 0x244D774 VA: 0x244D774
	public bool get_HasNum() { }

	// RVA: 0x244D7A4 Offset: 0x244D7A4 VA: 0x244D7A4
	public void .ctor() { }

	// RVA: 0x244D840 Offset: 0x244D840 VA: 0x244D840
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244D8F8 Offset: 0x244D8F8 VA: 0x244D8F8 Slot: 5
	protected override void decode() { }

	// RVA: 0x244DA18 Offset: 0x244DA18 VA: 0x244DA18 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244DB7C Offset: 0x244DB7C VA: 0x244DB7C Slot: 3
	public override string ToString() { }

	// RVA: 0x244DC2C Offset: 0x244DC2C VA: 0x244DC2C
	private static void .cctor() { }
}
