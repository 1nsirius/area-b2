// Namespace: 
public class ambient_sound_table.Record : ICloneable // TypeDefIndex: 10528
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56EB14 Offset: 0x56EB14 VA: 0x56EB14
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56EB24 Offset: 0x56EB24 VA: 0x56EB24
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56EB34 Offset: 0x56EB34 VA: 0x56EB34
	private int <play>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56EB44 Offset: 0x56EB44 VA: 0x56EB44
	private int <stop>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56EB54 Offset: 0x56EB54 VA: 0x56EB54
	private int <rtpc>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56EB64 Offset: 0x56EB64 VA: 0x56EB64
	private string <desc>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int play { get; set; }
	public int stop { get; set; }
	public int rtpc { get; set; }
	public string desc { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65E190 Offset: 0x65E190 VA: 0x65E190
	// RVA: 0x1E8AD80 Offset: 0x1E8AD80 VA: 0x1E8AD80
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E1A0 Offset: 0x65E1A0 VA: 0x65E1A0
	// RVA: 0x1E8AD88 Offset: 0x1E8AD88 VA: 0x1E8AD88
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E1B0 Offset: 0x65E1B0 VA: 0x65E1B0
	// RVA: 0x1E8AD90 Offset: 0x1E8AD90 VA: 0x1E8AD90
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E1C0 Offset: 0x65E1C0 VA: 0x65E1C0
	// RVA: 0x1E8AD98 Offset: 0x1E8AD98 VA: 0x1E8AD98
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E1D0 Offset: 0x65E1D0 VA: 0x65E1D0
	// RVA: 0x1E8ADA0 Offset: 0x1E8ADA0 VA: 0x1E8ADA0
	public int get_play() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E1E0 Offset: 0x65E1E0 VA: 0x65E1E0
	// RVA: 0x1E8ADA8 Offset: 0x1E8ADA8 VA: 0x1E8ADA8
	private void set_play(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E1F0 Offset: 0x65E1F0 VA: 0x65E1F0
	// RVA: 0x1E8ADB0 Offset: 0x1E8ADB0 VA: 0x1E8ADB0
	public int get_stop() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E200 Offset: 0x65E200 VA: 0x65E200
	// RVA: 0x1E8ADB8 Offset: 0x1E8ADB8 VA: 0x1E8ADB8
	private void set_stop(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E210 Offset: 0x65E210 VA: 0x65E210
	// RVA: 0x1E8ADC0 Offset: 0x1E8ADC0 VA: 0x1E8ADC0
	public int get_rtpc() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E220 Offset: 0x65E220 VA: 0x65E220
	// RVA: 0x1E8ADC8 Offset: 0x1E8ADC8 VA: 0x1E8ADC8
	private void set_rtpc(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E230 Offset: 0x65E230 VA: 0x65E230
	// RVA: 0x1E8ADD0 Offset: 0x1E8ADD0 VA: 0x1E8ADD0
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E240 Offset: 0x65E240 VA: 0x65E240
	// RVA: 0x1E8ADD8 Offset: 0x1E8ADD8 VA: 0x1E8ADD8
	private void set_desc(string value) { }

	// RVA: 0x1E8AB80 Offset: 0x1E8AB80 VA: 0x1E8AB80
	internal void .ctor(MemoryStream reader, Action<ambient_sound_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E89CB0 Offset: 0x1E89CB0 VA: 0x1E89CB0
	internal static bool SetupReadActions(Field[] fields, Action<ambient_sound_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E8ADE8 Offset: 0x1E8ADE8 VA: 0x1E8ADE8 Slot: 4
	public object Clone() { }
}
