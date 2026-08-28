// Namespace: 
public class activity_card_table.Record : ICloneable // TypeDefIndex: 10516
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56EA14 Offset: 0x56EA14 VA: 0x56EA14
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56EA24 Offset: 0x56EA24 VA: 0x56EA24
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56EA34 Offset: 0x56EA34 VA: 0x56EA34
	private int[] <task_library>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56EA44 Offset: 0x56EA44 VA: 0x56EA44
	private int[] <goods_id>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56EA54 Offset: 0x56EA54 VA: 0x56EA54
	private int <day>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56EA64 Offset: 0x56EA64 VA: 0x56EA64
	private int <type>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public int[] task_library { get; set; }
	public int[] goods_id { get; set; }
	public int day { get; set; }
	public int type { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65DF90 Offset: 0x65DF90 VA: 0x65DF90
	// RVA: 0x1E83A18 Offset: 0x1E83A18 VA: 0x1E83A18
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65DFA0 Offset: 0x65DFA0 VA: 0x65DFA0
	// RVA: 0x1E83A20 Offset: 0x1E83A20 VA: 0x1E83A20
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65DFB0 Offset: 0x65DFB0 VA: 0x65DFB0
	// RVA: 0x1E83A28 Offset: 0x1E83A28 VA: 0x1E83A28
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x65DFC0 Offset: 0x65DFC0 VA: 0x65DFC0
	// RVA: 0x1E83A30 Offset: 0x1E83A30 VA: 0x1E83A30
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65DFD0 Offset: 0x65DFD0 VA: 0x65DFD0
	// RVA: 0x1E83A38 Offset: 0x1E83A38 VA: 0x1E83A38
	public int[] get_task_library() { }

	[CompilerGeneratedAttribute] // RVA: 0x65DFE0 Offset: 0x65DFE0 VA: 0x65DFE0
	// RVA: 0x1E83A40 Offset: 0x1E83A40 VA: 0x1E83A40
	private void set_task_library(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65DFF0 Offset: 0x65DFF0 VA: 0x65DFF0
	// RVA: 0x1E83A48 Offset: 0x1E83A48 VA: 0x1E83A48
	public int[] get_goods_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E000 Offset: 0x65E000 VA: 0x65E000
	// RVA: 0x1E83A50 Offset: 0x1E83A50 VA: 0x1E83A50
	private void set_goods_id(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E010 Offset: 0x65E010 VA: 0x65E010
	// RVA: 0x1E83A58 Offset: 0x1E83A58 VA: 0x1E83A58
	public int get_day() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E020 Offset: 0x65E020 VA: 0x65E020
	// RVA: 0x1E83A60 Offset: 0x1E83A60 VA: 0x1E83A60
	private void set_day(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E030 Offset: 0x65E030 VA: 0x65E030
	// RVA: 0x1E83A68 Offset: 0x1E83A68 VA: 0x1E83A68
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E040 Offset: 0x65E040 VA: 0x65E040
	// RVA: 0x1E83A70 Offset: 0x1E83A70 VA: 0x1E83A70
	private void set_type(int value) { }

	// RVA: 0x1E83818 Offset: 0x1E83818 VA: 0x1E83818
	internal void .ctor(MemoryStream reader, Action<activity_card_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E82948 Offset: 0x1E82948 VA: 0x1E82948
	internal static bool SetupReadActions(Field[] fields, Action<activity_card_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E83A80 Offset: 0x1E83A80 VA: 0x1E83A80 Slot: 4
	public object Clone() { }
}
