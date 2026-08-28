// Namespace: 
public abstract class LocalBuildingToolCtrlr.State_BuildIn : LocalToolBaseCtrlr.State // TypeDefIndex: 12857
{
	// Fields
	private Conduct conduct_build; // 0x14

	// Properties
	private LocalBuildingToolCtrlr buildInCtrl { get; }
	protected abstract float build_duration { get; }
	protected abstract string OperationName { get; }

	// Methods

	// RVA: 0xA3F4C4 Offset: 0xA3F4C4 VA: 0xA3F4C4
	private LocalBuildingToolCtrlr get_buildInCtrl() { }

	// RVA: -1 Offset: -1 Slot: 41
	protected abstract float get_build_duration();

	// RVA: -1 Offset: -1 Slot: 42
	protected abstract string get_OperationName();

	// RVA: 0xA3BCC0 Offset: 0xA3BCC0 VA: 0xA3BCC0 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xA3F5C4 Offset: 0xA3F5C4 VA: 0xA3F5C4 Slot: 43
	protected virtual void Success() { }

	// RVA: 0xA3C3D4 Offset: 0xA3C3D4 VA: 0xA3C3D4 Slot: 33
	public override void leave() { }

	// RVA: 0xA3C180 Offset: 0xA3C180 VA: 0xA3C180 Slot: 34
	public override void update() { }

	// RVA: 0xA3F5C8 Offset: 0xA3F5C8 VA: 0xA3F5C8 Slot: 44
	public virtual void MakeCurrent(object argument) { }

	// RVA: 0xA3C5D4 Offset: 0xA3C5D4 VA: 0xA3C5D4
	protected void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x6680E0 Offset: 0x6680E0 VA: 0x6680E0
	// RVA: 0xA3F5CC Offset: 0xA3F5CC VA: 0xA3F5CC
	private void <enter>b__7_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x6680F0 Offset: 0x6680F0 VA: 0x6680F0
	// RVA: 0xA3F6AC Offset: 0xA3F6AC VA: 0xA3F6AC
	private void <enter>b__7_1(float p) { }
}
