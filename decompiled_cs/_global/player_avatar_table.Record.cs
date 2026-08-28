// Namespace: 
public class player_avatar_table.Record : ICloneable // TypeDefIndex: 10756
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572124 Offset: 0x572124 VA: 0x572124
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572134 Offset: 0x572134 VA: 0x572134
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572144 Offset: 0x572144 VA: 0x572144
	private string <icon>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572154 Offset: 0x572154 VA: 0x572154
	private int <lang_id>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572164 Offset: 0x572164 VA: 0x572164
	private int <whether_open>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x572174 Offset: 0x572174 VA: 0x572174
	private int <acquire>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string icon { get; set; }
	public int lang_id { get; set; }
	public int whether_open { get; set; }
	public int acquire { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x664DB0 Offset: 0x664DB0 VA: 0x664DB0
	// RVA: 0x1EC5524 Offset: 0x1EC5524 VA: 0x1EC5524
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x664DC0 Offset: 0x664DC0 VA: 0x664DC0
	// RVA: 0x1EC552C Offset: 0x1EC552C VA: 0x1EC552C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664DD0 Offset: 0x664DD0 VA: 0x664DD0
	// RVA: 0x1EC5534 Offset: 0x1EC5534 VA: 0x1EC5534
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x664DE0 Offset: 0x664DE0 VA: 0x664DE0
	// RVA: 0x1EC553C Offset: 0x1EC553C VA: 0x1EC553C
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664DF0 Offset: 0x664DF0 VA: 0x664DF0
	// RVA: 0x1EC5544 Offset: 0x1EC5544 VA: 0x1EC5544
	public string get_icon() { }

	[CompilerGeneratedAttribute] // RVA: 0x664E00 Offset: 0x664E00 VA: 0x664E00
	// RVA: 0x1EC554C Offset: 0x1EC554C VA: 0x1EC554C
	private void set_icon(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664E10 Offset: 0x664E10 VA: 0x664E10
	// RVA: 0x1EC5554 Offset: 0x1EC5554 VA: 0x1EC5554
	public int get_lang_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x664E20 Offset: 0x664E20 VA: 0x664E20
	// RVA: 0x1EC555C Offset: 0x1EC555C VA: 0x1EC555C
	private void set_lang_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664E30 Offset: 0x664E30 VA: 0x664E30
	// RVA: 0x1EC5564 Offset: 0x1EC5564 VA: 0x1EC5564
	public int get_whether_open() { }

	[CompilerGeneratedAttribute] // RVA: 0x664E40 Offset: 0x664E40 VA: 0x664E40
	// RVA: 0x1EC556C Offset: 0x1EC556C VA: 0x1EC556C
	private void set_whether_open(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664E50 Offset: 0x664E50 VA: 0x664E50
	// RVA: 0x1EC5574 Offset: 0x1EC5574 VA: 0x1EC5574
	public int get_acquire() { }

	[CompilerGeneratedAttribute] // RVA: 0x664E60 Offset: 0x664E60 VA: 0x664E60
	// RVA: 0x1EC557C Offset: 0x1EC557C VA: 0x1EC557C
	private void set_acquire(int value) { }

	// RVA: 0x1EC5324 Offset: 0x1EC5324 VA: 0x1EC5324
	internal void .ctor(MemoryStream reader, Action<player_avatar_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1EC4454 Offset: 0x1EC4454 VA: 0x1EC4454
	internal static bool SetupReadActions(Field[] fields, Action<player_avatar_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1EC558C Offset: 0x1EC558C VA: 0x1EC558C Slot: 4
	public object Clone() { }
}
