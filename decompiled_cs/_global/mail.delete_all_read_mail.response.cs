// Namespace: 
public class mail.delete_all_read_mail.response : SprotoTypeBase // TypeDefIndex: 9433
{
	// Fields
	private static int max_field_count; // 0x0
	private long _operate_type; // 0x18
	private List<long> _mail_ids; // 0x20

	// Properties
	public long operate_type { get; set; }
	public bool HasOperate_type { get; }
	public List<long> mail_ids { get; set; }
	public bool HasMail_ids { get; }

	// Methods

	// RVA: 0xD6D80C Offset: 0xD6D80C VA: 0xD6D80C
	public long get_operate_type() { }

	// RVA: 0xD6D814 Offset: 0xD6D814 VA: 0xD6D814
	public void set_operate_type(long value) { }

	// RVA: 0xD6D858 Offset: 0xD6D858 VA: 0xD6D858
	public bool get_HasOperate_type() { }

	// RVA: 0xD6D888 Offset: 0xD6D888 VA: 0xD6D888
	public List<long> get_mail_ids() { }

	// RVA: 0xD6D890 Offset: 0xD6D890 VA: 0xD6D890
	public void set_mail_ids(List<long> value) { }

	// RVA: 0xD6D8D0 Offset: 0xD6D8D0 VA: 0xD6D8D0
	public bool get_HasMail_ids() { }

	// RVA: 0xD6D900 Offset: 0xD6D900 VA: 0xD6D900
	public void .ctor() { }

	// RVA: 0xD6D99C Offset: 0xD6D99C VA: 0xD6D99C
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD6DA54 Offset: 0xD6DA54 VA: 0xD6DA54 Slot: 5
	protected override void decode() { }

	// RVA: 0xD6DB2C Offset: 0xD6DB2C VA: 0xD6DB2C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD6DC44 Offset: 0xD6DC44 VA: 0xD6DC44 Slot: 3
	public override string ToString() { }

	// RVA: 0xD6DCF4 Offset: 0xD6DCF4 VA: 0xD6DCF4
	private static void .cctor() { }
}
