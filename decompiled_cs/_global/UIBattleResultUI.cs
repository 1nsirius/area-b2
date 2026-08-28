// Namespace: 
public class UIBattleResultUI : BaseView // TypeDefIndex: 5791
{
	// Fields
	private RectTransform mBlueTeam; // 0x30
	private RectTransform mRedTeam; // 0x34
	private Text _resultText; // 0x38
	private RectTransform mWinImg; // 0x3C
	private RectTransform mLoseImg; // 0x40
	private RectTransform mDogfallImg; // 0x44
	private LanguageMono modeTxt; // 0x48
	private GameObject _bgGo; // 0x4C
	private Animator _blackScreen; // 0x50
	private Button _exitToLobby; // 0x54
	private Button _shareBtn; // 0x58
	private RectTransform _shareTips; // 0x5C
	private bool _tooltipsIsDirty; // 0x60
	private readonly List<UIBattleResultUI.WinerCharacterTooltip> _tooltips; // 0x64
	private readonly List<UIBattleResultUI.WinerCharacterTooltip> _tooltipsCopy; // 0x68
	private GameObject _tooltipClone; // 0x6C
	private BattleResultTeamInfos mBattleTeamInfos; // 0x70
	private string winerName; // 0x74
	private int mCharacterId; // 0x78
	private game.CommonBattleResult _battleResult; // 0x7C

	// Methods

	// RVA: 0xAE1960 Offset: 0xAE1960 VA: 0xAE1960
	public void .ctor() { }

	// RVA: 0xAE1A18 Offset: 0xAE1A18 VA: 0xAE1A18 Slot: 19
	public override void InitViews() { }

	// RVA: 0xAE242C Offset: 0xAE242C VA: 0xAE242C
	private void RefreshMode() { }

	// RVA: 0xAE25BC Offset: 0xAE25BC VA: 0xAE25BC Slot: 20
	public override void AddListeners() { }

	// RVA: 0xAE28BC Offset: 0xAE28BC VA: 0xAE28BC
	private void Instance_OnBattleFinishBalckScreenEvt() { }

	// RVA: 0xAE297C Offset: 0xAE297C VA: 0xAE297C
	private void OnBattleFinishPhaseEvtTwo() { }

	// RVA: 0xAE311C Offset: 0xAE311C VA: 0xAE311C
	private void Instance_OnBattleFinishPhaseTwoEvt(List<IWinnerCharacter> arg1, IWinnerCharacter arg2) { }

	// RVA: 0xAE2FE8 Offset: 0xAE2FE8 VA: 0xAE2FE8
	private void DeActiveGameResult() { }

	// RVA: 0xAE2C14 Offset: 0xAE2C14 VA: 0xAE2C14
	private void ShowWinersNames() { }

	// RVA: 0xAE3738 Offset: 0xAE3738 VA: 0xAE3738
	private void AddTooltip(UIBattleResultUI.WinerCharacterTooltip tooltip) { }

	// RVA: 0xAE37C0 Offset: 0xAE37C0 VA: 0xAE37C0
	private void Instance_OnBattleFinishPhaseThreeEvt(string name, int characterId) { }

	// RVA: 0xAE3B08 Offset: 0xAE3B08 VA: 0xAE3B08 Slot: 24
	public override void OnTick() { }

	// RVA: 0xAE3CF4 Offset: 0xAE3CF4 VA: 0xAE3CF4
	private void UpdateTooltipsCopy() { }

	// RVA: 0xAE404C Offset: 0xAE404C VA: 0xAE404C Slot: 23
	public override void OnViewOpen(object[] objs) { }

	// RVA: 0xAE4968 Offset: 0xAE4968 VA: 0xAE4968
	private void RefreshScore(game.CommonBattleResult pkt) { }

	// RVA: 0xAE47E4 Offset: 0xAE47E4 VA: 0xAE47E4
	private void RefreshTeamName() { }

	// RVA: 0xAE44F4 Offset: 0xAE44F4 VA: 0xAE44F4
	private void RefreshResult(game.CommonBattleResult pkt) { }

	// RVA: 0xAE4D2C Offset: 0xAE4D2C VA: 0xAE4D2C
	private void SetRoundEndScores() { }

	// RVA: 0xAE5108 Offset: 0xAE5108 VA: 0xAE5108
	private void ActiveGamePoint(GameObject itemGo, game.ActionPoint point) { }

	// RVA: 0xAE550C Offset: 0xAE550C VA: 0xAE550C
	private void __OnExitLobbyBtnBeClickCallBack() { }

	// RVA: 0xAE5760 Offset: 0xAE5760 VA: 0xAE5760 Slot: 27
	public override void OnViewDestroy() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD7C Offset: 0x57AD7C VA: 0x57AD7C
	// RVA: 0xAE58E8 Offset: 0xAE58E8 VA: 0xAE58E8
	private void <InitViews>b__19_0() { }
}
