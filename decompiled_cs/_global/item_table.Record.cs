// Namespace: 
public class item_table.Record : ICloneable // TypeDefIndex: 10704
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571814 Offset: 0x571814 VA: 0x571814
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571824 Offset: 0x571824 VA: 0x571824
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571834 Offset: 0x571834 VA: 0x571834
	private string <name>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x571844 Offset: 0x571844 VA: 0x571844
	private int <content_id>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x571854 Offset: 0x571854 VA: 0x571854
	private int <type>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x571864 Offset: 0x571864 VA: 0x571864
	private int <energy_id>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x571874 Offset: 0x571874 VA: 0x571874
	private string <config_path>k__BackingField; // 0x20

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string name { get; set; }
	public int content_id { get; set; }
	public int type { get; set; }
	public int energy_id { get; set; }
	public string config_path { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x663B90 Offset: 0x663B90 VA: 0x663B90
	// RVA: 0x1979730 Offset: 0x1979730 VA: 0x1979730
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663BA0 Offset: 0x663BA0 VA: 0x663BA0
	// RVA: 0x1979738 Offset: 0x1979738 VA: 0x1979738
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663BB0 Offset: 0x663BB0 VA: 0x663BB0
	// RVA: 0x1979740 Offset: 0x1979740 VA: 0x1979740
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x663BC0 Offset: 0x663BC0 VA: 0x663BC0
	// RVA: 0x1979748 Offset: 0x1979748 VA: 0x1979748
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663BD0 Offset: 0x663BD0 VA: 0x663BD0
	// RVA: 0x1979750 Offset: 0x1979750 VA: 0x1979750
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663BE0 Offset: 0x663BE0 VA: 0x663BE0
	// RVA: 0x1979758 Offset: 0x1979758 VA: 0x1979758
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663BF0 Offset: 0x663BF0 VA: 0x663BF0
	// RVA: 0x1979760 Offset: 0x1979760 VA: 0x1979760
	public int get_content_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663C00 Offset: 0x663C00 VA: 0x663C00
	// RVA: 0x1979768 Offset: 0x1979768 VA: 0x1979768
	private void set_content_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663C10 Offset: 0x663C10 VA: 0x663C10
	// RVA: 0x1979770 Offset: 0x1979770 VA: 0x1979770
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x663C20 Offset: 0x663C20 VA: 0x663C20
	// RVA: 0x1979778 Offset: 0x1979778 VA: 0x1979778
	private void set_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663C30 Offset: 0x663C30 VA: 0x663C30
	// RVA: 0x1979780 Offset: 0x1979780 VA: 0x1979780
	public int get_energy_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663C40 Offset: 0x663C40 VA: 0x663C40
	// RVA: 0x1979788 Offset: 0x1979788 VA: 0x1979788
	private void set_energy_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663C50 Offset: 0x663C50 VA: 0x663C50
	// RVA: 0x1979790 Offset: 0x1979790 VA: 0x1979790
	public string get_config_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x663C60 Offset: 0x663C60 VA: 0x663C60
	// RVA: 0x1979798 Offset: 0x1979798 VA: 0x1979798
	private void set_config_path(string value) { }

	// RVA: 0x1979530 Offset: 0x1979530 VA: 0x1979530
	internal void .ctor(MemoryStream reader, Action<item_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x19784EC Offset: 0x19784EC VA: 0x19784EC
	internal static bool SetupReadActions(Field[] fields, Action<item_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x19797A8 Offset: 0x19797A8 VA: 0x19797A8 Slot: 4
	public object Clone() { }
}
