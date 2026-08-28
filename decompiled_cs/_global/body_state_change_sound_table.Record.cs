// Namespace: 
public class body_state_change_sound_table.Record : ICloneable // TypeDefIndex: 10548
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56F194 Offset: 0x56F194 VA: 0x56F194
	private int <last_body_state>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56F1A4 Offset: 0x56F1A4 VA: 0x56F1A4
	private int <body_state>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56F1B4 Offset: 0x56F1B4 VA: 0x56F1B4
	private int[] <sound_fp>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56F1C4 Offset: 0x56F1C4 VA: 0x56F1C4
	private int[] <sound_tp>k__BackingField; // 0x14

	// Properties
	public int last_body_state { get; set; }
	public int body_state { get; set; }
	public int[] sound_fp { get; set; }
	public int[] sound_tp { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65EE90 Offset: 0x65EE90 VA: 0x65EE90
	// RVA: 0x1E93C38 Offset: 0x1E93C38 VA: 0x1E93C38
	public int get_last_body_state() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EEA0 Offset: 0x65EEA0 VA: 0x65EEA0
	// RVA: 0x1E93C48 Offset: 0x1E93C48 VA: 0x1E93C48
	private void set_last_body_state(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EEB0 Offset: 0x65EEB0 VA: 0x65EEB0
	// RVA: 0x1E93C40 Offset: 0x1E93C40 VA: 0x1E93C40
	public int get_body_state() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EEC0 Offset: 0x65EEC0 VA: 0x65EEC0
	// RVA: 0x1E93C50 Offset: 0x1E93C50 VA: 0x1E93C50
	private void set_body_state(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EED0 Offset: 0x65EED0 VA: 0x65EED0
	// RVA: 0x1E93C58 Offset: 0x1E93C58 VA: 0x1E93C58
	public int[] get_sound_fp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EEE0 Offset: 0x65EEE0 VA: 0x65EEE0
	// RVA: 0x1E93C60 Offset: 0x1E93C60 VA: 0x1E93C60
	private void set_sound_fp(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EEF0 Offset: 0x65EEF0 VA: 0x65EEF0
	// RVA: 0x1E93C68 Offset: 0x1E93C68 VA: 0x1E93C68
	public int[] get_sound_tp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EF00 Offset: 0x65EF00 VA: 0x65EF00
	// RVA: 0x1E93C70 Offset: 0x1E93C70 VA: 0x1E93C70
	private void set_sound_tp(int[] value) { }

	// RVA: 0x1E93A10 Offset: 0x1E93A10 VA: 0x1E93A10
	internal void .ctor(MemoryStream reader, Action<body_state_change_sound_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E92E58 Offset: 0x1E92E58 VA: 0x1E92E58
	internal static bool SetupReadActions(Field[] fields, Action<body_state_change_sound_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E93C80 Offset: 0x1E93C80 VA: 0x1E93C80 Slot: 4
	public object Clone() { }
}
