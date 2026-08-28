// Namespace: 
public class handprop_skin_table.Record : ICloneable // TypeDefIndex: 10692
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5716F4 Offset: 0x5716F4 VA: 0x5716F4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571704 Offset: 0x571704 VA: 0x571704
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571714 Offset: 0x571714 VA: 0x571714
	private int <hand_prop_id>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x571724 Offset: 0x571724 VA: 0x571724
	private string <model_path>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x571734 Offset: 0x571734 VA: 0x571734
	private string[] <basic_mats>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x571744 Offset: 0x571744 VA: 0x571744
	private string[] <override_mats>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x571754 Offset: 0x571754 VA: 0x571754
	private int[] <appr_attachment_skins>k__BackingField; // 0x20

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int hand_prop_id { get; set; }
	public string model_path { get; set; }
	public string[] basic_mats { get; set; }
	public string[] override_mats { get; set; }
	public int[] appr_attachment_skins { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x663950 Offset: 0x663950 VA: 0x663950
	// RVA: 0x1975198 Offset: 0x1975198 VA: 0x1975198
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663960 Offset: 0x663960 VA: 0x663960
	// RVA: 0x19751A0 Offset: 0x19751A0 VA: 0x19751A0
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663970 Offset: 0x663970 VA: 0x663970
	// RVA: 0x19751A8 Offset: 0x19751A8 VA: 0x19751A8
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663980 Offset: 0x663980 VA: 0x663980
	// RVA: 0x19751B0 Offset: 0x19751B0 VA: 0x19751B0
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663990 Offset: 0x663990 VA: 0x663990
	// RVA: 0x19751B8 Offset: 0x19751B8 VA: 0x19751B8
	public int get_hand_prop_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6639A0 Offset: 0x6639A0 VA: 0x6639A0
	// RVA: 0x19751C0 Offset: 0x19751C0 VA: 0x19751C0
	private void set_hand_prop_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6639B0 Offset: 0x6639B0 VA: 0x6639B0
	// RVA: 0x19751C8 Offset: 0x19751C8 VA: 0x19751C8
	public string get_model_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x6639C0 Offset: 0x6639C0 VA: 0x6639C0
	// RVA: 0x19751D0 Offset: 0x19751D0 VA: 0x19751D0
	private void set_model_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6639D0 Offset: 0x6639D0 VA: 0x6639D0
	// RVA: 0x19751D8 Offset: 0x19751D8 VA: 0x19751D8
	public string[] get_basic_mats() { }

	[CompilerGeneratedAttribute] // RVA: 0x6639E0 Offset: 0x6639E0 VA: 0x6639E0
	// RVA: 0x19751E0 Offset: 0x19751E0 VA: 0x19751E0
	private void set_basic_mats(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6639F0 Offset: 0x6639F0 VA: 0x6639F0
	// RVA: 0x19751E8 Offset: 0x19751E8 VA: 0x19751E8
	public string[] get_override_mats() { }

	[CompilerGeneratedAttribute] // RVA: 0x663A00 Offset: 0x663A00 VA: 0x663A00
	// RVA: 0x19751F0 Offset: 0x19751F0 VA: 0x19751F0
	private void set_override_mats(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663A10 Offset: 0x663A10 VA: 0x663A10
	// RVA: 0x19751F8 Offset: 0x19751F8 VA: 0x19751F8
	public int[] get_appr_attachment_skins() { }

	[CompilerGeneratedAttribute] // RVA: 0x663A20 Offset: 0x663A20 VA: 0x663A20
	// RVA: 0x1975200 Offset: 0x1975200 VA: 0x1975200
	private void set_appr_attachment_skins(int[] value) { }

	// RVA: 0x1974F98 Offset: 0x1974F98 VA: 0x1974F98
	internal void .ctor(MemoryStream reader, Action<handprop_skin_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1973F54 Offset: 0x1973F54 VA: 0x1973F54
	internal static bool SetupReadActions(Field[] fields, Action<handprop_skin_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1975210 Offset: 0x1975210 VA: 0x1975210 Slot: 4
	public object Clone() { }
}
