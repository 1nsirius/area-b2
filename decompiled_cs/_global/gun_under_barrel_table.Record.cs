// Namespace: 
public class gun_under_barrel_table.Record : ICloneable // TypeDefIndex: 10668
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x570CB4 Offset: 0x570CB4 VA: 0x570CB4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x570CC4 Offset: 0x570CC4 VA: 0x570CC4
	private string <note>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x570CD4 Offset: 0x570CD4 VA: 0x570CD4
	private float <scatter>k__BackingField; // 0x10

	// Properties
	public int id { get; set; }
	public string note { get; set; }
	public float scatter { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6624D0 Offset: 0x6624D0 VA: 0x6624D0
	// RVA: 0x1C814AC Offset: 0x1C814AC VA: 0x1C814AC
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6624E0 Offset: 0x6624E0 VA: 0x6624E0
	// RVA: 0x1C814B4 Offset: 0x1C814B4 VA: 0x1C814B4
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6624F0 Offset: 0x6624F0 VA: 0x6624F0
	// RVA: 0x1C814BC Offset: 0x1C814BC VA: 0x1C814BC
	public string get_note() { }

	[CompilerGeneratedAttribute] // RVA: 0x662500 Offset: 0x662500 VA: 0x662500
	// RVA: 0x1C814C4 Offset: 0x1C814C4 VA: 0x1C814C4
	private void set_note(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662510 Offset: 0x662510 VA: 0x662510
	// RVA: 0x1C814CC Offset: 0x1C814CC VA: 0x1C814CC
	public float get_scatter() { }

	[CompilerGeneratedAttribute] // RVA: 0x662520 Offset: 0x662520 VA: 0x662520
	// RVA: 0x1C814D4 Offset: 0x1C814D4 VA: 0x1C814D4
	private void set_scatter(float value) { }

	// RVA: 0x1C812AC Offset: 0x1C812AC VA: 0x1C812AC
	internal void .ctor(MemoryStream reader, Action<gun_under_barrel_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C808D4 Offset: 0x1C808D4 VA: 0x1C808D4
	internal static bool SetupReadActions(Field[] fields, Action<gun_under_barrel_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C814E4 Offset: 0x1C814E4 VA: 0x1C814E4 Slot: 4
	public object Clone() { }
}
