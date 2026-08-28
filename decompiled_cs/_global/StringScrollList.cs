// Namespace: 
public class StringScrollList : MonoSingleton<StringScrollList> // TypeDefIndex: 5704
{
	// Fields
	public int MaxItemLimit; // 0xC
	public float MessageLifeTime; // 0x10
	public StringScrollListItem Item; // 0x14
	private List<StringScrollListItem> mItemList; // 0x18
	private Queue<int> mDelayClearActions; // 0x1C
	private int mCurIndex; // 0x20

	// Methods

	// RVA: 0xD7FEC0 Offset: 0xD7FEC0 VA: 0xD7FEC0
	private void Start() { }

	// RVA: 0xD80028 Offset: 0xD80028 VA: 0xD80028 Slot: 5
	protected override void OnDestroy() { }

	// RVA: 0xD801A8 Offset: 0xD801A8 VA: 0xD801A8
	public void AppendString(string text, BattleTeam team) { }

	// RVA: 0xD80648 Offset: 0xD80648 VA: 0xD80648
	private void Forward(BattleTeam team) { }

	// RVA: 0xD80904 Offset: 0xD80904 VA: 0xD80904
	public void .ctor() { }
}
