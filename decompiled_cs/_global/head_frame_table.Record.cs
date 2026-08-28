// Namespace: 
public class head_frame_table.Record : ICloneable // TypeDefIndex: 10696
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571764 Offset: 0x571764 VA: 0x571764
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571774 Offset: 0x571774 VA: 0x571774
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571784 Offset: 0x571784 VA: 0x571784
	private string <icon>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x571794 Offset: 0x571794 VA: 0x571794
	private int <name>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5717A4 Offset: 0x5717A4 VA: 0x5717A4
	private int <condition>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string icon { get; set; }
	public int name { get; set; }
	public int condition { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x663A30 Offset: 0x663A30 VA: 0x663A30
	// RVA: 0x1976770 Offset: 0x1976770 VA: 0x1976770
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663A40 Offset: 0x663A40 VA: 0x663A40
	// RVA: 0x1976778 Offset: 0x1976778 VA: 0x1976778
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663A50 Offset: 0x663A50 VA: 0x663A50
	// RVA: 0x1976780 Offset: 0x1976780 VA: 0x1976780
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x663A60 Offset: 0x663A60 VA: 0x663A60
	// RVA: 0x1976788 Offset: 0x1976788 VA: 0x1976788
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663A70 Offset: 0x663A70 VA: 0x663A70
	// RVA: 0x1976790 Offset: 0x1976790 VA: 0x1976790
	public string get_icon() { }

	[CompilerGeneratedAttribute] // RVA: 0x663A80 Offset: 0x663A80 VA: 0x663A80
	// RVA: 0x1976798 Offset: 0x1976798 VA: 0x1976798
	private void set_icon(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663A90 Offset: 0x663A90 VA: 0x663A90
	// RVA: 0x19767A0 Offset: 0x19767A0 VA: 0x19767A0
	public int get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663AA0 Offset: 0x663AA0 VA: 0x663AA0
	// RVA: 0x19767A8 Offset: 0x19767A8 VA: 0x19767A8
	private void set_name(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663AB0 Offset: 0x663AB0 VA: 0x663AB0
	// RVA: 0x19767B0 Offset: 0x19767B0 VA: 0x19767B0
	public int get_condition() { }

	[CompilerGeneratedAttribute] // RVA: 0x663AC0 Offset: 0x663AC0 VA: 0x663AC0
	// RVA: 0x19767B8 Offset: 0x19767B8 VA: 0x19767B8
	private void set_condition(int value) { }

	// RVA: 0x1976570 Offset: 0x1976570 VA: 0x1976570
	internal void .ctor(MemoryStream reader, Action<head_frame_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1975848 Offset: 0x1975848 VA: 0x1975848
	internal static bool SetupReadActions(Field[] fields, Action<head_frame_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x19767C8 Offset: 0x19767C8 VA: 0x19767C8 Slot: 4
	public object Clone() { }
}
