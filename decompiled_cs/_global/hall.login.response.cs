// Namespace: 
public class hall.login.response : SprotoTypeBase // TypeDefIndex: 9410
{
	// Fields
	private static int max_field_count; // 0x0
	private long _code; // 0x18
	private string _account; // 0x20

	// Properties
	public long code { get; set; }
	public bool HasCode { get; }
	public string account { get; set; }
	public bool HasAccount { get; }

	// Methods

	// RVA: 0x226C3AC Offset: 0x226C3AC VA: 0x226C3AC
	public long get_code() { }

	// RVA: 0x226C3B4 Offset: 0x226C3B4 VA: 0x226C3B4
	public void set_code(long value) { }

	// RVA: 0x226C3F8 Offset: 0x226C3F8 VA: 0x226C3F8
	public bool get_HasCode() { }

	// RVA: 0x226C428 Offset: 0x226C428 VA: 0x226C428
	public string get_account() { }

	// RVA: 0x226C430 Offset: 0x226C430 VA: 0x226C430
	public void set_account(string value) { }

	// RVA: 0x226C470 Offset: 0x226C470 VA: 0x226C470
	public bool get_HasAccount() { }

	// RVA: 0x226C4A0 Offset: 0x226C4A0 VA: 0x226C4A0
	public void .ctor() { }

	// RVA: 0x226C53C Offset: 0x226C53C VA: 0x226C53C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226C5F4 Offset: 0x226C5F4 VA: 0x226C5F4 Slot: 5
	protected override void decode() { }

	// RVA: 0x226C6CC Offset: 0x226C6CC VA: 0x226C6CC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226C7E4 Offset: 0x226C7E4 VA: 0x226C7E4 Slot: 3
	public override string ToString() { }

	// RVA: 0x226C878 Offset: 0x226C878 VA: 0x226C878
	private static void .cctor() { }
}
