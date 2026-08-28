// Namespace: 
public class country_table.Record : ICloneable // TypeDefIndex: 10620
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56FF94 Offset: 0x56FF94 VA: 0x56FF94
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56FFA4 Offset: 0x56FFA4 VA: 0x56FFA4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56FFB4 Offset: 0x56FFB4 VA: 0x56FFB4
	private string <country>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56FFC4 Offset: 0x56FFC4 VA: 0x56FFC4
	private string <currency_symbol>k__BackingField; // 0x14

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string country { get; set; }
	public string currency_symbol { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x660A90 Offset: 0x660A90 VA: 0x660A90
	// RVA: 0x1E6C1C4 Offset: 0x1E6C1C4 VA: 0x1E6C1C4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660AA0 Offset: 0x660AA0 VA: 0x660AA0
	// RVA: 0x1E6C1CC Offset: 0x1E6C1CC VA: 0x1E6C1CC
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660AB0 Offset: 0x660AB0 VA: 0x660AB0
	// RVA: 0x1E6C1D4 Offset: 0x1E6C1D4 VA: 0x1E6C1D4
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x660AC0 Offset: 0x660AC0 VA: 0x660AC0
	// RVA: 0x1E6C1DC Offset: 0x1E6C1DC VA: 0x1E6C1DC
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660AD0 Offset: 0x660AD0 VA: 0x660AD0
	// RVA: 0x1E6C1E4 Offset: 0x1E6C1E4 VA: 0x1E6C1E4
	public string get_country() { }

	[CompilerGeneratedAttribute] // RVA: 0x660AE0 Offset: 0x660AE0 VA: 0x660AE0
	// RVA: 0x1E6C1EC Offset: 0x1E6C1EC VA: 0x1E6C1EC
	private void set_country(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660AF0 Offset: 0x660AF0 VA: 0x660AF0
	// RVA: 0x1E6C1F4 Offset: 0x1E6C1F4 VA: 0x1E6C1F4
	public string get_currency_symbol() { }

	[CompilerGeneratedAttribute] // RVA: 0x660B00 Offset: 0x660B00 VA: 0x660B00
	// RVA: 0x1E6C1FC Offset: 0x1E6C1FC VA: 0x1E6C1FC
	private void set_currency_symbol(string value) { }

	// RVA: 0x1E6BFC4 Offset: 0x1E6BFC4 VA: 0x1E6BFC4
	internal void .ctor(MemoryStream reader, Action<country_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E6B444 Offset: 0x1E6B444 VA: 0x1E6B444
	internal static bool SetupReadActions(Field[] fields, Action<country_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E6C20C Offset: 0x1E6C20C VA: 0x1E6C20C Slot: 4
	public object Clone() { }
}
