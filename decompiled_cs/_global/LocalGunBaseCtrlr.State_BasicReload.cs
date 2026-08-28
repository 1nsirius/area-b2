// Namespace: 
public class LocalGunBaseCtrlr.State_BasicReload : LocalToolBaseCtrlr.State // TypeDefIndex: 13105
{
	// Fields
	private bool mShouldQuitAim; // 0x14
	protected float mEndTime; // 0x18

	// Properties
	protected LocalGunBaseCtrlr ToolCtrlr { get; }

	// Methods

	// RVA: 0xCF64A4 Offset: 0xCF64A4 VA: 0xCF64A4
	protected LocalGunBaseCtrlr get_ToolCtrlr() { }

	// RVA: 0xCF65A4 Offset: 0xCF65A4 VA: 0xCF65A4
	public void SetupReload(bool shouldQuitAim) { }

	// RVA: 0xCF65AC Offset: 0xCF65AC VA: 0xCF65AC Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xCF66C4 Offset: 0xCF66C4 VA: 0xCF66C4 Slot: 34
	public override void update() { }

	// RVA: 0xCF6704 Offset: 0xCF6704 VA: 0xCF6704 Slot: 41
	protected virtual void OnStateTimesUp() { }

	// RVA: 0xCF6708 Offset: 0xCF6708 VA: 0xCF6708 Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xCF68F0 Offset: 0xCF68F0 VA: 0xCF68F0 Slot: 36
	public override void Equip(Action callback, bool withAssist, bool needSendToServer) { }

	// RVA: 0xCF6964 Offset: 0xCF6964 VA: 0xCF6964
	public void .ctor() { }
}
