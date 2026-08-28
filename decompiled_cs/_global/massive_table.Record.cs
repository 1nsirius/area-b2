// Namespace: 
public class massive_table.Record : ICloneable // TypeDefIndex: 10724
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571B64 Offset: 0x571B64 VA: 0x571B64
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571B74 Offset: 0x571B74 VA: 0x571B74
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571B84 Offset: 0x571B84 VA: 0x571B84
	private string <desc>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x571B94 Offset: 0x571B94 VA: 0x571B94
	private float <value1>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x571BA4 Offset: 0x571BA4 VA: 0x571BA4
	private float[] <value2>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public string desc { get; set; }
	public float value1 { get; set; }
	public float[] value2 { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x664230 Offset: 0x664230 VA: 0x664230
	// RVA: 0x1983420 Offset: 0x1983420 VA: 0x1983420
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x664240 Offset: 0x664240 VA: 0x664240
	// RVA: 0x1983428 Offset: 0x1983428 VA: 0x1983428
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664250 Offset: 0x664250 VA: 0x664250
	// RVA: 0x1983430 Offset: 0x1983430 VA: 0x1983430
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x664260 Offset: 0x664260 VA: 0x664260
	// RVA: 0x1983438 Offset: 0x1983438 VA: 0x1983438
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664270 Offset: 0x664270 VA: 0x664270
	// RVA: 0x1983440 Offset: 0x1983440 VA: 0x1983440
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x664280 Offset: 0x664280 VA: 0x664280
	// RVA: 0x1983448 Offset: 0x1983448 VA: 0x1983448
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664290 Offset: 0x664290 VA: 0x664290
	// RVA: 0x1983450 Offset: 0x1983450 VA: 0x1983450
	public float get_value1() { }

	[CompilerGeneratedAttribute] // RVA: 0x6642A0 Offset: 0x6642A0 VA: 0x6642A0
	// RVA: 0x1983458 Offset: 0x1983458 VA: 0x1983458
	private void set_value1(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6642B0 Offset: 0x6642B0 VA: 0x6642B0
	// RVA: 0x1983460 Offset: 0x1983460 VA: 0x1983460
	public float[] get_value2() { }

	[CompilerGeneratedAttribute] // RVA: 0x6642C0 Offset: 0x6642C0 VA: 0x6642C0
	// RVA: 0x1983468 Offset: 0x1983468 VA: 0x1983468
	private void set_value2(float[] value) { }

	// RVA: 0x1983220 Offset: 0x1983220 VA: 0x1983220
	internal void .ctor(MemoryStream reader, Action<massive_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x19824F8 Offset: 0x19824F8 VA: 0x19824F8
	internal static bool SetupReadActions(Field[] fields, Action<massive_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1983478 Offset: 0x1983478 VA: 0x1983478 Slot: 4
	public object Clone() { }
}
