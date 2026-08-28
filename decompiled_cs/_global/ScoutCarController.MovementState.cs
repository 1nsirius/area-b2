// Namespace: 
public class ScoutCarController.MovementState : ILogicState<ScoutCarController.MovementState> // TypeDefIndex: 11978
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573CD0 Offset: 0x573CD0 VA: 0x573CD0
	private readonly ScoutCarController <Owner>k__BackingField; // 0x8

	// Properties
	protected ScoutCarController Owner { get; }
	public virtual bool CanJump { get; }

	// Methods

	// RVA: 0xA09C1C Offset: 0xA09C1C VA: 0xA09C1C
	protected void .ctor(ScoutCarController owner) { }

	[CompilerGeneratedAttribute] // RVA: 0x667C30 Offset: 0x667C30 VA: 0x667C30
	// RVA: 0xA09C3C Offset: 0xA09C3C VA: 0xA09C3C
	protected ScoutCarController get_Owner() { }

	// RVA: 0xA09C44 Offset: 0xA09C44 VA: 0xA09C44 Slot: 8
	public virtual bool get_CanJump() { }

	// RVA: 0xA09C4C Offset: 0xA09C4C VA: 0xA09C4C Slot: 9
	public virtual void enter(ScoutCarController.MovementState last) { }

	// RVA: 0xA09C50 Offset: 0xA09C50 VA: 0xA09C50 Slot: 5
	public void post_enter() { }

	// RVA: 0xA09C54 Offset: 0xA09C54 VA: 0xA09C54 Slot: 10
	public virtual void leave() { }

	// RVA: 0xA09C58 Offset: 0xA09C58 VA: 0xA09C58 Slot: 11
	public virtual void update() { }

	// RVA: 0xA09C5C Offset: 0xA09C5C VA: 0xA09C5C
	public void MakeCurrent() { }

	// RVA: 0xA09CEC Offset: 0xA09CEC VA: 0xA09CEC Slot: 12
	public virtual void to_idle() { }

	// RVA: 0xA09CF0 Offset: 0xA09CF0 VA: 0xA09CF0 Slot: 13
	public virtual void to_move() { }

	// RVA: 0xA09CF4 Offset: 0xA09CF4 VA: 0xA09CF4 Slot: 14
	public virtual void to_jump() { }

	// RVA: 0xA09CF8 Offset: 0xA09CF8 VA: 0xA09CF8 Slot: 15
	public virtual void OnLand() { }
}
