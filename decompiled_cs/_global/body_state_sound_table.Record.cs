// Namespace: 
public class body_state_sound_table.Record : ICloneable // TypeDefIndex: 10552
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56F1D4 Offset: 0x56F1D4 VA: 0x56F1D4
	private int <body_state>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56F1E4 Offset: 0x56F1E4 VA: 0x56F1E4
	private int[] <sound_fp>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56F1F4 Offset: 0x56F1F4 VA: 0x56F1F4
	private int[] <sound_tp>k__BackingField; // 0x10

	// Properties
	public int body_state { get; set; }
	public int[] sound_fp { get; set; }
	public int[] sound_tp { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65EF10 Offset: 0x65EF10 VA: 0x65EF10
	// RVA: 0x1E94DF4 Offset: 0x1E94DF4 VA: 0x1E94DF4
	public int get_body_state() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EF20 Offset: 0x65EF20 VA: 0x65EF20
	// RVA: 0x1E94DFC Offset: 0x1E94DFC VA: 0x1E94DFC
	private void set_body_state(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EF30 Offset: 0x65EF30 VA: 0x65EF30
	// RVA: 0x1E94E04 Offset: 0x1E94E04 VA: 0x1E94E04
	public int[] get_sound_fp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EF40 Offset: 0x65EF40 VA: 0x65EF40
	// RVA: 0x1E94E0C Offset: 0x1E94E0C VA: 0x1E94E0C
	private void set_sound_fp(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EF50 Offset: 0x65EF50 VA: 0x65EF50
	// RVA: 0x1E94E14 Offset: 0x1E94E14 VA: 0x1E94E14
	public int[] get_sound_tp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EF60 Offset: 0x65EF60 VA: 0x65EF60
	// RVA: 0x1E94E1C Offset: 0x1E94E1C VA: 0x1E94E1C
	private void set_sound_tp(int[] value) { }

	// RVA: 0x1E94BF4 Offset: 0x1E94BF4 VA: 0x1E94BF4
	internal void .ctor(MemoryStream reader, Action<body_state_sound_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E9421C Offset: 0x1E9421C VA: 0x1E9421C
	internal static bool SetupReadActions(Field[] fields, Action<body_state_sound_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E94E2C Offset: 0x1E94E2C VA: 0x1E94E2C Slot: 4
	public object Clone() { }
}
