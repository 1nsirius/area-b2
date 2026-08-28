// Namespace: 
public abstract class LocalGunBaseCtrlr.FireStateBase : ILogicState<LocalGunBaseCtrlr.FireStateBase> // TypeDefIndex: 13091
{
	// Fields
	protected readonly LocalGunBaseCtrlr gunCtrlr; // 0x8

	// Properties
	public virtual bool IsHide { get; }

	// Methods

	// RVA: 0xCF40F8 Offset: 0xCF40F8 VA: 0xCF40F8 Slot: 8
	public virtual bool get_IsHide() { }

	// RVA: 0xCF3A5C Offset: 0xCF3A5C VA: 0xCF3A5C
	protected void .ctor(LocalGunBaseCtrlr gunCtrlr) { }

	// RVA: 0xCF3A88 Offset: 0xCF3A88 VA: 0xCF3A88 Slot: 9
	public virtual void enter(LocalGunBaseCtrlr.FireStateBase last) { }

	// RVA: 0xCF4100 Offset: 0xCF4100 VA: 0xCF4100 Slot: 5
	public void post_enter() { }

	// RVA: 0xCF4104 Offset: 0xCF4104 VA: 0xCF4104 Slot: 10
	public virtual void leave() { }

	// RVA: 0xCF3FF4 Offset: 0xCF3FF4 VA: 0xCF3FF4 Slot: 11
	public virtual void update() { }

	// RVA: 0xCF3CEC Offset: 0xCF3CEC VA: 0xCF3CEC Slot: 12
	public virtual void InputFire() { }

	// RVA: 0xCF3CFC Offset: 0xCF3CFC VA: 0xCF3CFC Slot: 13
	public virtual void InputNoFire() { }

	// RVA: 0xCF4108 Offset: 0xCF4108 VA: 0xCF4108 Slot: 14
	public virtual void MakeCurrent() { }
}
