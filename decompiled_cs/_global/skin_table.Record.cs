// Namespace: 
public class skin_table.Record : ICloneable // TypeDefIndex: 10816
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572C04 Offset: 0x572C04 VA: 0x572C04
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572C14 Offset: 0x572C14 VA: 0x572C14
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572C24 Offset: 0x572C24 VA: 0x572C24
	private int <type>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572C34 Offset: 0x572C34 VA: 0x572C34
	private int[] <characters>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572C44 Offset: 0x572C44 VA: 0x572C44
	private int[] <handprops>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x572C54 Offset: 0x572C54 VA: 0x572C54
	private int <bag_id_index>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public int type { get; set; }
	public int[] characters { get; set; }
	public int[] handprops { get; set; }
	public int bag_id_index { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x666370 Offset: 0x666370 VA: 0x666370
	// RVA: 0x1F30180 Offset: 0x1F30180 VA: 0x1F30180
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x666380 Offset: 0x666380 VA: 0x666380
	// RVA: 0x1F30188 Offset: 0x1F30188 VA: 0x1F30188
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666390 Offset: 0x666390 VA: 0x666390
	// RVA: 0x1F30190 Offset: 0x1F30190 VA: 0x1F30190
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x6663A0 Offset: 0x6663A0 VA: 0x6663A0
	// RVA: 0x1F30198 Offset: 0x1F30198 VA: 0x1F30198
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6663B0 Offset: 0x6663B0 VA: 0x6663B0
	// RVA: 0x1F301A0 Offset: 0x1F301A0 VA: 0x1F301A0
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x6663C0 Offset: 0x6663C0 VA: 0x6663C0
	// RVA: 0x1F301A8 Offset: 0x1F301A8 VA: 0x1F301A8
	private void set_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6663D0 Offset: 0x6663D0 VA: 0x6663D0
	// RVA: 0x1F301B0 Offset: 0x1F301B0 VA: 0x1F301B0
	public int[] get_characters() { }

	[CompilerGeneratedAttribute] // RVA: 0x6663E0 Offset: 0x6663E0 VA: 0x6663E0
	// RVA: 0x1F301B8 Offset: 0x1F301B8 VA: 0x1F301B8
	private void set_characters(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6663F0 Offset: 0x6663F0 VA: 0x6663F0
	// RVA: 0x1F301C0 Offset: 0x1F301C0 VA: 0x1F301C0
	public int[] get_handprops() { }

	[CompilerGeneratedAttribute] // RVA: 0x666400 Offset: 0x666400 VA: 0x666400
	// RVA: 0x1F301C8 Offset: 0x1F301C8 VA: 0x1F301C8
	private void set_handprops(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666410 Offset: 0x666410 VA: 0x666410
	// RVA: 0x1F301D0 Offset: 0x1F301D0 VA: 0x1F301D0
	public int get_bag_id_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x666420 Offset: 0x666420 VA: 0x666420
	// RVA: 0x1F301D8 Offset: 0x1F301D8 VA: 0x1F301D8
	private void set_bag_id_index(int value) { }

	// RVA: 0x1F2FF80 Offset: 0x1F2FF80 VA: 0x1F2FF80
	internal void .ctor(MemoryStream reader, Action<skin_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F2F0B0 Offset: 0x1F2F0B0 VA: 0x1F2F0B0
	internal static bool SetupReadActions(Field[] fields, Action<skin_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F301E8 Offset: 0x1F301E8 VA: 0x1F301E8 Slot: 4
	public object Clone() { }
}
