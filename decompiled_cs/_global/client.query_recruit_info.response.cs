// Namespace: 
public class client.query_recruit_info.response : SprotoTypeBase // TypeDefIndex: 9154
{
	// Fields
	private static int max_field_count; // 0x0
	private string _recruit_code; // 0x14
	private long _recruiter_uid; // 0x18
	private long _recruitee_count; // 0x20

	// Properties
	public string recruit_code { get; set; }
	public bool HasRecruit_code { get; }
	public long recruiter_uid { get; set; }
	public bool HasRecruiter_uid { get; }
	public long recruitee_count { get; set; }
	public bool HasRecruitee_count { get; }

	// Methods

	// RVA: 0x2448AE0 Offset: 0x2448AE0 VA: 0x2448AE0
	public string get_recruit_code() { }

	// RVA: 0x2448AE8 Offset: 0x2448AE8 VA: 0x2448AE8
	public void set_recruit_code(string value) { }

	// RVA: 0x2448B28 Offset: 0x2448B28 VA: 0x2448B28
	public bool get_HasRecruit_code() { }

	// RVA: 0x2448B58 Offset: 0x2448B58 VA: 0x2448B58
	public long get_recruiter_uid() { }

	// RVA: 0x2448B60 Offset: 0x2448B60 VA: 0x2448B60
	public void set_recruiter_uid(long value) { }

	// RVA: 0x2448BA4 Offset: 0x2448BA4 VA: 0x2448BA4
	public bool get_HasRecruiter_uid() { }

	// RVA: 0x2448BD4 Offset: 0x2448BD4 VA: 0x2448BD4
	public long get_recruitee_count() { }

	// RVA: 0x2448BDC Offset: 0x2448BDC VA: 0x2448BDC
	public void set_recruitee_count(long value) { }

	// RVA: 0x2448C20 Offset: 0x2448C20 VA: 0x2448C20
	public bool get_HasRecruitee_count() { }

	// RVA: 0x2448C50 Offset: 0x2448C50 VA: 0x2448C50
	public void .ctor() { }

	// RVA: 0x2448CEC Offset: 0x2448CEC VA: 0x2448CEC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2448DA4 Offset: 0x2448DA4 VA: 0x2448DA4 Slot: 5
	protected override void decode() { }

	// RVA: 0x2448EC4 Offset: 0x2448EC4 VA: 0x2448EC4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2449044 Offset: 0x2449044 VA: 0x2449044 Slot: 3
	public override string ToString() { }

	// RVA: 0x2449108 Offset: 0x2449108 VA: 0x2449108
	private static void .cctor() { }
}
