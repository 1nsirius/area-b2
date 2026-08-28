// Namespace: 
protected abstract class LocalDragCtrlr.State_Drag_DragTool : State_Drag // TypeDefIndex: 12935
{
	// Fields
	private LerpData mLerpData; // 0x14

	// Properties
	private LocalDragCtrlr ToolCtrlr { get; }

	// Methods

	// RVA: 0xA48798 Offset: 0xA48798 VA: 0xA48798
	private LocalDragCtrlr get_ToolCtrlr() { }

	// RVA: 0xA48898 Offset: 0xA48898 VA: 0xA48898 Slot: 42
	protected override TransitionWorker Drag(ref State_Drag.Data dragData) { }

	// RVA: 0xA48E14 Offset: 0xA48E14 VA: 0xA48E14 Slot: 45
	protected virtual void Calc(out LerpData lerpData) { }

	// RVA: 0xA48E2C Offset: 0xA48E2C VA: 0xA48E2C Slot: 43
	protected override void BeforeDrag(ref State_Drag.Data dragData) { }

	// RVA: 0xA32F44 Offset: 0xA32F44 VA: 0xA32F44 Slot: 46
	protected virtual void CalcRecovery(out LerpData transRecovery) { }

	// RVA: 0xA490B4 Offset: 0xA490B4 VA: 0xA490B4
	protected void DefaultCalcRecovery(out LerpData transRecovery) { }

	// RVA: 0xA490D4 Offset: 0xA490D4 VA: 0xA490D4
	protected void .ctor() { }
}
