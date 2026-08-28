// Namespace: 
public class mail.operate_mail.response : SprotoTypeBase // TypeDefIndex: 9447
{
	// Fields
	private static int max_field_count; // 0x0
	private long _operate_type; // 0x18
	private mail.MailOperateRes _operate_result; // 0x20

	// Properties
	public long operate_type { get; set; }
	public bool HasOperate_type { get; }
	public mail.MailOperateRes operate_result { get; set; }
	public bool HasOperate_result { get; }

	// Methods

	// RVA: 0xD6FBDC Offset: 0xD6FBDC VA: 0xD6FBDC
	public long get_operate_type() { }

	// RVA: 0xD6FBE4 Offset: 0xD6FBE4 VA: 0xD6FBE4
	public void set_operate_type(long value) { }

	// RVA: 0xD6FC28 Offset: 0xD6FC28 VA: 0xD6FC28
	public bool get_HasOperate_type() { }

	// RVA: 0xD6FC58 Offset: 0xD6FC58 VA: 0xD6FC58
	public mail.MailOperateRes get_operate_result() { }

	// RVA: 0xD6FC60 Offset: 0xD6FC60 VA: 0xD6FC60
	public void set_operate_result(mail.MailOperateRes value) { }

	// RVA: 0xD6FCA0 Offset: 0xD6FCA0 VA: 0xD6FCA0
	public bool get_HasOperate_result() { }

	// RVA: 0xD6FCD0 Offset: 0xD6FCD0 VA: 0xD6FCD0
	public void .ctor() { }

	// RVA: 0xD6FD6C Offset: 0xD6FD6C VA: 0xD6FD6C
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD6FE24 Offset: 0xD6FE24 VA: 0xD6FE24 Slot: 5
	protected override void decode() { }

	// RVA: 0xD6FF44 Offset: 0xD6FF44 VA: 0xD6FF44 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD7005C Offset: 0xD7005C VA: 0xD7005C Slot: 3
	public override string ToString() { }

	// RVA: 0xD700F0 Offset: 0xD700F0 VA: 0xD700F0
	private static void .cctor() { }
}
