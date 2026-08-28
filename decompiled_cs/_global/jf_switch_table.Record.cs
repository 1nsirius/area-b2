// Namespace: 
public class jf_switch_table.Record : ICloneable // TypeDefIndex: 10708
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571884 Offset: 0x571884 VA: 0x571884
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571894 Offset: 0x571894 VA: 0x571894
	private string <code>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5718A4 Offset: 0x5718A4 VA: 0x5718A4
	private string <event_name>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5718B4 Offset: 0x5718B4 VA: 0x5718B4
	private string <desc>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5718C4 Offset: 0x5718C4 VA: 0x5718C4
	private int <switch_value>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string code { get; set; }
	public string event_name { get; set; }
	public string desc { get; set; }
	public int switch_value { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x663C70 Offset: 0x663C70 VA: 0x663C70
	// RVA: 0x197AD08 Offset: 0x197AD08 VA: 0x197AD08
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663C80 Offset: 0x663C80 VA: 0x663C80
	// RVA: 0x197AD10 Offset: 0x197AD10 VA: 0x197AD10
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663C90 Offset: 0x663C90 VA: 0x663C90
	// RVA: 0x197AD18 Offset: 0x197AD18 VA: 0x197AD18
	public string get_code() { }

	[CompilerGeneratedAttribute] // RVA: 0x663CA0 Offset: 0x663CA0 VA: 0x663CA0
	// RVA: 0x197AD20 Offset: 0x197AD20 VA: 0x197AD20
	private void set_code(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663CB0 Offset: 0x663CB0 VA: 0x663CB0
	// RVA: 0x197AD28 Offset: 0x197AD28 VA: 0x197AD28
	public string get_event_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663CC0 Offset: 0x663CC0 VA: 0x663CC0
	// RVA: 0x197AD30 Offset: 0x197AD30 VA: 0x197AD30
	private void set_event_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663CD0 Offset: 0x663CD0 VA: 0x663CD0
	// RVA: 0x197AD38 Offset: 0x197AD38 VA: 0x197AD38
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x663CE0 Offset: 0x663CE0 VA: 0x663CE0
	// RVA: 0x197AD40 Offset: 0x197AD40 VA: 0x197AD40
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663CF0 Offset: 0x663CF0 VA: 0x663CF0
	// RVA: 0x197AD48 Offset: 0x197AD48 VA: 0x197AD48
	public int get_switch_value() { }

	[CompilerGeneratedAttribute] // RVA: 0x663D00 Offset: 0x663D00 VA: 0x663D00
	// RVA: 0x197AD50 Offset: 0x197AD50 VA: 0x197AD50
	private void set_switch_value(int value) { }

	// RVA: 0x197AB08 Offset: 0x197AB08 VA: 0x197AB08
	internal void .ctor(MemoryStream reader, Action<jf_switch_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1979DE0 Offset: 0x1979DE0 VA: 0x1979DE0
	internal static bool SetupReadActions(Field[] fields, Action<jf_switch_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x197AD60 Offset: 0x197AD60 VA: 0x197AD60 Slot: 4
	public object Clone() { }
}
