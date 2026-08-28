// Namespace: 
public class ActivityDataManager.ExchangeGroup : ActivityDataManager.ActivityGroup // TypeDefIndex: 9871
{
	// Fields
	public long EndTimeTick; // 0x20
	public List<ActivityDataManager.ExchangeRule> Rules; // 0x28
	public List<int> Tokens; // 0x2C
	public Dictionary<int, int> TokenNum; // 0x30

	// Methods

	// RVA: 0xBE304C Offset: 0xBE304C VA: 0xBE304C
	public void SortTask() { }

	// RVA: 0xBE6268 Offset: 0xBE6268 VA: 0xBE6268
	public bool CheckReddot() { }

	// RVA: 0xBE642C Offset: 0xBE642C VA: 0xBE642C Slot: 4
	public override bool HasRedDot() { }

	// RVA: 0xBE6454 Offset: 0xBE6454 VA: 0xBE6454
	public bool HasTaskRedDot() { }

	// RVA: 0xBE6458 Offset: 0xBE6458 VA: 0xBE6458
	public bool HasRewardRedDot() { }

	// RVA: 0xBE2670 Offset: 0xBE2670 VA: 0xBE2670
	public void .ctor() { }
}
