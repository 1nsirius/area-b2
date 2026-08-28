// Namespace: 
public class client.submit_recruit_code_req.response : SprotoTypeBase // TypeDefIndex: 9173
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _recruiter_uid; // 0x20
	private string _recruiter_name; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long recruiter_uid { get; set; }
	public bool HasRecruiter_uid { get; }
	public string recruiter_name { get; set; }
	public bool HasRecruiter_name { get; }

	// Methods

	// RVA: 0x2543D7C Offset: 0x2543D7C VA: 0x2543D7C
	public long get_errorcode() { }

	// RVA: 0x2543D84 Offset: 0x2543D84 VA: 0x2543D84
	public void set_errorcode(long value) { }

	// RVA: 0x2543DC8 Offset: 0x2543DC8 VA: 0x2543DC8
	public bool get_HasErrorcode() { }

	// RVA: 0x2543DF8 Offset: 0x2543DF8 VA: 0x2543DF8
	public long get_recruiter_uid() { }

	// RVA: 0x2543E00 Offset: 0x2543E00 VA: 0x2543E00
	public void set_recruiter_uid(long value) { }

	// RVA: 0x2543E44 Offset: 0x2543E44 VA: 0x2543E44
	public bool get_HasRecruiter_uid() { }

	// RVA: 0x2543E74 Offset: 0x2543E74 VA: 0x2543E74
	public string get_recruiter_name() { }

	// RVA: 0x2543E7C Offset: 0x2543E7C VA: 0x2543E7C
	public void set_recruiter_name(string value) { }

	// RVA: 0x2543EBC Offset: 0x2543EBC VA: 0x2543EBC
	public bool get_HasRecruiter_name() { }

	// RVA: 0x2543EEC Offset: 0x2543EEC VA: 0x2543EEC
	public void .ctor() { }

	// RVA: 0x2543F88 Offset: 0x2543F88 VA: 0x2543F88
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2544040 Offset: 0x2544040 VA: 0x2544040 Slot: 5
	protected override void decode() { }

	// RVA: 0x2544160 Offset: 0x2544160 VA: 0x2544160 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x25442DC Offset: 0x25442DC VA: 0x25442DC Slot: 3
	public override string ToString() { }

	// RVA: 0x2544398 Offset: 0x2544398 VA: 0x2544398
	private static void .cctor() { }
}
