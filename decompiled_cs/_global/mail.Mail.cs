// Namespace: 
public class mail.Mail : SprotoTypeBase // TypeDefIndex: 9428
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private string _title; // 0x20
	private string _content; // 0x24
	private long _mail_type; // 0x28
	private bool _is_custom; // 0x30
	private long _expire_ts; // 0x38
	private long _status; // 0x40
	private List<mail.MailReward> _rewards; // 0x48
	private long _create_ts; // 0x50
	private List<string> _content_param; // 0x58
	private long _template_type; // 0x60

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public string title { get; set; }
	public bool HasTitle { get; }
	public string content { get; set; }
	public bool HasContent { get; }
	public long mail_type { get; set; }
	public bool HasMail_type { get; }
	public bool is_custom { get; set; }
	public bool HasIs_custom { get; }
	public long expire_ts { get; set; }
	public bool HasExpire_ts { get; }
	public long status { get; set; }
	public bool HasStatus { get; }
	public List<mail.MailReward> rewards { get; set; }
	public bool HasRewards { get; }
	public long create_ts { get; set; }
	public bool HasCreate_ts { get; }
	public List<string> content_param { get; set; }
	public bool HasContent_param { get; }
	public long template_type { get; set; }
	public bool HasTemplate_type { get; }

	// Methods

	// RVA: 0x22706F4 Offset: 0x22706F4 VA: 0x22706F4
	public long get_id() { }

	// RVA: 0x22706FC Offset: 0x22706FC VA: 0x22706FC
	public void set_id(long value) { }

	// RVA: 0x2270740 Offset: 0x2270740 VA: 0x2270740
	public bool get_HasId() { }

	// RVA: 0x2270770 Offset: 0x2270770 VA: 0x2270770
	public string get_title() { }

	// RVA: 0x2270778 Offset: 0x2270778 VA: 0x2270778
	public void set_title(string value) { }

	// RVA: 0x22707B8 Offset: 0x22707B8 VA: 0x22707B8
	public bool get_HasTitle() { }

	// RVA: 0x22707E8 Offset: 0x22707E8 VA: 0x22707E8
	public string get_content() { }

	// RVA: 0x22707F0 Offset: 0x22707F0 VA: 0x22707F0
	public void set_content(string value) { }

	// RVA: 0x2270830 Offset: 0x2270830 VA: 0x2270830
	public bool get_HasContent() { }

	// RVA: 0x2270860 Offset: 0x2270860 VA: 0x2270860
	public long get_mail_type() { }

	// RVA: 0x2270868 Offset: 0x2270868 VA: 0x2270868
	public void set_mail_type(long value) { }

	// RVA: 0x22708AC Offset: 0x22708AC VA: 0x22708AC
	public bool get_HasMail_type() { }

	// RVA: 0x22708DC Offset: 0x22708DC VA: 0x22708DC
	public bool get_is_custom() { }

	// RVA: 0x22708E4 Offset: 0x22708E4 VA: 0x22708E4
	public void set_is_custom(bool value) { }

	// RVA: 0x2270924 Offset: 0x2270924 VA: 0x2270924
	public bool get_HasIs_custom() { }

	// RVA: 0x2270954 Offset: 0x2270954 VA: 0x2270954
	public long get_expire_ts() { }

	// RVA: 0x227095C Offset: 0x227095C VA: 0x227095C
	public void set_expire_ts(long value) { }

	// RVA: 0x22709A0 Offset: 0x22709A0 VA: 0x22709A0
	public bool get_HasExpire_ts() { }

	// RVA: 0x22709D0 Offset: 0x22709D0 VA: 0x22709D0
	public long get_status() { }

	// RVA: 0x22709D8 Offset: 0x22709D8 VA: 0x22709D8
	public void set_status(long value) { }

	// RVA: 0x2270A1C Offset: 0x2270A1C VA: 0x2270A1C
	public bool get_HasStatus() { }

	// RVA: 0x2270A4C Offset: 0x2270A4C VA: 0x2270A4C
	public List<mail.MailReward> get_rewards() { }

	// RVA: 0x2270A54 Offset: 0x2270A54 VA: 0x2270A54
	public void set_rewards(List<mail.MailReward> value) { }

	// RVA: 0x2270A94 Offset: 0x2270A94 VA: 0x2270A94
	public bool get_HasRewards() { }

	// RVA: 0x2270AC4 Offset: 0x2270AC4 VA: 0x2270AC4
	public long get_create_ts() { }

	// RVA: 0x2270ACC Offset: 0x2270ACC VA: 0x2270ACC
	public void set_create_ts(long value) { }

	// RVA: 0x2270B10 Offset: 0x2270B10 VA: 0x2270B10
	public bool get_HasCreate_ts() { }

	// RVA: 0x2270B40 Offset: 0x2270B40 VA: 0x2270B40
	public List<string> get_content_param() { }

	// RVA: 0x2270B48 Offset: 0x2270B48 VA: 0x2270B48
	public void set_content_param(List<string> value) { }

	// RVA: 0x2270B88 Offset: 0x2270B88 VA: 0x2270B88
	public bool get_HasContent_param() { }

	// RVA: 0x2270BB8 Offset: 0x2270BB8 VA: 0x2270BB8
	public long get_template_type() { }

	// RVA: 0x2270BC0 Offset: 0x2270BC0 VA: 0x2270BC0
	public void set_template_type(long value) { }

	// RVA: 0x2270C04 Offset: 0x2270C04 VA: 0x2270C04
	public bool get_HasTemplate_type() { }

	// RVA: 0x2270C34 Offset: 0x2270C34 VA: 0x2270C34
	public void .ctor() { }

	// RVA: 0x2270CD0 Offset: 0x2270CD0 VA: 0x2270CD0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2270D88 Offset: 0x2270D88 VA: 0x2270D88 Slot: 5
	protected override void decode() { }

	// RVA: 0x22710A0 Offset: 0x22710A0 VA: 0x22710A0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x227155C Offset: 0x227155C VA: 0x227155C Slot: 3
	public override string ToString() { }

	// RVA: 0x2271AB8 Offset: 0x2271AB8 VA: 0x2271AB8
	private static void .cctor() { }
}
