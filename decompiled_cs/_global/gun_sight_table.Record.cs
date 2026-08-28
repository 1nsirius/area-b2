// Namespace: 
public class gun_sight_table.Record : ICloneable // TypeDefIndex: 10664
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x570C54 Offset: 0x570C54 VA: 0x570C54
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x570C64 Offset: 0x570C64 VA: 0x570C64
	private string <note>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x570C74 Offset: 0x570C74 VA: 0x570C74
	private float <fov>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x570C84 Offset: 0x570C84 VA: 0x570C84
	private float <gun_fov>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x570C94 Offset: 0x570C94 VA: 0x570C94
	private int <crosshair_id>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x570CA4 Offset: 0x570CA4 VA: 0x570CA4
	private int <power_type>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string note { get; set; }
	public float fov { get; set; }
	public float gun_fov { get; set; }
	public int crosshair_id { get; set; }
	public int power_type { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x662410 Offset: 0x662410 VA: 0x662410
	// RVA: 0x1C80258 Offset: 0x1C80258 VA: 0x1C80258
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x662420 Offset: 0x662420 VA: 0x662420
	// RVA: 0x1C80260 Offset: 0x1C80260 VA: 0x1C80260
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662430 Offset: 0x662430 VA: 0x662430
	// RVA: 0x1C80268 Offset: 0x1C80268 VA: 0x1C80268
	public string get_note() { }

	[CompilerGeneratedAttribute] // RVA: 0x662440 Offset: 0x662440 VA: 0x662440
	// RVA: 0x1C80270 Offset: 0x1C80270 VA: 0x1C80270
	private void set_note(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662450 Offset: 0x662450 VA: 0x662450
	// RVA: 0x1C80278 Offset: 0x1C80278 VA: 0x1C80278
	public float get_fov() { }

	[CompilerGeneratedAttribute] // RVA: 0x662460 Offset: 0x662460 VA: 0x662460
	// RVA: 0x1C80280 Offset: 0x1C80280 VA: 0x1C80280
	private void set_fov(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662470 Offset: 0x662470 VA: 0x662470
	// RVA: 0x1C80288 Offset: 0x1C80288 VA: 0x1C80288
	public float get_gun_fov() { }

	[CompilerGeneratedAttribute] // RVA: 0x662480 Offset: 0x662480 VA: 0x662480
	// RVA: 0x1C80290 Offset: 0x1C80290 VA: 0x1C80290
	private void set_gun_fov(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662490 Offset: 0x662490 VA: 0x662490
	// RVA: 0x1C80298 Offset: 0x1C80298 VA: 0x1C80298
	public int get_crosshair_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6624A0 Offset: 0x6624A0 VA: 0x6624A0
	// RVA: 0x1C802A0 Offset: 0x1C802A0 VA: 0x1C802A0
	private void set_crosshair_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6624B0 Offset: 0x6624B0 VA: 0x6624B0
	// RVA: 0x1C802A8 Offset: 0x1C802A8 VA: 0x1C802A8
	public int get_power_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x6624C0 Offset: 0x6624C0 VA: 0x6624C0
	// RVA: 0x1C802B0 Offset: 0x1C802B0 VA: 0x1C802B0
	private void set_power_type(int value) { }

	// RVA: 0x1C80058 Offset: 0x1C80058 VA: 0x1C80058
	internal void .ctor(MemoryStream reader, Action<gun_sight_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C7F188 Offset: 0x1C7F188 VA: 0x1C7F188
	internal static bool SetupReadActions(Field[] fields, Action<gun_sight_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C802C0 Offset: 0x1C802C0 VA: 0x1C802C0 Slot: 4
	public object Clone() { }
}
