// Namespace: 
public class LocalThrowoutTriggerableCtrlr.StateCanExploseive : LocalToolBaseCtrlr.State // TypeDefIndex: 13061
{
	// Fields
	private MainCharacterController.CommonSkillController mExplodeSkillController; // 0x14
	private Action mCheckGetbackAction; // 0x18
	private Action mOnLeaveAction; // 0x1C

	// Properties
	public LocalThrowoutTriggerableCtrlr ToolCtrlr { get; }
	private SkillIndex ExplodeSkillIndex { get; }

	// Methods

	// RVA: 0xC5B62C Offset: 0xC5B62C VA: 0xC5B62C
	public LocalThrowoutTriggerableCtrlr get_ToolCtrlr() { }

	// RVA: 0xC5B72C Offset: 0xC5B72C VA: 0xC5B72C
	private SkillIndex get_ExplodeSkillIndex() { }

	// RVA: 0xC5A304 Offset: 0xC5A304 VA: 0xC5A304
	public void Init(MainCharacterController.CommonSkillController explodeSkillCtrlr, Action checkGetbackAction, Action onLeave) { }

	// RVA: 0xC5B754 Offset: 0xC5B754 VA: 0xC5B754 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xC5B7CC Offset: 0xC5B7CC VA: 0xC5B7CC Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xC5B8E8 Offset: 0xC5B8E8 VA: 0xC5B8E8 Slot: 37
	public override void Unequip(Action callback, Action onEnter, Action onUpdate, LocalToolBaseCtrlr.State targetToolState, Nullable<float> startTime, bool withAssist, bool needSendToServer) { }

	// RVA: 0xC5B9C8 Offset: 0xC5B9C8 VA: 0xC5B9C8 Slot: 39
	public override void SwitchOutAssist(Action afterSwitchOut, Action onUpdate, Nullable<float> startTime) { }

	// RVA: 0xC5BA90 Offset: 0xC5BA90 VA: 0xC5BA90 Slot: 34
	public override void update() { }

	// RVA: 0xC5BB9C Offset: 0xC5BB9C VA: 0xC5BB9C Slot: 33
	public override void leave() { }

	// RVA: 0xC5BC1C Offset: 0xC5BC1C VA: 0xC5BC1C
	public void .ctor() { }
}
