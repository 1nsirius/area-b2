// Namespace: 
public class mail.operate_mail.request : SprotoTypeBase // TypeDefIndex: 9446
{
	// Fields
	private static int max_field_count; // 0x0
	private long _operate_type; // 0x18
	private long _mail_id; // 0x20

	// Properties
	public long operate_type { get; set; }
	public bool HasOperate_type { get; }
	public long mail_id { get; set; }
	public bool HasMail_id { get; }

	// Methods

	// RVA: 0xD6F678 Offset: 0xD6F678 VA: 0xD6F678
	public long get_operate_type() { }

	// RVA: 0xD6F680 Offset: 0xD6F680 VA: 0xD6F680
	public void set_operate_type(long value) { }

	// RVA: 0xD6F6C4 Offset: 0xD6F6C4 VA: 0xD6F6C4
	public bool get_HasOperate_type() { }

	// RVA: 0xD6F6F4 Offset: 0xD6F6F4 VA: 0xD6F6F4
	public long get_mail_id() { }

	// RVA: 0xD6F6FC Offset: 0xD6F6FC VA: 0xD6F6FC
	public void set_mail_id(long value) { }

	// RVA: 0xD6F740 Offset: 0xD6F740 VA: 0xD6F740
	public bool get_HasMail_id() { }

	// RVA: 0xD6F770 Offset: 0xD6F770 VA: 0xD6F770
	public void .ctor() { }

	// RVA: 0xD6F80C Offset: 0xD6F80C VA: 0xD6F80C
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD6F8C4 Offset: 0xD6F8C4 VA: 0xD6F8C4 Slot: 5
	protected override void decode() { }

	// RVA: 0xD6F9A0 Offset: 0xD6F9A0 VA: 0xD6F9A0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD6FAC4 Offset: 0xD6FAC4 VA: 0xD6FAC4 Slot: 3
	public override string ToString() { }

	// RVA: 0xD6FB74 Offset: 0xD6FB74 VA: 0xD6FB74
	private static void .cctor() { }
}
