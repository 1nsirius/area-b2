// Namespace: 
public class SelectOccPage2 : MonoBehaviour // TypeDefIndex: 5658
{
	// Fields
	private Button mCancleBtn; // 0xC
	private SelectOccPanel.IAssetLoader mLoader; // 0x10
	private SelectOccPanel.IPacker mPacker; // 0x14
	private List<SelectOccPage2.PlayerOccCtrlr> mPlayerList; // 0x18
	private Transform mPlayerParent; // 0x1C
	private SelectOccPage2.PlayerOccView mPlayerPrefab; // 0x20
	private Text mTips; // 0x24
	public static float[] DelayAnimTimes; // 0x0

	// Methods

	// RVA: 0x2CFAEE4 Offset: 0x2CFAEE4 VA: 0x2CFAEE4
	public void InitView(SelectOccPanel.IPacker packer, SelectOccPanel.IAssetLoader loader) { }

	// RVA: 0x2CFB564 Offset: 0x2CFB564 VA: 0x2CFB564
	public void OnDispose() { }

	// RVA: 0x2CFB6D4 Offset: 0x2CFB6D4 VA: 0x2CFB6D4
	public void OnPlayerBeginLoading() { }

	// RVA: 0x2CFB864 Offset: 0x2CFB864 VA: 0x2CFB864
	public void OnPlayerLoadFinish(uint uid) { }

	// RVA: 0x2CFB9A8 Offset: 0x2CFB9A8 VA: 0x2CFB9A8
	public void OnPlayerLoadProgressChange(uint playerUid, float progress) { }

	// RVA: 0x2CFBA00 Offset: 0x2CFBA00 VA: 0x2CFBA00
	public void OnPlayerRegionChange(uint playerUid, int region) { }

	// RVA: 0x2CFBB30 Offset: 0x2CFBB30 VA: 0x2CFBB30
	public void RefreshPlayers() { }

	// RVA: 0x2CFC1E4 Offset: 0x2CFC1E4 VA: 0x2CFC1E4
	public void SetInteraction(bool interaction) { }

	// RVA: 0x2CFC2C0 Offset: 0x2CFC2C0 VA: 0x2CFC2C0
	public void SetVisiable(bool visiable) { }

	// RVA: 0x2CFC5A0 Offset: 0x2CFC5A0 VA: 0x2CFC5A0
	private void AddEmptyPlayer(int team) { }

	// RVA: 0x2CFC808 Offset: 0x2CFC808 VA: 0x2CFC808
	private void AddPlayer(uint playerUid, string playerName, int team) { }

	// RVA: 0x2CFB888 Offset: 0x2CFB888 VA: 0x2CFB888
	private SelectOccPage2.PlayerOccCtrlr GetPlayerCtrlr(uint playerUid) { }

	// RVA: 0x2CFB1B4 Offset: 0x2CFB1B4 VA: 0x2CFB1B4
	private void InitPlayers() { }

	// RVA: 0x2CFC95C Offset: 0x2CFC95C VA: 0x2CFC95C
	public void PlayAllPlayersShowAnim() { }

	// RVA: 0x2CFCA18 Offset: 0x2CFCA18 VA: 0x2CFCA18
	public void PlayAllPlayersHideAnim() { }

	// RVA: 0x2CFCAD0 Offset: 0x2CFCAD0 VA: 0x2CFCAD0
	public void PlayAllPlayersBecomeBiggerAnim() { }

	// RVA: 0x2CFC650 Offset: 0x2CFC650 VA: 0x2CFC650
	private SelectOccPage2.PlayerOccCtrlr InnerAddPlayer(uint playerUid, string playerName, int team, bool isSelf, SelectOccPage2.EState state) { }

	// RVA: 0x2CFC870 Offset: 0x2CFC870 VA: 0x2CFC870
	private bool IsSelf(uint uid) { }

	// RVA: 0x2CFCB88 Offset: 0x2CFCB88 VA: 0x2CFCB88
	private void OnPlayerChangeOcc(uint uid, int occUid) { }

	// RVA: 0x2CFBE30 Offset: 0x2CFBE30 VA: 0x2CFBE30
	private void RefreshPlayer(SelectOccPage2.PlayerOccCtrlr playerCtrlr, int occUid, string spawnName, string secondPosName) { }

	// RVA: 0x2CFCD48 Offset: 0x2CFCD48 VA: 0x2CFCD48
	public void RefreshBombModePresentation(long pickUpedBombPlayerId) { }

	// RVA: 0x2CFCE1C Offset: 0x2CFCE1C VA: 0x2CFCE1C
	public void .ctor() { }

	// RVA: 0x2CFCE24 Offset: 0x2CFCE24 VA: 0x2CFCE24
	private static void .cctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A94C Offset: 0x57A94C VA: 0x57A94C
	// RVA: 0x2CFCEBC Offset: 0x2CFCEBC VA: 0x2CFCEBC
	private void <SetVisiable>b__15_0(uint uid, int occUid) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A95C Offset: 0x57A95C VA: 0x57A95C
	// RVA: 0x2CFCEC0 Offset: 0x2CFCEC0 VA: 0x2CFCEC0
	private void <SetVisiable>b__15_1(uint uid, int occUid) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A96C Offset: 0x57A96C VA: 0x57A96C
	// RVA: 0x2CFCEC4 Offset: 0x2CFCEC4 VA: 0x2CFCEC4
	private void <SetVisiable>b__15_2(uint uid, int occUid) { }
}
