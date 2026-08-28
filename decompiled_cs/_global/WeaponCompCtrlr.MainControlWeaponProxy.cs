// Namespace: 
private class WeaponCompCtrlr.MainControlWeaponProxy : WeaponCompCtrlr.IWeaponProxy // TypeDefIndex: 5673
{
	// Fields
	private LocalWeaponCtrlr mWeaponCtrlr; // 0x8

	// Properties
	public bool IsComb { get; }
	public string SelfIcon { get; }
	public string Name { get; }
	public string SecondIcon { get; }
	public Count Clip { get; }
	public Count RemainAmmon { get; }
	public bool NeedShowBulletCnt { get; }

	// Methods

	// RVA: 0x13002B4 Offset: 0x13002B4 VA: 0x13002B4
	public void .ctor(LocalWeaponCtrlr weaponCtrlr) { }

	// RVA: 0x1300894 Offset: 0x1300894 VA: 0x1300894 Slot: 11
	public bool AllowOperate() { }

	// RVA: 0x13008C0 Offset: 0x13008C0 VA: 0x13008C0 Slot: 4
	public bool get_IsComb() { }

	// RVA: 0x13008C8 Offset: 0x13008C8 VA: 0x13008C8 Slot: 5
	public string get_SelfIcon() { }

	// RVA: 0x1300934 Offset: 0x1300934 VA: 0x1300934 Slot: 6
	public string get_Name() { }

	// RVA: 0x1300988 Offset: 0x1300988 VA: 0x1300988 Slot: 7
	public string get_SecondIcon() { }

	// RVA: 0x1300990 Offset: 0x1300990 VA: 0x1300990 Slot: 8
	public Count get_Clip() { }

	// RVA: 0x13009A8 Offset: 0x13009A8 VA: 0x13009A8 Slot: 9
	public Count get_RemainAmmon() { }

	// RVA: 0x13009C0 Offset: 0x13009C0 VA: 0x13009C0 Slot: 10
	public bool get_NeedShowBulletCnt() { }
}
