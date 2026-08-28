// Namespace: 
public class UIBattleScanCharacterTooltipCtrl : BaseView // TypeDefIndex: 5795
{
	// Fields
	private const float TOOLTIP_LIVE_TIME = 10;
	private GameObject _tooltipClone; // 0x30
	private RectTransform _tooltipsParent; // 0x34
	private bool _tooltipsIsDirty; // 0x38
	private readonly List<UIBattleScanCharacterTooltipCtrl.ICharacterTooltip> _tooltips; // 0x3C
	private readonly Dictionary<byte, UIBattleScanCharacterTooltipCtrl.ScanCharacterTooltip> _tooltipDic; // 0x40
	private readonly Queue<UIBattleScanCharacterTooltipCtrl.ScanCharacterTooltip> mFreeSCTooltiQueue; // 0x44
	private readonly Dictionary<byte, UIBattleScanCharacterTooltipCtrl.TraceCharacterTooltip> _traceTooltipDic; // 0x48
	private readonly Queue<UIBattleScanCharacterTooltipCtrl.TraceCharacterTooltip> mFreeTCTooltiQueue; // 0x4C
	private readonly List<UIBattleScanCharacterTooltipCtrl.ICharacterTooltip> _tooltipsCopy; // 0x50
	private Lazy<Func<byte, Vector3>> getCharacterPosFunc; // 0x54

	// Methods

	// RVA: 0xAE6558 Offset: 0xAE6558 VA: 0xAE6558
	public void .ctor() { }

	// RVA: 0xAE67FC Offset: 0xAE67FC VA: 0xAE67FC Slot: 19
	public override void InitViews() { }

	// RVA: 0xAE6EE4 Offset: 0xAE6EE4 VA: 0xAE6EE4 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xAE7130 Offset: 0xAE7130 VA: 0xAE7130
	private void RemoveListeners() { }

	// RVA: 0xAE737C Offset: 0xAE737C VA: 0xAE737C
	private void Instance_OnScanOperationDataRetEvt(RspScanEnemies obj) { }

	// RVA: 0xAE77E4 Offset: 0xAE77E4 VA: 0xAE77E4
	private void Instance_OnCamScanOperationDataRetEvt(RspMonitorScanEnemies obj) { }

	// RVA: 0xAE7954 Offset: 0xAE7954 VA: 0xAE7954
	private void World_OnTrackerReportEvt(RspTrackerReport.Data data) { }

	// RVA: 0xAE74EC Offset: 0xAE74EC VA: 0xAE74EC
	private void TryToShowYouWasFound(vector<ScanEnemyInfo> enemies, int scanType = 0) { }

	// RVA: 0xAE7BA0 Offset: 0xAE7BA0 VA: 0xAE7BA0
	private void AddTooltip(RspTrackerReport.Data data) { }

	// RVA: 0xAE801C Offset: 0xAE801C VA: 0xAE801C
	private void AddTooltip(ScanEnemyInfo info) { }

	// RVA: 0xAE81BC Offset: 0xAE81BC VA: 0xAE81BC
	private UIBattleScanCharacterTooltipCtrl.ScanCharacterTooltip GetScanCharacterTooltip() { }

	// RVA: 0xAE69B0 Offset: 0xAE69B0 VA: 0xAE69B0
	private UIBattleScanCharacterTooltipCtrl.ScanCharacterTooltip CreateTooltip() { }

	// RVA: 0xAE7D60 Offset: 0xAE7D60 VA: 0xAE7D60
	private UIBattleScanCharacterTooltipCtrl.TraceCharacterTooltip GetTraceCharacterTooltip() { }

	// RVA: 0xAE6C4C Offset: 0xAE6C4C VA: 0xAE6C4C
	private UIBattleScanCharacterTooltipCtrl.TraceCharacterTooltip CreateTraceCTTooltip() { }

	// RVA: 0xAE86AC Offset: 0xAE86AC VA: 0xAE86AC
	private void RemoveTooltip(UIBattleScanCharacterTooltipCtrl.ICharacterTooltip tooltip) { }

	// RVA: 0xAE89E8 Offset: 0xAE89E8 VA: 0xAE89E8 Slot: 25
	public override void OnLateTick() { }

	// RVA: 0xAE8C20 Offset: 0xAE8C20 VA: 0xAE8C20
	private void UpdateTooltipsCopy() { }

	// RVA: 0xAE8DD0 Offset: 0xAE8DD0 VA: 0xAE8DD0 Slot: 27
	public override void OnViewDestroy() { }
}
