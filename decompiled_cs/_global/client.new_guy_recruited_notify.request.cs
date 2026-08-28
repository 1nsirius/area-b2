// Namespace: 
public class client.new_guy_recruited_notify.request : SprotoTypeBase // TypeDefIndex: 9130
{
	// Fields
	private static int max_field_count; // 0x0
	private long _recruitee_uid; // 0x18
	private string _recruitee_name; // 0x20

	// Properties
	public long recruitee_uid { get; set; }
	public bool HasRecruitee_uid { get; }
	public string recruitee_name { get; set; }
	public bool HasRecruitee_name { get; }

	// Methods

	// RVA: 0x2442DB4 Offset: 0x2442DB4 VA: 0x2442DB4
	public long get_recruitee_uid() { }

	// RVA: 0x2442DBC Offset: 0x2442DBC VA: 0x2442DBC
	public void set_recruitee_uid(long value) { }

	// RVA: 0x2442E00 Offset: 0x2442E00 VA: 0x2442E00
	public bool get_HasRecruitee_uid() { }

	// RVA: 0x2442E30 Offset: 0x2442E30 VA: 0x2442E30
	public string get_recruitee_name() { }

	// RVA: 0x2442E38 Offset: 0x2442E38 VA: 0x2442E38
	public void set_recruitee_name(string value) { }

	// RVA: 0x2442E78 Offset: 0x2442E78 VA: 0x2442E78
	public bool get_HasRecruitee_name() { }

	// RVA: 0x2442EA8 Offset: 0x2442EA8 VA: 0x2442EA8
	public void .ctor() { }

	// RVA: 0x2442F44 Offset: 0x2442F44 VA: 0x2442F44
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2442FFC Offset: 0x2442FFC VA: 0x2442FFC Slot: 5
	protected override void decode() { }

	// RVA: 0x24430D4 Offset: 0x24430D4 VA: 0x24430D4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x24431EC Offset: 0x24431EC VA: 0x24431EC Slot: 3
	public override string ToString() { }

	// RVA: 0x2443280 Offset: 0x2443280 VA: 0x2443280
	private static void .cctor() { }
}
