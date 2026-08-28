// Namespace: 
public class character_level_table.Record : ICloneable // TypeDefIndex: 10588
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56FA64 Offset: 0x56FA64 VA: 0x56FA64
	private int <level>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56FA74 Offset: 0x56FA74 VA: 0x56FA74
	private int <exp>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56FA84 Offset: 0x56FA84 VA: 0x56FA84
	private int <exp_level>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56FA94 Offset: 0x56FA94 VA: 0x56FA94
	private int <unlock_type>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56FAA4 Offset: 0x56FAA4 VA: 0x56FAA4
	private int <unlock_id>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56FAB4 Offset: 0x56FAB4 VA: 0x56FAB4
	private int <unlock_value>k__BackingField; // 0x1C

	// Properties
	public int level { get; set; }
	public int exp { get; set; }
	public int exp_level { get; set; }
	public int unlock_type { get; set; }
	public int unlock_id { get; set; }
	public int unlock_value { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x660030 Offset: 0x660030 VA: 0x660030
	// RVA: 0x1E085E0 Offset: 0x1E085E0 VA: 0x1E085E0
	public int get_level() { }

	[CompilerGeneratedAttribute] // RVA: 0x660040 Offset: 0x660040 VA: 0x660040
	// RVA: 0x1E085E8 Offset: 0x1E085E8 VA: 0x1E085E8
	private void set_level(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660050 Offset: 0x660050 VA: 0x660050
	// RVA: 0x1E085F0 Offset: 0x1E085F0 VA: 0x1E085F0
	public int get_exp() { }

	[CompilerGeneratedAttribute] // RVA: 0x660060 Offset: 0x660060 VA: 0x660060
	// RVA: 0x1E085F8 Offset: 0x1E085F8 VA: 0x1E085F8
	private void set_exp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660070 Offset: 0x660070 VA: 0x660070
	// RVA: 0x1E08600 Offset: 0x1E08600 VA: 0x1E08600
	public int get_exp_level() { }

	[CompilerGeneratedAttribute] // RVA: 0x660080 Offset: 0x660080 VA: 0x660080
	// RVA: 0x1E08608 Offset: 0x1E08608 VA: 0x1E08608
	private void set_exp_level(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660090 Offset: 0x660090 VA: 0x660090
	// RVA: 0x1E08610 Offset: 0x1E08610 VA: 0x1E08610
	public int get_unlock_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x6600A0 Offset: 0x6600A0 VA: 0x6600A0
	// RVA: 0x1E08618 Offset: 0x1E08618 VA: 0x1E08618
	private void set_unlock_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6600B0 Offset: 0x6600B0 VA: 0x6600B0
	// RVA: 0x1E08620 Offset: 0x1E08620 VA: 0x1E08620
	public int get_unlock_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6600C0 Offset: 0x6600C0 VA: 0x6600C0
	// RVA: 0x1E08628 Offset: 0x1E08628 VA: 0x1E08628
	private void set_unlock_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6600D0 Offset: 0x6600D0 VA: 0x6600D0
	// RVA: 0x1E08630 Offset: 0x1E08630 VA: 0x1E08630
	public int get_unlock_value() { }

	[CompilerGeneratedAttribute] // RVA: 0x6600E0 Offset: 0x6600E0 VA: 0x6600E0
	// RVA: 0x1E08638 Offset: 0x1E08638 VA: 0x1E08638
	private void set_unlock_value(int value) { }

	// RVA: 0x1E083E0 Offset: 0x1E083E0 VA: 0x1E083E0
	internal void .ctor(MemoryStream reader, Action<character_level_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E07510 Offset: 0x1E07510 VA: 0x1E07510
	internal static bool SetupReadActions(Field[] fields, Action<character_level_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E08648 Offset: 0x1E08648 VA: 0x1E08648 Slot: 4
	public object Clone() { }
}
