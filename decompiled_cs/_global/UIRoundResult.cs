// Namespace: 
public class UIRoundResult : BaseView // TypeDefIndex: 5815
{
	// Fields
	private Text mReasonText; // 0x30
	private Text mResultText; // 0x34
	private RectTransform mBgWin; // 0x38
	private RectTransform mBgLose; // 0x3C
	private RectTransform mCampAttacker; // 0x40
	private RectTransform mCampDefender; // 0x44
	[TupleElementNamesAttribute] // RVA: 0x55EC4C Offset: 0x55EC4C VA: 0x55EC4C
	private Dictionary<BattleGameOverReason, ValueTuple<int, int>> sCfg; // 0x48

	// Methods

	// RVA: 0xAF711C Offset: 0xAF711C VA: 0xAF711C
	public void .ctor() { }

	// RVA: 0xAF74D4 Offset: 0xAF74D4 VA: 0xAF74D4 Slot: 19
	public override void InitViews() { }

	// RVA: 0xAF760C Offset: 0xAF760C VA: 0xAF760C Slot: 23
	public override void OnViewOpen(object[] args) { }

	// RVA: 0xAF7A84 Offset: 0xAF7A84 VA: 0xAF7A84
	private void ActiveGamePoint(GameObject itemGo, ActionPoint point) { }

	// RVA: 0xAF7968 Offset: 0xAF7968 VA: 0xAF7968
	private string GetReasonString(BattleCamp camp, BattleGameOverReason reason) { }

	// RVA: 0xAF7E50 Offset: 0xAF7E50 VA: 0xAF7E50
	private void SetRoundEndScores() { }
}
