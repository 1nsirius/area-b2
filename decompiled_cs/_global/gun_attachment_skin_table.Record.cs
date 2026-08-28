// Namespace: 
public class gun_attachment_skin_table.Record : ICloneable // TypeDefIndex: 10648
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5705B4 Offset: 0x5705B4 VA: 0x5705B4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5705C4 Offset: 0x5705C4 VA: 0x5705C4
	private string <note>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5705D4 Offset: 0x5705D4 VA: 0x5705D4
	private int <attachment_id>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5705E4 Offset: 0x5705E4 VA: 0x5705E4
	private string <model_path>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5705F4 Offset: 0x5705F4 VA: 0x5705F4
	private string[] <basic_mats>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x570604 Offset: 0x570604 VA: 0x570604
	private string[] <override_mats>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string note { get; set; }
	public int attachment_id { get; set; }
	public string model_path { get; set; }
	public string[] basic_mats { get; set; }
	public string[] override_mats { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6616D0 Offset: 0x6616D0 VA: 0x6616D0
	// RVA: 0x1E7B2D4 Offset: 0x1E7B2D4 VA: 0x1E7B2D4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6616E0 Offset: 0x6616E0 VA: 0x6616E0
	// RVA: 0x1E7B2DC Offset: 0x1E7B2DC VA: 0x1E7B2DC
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6616F0 Offset: 0x6616F0 VA: 0x6616F0
	// RVA: 0x1E7B2E4 Offset: 0x1E7B2E4 VA: 0x1E7B2E4
	public string get_note() { }

	[CompilerGeneratedAttribute] // RVA: 0x661700 Offset: 0x661700 VA: 0x661700
	// RVA: 0x1E7B2EC Offset: 0x1E7B2EC VA: 0x1E7B2EC
	private void set_note(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661710 Offset: 0x661710 VA: 0x661710
	// RVA: 0x1E7B2F4 Offset: 0x1E7B2F4 VA: 0x1E7B2F4
	public int get_attachment_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x661720 Offset: 0x661720 VA: 0x661720
	// RVA: 0x1E7B2FC Offset: 0x1E7B2FC VA: 0x1E7B2FC
	private void set_attachment_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661730 Offset: 0x661730 VA: 0x661730
	// RVA: 0x1E7B304 Offset: 0x1E7B304 VA: 0x1E7B304
	public string get_model_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x661740 Offset: 0x661740 VA: 0x661740
	// RVA: 0x1E7B30C Offset: 0x1E7B30C VA: 0x1E7B30C
	private void set_model_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661750 Offset: 0x661750 VA: 0x661750
	// RVA: 0x1E7B314 Offset: 0x1E7B314 VA: 0x1E7B314
	public string[] get_basic_mats() { }

	[CompilerGeneratedAttribute] // RVA: 0x661760 Offset: 0x661760 VA: 0x661760
	// RVA: 0x1E7B31C Offset: 0x1E7B31C VA: 0x1E7B31C
	private void set_basic_mats(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661770 Offset: 0x661770 VA: 0x661770
	// RVA: 0x1E7B324 Offset: 0x1E7B324 VA: 0x1E7B324
	public string[] get_override_mats() { }

	[CompilerGeneratedAttribute] // RVA: 0x661780 Offset: 0x661780 VA: 0x661780
	// RVA: 0x1E7B32C Offset: 0x1E7B32C VA: 0x1E7B32C
	private void set_override_mats(string[] value) { }

	// RVA: 0x1E7B0D4 Offset: 0x1E7B0D4 VA: 0x1E7B0D4
	internal void .ctor(MemoryStream reader, Action<gun_attachment_skin_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E7A204 Offset: 0x1E7A204 VA: 0x1E7A204
	internal static bool SetupReadActions(Field[] fields, Action<gun_attachment_skin_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E7B33C Offset: 0x1E7B33C VA: 0x1E7B33C Slot: 4
	public object Clone() { }
}
