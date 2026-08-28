// Namespace: 
public class PreBattleEquipmentSettingView.WeaponPartsInfoUI // TypeDefIndex: 10461
{
	// Fields
	private RectTransform mPartsRt; // 0x8
	private GameObject mPartUIGo; // 0xC
	private readonly List<PreBattleEquipmentSettingView.PartUI> mWeaponList; // 0x10
	private PreBattleEquipmentSettingView.WeaponUI mWeaponUI; // 0x14
	private EquipmentData mEquipmentData; // 0x18
	private PreBattleEquipmentSettingView.PartSelectWindow mPartSelectWindow; // 0x1C
	private GameObject mContent; // 0x20

	// Methods

	// RVA: 0xC82B6C Offset: 0xC82B6C VA: 0xC82B6C
	public void .ctor(RectTransform partsRt, PreBattleEquipmentSettingView.PartSelectWindow mPartSelectWindow) { }

	// RVA: 0xC82F6C Offset: 0xC82F6C VA: 0xC82F6C
	public void Active(bool active) { }

	// RVA: 0xC82D88 Offset: 0xC82D88 VA: 0xC82D88
	private void AddListeners() { }

	// RVA: 0xC82FD0 Offset: 0xC82FD0 VA: 0xC82FD0
	private void OnPartUIClickCallBack(PreBattleEquipmentSettingView.PartUI partUI) { }

	// RVA: 0xC831FC Offset: 0xC831FC VA: 0xC831FC
	private LocWeaponInfo GetWeaponInfo(WeaponType type, uint weaponId) { }

	// RVA: 0xC833A8 Offset: 0xC833A8 VA: 0xC833A8
	public void FillData(PreBattleEquipmentSettingView.WeaponUI weaponUI, EquipmentData equipData) { }

	// RVA: 0xC833B4 Offset: 0xC833B4 VA: 0xC833B4
	public void Refresh() { }

	// RVA: 0xC833B8 Offset: 0xC833B8 VA: 0xC833B8
	private void RefreshInfos() { }

	// RVA: 0xC83718 Offset: 0xC83718 VA: 0xC83718
	private bool RefreshPartUI(PreBattleEquipmentSettingView.PartUI partUI, AttachmentKind attachmentKind, int[] partIds, out bool isEquiped) { }

	// RVA: 0xC839BC Offset: 0xC839BC VA: 0xC839BC
	public void OnClose() { }
}
