// Namespace: 
private class WeaponCompCtrlr.MainControlGunProxy : WeaponCompCtrlr.IWeaponProxy // TypeDefIndex: 5674
{
	// Fields
	private LocalGunBaseCtrlr mGunCtrlr; // 0x8

	// Properties
	public bool IsComb { get; }
	public string SelfIcon { get; }
	public string Name { get; }
	public string SecondIcon { get; }
	public Count Clip { get; }
	public Count RemainAmmon { get; }
	public bool NeedShowBulletCnt { get; }

	// Methods

	// RVA: 0x1300294 Offset: 0x1300294 VA: 0x1300294
	public void .ctor(LocalGunBaseCtrlr gunCtrlr) { }

	// RVA: 0x13006C0 Offset: 0x13006C0 VA: 0x13006C0 Slot: 11
	public bool AllowOperate() { }

	// RVA: 0x13006EC Offset: 0x13006EC VA: 0x13006EC Slot: 4
	public bool get_IsComb() { }

	// RVA: 0x13006F4 Offset: 0x13006F4 VA: 0x13006F4 Slot: 5
	public string get_SelfIcon() { }

	// RVA: 0x1300760 Offset: 0x1300760 VA: 0x1300760 Slot: 6
	public string get_Name() { }

	// RVA: 0x13007B4 Offset: 0x13007B4 VA: 0x13007B4 Slot: 7
	public string get_SecondIcon() { }

	// RVA: 0x13007BC Offset: 0x13007BC VA: 0x13007BC Slot: 8
	public Count get_Clip() { }

	// RVA: 0x1300844 Offset: 0x1300844 VA: 0x1300844 Slot: 9
	public Count get_RemainAmmon() { }

	// RVA: 0x130088C Offset: 0x130088C VA: 0x130088C Slot: 10
	public bool get_NeedShowBulletCnt() { }
}
