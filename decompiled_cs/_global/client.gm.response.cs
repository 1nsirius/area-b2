// Namespace: 
public class client.gm.response : SprotoTypeBase // TypeDefIndex: 9120
{
	// Fields
	private static int max_field_count; // 0x0
	private bool _succeed; // 0x14
	private string _info; // 0x18

	// Properties
	public bool succeed { get; set; }
	public bool HasSucceed { get; }
	public string info { get; set; }
	public bool HasInfo { get; }

	// Methods

	// RVA: 0x2440E30 Offset: 0x2440E30 VA: 0x2440E30
	public bool get_succeed() { }

	// RVA: 0x2440E38 Offset: 0x2440E38 VA: 0x2440E38
	public void set_succeed(bool value) { }

	// RVA: 0x2440E78 Offset: 0x2440E78 VA: 0x2440E78
	public bool get_HasSucceed() { }

	// RVA: 0x2440EA8 Offset: 0x2440EA8 VA: 0x2440EA8
	public string get_info() { }

	// RVA: 0x2440EB0 Offset: 0x2440EB0 VA: 0x2440EB0
	public void set_info(string value) { }

	// RVA: 0x2440EF0 Offset: 0x2440EF0 VA: 0x2440EF0
	public bool get_HasInfo() { }

	// RVA: 0x2440F20 Offset: 0x2440F20 VA: 0x2440F20
	public void .ctor() { }

	// RVA: 0x2440FBC Offset: 0x2440FBC VA: 0x2440FBC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2441074 Offset: 0x2441074 VA: 0x2441074 Slot: 5
	protected override void decode() { }

	// RVA: 0x244113C Offset: 0x244113C VA: 0x244113C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244124C Offset: 0x244124C VA: 0x244124C Slot: 3
	public override string ToString() { }

	// RVA: 0x24412E0 Offset: 0x24412E0 VA: 0x24412E0
	private static void .cctor() { }
}
