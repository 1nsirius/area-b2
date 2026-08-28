// Namespace: 
public class client.load_role.response : SprotoTypeBase // TypeDefIndex: 9128
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _uid; // 0x20
	private client.role_data _role; // 0x28
	private string _risk_errorcode; // 0x2C

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long uid { get; set; }
	public bool HasUid { get; }
	public client.role_data role { get; set; }
	public bool HasRole { get; }
	public string risk_errorcode { get; set; }
	public bool HasRisk_errorcode { get; }

	// Methods

	// RVA: 0x2442468 Offset: 0x2442468 VA: 0x2442468
	public long get_errorcode() { }

	// RVA: 0x2442470 Offset: 0x2442470 VA: 0x2442470
	public void set_errorcode(long value) { }

	// RVA: 0x24424B4 Offset: 0x24424B4 VA: 0x24424B4
	public bool get_HasErrorcode() { }

	// RVA: 0x24424E4 Offset: 0x24424E4 VA: 0x24424E4
	public long get_uid() { }

	// RVA: 0x24424EC Offset: 0x24424EC VA: 0x24424EC
	public void set_uid(long value) { }

	// RVA: 0x2442530 Offset: 0x2442530 VA: 0x2442530
	public bool get_HasUid() { }

	// RVA: 0x2442560 Offset: 0x2442560 VA: 0x2442560
	public client.role_data get_role() { }

	// RVA: 0x2442568 Offset: 0x2442568 VA: 0x2442568
	public void set_role(client.role_data value) { }

	// RVA: 0x24425A8 Offset: 0x24425A8 VA: 0x24425A8
	public bool get_HasRole() { }

	// RVA: 0x24425D8 Offset: 0x24425D8 VA: 0x24425D8
	public string get_risk_errorcode() { }

	// RVA: 0x24425E0 Offset: 0x24425E0 VA: 0x24425E0
	public void set_risk_errorcode(string value) { }

	// RVA: 0x2442620 Offset: 0x2442620 VA: 0x2442620
	public bool get_HasRisk_errorcode() { }

	// RVA: 0x2442650 Offset: 0x2442650 VA: 0x2442650
	public void .ctor() { }

	// RVA: 0x24426EC Offset: 0x24426EC VA: 0x24426EC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24427A4 Offset: 0x24427A4 VA: 0x24427A4 Slot: 5
	protected override void decode() { }

	// RVA: 0x2442940 Offset: 0x2442940 VA: 0x2442940 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2442B14 Offset: 0x2442B14 VA: 0x2442B14 Slot: 3
	public override string ToString() { }

	// RVA: 0x2442D44 Offset: 0x2442D44 VA: 0x2442D44
	private static void .cctor() { }
}
