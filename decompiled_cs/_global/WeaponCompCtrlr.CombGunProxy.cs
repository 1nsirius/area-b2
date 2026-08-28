// Namespace: 
private class WeaponCompCtrlr.CombGunProxy : WeaponCompCtrlr.IWeaponProxy // TypeDefIndex: 5676
{
	// Fields
	private LocalGunBaseCtrlr mMainControl; // 0x8
	private LocalWeaponCtrlr mSelf; // 0xC

	// Properties
	public bool IsComb { get; }
	public string SelfIcon { get; }
	public string Name { get; }
	public string SecondIcon { get; }
	public Count Clip { get; }
	public Count RemainAmmon { get; }
	public bool NeedShowBulletCnt { get; }

	// Methods

	// RVA: 0x1300244 Offset: 0x1300244 VA: 0x1300244
	public void .ctor(LocalWeaponCtrlr self, LocalGunBaseCtrlr mainControl) { }

	// RVA: 0x13002F0 Offset: 0x13002F0 VA: 0x13002F0 Slot: 11
	public bool AllowOperate() { }

	// RVA: 0x130031C Offset: 0x130031C VA: 0x130031C Slot: 4
	public bool get_IsComb() { }

	// RVA: 0x1300324 Offset: 0x1300324 VA: 0x1300324 Slot: 5
	public string get_SelfIcon() { }

	// RVA: 0x1300390 Offset: 0x1300390 VA: 0x1300390 Slot: 6
	public string get_Name() { }

	// RVA: 0x13003E4 Offset: 0x13003E4 VA: 0x13003E4 Slot: 7
	public string get_SecondIcon() { }

	// RVA: 0x1300450 Offset: 0x1300450 VA: 0x1300450 Slot: 8
	public Count get_Clip() { }

	// RVA: 0x13004D8 Offset: 0x13004D8 VA: 0x13004D8 Slot: 9
	public Count get_RemainAmmon() { }

	// RVA: 0x1300520 Offset: 0x1300520 VA: 0x1300520 Slot: 10
	public bool get_NeedShowBulletCnt() { }
}
