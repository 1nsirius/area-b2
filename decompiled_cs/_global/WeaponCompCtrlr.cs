// Namespace: 
public class WeaponCompCtrlr // TypeDefIndex: 5671
{
	// Fields
	private WeaponComp mComp; // 0x8
	public static EWeaponState ActiveState; // 0x0
	private bool mEnable; // 0xC
	private WeaponCompCtrlr.IWeaponProxy mWeaponProxy; // 0x10
	private Nullable<EWeaponState> mWeaponState; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x55E4BC Offset: 0x55E4BC VA: 0x55E4BC
	private Action OnClickEvt; // 0x1C

	// Properties
	public bool Enable { get; set; }

	// Methods

	// RVA: 0x12FF478 Offset: 0x12FF478 VA: 0x12FF478
	public bool get_Enable() { }

	// RVA: 0x12FF480 Offset: 0x12FF480 VA: 0x12FF480
	public void set_Enable(bool value) { }

	// RVA: 0x12FF488 Offset: 0x12FF488 VA: 0x12FF488
	public void Init(WeaponComp comp, LocalWeaponCtrlr gunCtrlr, Nullable<EWeaponState> weaponState) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A9CC Offset: 0x57A9CC VA: 0x57A9CC
	// RVA: 0x12FF924 Offset: 0x12FF924 VA: 0x12FF924
	public void add_OnClickEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A9DC Offset: 0x57A9DC VA: 0x57A9DC
	// RVA: 0x12FFA30 Offset: 0x12FFA30 VA: 0x12FFA30
	public void remove_OnClickEvt(Action value) { }

	// RVA: 0x12FFB3C Offset: 0x12FFB3C VA: 0x12FFB3C
	public void OnTick() { }

	// RVA: 0x12FF560 Offset: 0x12FF560 VA: 0x12FF560
	public void SetGunCtrlr(LocalWeaponCtrlr gunCtrlr) { }

	// RVA: 0x1300178 Offset: 0x1300178 VA: 0x1300178
	private static WeaponCompCtrlr.IWeaponProxy CreateCombWeaponCtrlr(LocalWeaponCtrlr weaponCtrlr, LocalWeaponCtrlr mainWeapon) { }

	// RVA: 0x12FFFC4 Offset: 0x12FFFC4 VA: 0x12FFFC4
	private void CreateWeaponProxy(LocalWeaponCtrlr weaponCtrlr) { }

	// RVA: 0x13002D4 Offset: 0x13002D4 VA: 0x13002D4
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A9EC Offset: 0x57A9EC VA: 0x57A9EC
	// RVA: 0x13002DC Offset: 0x13002DC VA: 0x13002DC
	private void <Init>b__8_0() { }
}
