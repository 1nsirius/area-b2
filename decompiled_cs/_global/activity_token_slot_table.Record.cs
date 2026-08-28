// Namespace: 
public class activity_token_slot_table.Record : ICloneable // TypeDefIndex: 10524
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56EAD4 Offset: 0x56EAD4 VA: 0x56EAD4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56EAE4 Offset: 0x56EAE4 VA: 0x56EAE4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56EAF4 Offset: 0x56EAF4 VA: 0x56EAF4
	private int[] <task_library>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56EB04 Offset: 0x56EB04 VA: 0x56EB04
	private int[] <task_library_weight>k__BackingField; // 0x14

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public int[] task_library { get; set; }
	public int[] task_library_weight { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65E110 Offset: 0x65E110 VA: 0x65E110
	// RVA: 0x1E896CC Offset: 0x1E896CC VA: 0x1E896CC
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E120 Offset: 0x65E120 VA: 0x65E120
	// RVA: 0x1E896D4 Offset: 0x1E896D4 VA: 0x1E896D4
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E130 Offset: 0x65E130 VA: 0x65E130
	// RVA: 0x1E896DC Offset: 0x1E896DC VA: 0x1E896DC
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E140 Offset: 0x65E140 VA: 0x65E140
	// RVA: 0x1E896E4 Offset: 0x1E896E4 VA: 0x1E896E4
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E150 Offset: 0x65E150 VA: 0x65E150
	// RVA: 0x1E896EC Offset: 0x1E896EC VA: 0x1E896EC
	public int[] get_task_library() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E160 Offset: 0x65E160 VA: 0x65E160
	// RVA: 0x1E896F4 Offset: 0x1E896F4 VA: 0x1E896F4
	private void set_task_library(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E170 Offset: 0x65E170 VA: 0x65E170
	// RVA: 0x1E896FC Offset: 0x1E896FC VA: 0x1E896FC
	public int[] get_task_library_weight() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E180 Offset: 0x65E180 VA: 0x65E180
	// RVA: 0x1E89704 Offset: 0x1E89704 VA: 0x1E89704
	private void set_task_library_weight(int[] value) { }

	// RVA: 0x1E894CC Offset: 0x1E894CC VA: 0x1E894CC
	internal void .ctor(MemoryStream reader, Action<activity_token_slot_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E8894C Offset: 0x1E8894C VA: 0x1E8894C
	internal static bool SetupReadActions(Field[] fields, Action<activity_token_slot_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E89714 Offset: 0x1E89714 VA: 0x1E89714 Slot: 4
	public object Clone() { }
}
