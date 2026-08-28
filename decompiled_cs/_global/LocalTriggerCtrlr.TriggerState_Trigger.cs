// Namespace: 
public class LocalTriggerCtrlr.TriggerState_Trigger : LocalToolBaseCtrlr.State // TypeDefIndex: 12930
{
	// Fields
	private Conduct mConduct; // 0x14
	private Action mOnBegin; // 0x18

	// Properties
	private LocalTriggerCtrlr ToolCtrlr { get; }

	// Methods

	// RVA: 0xDC15B4 Offset: 0xDC15B4 VA: 0xDC15B4
	private LocalTriggerCtrlr get_ToolCtrlr() { }

	// RVA: 0xDC16A8 Offset: 0xDC16A8 VA: 0xDC16A8 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xDC1984 Offset: 0xDC1984 VA: 0xDC1984 Slot: 34
	public override void update() { }

	// RVA: 0xDC19B0 Offset: 0xDC19B0 VA: 0xDC19B0 Slot: 33
	public override void leave() { }

	// RVA: 0xDC1358 Offset: 0xDC1358 VA: 0xDC1358
	public void MakeCurrent(Action onBegin, Action onTrigger, Action onFinish) { }

	// RVA: 0xDC1A40 Offset: 0xDC1A40 VA: 0xDC1A40
	public void .ctor() { }
}
