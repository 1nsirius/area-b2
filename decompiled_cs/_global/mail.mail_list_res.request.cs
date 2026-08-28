// Namespace: 
public class mail.mail_list_res.request : SprotoTypeBase // TypeDefIndex: 9442
{
	// Fields
	private static int max_field_count; // 0x0
	private List<mail.Mail> _mail_list; // 0x14
	private bool _end_flag; // 0x18

	// Properties
	public List<mail.Mail> mail_list { get; set; }
	public bool HasMail_list { get; }
	public bool end_flag { get; set; }
	public bool HasEnd_flag { get; }

	// Methods

	// RVA: 0xD6EC8C Offset: 0xD6EC8C VA: 0xD6EC8C
	public List<mail.Mail> get_mail_list() { }

	// RVA: 0xD6EC94 Offset: 0xD6EC94 VA: 0xD6EC94
	public void set_mail_list(List<mail.Mail> value) { }

	// RVA: 0xD6ECD4 Offset: 0xD6ECD4 VA: 0xD6ECD4
	public bool get_HasMail_list() { }

	// RVA: 0xD6ED04 Offset: 0xD6ED04 VA: 0xD6ED04
	public bool get_end_flag() { }

	// RVA: 0xD6ED0C Offset: 0xD6ED0C VA: 0xD6ED0C
	public void set_end_flag(bool value) { }

	// RVA: 0xD6ED4C Offset: 0xD6ED4C VA: 0xD6ED4C
	public bool get_HasEnd_flag() { }

	// RVA: 0xD6ED7C Offset: 0xD6ED7C VA: 0xD6ED7C
	public void .ctor() { }

	// RVA: 0xD6EE18 Offset: 0xD6EE18 VA: 0xD6EE18
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD6EED0 Offset: 0xD6EED0 VA: 0xD6EED0 Slot: 5
	protected override void decode() { }

	// RVA: 0xD6EFE0 Offset: 0xD6EFE0 VA: 0xD6EFE0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD6F138 Offset: 0xD6F138 VA: 0xD6F138 Slot: 3
	public override string ToString() { }

	// RVA: 0xD6F1E8 Offset: 0xD6F1E8 VA: 0xD6F1E8
	private static void .cctor() { }
}
