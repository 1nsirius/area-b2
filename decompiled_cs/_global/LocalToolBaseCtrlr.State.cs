// Namespace: 
public abstract class LocalToolBaseCtrlr.State : ILogicState<LocalToolBaseCtrlr.State> // TypeDefIndex: 12900
{
	// Fields
	protected readonly ITranslateManager mStateTranslateMgr; // 0x8
	protected operable_by_action_table.Record mOperable; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5795CC Offset: 0x5795CC VA: 0x5795CC
	private LocalToolBaseCtrlr <ToolCtrlr>k__BackingField; // 0x10

	// Properties
	public LocalToolBaseCtrlr ToolCtrlr { get; set; }
	public virtual bool AllowTakeIntoIndoor { get; }
	public virtual bool IsNotHide { get; }
	public virtual bool AllowBodyTilt { get; }
	public virtual bool BodyLocked { get; }
	public virtual bool RunEnabled { get; }
	public virtual bool CanClimbLadder { get; }
	public virtual bool AllowCreep { get; }
	public virtual bool AllowCrouch { get; }
	public virtual bool AllowMelee { get; }
	public virtual bool ShowAimPointEnabled { get; }
	public virtual bool AllowGetBack { get; }
	public virtual bool AllowOperateSceneTool { get; }
	public virtual bool AllowPlace { get; }
	public virtual bool AllowJump { get; }
	public virtual bool OverlapRecoveryEnabled { get; }
	public virtual bool AllowTrigger { get; }
	public virtual bool AllowUnequip { get; }
	public bool AllowSwitchInAssist { get; }
	public bool AllowSwitchOutAssist { get; }
	public virtual bool AllowFall { get; }
	public virtual bool IsInSwitchOut { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x668160 Offset: 0x668160 VA: 0x668160
	// RVA: 0xDB0D70 Offset: 0xDB0D70 VA: 0xDB0D70
	public LocalToolBaseCtrlr get_ToolCtrlr() { }

	[CompilerGeneratedAttribute] // RVA: 0x668170 Offset: 0x668170 VA: 0x668170
	// RVA: 0xDB64AC Offset: 0xDB64AC VA: 0xDB64AC
	private void set_ToolCtrlr(LocalToolBaseCtrlr value) { }

	// RVA: 0xDB64B4 Offset: 0xDB64B4 VA: 0xDB64B4
	public void Setup(LocalToolBaseCtrlr toolCtrlr, operable_by_action_table.Record operable) { }

	// RVA: 0xDB64C0 Offset: 0xDB64C0 VA: 0xDB64C0 Slot: 8
	public virtual void InitStateTranslate() { }

	// RVA: 0xDB64C4 Offset: 0xDB64C4 VA: 0xDB64C4
	protected StateTranslate CreateTranslate(Func<bool> condition, LocalToolBaseCtrlr.State nextState) { }

	// RVA: 0xDB6540 Offset: 0xDB6540 VA: 0xDB6540 Slot: 9
	public virtual void AddTranslate(TranslateEvent event, Func<bool> condition, LocalToolBaseCtrlr.State nextState) { }

	// RVA: 0xDB663C Offset: 0xDB663C VA: 0xDB663C Slot: 10
	public virtual void AddTranslate(TranslateEvent event, IStateTranslate translate) { }

	// RVA: 0xDB6724 Offset: 0xDB6724 VA: 0xDB6724 Slot: 11
	public virtual void AddTranslate(TranslateEvent event, LocalToolBaseCtrlr.State nextState) { }

	// RVA: 0xDB67B8 Offset: 0xDB67B8 VA: 0xDB67B8
	protected int GetConditionVal(ETranslateParamName conditionKey) { }

	// RVA: 0xDB67CC Offset: 0xDB67CC VA: 0xDB67CC Slot: 12
	public virtual bool get_AllowTakeIntoIndoor() { }

	// RVA: 0xDB6A38 Offset: 0xDB6A38 VA: 0xDB6A38 Slot: 13
	public virtual bool get_IsNotHide() { }

	// RVA: 0xDB6AA8 Offset: 0xDB6AA8 VA: 0xDB6AA8 Slot: 14
	public virtual bool get_AllowBodyTilt() { }

	// RVA: 0xDB6C34 Offset: 0xDB6C34 VA: 0xDB6C34 Slot: 15
	public virtual bool get_BodyLocked() { }

	// RVA: 0xDB6D44 Offset: 0xDB6D44 VA: 0xDB6D44 Slot: 16
	public virtual bool get_RunEnabled() { }

	// RVA: 0xDB6E50 Offset: 0xDB6E50 VA: 0xDB6E50 Slot: 17
	public virtual bool get_CanClimbLadder() { }

	// RVA: 0xDB6F5C Offset: 0xDB6F5C VA: 0xDB6F5C Slot: 18
	public virtual bool get_AllowCreep() { }

	// RVA: 0xDB7068 Offset: 0xDB7068 VA: 0xDB7068 Slot: 19
	public virtual bool get_AllowCrouch() { }

	// RVA: 0xDB7174 Offset: 0xDB7174 VA: 0xDB7174 Slot: 20
	public virtual bool get_AllowMelee() { }

	// RVA: 0xDB7280 Offset: 0xDB7280 VA: 0xDB7280 Slot: 21
	public virtual bool get_ShowAimPointEnabled() { }

	// RVA: 0xDB740C Offset: 0xDB740C VA: 0xDB740C Slot: 22
	public virtual bool get_AllowGetBack() { }

	// RVA: 0xDB7598 Offset: 0xDB7598 VA: 0xDB7598 Slot: 23
	public virtual bool get_AllowOperateSceneTool() { }

	// RVA: 0xDB7724 Offset: 0xDB7724 VA: 0xDB7724 Slot: 24
	public virtual bool get_AllowPlace() { }

	// RVA: 0xDB78B0 Offset: 0xDB78B0 VA: 0xDB78B0 Slot: 25
	public virtual bool get_AllowJump() { }

	// RVA: 0xDB7A90 Offset: 0xDB7A90 VA: 0xDB7A90 Slot: 26
	public virtual bool get_OverlapRecoveryEnabled() { }

	// RVA: 0xDB7C1C Offset: 0xDB7C1C VA: 0xDB7C1C Slot: 27
	public virtual bool get_AllowTrigger() { }

	// RVA: 0xDB7D28 Offset: 0xDB7D28 VA: 0xDB7D28 Slot: 28
	public virtual bool get_AllowUnequip() { }

	// RVA: 0xDB379C Offset: 0xDB379C VA: 0xDB379C
	public bool get_AllowSwitchInAssist() { }

	// RVA: 0xDB7E34 Offset: 0xDB7E34 VA: 0xDB7E34
	public bool get_AllowSwitchOutAssist() { }

	// RVA: 0xDB7F34 Offset: 0xDB7F34 VA: 0xDB7F34 Slot: 29
	public virtual bool get_AllowFall() { }

	// RVA: 0xDB8040 Offset: 0xDB8040 VA: 0xDB8040 Slot: 30
	public virtual bool get_IsInSwitchOut() { }

	// RVA: 0xDB8048 Offset: 0xDB8048 VA: 0xDB8048 Slot: 31
	public virtual void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xDB8218 Offset: 0xDB8218 VA: 0xDB8218 Slot: 32
	public virtual void post_enter() { }

	// RVA: 0xDB82A0 Offset: 0xDB82A0 VA: 0xDB82A0 Slot: 33
	public virtual void leave() { }

	// RVA: 0xDB82A4 Offset: 0xDB82A4 VA: 0xDB82A4 Slot: 34
	public virtual void update() { }

	// RVA: 0xDB83C4 Offset: 0xDB83C4 VA: 0xDB83C4 Slot: 35
	public virtual void MakeCurrent() { }

	// RVA: 0xDB8454 Offset: 0xDB8454 VA: 0xDB8454 Slot: 36
	public virtual void Equip(Action callback, bool withAssist, bool needSendToServer) { }

	// RVA: 0xDB8458 Offset: 0xDB8458 VA: 0xDB8458 Slot: 37
	public virtual void Unequip(Action callback, Action onEnter, Action onUpdate, LocalToolBaseCtrlr.State targetToolState, Nullable<float> startTime, bool withAssist, bool needSendToServer) { }

	// RVA: 0xDB8534 Offset: 0xDB8534 VA: 0xDB8534 Slot: 38
	public virtual void Operate(OperateInput operate, object argument) { }

	// RVA: 0xDB68D8 Offset: 0xDB68D8 VA: 0xDB68D8
	protected bool GetBoolFromTable(Nullable<int> v, bool def = True) { }

	// RVA: 0xDB8538 Offset: 0xDB8538 VA: 0xDB8538 Slot: 39
	public virtual void SwitchOutAssist(Action afterSwitchOut, Action onUpdate, Nullable<float> startTime) { }

	// RVA: 0xDB8738 Offset: 0xDB8738 VA: 0xDB8738 Slot: 40
	public virtual void SwitchInAssist() { }

	// RVA: 0xDB8788 Offset: 0xDB8788 VA: 0xDB8788
	protected void .ctor() { }
}
