// Namespace: 
private class WeaponCompCtrlr.CombWeaponProxy : WeaponCompCtrlr.IWeaponProxy // TypeDefIndex: 5675
{
	// Fields
	private LocalWeaponCtrlr mAinControl; // 0x8
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

	// RVA: 0x130026C Offset: 0x130026C VA: 0x130026C
	public void .ctor(LocalWeaponCtrlr self, LocalWeaponCtrlr ainControl) { }

	// RVA: 0x1300528 Offset: 0x1300528 VA: 0x1300528 Slot: 11
	public bool AllowOperate() { }

	// RVA: 0x1300554 Offset: 0x1300554 VA: 0x1300554 Slot: 4
	public bool get_IsComb() { }

	// RVA: 0x130055C Offset: 0x130055C VA: 0x130055C Slot: 5
	public string get_SelfIcon() { }

	// RVA: 0x13005C8 Offset: 0x13005C8 VA: 0x13005C8 Slot: 6
	public string get_Name() { }

	// RVA: 0x130061C Offset: 0x130061C VA: 0x130061C Slot: 7
	public string get_SecondIcon() { }

	// RVA: 0x1300688 Offset: 0x1300688 VA: 0x1300688 Slot: 8
	public Count get_Clip() { }

	// RVA: 0x13006A0 Offset: 0x13006A0 VA: 0x13006A0 Slot: 9
	public Count get_RemainAmmon() { }

	// RVA: 0x13006B8 Offset: 0x13006B8 VA: 0x13006B8 Slot: 10
	public bool get_NeedShowBulletCnt() { }
}
