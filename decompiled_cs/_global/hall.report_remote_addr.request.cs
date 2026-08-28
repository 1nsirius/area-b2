// Namespace: 
public class hall.report_remote_addr.request : SprotoTypeBase // TypeDefIndex: 9412
{
	// Fields
	private static int max_field_count; // 0x0
	private string _remote_addr; // 0x14
	private string _local_addr; // 0x18

	// Properties
	public string remote_addr { get; set; }
	public bool HasRemote_addr { get; }
	public string local_addr { get; set; }
	public bool HasLocal_addr { get; }

	// Methods

	// RVA: 0x226C8E8 Offset: 0x226C8E8 VA: 0x226C8E8
	public string get_remote_addr() { }

	// RVA: 0x226C8F0 Offset: 0x226C8F0 VA: 0x226C8F0
	public void set_remote_addr(string value) { }

	// RVA: 0x226C930 Offset: 0x226C930 VA: 0x226C930
	public bool get_HasRemote_addr() { }

	// RVA: 0x226C960 Offset: 0x226C960 VA: 0x226C960
	public string get_local_addr() { }

	// RVA: 0x226C968 Offset: 0x226C968 VA: 0x226C968
	public void set_local_addr(string value) { }

	// RVA: 0x226C9A8 Offset: 0x226C9A8 VA: 0x226C9A8
	public bool get_HasLocal_addr() { }

	// RVA: 0x226C9D8 Offset: 0x226C9D8 VA: 0x226C9D8
	public void .ctor() { }

	// RVA: 0x226CA74 Offset: 0x226CA74 VA: 0x226CA74
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226CB2C Offset: 0x226CB2C VA: 0x226CB2C Slot: 5
	protected override void decode() { }

	// RVA: 0x226CBF4 Offset: 0x226CBF4 VA: 0x226CBF4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226CCFC Offset: 0x226CCFC VA: 0x226CCFC Slot: 3
	public override string ToString() { }

	// RVA: 0x226CF6C Offset: 0x226CF6C VA: 0x226CF6C
	private static void .cctor() { }
}
