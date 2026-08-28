// Namespace: 
public class gun_grip_table.Record : ICloneable // TypeDefIndex: 10660
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x570C14 Offset: 0x570C14 VA: 0x570C14
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x570C24 Offset: 0x570C24 VA: 0x570C24
	private string <note>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x570C34 Offset: 0x570C34 VA: 0x570C34
	private float <recoil>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x570C44 Offset: 0x570C44 VA: 0x570C44
	private float <aim_in_time>k__BackingField; // 0x14

	// Properties
	public int id { get; set; }
	public string note { get; set; }
	public float recoil { get; set; }
	public float aim_in_time { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x662390 Offset: 0x662390 VA: 0x662390
	// RVA: 0x1C7EB94 Offset: 0x1C7EB94 VA: 0x1C7EB94
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6623A0 Offset: 0x6623A0 VA: 0x6623A0
	// RVA: 0x1C7EB9C Offset: 0x1C7EB9C VA: 0x1C7EB9C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6623B0 Offset: 0x6623B0 VA: 0x6623B0
	// RVA: 0x1C7EBA4 Offset: 0x1C7EBA4 VA: 0x1C7EBA4
	public string get_note() { }

	[CompilerGeneratedAttribute] // RVA: 0x6623C0 Offset: 0x6623C0 VA: 0x6623C0
	// RVA: 0x1C7EBAC Offset: 0x1C7EBAC VA: 0x1C7EBAC
	private void set_note(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6623D0 Offset: 0x6623D0 VA: 0x6623D0
	// RVA: 0x1C7EBB4 Offset: 0x1C7EBB4 VA: 0x1C7EBB4
	public float get_recoil() { }

	[CompilerGeneratedAttribute] // RVA: 0x6623E0 Offset: 0x6623E0 VA: 0x6623E0
	// RVA: 0x1C7EBBC Offset: 0x1C7EBBC VA: 0x1C7EBBC
	private void set_recoil(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6623F0 Offset: 0x6623F0 VA: 0x6623F0
	// RVA: 0x1C7EBC4 Offset: 0x1C7EBC4 VA: 0x1C7EBC4
	public float get_aim_in_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x662400 Offset: 0x662400 VA: 0x662400
	// RVA: 0x1C7EBCC Offset: 0x1C7EBCC VA: 0x1C7EBCC
	private void set_aim_in_time(float value) { }

	// RVA: 0x1C7E994 Offset: 0x1C7E994 VA: 0x1C7E994
	internal void .ctor(MemoryStream reader, Action<gun_grip_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C7DE14 Offset: 0x1C7DE14 VA: 0x1C7DE14
	internal static bool SetupReadActions(Field[] fields, Action<gun_grip_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C7EBDC Offset: 0x1C7EBDC VA: 0x1C7EBDC Slot: 4
	public object Clone() { }
}
