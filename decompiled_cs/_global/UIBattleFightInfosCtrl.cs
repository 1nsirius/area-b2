// Namespace: 
public class UIBattleFightInfosCtrl : BaseView // TypeDefIndex: 5745
{
	// Fields
	private Text mGameTimeText; // 0x30
	private Image mLeftOffensiveCampImg; // 0x34
	private Image mLeftDefensiveCampImg; // 0x38
	private Text mLeftCampScoreText; // 0x3C
	private Image mRightOffensiveCampImg; // 0x40
	private Image mRightDefensiveCampImg; // 0x44
	private Text mRightCampScoreText; // 0x48
	private readonly UIBattleFightInfosCtrl.PlayerInfoMiniUI[] mLeftPMiniUIs; // 0x4C
	private readonly UIBattleFightInfosCtrl.PlayerInfoMiniUI[] mRightPMiniUIs; // 0x50
	private int mLastRemainTime; // 0x54
	private float mPlayerItemWidth; // 0x58
	private static readonly int mIsInCrackingStage; // 0x0
	private const int TimeStringLength = 5;
	private string mTimeString; // 0x5C

	// Methods

	// RVA: 0xB3A39C Offset: 0xB3A39C VA: 0xB3A39C
	public void .ctor() { }

	// RVA: 0xB3A450 Offset: 0xB3A450 VA: 0xB3A450 Slot: 19
	public override void InitViews() { }

	// RVA: 0xB3BDBC Offset: 0xB3BDBC VA: 0xB3BDBC Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB3BF6C Offset: 0xB3BF6C VA: 0xB3BF6C
	private void RemoveListeners() { }

	// RVA: 0xB3C11C Offset: 0xB3C11C VA: 0xB3C11C
	private void Instance_OnScanOperationDataRetEvt(RspScanEnemies enemies) { }

	// RVA: 0xB3C528 Offset: 0xB3C528 VA: 0xB3C528
	private void Instance_OnCamScanOperationDataRetEvt(RspMonitorScanEnemies enemies) { }

	// RVA: 0xB3C1E4 Offset: 0xB3C1E4 VA: 0xB3C1E4
	private void UpdatePlayerCareerData(vector<ScanEnemyInfo> data) { }

	// RVA: 0xB3C8D0 Offset: 0xB3C8D0 VA: 0xB3C8D0 Slot: 21
	public override void Init() { }

	// RVA: 0xB3C8D4 Offset: 0xB3C8D4 VA: 0xB3C8D4
	private void SetAllInfos() { }

	// RVA: 0xB3CF68 Offset: 0xB3CF68 VA: 0xB3CF68
	private void SortProxies(List<ICharacterProxy> leftProxies, List<ICharacterProxy> rightProxies) { }

	// RVA: 0xB3D704 Offset: 0xB3D704 VA: 0xB3D704 Slot: 24
	public override void OnTick() { }

	// RVA: 0xB3D158 Offset: 0xB3D158 VA: 0xB3D158
	private void UpdateGameInfos() { }

	// RVA: 0xB3D720 Offset: 0xB3D720 VA: 0xB3D720
	private void CalculateCurTimeString(int duration) { }

	// RVA: 0xB3D600 Offset: 0xB3D600 VA: 0xB3D600
	private void UpdatePlayerMiniUIs() { }

	// RVA: 0xB3DA04 Offset: 0xB3DA04 VA: 0xB3DA04 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xB3DA24 Offset: 0xB3DA24 VA: 0xB3DA24 Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0xB3DB80 Offset: 0xB3DB80 VA: 0xB3DB80
	private void RefreshPlayerVoiceState(long playerId, float volume) { }

	// RVA: 0xB3DD9C Offset: 0xB3DD9C VA: 0xB3DD9C
	private static void .cctor() { }
}
