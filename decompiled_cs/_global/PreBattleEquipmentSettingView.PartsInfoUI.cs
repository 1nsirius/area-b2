// Namespace: 
public class PreBattleEquipmentSettingView.PartsInfoUI // TypeDefIndex: 10467
{
	// Fields
	private RectTransform mRt; // 0x8
	private Text mWeaponName; // 0xC
	private ImageWrapper mWeaponIcon; // 0x10
	private Text mWeaponDesc; // 0x14
	private RectTransform mPartsRt; // 0x18
	private GameObject mPartUIGo; // 0x1C
	private GameObject mNoHavePartsDescGo; // 0x20
	private RectTransform mDamageRt; // 0x24
	private Image mDamageImg; // 0x28
	private Text mDamageText; // 0x2C
	private PreBattleProgressBarControl mDamageControl; // 0x30
	private RectTransform mFireRateRt; // 0x34
	private Image mFireRateImg; // 0x38
	private Text mFireRateText; // 0x3C
	private PreBattleProgressBarControl mFireRateControl; // 0x40
	private RectTransform mCartridgeRt; // 0x44
	private Image mCartridgeImg; // 0x48
	private Text mCartridgeText; // 0x4C
	private PreBattleProgressBarControl mCartridgeControl; // 0x50
	private RectTransform mRecoilRt; // 0x54
	private Image mRecoilImg; // 0x58
	private Text mRecoilText; // 0x5C
	private PreBattleProgressBarControl mRecoilControl; // 0x60
	private readonly List<PreBattleEquipmentSettingView.PartUI> mWeaponList; // 0x64
	private EquipmentData mEquipmentData; // 0x68
	private PreBattleEquipmentSettingView.PartSelectWindow mPartSelectWindow; // 0x6C
	private GameObject mParametersGo; // 0x70
	private GameObject mTitle0Go; // 0x74
	private Animator mTitle0Animator; // 0x78
	private float mParametersStartX; // 0x7C
	private float mParametersStartY; // 0x80
	private float mParametersInterval; // 0x84
	private Animator mAnimator; // 0x88

	// Properties
	public PreBattleEquipmentSettingView.PartSelectWindow PartSelectWindow { get; }

	// Methods

	// RVA: 0xC7FB2C Offset: 0xC7FB2C VA: 0xC7FB2C
	public PreBattleEquipmentSettingView.PartSelectWindow get_PartSelectWindow() { }

	// RVA: 0xC7FB34 Offset: 0xC7FB34 VA: 0xC7FB34
	public void .ctor(RectTransform rt, RectTransform partsRt, PreBattleEquipmentSettingView.PartSelectWindow mPartSelectWindow) { }

	// RVA: 0xC808B0 Offset: 0xC808B0 VA: 0xC808B0
	private void AddListeners() { }

	// RVA: 0xC80A94 Offset: 0xC80A94 VA: 0xC80A94
	private void OnPartUIClickCallBack(PreBattleEquipmentSettingView.PartUI partUI) { }

	// RVA: 0xC80CC4 Offset: 0xC80CC4 VA: 0xC80CC4
	private LocWeaponInfo GetWeaponInfo(WeaponType type, uint weaponId) { }

	// RVA: 0xC80E70 Offset: 0xC80E70 VA: 0xC80E70
	public void FillData(EquipmentData equipData) { }

	// RVA: 0xC80E78 Offset: 0xC80E78 VA: 0xC80E78
	public void Refresh() { }

	// RVA: 0xC81414 Offset: 0xC81414 VA: 0xC81414
	private void RefreshInfos() { }

	// RVA: 0xC823EC Offset: 0xC823EC VA: 0xC823EC
	public void PlayShowAnimation() { }

	// RVA: 0xC8211C Offset: 0xC8211C VA: 0xC8211C
	private bool RefreshPartUI(PreBattleEquipmentSettingView.PartUI partUI, AttachmentKind attachmentKind, int[] partIds, out bool isEquiped) { }

	// RVA: 0xC82480 Offset: 0xC82480 VA: 0xC82480
	public void OnClose() { }
}
