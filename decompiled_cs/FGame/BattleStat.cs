namespace FGame
{

// Namespace: FGame
public class BattleStat // TypeDefIndex: 9885
{
	// Fields
	private readonly Dictionary<string, long> mDict; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563494 Offset: 0x563494 VA: 0x563494
	private string <Type>k__BackingField; // 0xC

	// Properties
	public string Type { get; set; }

	// Methods

	// RVA: 0xBE986C Offset: 0xBE986C VA: 0xBE986C
	public void .ctor(string type) { }

	[CompilerGeneratedAttribute] // RVA: 0x646D20 Offset: 0x646D20 VA: 0x646D20
	// RVA: 0xBE9908 Offset: 0xBE9908 VA: 0xBE9908
	public string get_Type() { }

	[CompilerGeneratedAttribute] // RVA: 0x646D30 Offset: 0x646D30 VA: 0x646D30
	// RVA: 0xBE9900 Offset: 0xBE9900 VA: 0xBE9900
	private void set_Type(string value) { }

	// RVA: 0xBE9910 Offset: 0xBE9910 VA: 0xBE9910
	public void Reset(client.EventStat stats) { }

	// RVA: 0xBE9A70 Offset: 0xBE9A70 VA: 0xBE9A70
	public void AddOrUpdate(client.Stat stat) { }

	// RVA: 0xBE9B54 Offset: 0xBE9B54 VA: 0xBE9B54
	public void AddOrUpdate(string key, long val) { }

	// RVA: 0xBE9BF0 Offset: 0xBE9BF0 VA: 0xBE9BF0
	public long GetVal(string key) { }

	// RVA: 0xBE9CA0 Offset: 0xBE9CA0 VA: 0xBE9CA0
	public long GetVal(int key) { }

	// RVA: 0xBE9CD4 Offset: 0xBE9CD4 VA: 0xBE9CD4
	public long GetVal(BattleStatsInfo key) { }

	// RVA: 0xBE9D08 Offset: 0xBE9D08 VA: 0xBE9D08
	public bool CoptTo(Dictionary<string, int> target) { }

	// RVA: 0xBE99AC Offset: 0xBE99AC VA: 0xBE99AC
	private void Refill(List<client.Stat> list) { }
}

} // namespace FGame
