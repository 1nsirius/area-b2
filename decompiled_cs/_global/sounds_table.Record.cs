// Namespace: 
public class sounds_table.Record : ICloneable // TypeDefIndex: 10824
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572C94 Offset: 0x572C94 VA: 0x572C94
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572CA4 Offset: 0x572CA4 VA: 0x572CA4
	private string <path>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572CB4 Offset: 0x572CB4 VA: 0x572CB4
	private string <frame>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572CC4 Offset: 0x572CC4 VA: 0x572CC4
	private float <delay>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572CD4 Offset: 0x572CD4 VA: 0x572CD4
	private string <remark>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string path { get; set; }
	public string frame { get; set; }
	public float delay { get; set; }
	public string remark { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x666490 Offset: 0x666490 VA: 0x666490
	// RVA: 0x1F32894 Offset: 0x1F32894 VA: 0x1F32894
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6664A0 Offset: 0x6664A0 VA: 0x6664A0
	// RVA: 0x1F3289C Offset: 0x1F3289C VA: 0x1F3289C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6664B0 Offset: 0x6664B0 VA: 0x6664B0
	// RVA: 0x1F328A4 Offset: 0x1F328A4 VA: 0x1F328A4
	public string get_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x6664C0 Offset: 0x6664C0 VA: 0x6664C0
	// RVA: 0x1F328AC Offset: 0x1F328AC VA: 0x1F328AC
	private void set_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6664D0 Offset: 0x6664D0 VA: 0x6664D0
	// RVA: 0x1F328B4 Offset: 0x1F328B4 VA: 0x1F328B4
	public string get_frame() { }

	[CompilerGeneratedAttribute] // RVA: 0x6664E0 Offset: 0x6664E0 VA: 0x6664E0
	// RVA: 0x1F328BC Offset: 0x1F328BC VA: 0x1F328BC
	private void set_frame(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6664F0 Offset: 0x6664F0 VA: 0x6664F0
	// RVA: 0x1F328C4 Offset: 0x1F328C4 VA: 0x1F328C4
	public float get_delay() { }

	[CompilerGeneratedAttribute] // RVA: 0x666500 Offset: 0x666500 VA: 0x666500
	// RVA: 0x1F328CC Offset: 0x1F328CC VA: 0x1F328CC
	private void set_delay(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666510 Offset: 0x666510 VA: 0x666510
	// RVA: 0x1F328D4 Offset: 0x1F328D4 VA: 0x1F328D4
	public string get_remark() { }

	[CompilerGeneratedAttribute] // RVA: 0x666520 Offset: 0x666520 VA: 0x666520
	// RVA: 0x1F328DC Offset: 0x1F328DC VA: 0x1F328DC
	private void set_remark(string value) { }

	// RVA: 0x1F32694 Offset: 0x1F32694 VA: 0x1F32694
	internal void .ctor(MemoryStream reader, Action<sounds_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F3196C Offset: 0x1F3196C VA: 0x1F3196C
	internal static bool SetupReadActions(Field[] fields, Action<sounds_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F328EC Offset: 0x1F328EC VA: 0x1F328EC Slot: 4
	public object Clone() { }
}
