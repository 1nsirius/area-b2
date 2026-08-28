// Namespace: 
internal interface WeaponCompCtrlr.IWeaponProxy // TypeDefIndex: 5672
{
	// Properties
	public abstract bool IsComb { get; }
	public abstract string SelfIcon { get; }
	public abstract string Name { get; }
	public abstract string SecondIcon { get; }
	public abstract Count Clip { get; }
	public abstract Count RemainAmmon { get; }
	public abstract bool NeedShowBulletCnt { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract bool get_IsComb();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract string get_SelfIcon();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract string get_Name();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract string get_SecondIcon();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Count get_Clip();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract Count get_RemainAmmon();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract bool get_NeedShowBulletCnt();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract bool AllowOperate();
}
