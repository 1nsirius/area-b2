// Namespace: 
public class UIBattleResult1UI : BaseView // TypeDefIndex: 5789
{
	// Fields
	private Text _resultText; // 0x30
	private RectTransform mBlueTeam; // 0x34
	private RectTransform mDogfallImg; // 0x38
	private RectTransform mLoseImg; // 0x3C
	private LanguageMono modeTxt; // 0x40
	private RectTransform mRedTeam; // 0x44
	private RectTransform mWinImg; // 0x48

	// Methods

	// RVA: 0xAE0064 Offset: 0xAE0064 VA: 0xAE0064
	public void .ctor() { }

	// RVA: 0xAE00D0 Offset: 0xAE00D0 VA: 0xAE00D0 Slot: 19
	public override void InitViews() { }

	// RVA: 0xAE0188 Offset: 0xAE0188 VA: 0xAE0188
	private void InitInfos() { }

	// RVA: -1 Offset: -1
	private T FindChild<T>(Transform trans, string childName) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDEF058 Offset: 0xDEF058 VA: 0xDEF058
	|-UIBattleResult1UI.FindChild<LanguageMono>
	|-UIBattleResult1UI.FindChild<object>
	|-UIBattleResult1UI.FindChild<RectTransform>
	|-UIBattleResult1UI.FindChild<Transform>
	|-UIBattleResult1UI.FindChild<Text>
	*/

	// RVA: 0xAE03A8 Offset: 0xAE03A8 VA: 0xAE03A8 Slot: 23
	public override void OnViewOpen(object[] objs) { }

	// RVA: 0xAE07A4 Offset: 0xAE07A4 VA: 0xAE07A4
	private void RefreshModeTxt() { }

	// RVA: 0xAE0DA8 Offset: 0xAE0DA8 VA: 0xAE0DA8
	private void RefreshScore(game.CommonBattleResult pkt) { }

	// RVA: 0xAE0C24 Offset: 0xAE0C24 VA: 0xAE0C24
	private void RefreshTeamName() { }

	// RVA: 0xAE0934 Offset: 0xAE0934 VA: 0xAE0934
	private void RefreshResult(game.CommonBattleResult pkt) { }

	// RVA: 0xAE0FBC Offset: 0xAE0FBC VA: 0xAE0FBC
	private void RefreshPoints() { }

	// RVA: 0xAE1398 Offset: 0xAE1398 VA: 0xAE1398
	private void ActiveGamePoint(GameObject itemGo, game.ActionPoint point) { }
}
