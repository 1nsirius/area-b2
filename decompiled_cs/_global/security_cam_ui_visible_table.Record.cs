// Namespace: 
public class security_cam_ui_visible_table.Record : ICloneable // TypeDefIndex: 10800
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572964 Offset: 0x572964 VA: 0x572964
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572974 Offset: 0x572974 VA: 0x572974
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572984 Offset: 0x572984 VA: 0x572984
	private int <back_to_character>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572994 Offset: 0x572994 VA: 0x572994
	private int <scan>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5729A4 Offset: 0x5729A4 VA: 0x5729A4
	private int <switch_cam>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public int back_to_character { get; set; }
	public int scan { get; set; }
	public int switch_cam { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x665E30 Offset: 0x665E30 VA: 0x665E30
	// RVA: 0x1F2810C Offset: 0x1F2810C VA: 0x1F2810C
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x665E40 Offset: 0x665E40 VA: 0x665E40
	// RVA: 0x1F28114 Offset: 0x1F28114 VA: 0x1F28114
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665E50 Offset: 0x665E50 VA: 0x665E50
	// RVA: 0x1F2811C Offset: 0x1F2811C VA: 0x1F2811C
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x665E60 Offset: 0x665E60 VA: 0x665E60
	// RVA: 0x1F28124 Offset: 0x1F28124 VA: 0x1F28124
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665E70 Offset: 0x665E70 VA: 0x665E70
	// RVA: 0x1F2812C Offset: 0x1F2812C VA: 0x1F2812C
	public int get_back_to_character() { }

	[CompilerGeneratedAttribute] // RVA: 0x665E80 Offset: 0x665E80 VA: 0x665E80
	// RVA: 0x1F28134 Offset: 0x1F28134 VA: 0x1F28134
	private void set_back_to_character(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665E90 Offset: 0x665E90 VA: 0x665E90
	// RVA: 0x1F2813C Offset: 0x1F2813C VA: 0x1F2813C
	public int get_scan() { }

	[CompilerGeneratedAttribute] // RVA: 0x665EA0 Offset: 0x665EA0 VA: 0x665EA0
	// RVA: 0x1F28144 Offset: 0x1F28144 VA: 0x1F28144
	private void set_scan(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665EB0 Offset: 0x665EB0 VA: 0x665EB0
	// RVA: 0x1F2814C Offset: 0x1F2814C VA: 0x1F2814C
	public int get_switch_cam() { }

	[CompilerGeneratedAttribute] // RVA: 0x665EC0 Offset: 0x665EC0 VA: 0x665EC0
	// RVA: 0x1F28154 Offset: 0x1F28154 VA: 0x1F28154
	private void set_switch_cam(int value) { }

	// RVA: 0x1F27F0C Offset: 0x1F27F0C VA: 0x1F27F0C
	internal void .ctor(MemoryStream reader, Action<security_cam_ui_visible_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F271E4 Offset: 0x1F271E4 VA: 0x1F271E4
	internal static bool SetupReadActions(Field[] fields, Action<security_cam_ui_visible_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F28164 Offset: 0x1F28164 VA: 0x1F28164 Slot: 4
	public object Clone() { }
}
