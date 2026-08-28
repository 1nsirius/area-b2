// Namespace: 
public class quickchat_table.Record : ICloneable // TypeDefIndex: 10772
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572334 Offset: 0x572334 VA: 0x572334
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572344 Offset: 0x572344 VA: 0x572344
	private int <lang_id>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572354 Offset: 0x572354 VA: 0x572354
	private int <camp>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572364 Offset: 0x572364 VA: 0x572364
	private string <content>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572374 Offset: 0x572374 VA: 0x572374
	private int <order>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x572384 Offset: 0x572384 VA: 0x572384
	private string <voice>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public int lang_id { get; set; }
	public int camp { get; set; }
	public string content { get; set; }
	public int order { get; set; }
	public string voice { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6651D0 Offset: 0x6651D0 VA: 0x6651D0
	// RVA: 0x1ECC2C4 Offset: 0x1ECC2C4 VA: 0x1ECC2C4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6651E0 Offset: 0x6651E0 VA: 0x6651E0
	// RVA: 0x1ECC2CC Offset: 0x1ECC2CC VA: 0x1ECC2CC
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6651F0 Offset: 0x6651F0 VA: 0x6651F0
	// RVA: 0x1ECC2D4 Offset: 0x1ECC2D4 VA: 0x1ECC2D4
	public int get_lang_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x665200 Offset: 0x665200 VA: 0x665200
	// RVA: 0x1ECC2DC Offset: 0x1ECC2DC VA: 0x1ECC2DC
	private void set_lang_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665210 Offset: 0x665210 VA: 0x665210
	// RVA: 0x1ECC2E4 Offset: 0x1ECC2E4 VA: 0x1ECC2E4
	public int get_camp() { }

	[CompilerGeneratedAttribute] // RVA: 0x665220 Offset: 0x665220 VA: 0x665220
	// RVA: 0x1ECC2EC Offset: 0x1ECC2EC VA: 0x1ECC2EC
	private void set_camp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665230 Offset: 0x665230 VA: 0x665230
	// RVA: 0x1ECC2F4 Offset: 0x1ECC2F4 VA: 0x1ECC2F4
	public string get_content() { }

	[CompilerGeneratedAttribute] // RVA: 0x665240 Offset: 0x665240 VA: 0x665240
	// RVA: 0x1ECC2FC Offset: 0x1ECC2FC VA: 0x1ECC2FC
	private void set_content(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665250 Offset: 0x665250 VA: 0x665250
	// RVA: 0x1ECC304 Offset: 0x1ECC304 VA: 0x1ECC304
	public int get_order() { }

	[CompilerGeneratedAttribute] // RVA: 0x665260 Offset: 0x665260 VA: 0x665260
	// RVA: 0x1ECC30C Offset: 0x1ECC30C VA: 0x1ECC30C
	private void set_order(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665270 Offset: 0x665270 VA: 0x665270
	// RVA: 0x1ECC314 Offset: 0x1ECC314 VA: 0x1ECC314
	public string get_voice() { }

	[CompilerGeneratedAttribute] // RVA: 0x665280 Offset: 0x665280 VA: 0x665280
	// RVA: 0x1ECC31C Offset: 0x1ECC31C VA: 0x1ECC31C
	private void set_voice(string value) { }

	// RVA: 0x1ECC0C4 Offset: 0x1ECC0C4 VA: 0x1ECC0C4
	internal void .ctor(MemoryStream reader, Action<quickchat_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1ECB1F4 Offset: 0x1ECB1F4 VA: 0x1ECB1F4
	internal static bool SetupReadActions(Field[] fields, Action<quickchat_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1ECC32C Offset: 0x1ECC32C VA: 0x1ECC32C Slot: 4
	public object Clone() { }
}
