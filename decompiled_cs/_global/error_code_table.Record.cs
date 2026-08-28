// Namespace: 
public class error_code_table.Record : ICloneable // TypeDefIndex: 10636
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x570324 Offset: 0x570324 VA: 0x570324
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x570334 Offset: 0x570334 VA: 0x570334
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x570344 Offset: 0x570344 VA: 0x570344
	private string <desc>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x570354 Offset: 0x570354 VA: 0x570354
	private int <message_id>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x570364 Offset: 0x570364 VA: 0x570364
	private int <language_id>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public string desc { get; set; }
	public int message_id { get; set; }
	public int language_id { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6611B0 Offset: 0x6611B0 VA: 0x6611B0
	// RVA: 0x1E75EF8 Offset: 0x1E75EF8 VA: 0x1E75EF8
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6611C0 Offset: 0x6611C0 VA: 0x6611C0
	// RVA: 0x1E75F00 Offset: 0x1E75F00 VA: 0x1E75F00
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6611D0 Offset: 0x6611D0 VA: 0x6611D0
	// RVA: 0x1E75EF0 Offset: 0x1E75EF0 VA: 0x1E75EF0
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x6611E0 Offset: 0x6611E0 VA: 0x6611E0
	// RVA: 0x1E75F08 Offset: 0x1E75F08 VA: 0x1E75F08
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6611F0 Offset: 0x6611F0 VA: 0x6611F0
	// RVA: 0x1E75F10 Offset: 0x1E75F10 VA: 0x1E75F10
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x661200 Offset: 0x661200 VA: 0x661200
	// RVA: 0x1E75F18 Offset: 0x1E75F18 VA: 0x1E75F18
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661210 Offset: 0x661210 VA: 0x661210
	// RVA: 0x1E75F20 Offset: 0x1E75F20 VA: 0x1E75F20
	public int get_message_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x661220 Offset: 0x661220 VA: 0x661220
	// RVA: 0x1E75F28 Offset: 0x1E75F28 VA: 0x1E75F28
	private void set_message_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661230 Offset: 0x661230 VA: 0x661230
	// RVA: 0x1E75F30 Offset: 0x1E75F30 VA: 0x1E75F30
	public int get_language_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x661240 Offset: 0x661240 VA: 0x661240
	// RVA: 0x1E75F38 Offset: 0x1E75F38 VA: 0x1E75F38
	private void set_language_id(int value) { }

	// RVA: 0x1E75CF0 Offset: 0x1E75CF0 VA: 0x1E75CF0
	internal void .ctor(MemoryStream reader, Action<error_code_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E74F90 Offset: 0x1E74F90 VA: 0x1E74F90
	internal static bool SetupReadActions(Field[] fields, Action<error_code_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E75F48 Offset: 0x1E75F48 VA: 0x1E75F48 Slot: 4
	public object Clone() { }
}
