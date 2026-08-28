// Namespace: 
public class PreBattleEquipmentSettingView.WeaponUI // TypeDefIndex: 10463
{
	// Fields
	public WeaponType weaponType; // 0x8
	private RectTransform mRt; // 0xC
	private GameObject mContent; // 0x10
	private Text mName; // 0x14
	private ImageWrapper mImg; // 0x18
	private GameObject mEquipedGo; // 0x1C
	private GameObject mSelectedGo; // 0x20
	private CanvasGroup mCanvasGroup; // 0x24
	private PreBattleEquipmentSettingView.WeaponPartsInfoUI mWeaponPartsInfoUI; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56E6B4 Offset: 0x56E6B4 VA: 0x56E6B4
	private uint <WeaponId>k__BackingField; // 0x2C
	public Action<PreBattleEquipmentSettingView.WeaponUI> OnWeaponClickEvt; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x56E6C4 Offset: 0x56E6C4 VA: 0x56E6C4
	private bool <Selected>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x56E6D4 Offset: 0x56E6D4 VA: 0x56E6D4
	private bool <IsEquiped>k__BackingField; // 0x35
	[CompilerGeneratedAttribute] // RVA: 0x56E6E4 Offset: 0x56E6E4 VA: 0x56E6E4
	private EquipmentData <EquipData>k__BackingField; // 0x38

	// Properties
	public uint WeaponId { get; set; }
	public bool Selected { get; set; }
	public bool IsEquiped { get; set; }
	public EquipmentData EquipData { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65D880 Offset: 0x65D880 VA: 0x65D880
	// RVA: 0xC840CC Offset: 0xC840CC VA: 0xC840CC
	private void set_WeaponId(uint value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D890 Offset: 0x65D890 VA: 0x65D890
	// RVA: 0xC831F4 Offset: 0xC831F4 VA: 0xC831F4
	public uint get_WeaponId() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D8A0 Offset: 0x65D8A0 VA: 0x65D8A0
	// RVA: 0xC840D4 Offset: 0xC840D4 VA: 0xC840D4
	private void set_Selected(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D8B0 Offset: 0x65D8B0 VA: 0x65D8B0
	// RVA: 0xC840DC Offset: 0xC840DC VA: 0xC840DC
	public bool get_Selected() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D8C0 Offset: 0x65D8C0 VA: 0x65D8C0
	// RVA: 0xC840E4 Offset: 0xC840E4 VA: 0xC840E4
	private void set_IsEquiped(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D8D0 Offset: 0x65D8D0 VA: 0x65D8D0
	// RVA: 0xC840EC Offset: 0xC840EC VA: 0xC840EC
	public bool get_IsEquiped() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D8E0 Offset: 0x65D8E0 VA: 0x65D8E0
	// RVA: 0xC840F4 Offset: 0xC840F4 VA: 0xC840F4
	private void set_EquipData(EquipmentData value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D8F0 Offset: 0x65D8F0 VA: 0x65D8F0
	// RVA: 0xC840FC Offset: 0xC840FC VA: 0xC840FC
	public EquipmentData get_EquipData() { }

	// RVA: 0xC84104 Offset: 0xC84104 VA: 0xC84104
	public void .ctor(WeaponType type, RectTransform rt, PreBattleEquipmentSettingView.PartSelectWindow window) { }

	// RVA: 0xC843DC Offset: 0xC843DC VA: 0xC843DC
	private void AddListeners() { }

	// RVA: 0xC844A0 Offset: 0xC844A0 VA: 0xC844A0
	public void Active(bool active) { }

	// RVA: 0xC847CC Offset: 0xC847CC VA: 0xC847CC
	public void FillData(uint weaponId, EquipmentData equipData) { }

	// RVA: 0xC847D8 Offset: 0xC847D8 VA: 0xC847D8
	public void Refresh() { }

	// RVA: 0xC84A40 Offset: 0xC84A40 VA: 0xC84A40
	private void LoadItemIcon(string itemType, string iconName) { }

	// RVA: 0xC844F8 Offset: 0xC844F8 VA: 0xC844F8
	public void SetSelected(bool selected) { }

	// RVA: 0xC84650 Offset: 0xC84650 VA: 0xC84650
	public void SetEquipd(bool equiped) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D900 Offset: 0x65D900 VA: 0x65D900
	// RVA: 0xC84B58 Offset: 0xC84B58 VA: 0xC84B58
	private void <AddListeners>b__27_0(PointerEventData x) { }
}
