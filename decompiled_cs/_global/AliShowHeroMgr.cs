// Namespace: 
public class AliShowHeroMgr : BaseSingleton<AliShowHeroMgr>, IManager // TypeDefIndex: 5503
{
	// Fields
	private AliShowHeroCtrl showHeroCtrl; // 0x8
	private AliShowWeaponCtrl showWeaponCtrl; // 0xC
	private AliShowPendantCtrl shwoPendantCtrl; // 0x10
	private GameObject storeBackGround; // 0x14
	public AssetPool mAssetPool; // 0x18
	private PlayerShowUtil.ShowPanelType currentStageTape; // 0x1C
	public static Show3DType ViewType; // 0x0
	public static int ShowLevel; // 0x4

	// Properties
	public int charId { get; }
	public int charHeadId { get; }
	public int charBodyId { get; }
	public int charSuitId { get; }

	// Methods

	// RVA: 0xCB3034 Offset: 0xCB3034 VA: 0xCB3034
	public int get_charId() { }

	// RVA: 0xCB3048 Offset: 0xCB3048 VA: 0xCB3048
	public int get_charHeadId() { }

	// RVA: 0xCB305C Offset: 0xCB305C VA: 0xCB305C
	public int get_charBodyId() { }

	// RVA: 0xCB3070 Offset: 0xCB3070 VA: 0xCB3070
	public int get_charSuitId() { }

	// RVA: 0xCB3084 Offset: 0xCB3084 VA: 0xCB3084
	public void SwitchShowModeForCharacter(int skinId, GameObject dragObj, int suitId = 0, int headId = 0, int bodyId = 0, int defaultViewLevel = 1, int showType = 0) { }

	// RVA: 0xCB33EC Offset: 0xCB33EC VA: 0xCB33EC
	public void SwitchShowModeForWeapon(int skinId, GameObject dragObj, int[] skins, int defaultViewLevel = 1, int showType = 0) { }

	// RVA: 0xCB374C Offset: 0xCB374C VA: 0xCB374C
	public void SwitchShowModeForPendant(int skinId, GameObject dragObj, int defaultViewLevel = 1, int showType = 0) { }

	// RVA: 0xCB39DC Offset: 0xCB39DC VA: 0xCB39DC
	public void SwitchShowMode(int skinId, GameObject dragObj, int showType = 1) { }

	// RVA: 0xCB3B10 Offset: 0xCB3B10 VA: 0xCB3B10
	public void PlayEnterAnim(Action finishCallBack) { }

	// RVA: 0xCB3BE0 Offset: 0xCB3BE0 VA: 0xCB3BE0
	public void SetEnableLevel(bool enable) { }

	// RVA: 0xCB3CA0 Offset: 0xCB3CA0 VA: 0xCB3CA0
	public bool AllowChangeHeroSwitch() { }

	// RVA: 0xCB326C Offset: 0xCB326C VA: 0xCB326C
	public void AwakeScene(int skinId) { }

	// RVA: 0xCB3E30 Offset: 0xCB3E30 VA: 0xCB3E30
	public void ResetScene() { }

	// RVA: 0xCB423C Offset: 0xCB423C VA: 0xCB423C
	public void ReleaseRT() { }

	// RVA: 0xCB31C8 Offset: 0xCB31C8 VA: 0xCB31C8
	public void ClearShow3DCtrl(bool releaseRT = False) { }

	// RVA: 0xCB42A0 Offset: 0xCB42A0 VA: 0xCB42A0
	public void F_SetHeroOffsetPos(Vector2 offsetPos) { }

	// RVA: 0xCB44D8 Offset: 0xCB44D8 VA: 0xCB44D8
	public void ResetView() { }

	// RVA: 0xCB4678 Offset: 0xCB4678 VA: 0xCB4678
	public void SetViewLevel(int level) { }

	[IteratorStateMachineAttribute] // RVA: 0x579D84 Offset: 0x579D84 VA: 0x579D84
	// RVA: 0xCB4FB8 Offset: 0xCB4FB8 VA: 0xCB4FB8 Slot: 4
	public IEnumerator Initialize() { }

	// RVA: 0xCB504C Offset: 0xCB504C VA: 0xCB504C Slot: 5
	public void Shutdown() { }

	// RVA: 0xCB5050 Offset: 0xCB5050 VA: 0xCB5050 Slot: 6
	public void BeforeUpdate() { }

	// RVA: 0xCB5054 Offset: 0xCB5054 VA: 0xCB5054 Slot: 7
	public void Update() { }

	// RVA: 0xCB50B8 Offset: 0xCB50B8 VA: 0xCB50B8 Slot: 8
	public void LateUpdate() { }

	// RVA: 0xCB511C Offset: 0xCB511C VA: 0xCB511C Slot: 9
	public void FixedUpdate() { }

	// RVA: 0xCB5120 Offset: 0xCB5120 VA: 0xCB5120
	public void .ctor() { }

	// RVA: 0xCB51D4 Offset: 0xCB51D4 VA: 0xCB51D4
	private static void .cctor() { }
}
