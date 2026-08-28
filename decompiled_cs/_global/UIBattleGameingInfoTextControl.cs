// Namespace: 
public class UIBattleGameingInfoTextControl : BaseView // TypeDefIndex: 5768
{
	// Fields
	private MainCharacterController mainCtrl; // 0x30
	private HUDTextCanvas _hudTextCanvas; // 0x34
	private BattleCamp _battleCamp; // 0x38
	private XorInt _oldExposeState; // 0x3C
	private Nullable<bool> oppositeSideIsExposed; // 0x44
	private bool mNeedUpdateExposeState; // 0x46

	// Methods

	// RVA: 0xB3FD18 Offset: 0xB3FD18 VA: 0xB3FD18
	public void .ctor() { }

	// RVA: 0xB3FDDC Offset: 0xB3FDDC VA: 0xB3FDDC Slot: 19
	public override void InitViews() { }

	// RVA: 0xB3FF00 Offset: 0xB3FF00 VA: 0xB3FF00
	private void PreloadAsset() { }

	// RVA: 0xB40530 Offset: 0xB40530 VA: 0xB40530 Slot: 23
	public override void OnViewOpen(object[] args) { }

	// RVA: 0xB40574 Offset: 0xB40574 VA: 0xB40574 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB409F0 Offset: 0xB409F0 VA: 0xB409F0 Slot: 21
	public override void Init() { }

	// RVA: 0xB40CEC Offset: 0xB40CEC VA: 0xB40CEC Slot: 24
	public override void OnTick() { }

	// RVA: 0xB40D18 Offset: 0xB40D18 VA: 0xB40D18
	private void UpdateExposeState() { }

	// RVA: 0xB400B4 Offset: 0xB400B4 VA: 0xB400B4
	private void RemovevListeners() { }

	// RVA: 0xB419C0 Offset: 0xB419C0 VA: 0xB419C0
	private void Instance_OnGameingEventOccur(GameingInfoEvent evt, bool isReconnect) { }

	// RVA: 0xB42B14 Offset: 0xB42B14 VA: 0xB42B14
	private void Instance_OnGameingMiddleInfoEvtOccur(GameingScreenMiddleInfoEvent obj) { }

	// RVA: 0xB42B28 Offset: 0xB42B28 VA: 0xB42B28
	private void Instance_OnDiscoverGoalEvt(byte detectorBID, bool isReconnect) { }

	// RVA: 0xB42C54 Offset: 0xB42C54 VA: 0xB42C54
	private void Instance_OnCriticalProgressChangedEvt(RspCriticalProgressNotify netData) { }

	// RVA: 0xB42F94 Offset: 0xB42F94 VA: 0xB42F94
	private void OnBeforeGameStageChanged(Nullable<GameStage> oldStage, Nullable<GameStage> newStage) { }

	// RVA: 0xB43350 Offset: 0xB43350 VA: 0xB43350
	private void OnAfterGameStageChanged() { }

	// RVA: 0xB43624 Offset: 0xB43624 VA: 0xB43624 Slot: 26
	public override void OnViewClose() { }

	// RVA: 0xB43654 Offset: 0xB43654 VA: 0xB43654 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xB436AC Offset: 0xB436AC VA: 0xB436AC Slot: 22
	public override void OnMessage(object sender, object[] args) { }
}
