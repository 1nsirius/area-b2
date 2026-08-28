namespace FGame
{

// Namespace: FGame
public class BattleStatContainer // TypeDefIndex: 9886
{
	// Fields
	private Dictionary<string, BattleStat> mBattleStats; // 0x8

	// Methods

	// RVA: 0xBE9EC8 Offset: 0xBE9EC8 VA: 0xBE9EC8
	public BattleStat GetBattleStat(string battleType) { }

	// RVA: 0xBE9F68 Offset: 0xBE9F68 VA: 0xBE9F68
	public void AddOrUpdate(string battleType, string key, long val) { }

	// RVA: 0xBEA090 Offset: 0xBEA090 VA: 0xBEA090
	public void Reset(List<client.EventStat> stats) { }

	// RVA: 0xBEA284 Offset: 0xBEA284 VA: 0xBEA284
	public long GetVal(string battleStat, string key) { }

	// RVA: 0xBEA184 Offset: 0xBEA184 VA: 0xBEA184
	private void Refill(client.EventStat eventStat, int i) { }

	// RVA: 0xBEA350 Offset: 0xBEA350 VA: 0xBEA350
	public void .ctor() { }
}

} // namespace FGame
