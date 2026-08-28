// Namespace: 
protected class LocalRefactorReinforcedCtrlr.State_BuildInRefactorReinforced : LocalBuildingToolCtrlr.State_BuildIn // TypeDefIndex: 13027
{
	// Fields
	private IRefactorReinforcedWall _cur_refactor_reinforced_wall; // 0x18

	// Properties
	private LocalRefactorReinforcedCtrlr ToolCtrlr { get; }
	protected override float build_duration { get; }
	protected override string OperationName { get; }

	// Methods

	// RVA: 0xC40FE4 Offset: 0xC40FE4 VA: 0xC40FE4
	private LocalRefactorReinforcedCtrlr get_ToolCtrlr() { }

	// RVA: 0xC410E4 Offset: 0xC410E4 VA: 0xC410E4 Slot: 41
	protected override float get_build_duration() { }

	// RVA: 0xC412CC Offset: 0xC412CC VA: 0xC412CC Slot: 42
	protected override string get_OperationName() { }

	// RVA: 0xC41378 Offset: 0xC41378 VA: 0xC41378 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xC41E2C Offset: 0xC41E2C VA: 0xC41E2C
	private void EquipLastTool() { }

	// RVA: 0xC41F78 Offset: 0xC41F78 VA: 0xC41F78 Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xC42364 Offset: 0xC42364 VA: 0xC42364 Slot: 44
	public override void MakeCurrent(object argument) { }

	// RVA: 0xC4245C Offset: 0xC4245C VA: 0xC4245C Slot: 43
	protected override void Success() { }

	// RVA: 0xC426CC Offset: 0xC426CC VA: 0xC426CC
	public void .ctor() { }
}
