// Namespace: 
public abstract class StandAloneCharacterController.MovementStateBase : ILogicState<StandAloneCharacterController.MovementStateBase> // TypeDefIndex: 5525
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56D3C4 Offset: 0x56D3C4 VA: 0x56D3C4
	private readonly StandAloneCharacterController <owner>k__BackingField; // 0x8

	// Properties
	protected StandAloneCharacterController owner { get; }

	// Methods

	// RVA: 0xD7E340 Offset: 0xD7E340 VA: 0xD7E340
	protected void .ctor(StandAloneCharacterController owner) { }

	[CompilerGeneratedAttribute] // RVA: 0x652BD0 Offset: 0x652BD0 VA: 0x652BD0
	// RVA: 0xD7E3A4 Offset: 0xD7E3A4 VA: 0xD7E3A4
	protected StandAloneCharacterController get_owner() { }

	// RVA: 0xD7EA14 Offset: 0xD7EA14 VA: 0xD7EA14 Slot: 4
	private void Foundation.ILogicState<StandAloneCharacterController.MovementStateBase>.enter(StandAloneCharacterController.MovementStateBase last) { }

	// RVA: 0xD7EA24 Offset: 0xD7EA24 VA: 0xD7EA24 Slot: 5
	public void post_enter() { }

	// RVA: 0xD7EA28 Offset: 0xD7EA28 VA: 0xD7EA28 Slot: 6
	private void Foundation.ILogicState<StandAloneCharacterController.MovementStateBase>.leave() { }

	// RVA: 0xD7EA38 Offset: 0xD7EA38 VA: 0xD7EA38 Slot: 7
	private void Foundation.ILogicState<StandAloneCharacterController.MovementStateBase>.update() { }

	// RVA: 0xD7E3A0 Offset: 0xD7E3A0 VA: 0xD7E3A0 Slot: 8
	public virtual void enter(StandAloneCharacterController.MovementStateBase last) { }

	// RVA: 0xD7EA48 Offset: 0xD7EA48 VA: 0xD7EA48 Slot: 9
	public virtual void leave() { }

	// RVA: 0xD7EA4C Offset: 0xD7EA4C VA: 0xD7EA4C Slot: 10
	public virtual void update() { }

	// RVA: 0xD7EA50 Offset: 0xD7EA50 VA: 0xD7EA50 Slot: 11
	public virtual void to_stand() { }

	// RVA: 0xD7EA54 Offset: 0xD7EA54 VA: 0xD7EA54 Slot: 12
	public virtual void to_crouch() { }

	// RVA: 0xD7EA58 Offset: 0xD7EA58 VA: 0xD7EA58 Slot: 13
	public virtual void to_creep() { }

	// RVA: 0xD7EA5C Offset: 0xD7EA5C VA: 0xD7EA5C Slot: 14
	public virtual void to_run() { }

	// RVA: 0xD7EA60 Offset: 0xD7EA60 VA: 0xD7EA60 Slot: 15
	public virtual void OnFall() { }

	// RVA: 0xD7EA64 Offset: 0xD7EA64 VA: 0xD7EA64 Slot: 16
	public virtual void OnLand() { }
}
