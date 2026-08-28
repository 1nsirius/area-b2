// Namespace: 
public class crosshair_table.Record : ICloneable // TypeDefIndex: 10624
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56FFD4 Offset: 0x56FFD4 VA: 0x56FFD4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56FFE4 Offset: 0x56FFE4 VA: 0x56FFE4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56FFF4 Offset: 0x56FFF4 VA: 0x56FFF4
	private string <path>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x570004 Offset: 0x570004 VA: 0x570004
	private float <changeable>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x570014 Offset: 0x570014 VA: 0x570014
	private string <resName>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x570024 Offset: 0x570024 VA: 0x570024
	private float <moveable>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string path { get; set; }
	public float changeable { get; set; }
	public string resName { get; set; }
	public float moveable { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x660B10 Offset: 0x660B10 VA: 0x660B10
	// RVA: 0x1E6D878 Offset: 0x1E6D878 VA: 0x1E6D878
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660B20 Offset: 0x660B20 VA: 0x660B20
	// RVA: 0x1E6D880 Offset: 0x1E6D880 VA: 0x1E6D880
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660B30 Offset: 0x660B30 VA: 0x660B30
	// RVA: 0x1E6D888 Offset: 0x1E6D888 VA: 0x1E6D888
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x660B40 Offset: 0x660B40 VA: 0x660B40
	// RVA: 0x1E6D890 Offset: 0x1E6D890 VA: 0x1E6D890
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660B50 Offset: 0x660B50 VA: 0x660B50
	// RVA: 0x1E6D898 Offset: 0x1E6D898 VA: 0x1E6D898
	public string get_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x660B60 Offset: 0x660B60 VA: 0x660B60
	// RVA: 0x1E6D8A0 Offset: 0x1E6D8A0 VA: 0x1E6D8A0
	private void set_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660B70 Offset: 0x660B70 VA: 0x660B70
	// RVA: 0x1E6D8A8 Offset: 0x1E6D8A8 VA: 0x1E6D8A8
	public float get_changeable() { }

	[CompilerGeneratedAttribute] // RVA: 0x660B80 Offset: 0x660B80 VA: 0x660B80
	// RVA: 0x1E6D8B0 Offset: 0x1E6D8B0 VA: 0x1E6D8B0
	private void set_changeable(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660B90 Offset: 0x660B90 VA: 0x660B90
	// RVA: 0x1E6D8B8 Offset: 0x1E6D8B8 VA: 0x1E6D8B8
	public string get_resName() { }

	[CompilerGeneratedAttribute] // RVA: 0x660BA0 Offset: 0x660BA0 VA: 0x660BA0
	// RVA: 0x1E6D8C0 Offset: 0x1E6D8C0 VA: 0x1E6D8C0
	private void set_resName(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660BB0 Offset: 0x660BB0 VA: 0x660BB0
	// RVA: 0x1E6D8C8 Offset: 0x1E6D8C8 VA: 0x1E6D8C8
	public float get_moveable() { }

	[CompilerGeneratedAttribute] // RVA: 0x660BC0 Offset: 0x660BC0 VA: 0x660BC0
	// RVA: 0x1E6D8D0 Offset: 0x1E6D8D0 VA: 0x1E6D8D0
	private void set_moveable(float value) { }

	// RVA: 0x1E6D678 Offset: 0x1E6D678 VA: 0x1E6D678
	internal void .ctor(MemoryStream reader, Action<crosshair_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E6C7A8 Offset: 0x1E6C7A8 VA: 0x1E6C7A8
	internal static bool SetupReadActions(Field[] fields, Action<crosshair_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E6D8E0 Offset: 0x1E6D8E0 VA: 0x1E6D8E0 Slot: 4
	public object Clone() { }
}
