// Namespace: 
public class PreBattleEquipmentSettingView.WeaponsInfoUI // TypeDefIndex: 10465
{
	// Fields
	private readonly List<PreBattleEquipmentSettingView.WeaponUI> mWeaponUIList; // 0x8
	private readonly Dictionary<PreBattleEquipmentSettingView.WeaponUIType, List<PreBattleEquipmentSettingView.WeaponUI>> mWeaponUIDic; // 0xC
	private PreBattleEquipmentSettingView.PartsInfoUI mPartsInfoUI; // 0x10
	private EquipmentData mEquipmentData; // 0x14
	private GameObject mEquipmentsMainGo; // 0x18
	private GameObject mEquipmentsAdditionalGo; // 0x1C

	// Methods

	// RVA: 0xC84BC8 Offset: 0xC84BC8 VA: 0xC84BC8
	public void .ctor(RectTransform rt, PreBattleEquipmentSettingView.PartsInfoUI partsInfoUI) { }

	// RVA: 0xC85968 Offset: 0xC85968 VA: 0xC85968
	private void OnPartUIClickCallBack(PreBattleEquipmentSettingView.WeaponUI weaponUI) { }

	// RVA: 0xC85DB4 Offset: 0xC85DB4 VA: 0xC85DB4
	public LocWeaponInfo GetWeaponInfo(WeaponType type, uint weaponId) { }

	// RVA: 0xC85F60 Offset: 0xC85F60 VA: 0xC85F60
	public void FillData(EquipmentData equipData) { }

	// RVA: 0xC85F8C Offset: 0xC85F8C VA: 0xC85F8C
	public void Refresh() { }

	// RVA: 0xC85FBC Offset: 0xC85FBC VA: 0xC85FBC
	private void RefreshSelf() { }

	// RVA: 0xC86BA8 Offset: 0xC86BA8 VA: 0xC86BA8
	public void PlayPartUIAnimation() { }

	// RVA: 0xC86BD0 Offset: 0xC86BD0 VA: 0xC86BD0
	public void OnClose() { }
}
