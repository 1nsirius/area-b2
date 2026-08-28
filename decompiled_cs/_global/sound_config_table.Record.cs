// Namespace: 
public class sound_config_table.Record : ICloneable // TypeDefIndex: 10820
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572C64 Offset: 0x572C64 VA: 0x572C64
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572C74 Offset: 0x572C74 VA: 0x572C74
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572C84 Offset: 0x572C84 VA: 0x572C84
	private float <value1>k__BackingField; // 0x10

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public float value1 { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x666430 Offset: 0x666430 VA: 0x666430
	// RVA: 0x1F313C4 Offset: 0x1F313C4 VA: 0x1F313C4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x666440 Offset: 0x666440 VA: 0x666440
	// RVA: 0x1F313CC Offset: 0x1F313CC VA: 0x1F313CC
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666450 Offset: 0x666450 VA: 0x666450
	// RVA: 0x1F313D4 Offset: 0x1F313D4 VA: 0x1F313D4
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x666460 Offset: 0x666460 VA: 0x666460
	// RVA: 0x1F313DC Offset: 0x1F313DC VA: 0x1F313DC
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666470 Offset: 0x666470 VA: 0x666470
	// RVA: 0x1F313E4 Offset: 0x1F313E4 VA: 0x1F313E4
	public float get_value1() { }

	[CompilerGeneratedAttribute] // RVA: 0x666480 Offset: 0x666480 VA: 0x666480
	// RVA: 0x1F313EC Offset: 0x1F313EC VA: 0x1F313EC
	private void set_value1(float value) { }

	// RVA: 0x1F311C4 Offset: 0x1F311C4 VA: 0x1F311C4
	internal void .ctor(MemoryStream reader, Action<sound_config_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F307EC Offset: 0x1F307EC VA: 0x1F307EC
	internal static bool SetupReadActions(Field[] fields, Action<sound_config_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F313FC Offset: 0x1F313FC VA: 0x1F313FC Slot: 4
	public object Clone() { }
}
