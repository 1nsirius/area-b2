// Namespace: 
public class RoundViewPlayerInfoController // TypeDefIndex: 5714
{
	// Fields
	private BattlePlayersInfoControl<BattlePlayerIcon> m_playersInfo; // 0x8
	private Dictionary<uint, BattlePlayerIcon> playerIconMap; // 0xC
	private SelectOccPanel.IPacker packer; // 0x10
	private SelectOccPanel.IAssetLoader loader; // 0x14
	private Image img_ready; // 0x18
	private Image img_unknow; // 0x1C
	private Text img_loading; // 0x20
	private Image img_loaded; // 0x24
	private AssetPool mAssetPool; // 0x28

	// Methods

	// RVA: 0x2CF2C18 Offset: 0x2CF2C18 VA: 0x2CF2C18
	public void InitPlayerIcon(Transform _tran, SelectOccPanel.IPacker packer, SelectOccPanel.IAssetLoader loader) { }

	// RVA: 0x2CF448C Offset: 0x2CF448C VA: 0x2CF448C
	private Sprite LoadSprite(string path) { }

	// RVA: -1 Offset: -1
	private void RefreshTeamInf<T>(TeamInfoControl<T> teamCtrl, BattleTeam team) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B3C8 Offset: 0x101B3C8 VA: 0x101B3C8
	|-RoundViewPlayerInfoController.RefreshTeamInf<BattlePlayerIcon>
	|-RoundViewPlayerInfoController.RefreshTeamInf<object>
	*/

	// RVA: 0x2CF450C Offset: 0x2CF450C VA: 0x2CF450C
	public void SetLeftTime(TimeSpan span) { }

	// RVA: 0x2CF45C8 Offset: 0x2CF45C8 VA: 0x2CF45C8
	public void UpdateOffline() { }

	// RVA: 0x2CF47E4 Offset: 0x2CF47E4 VA: 0x2CF47E4
	public void ShowTime(bool show) { }

	// RVA: 0x2CF484C Offset: 0x2CF484C VA: 0x2CF484C
	public void OnPlayerBeginLoadinig() { }

	// RVA: 0x2CF4BE4 Offset: 0x2CF4BE4 VA: 0x2CF4BE4
	public void OnPlayerLoadFinish(uint uid) { }

	// RVA: 0x2CF4CC0 Offset: 0x2CF4CC0 VA: 0x2CF4CC0
	public void OnPlayerLoadProgressChange(uint playerUid, float progress) { }

	// RVA: 0x2CF4280 Offset: 0x2CF4280 VA: 0x2CF4280
	private static void RegistBattlePlayerIcon(Dictionary<uint, BattlePlayerIcon> map, BattlePlayerIcon[] icons, List<uint> players) { }

	// RVA: 0x2CF4DC4 Offset: 0x2CF4DC4 VA: 0x2CF4DC4
	public void RefreshBombModePresentation(long pickUpedBombPlayerId) { }

	// RVA: 0x2CF4FB4 Offset: 0x2CF4FB4 VA: 0x2CF4FB4
	public void OnDestory() { }

	// RVA: 0x2CF4FE0 Offset: 0x2CF4FE0 VA: 0x2CF4FE0
	public void .ctor() { }
}
