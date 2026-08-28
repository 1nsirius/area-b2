// Namespace: 
public abstract class MainCharacterController.MovementStateBase : ILogicState<MainCharacterController.MovementStateBase> // TypeDefIndex: 12584
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x57904C Offset: 0x57904C VA: 0x57904C
	private readonly MainCharacterController <owner>k__BackingField; // 0x8

	// Properties
	protected MainCharacterController owner { get; }
	public virtual float MaxSpeed { get; }
	public virtual bool AboutEquipEnabled { get; }

	// Methods

	// RVA: 0xAB6194 Offset: 0xAB6194 VA: 0xAB6194
	protected void .ctor(MainCharacterController owner) { }

	[CompilerGeneratedAttribute] // RVA: 0x667DB0 Offset: 0x667DB0 VA: 0x667DB0
	// RVA: 0xAB61B4 Offset: 0xAB61B4 VA: 0xAB61B4
	protected MainCharacterController get_owner() { }

	// RVA: 0xAB61BC Offset: 0xAB61BC VA: 0xAB61BC Slot: 8
	public virtual float get_MaxSpeed() { }

	// RVA: 0xAB61C4 Offset: 0xAB61C4 VA: 0xAB61C4 Slot: 9
	public virtual bool get_AboutEquipEnabled() { }

	// RVA: 0xAB61CC Offset: 0xAB61CC VA: 0xAB61CC Slot: 4
	private void Foundation.ILogicState<Game.Battle.Character.MainCharacterController.MovementStateBase>.enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xAB61DC Offset: 0xAB61DC VA: 0xAB61DC Slot: 5
	public void post_enter() { }

	// RVA: 0xAB61E0 Offset: 0xAB61E0 VA: 0xAB61E0 Slot: 6
	private void Foundation.ILogicState<Game.Battle.Character.MainCharacterController.MovementStateBase>.leave() { }

	// RVA: 0xAB61F0 Offset: 0xAB61F0 VA: 0xAB61F0 Slot: 7
	private void Foundation.ILogicState<Game.Battle.Character.MainCharacterController.MovementStateBase>.update() { }

	// RVA: 0xAB6200 Offset: 0xAB6200 VA: 0xAB6200 Slot: 10
	public virtual void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xAB6204 Offset: 0xAB6204 VA: 0xAB6204 Slot: 11
	public virtual void leave() { }

	// RVA: 0xAB62B4 Offset: 0xAB62B4 VA: 0xAB62B4 Slot: 12
	public virtual void on_actor_update() { }

	// RVA: 0xAB62B8 Offset: 0xAB62B8 VA: 0xAB62B8 Slot: 13
	public virtual void update() { }

	// RVA: 0xAB6300 Offset: 0xAB6300 VA: 0xAB6300 Slot: 14
	public virtual void to_stand(bool needSendToServer = True) { }

	// RVA: 0xAB6304 Offset: 0xAB6304 VA: 0xAB6304 Slot: 15
	public virtual void to_mounted_lmg() { }

	// RVA: 0xAB6308 Offset: 0xAB6308 VA: 0xAB6308 Slot: 16
	public virtual void to_crouch(bool needSendToServer = True) { }

	// RVA: 0xAB630C Offset: 0xAB630C VA: 0xAB630C Slot: 17
	public virtual void to_creep(EBodyState targetState) { }

	// RVA: 0xAB6310 Offset: 0xAB6310 VA: 0xAB6310 Slot: 18
	public virtual void to_run() { }

	// RVA: 0xAB6314 Offset: 0xAB6314 VA: 0xAB6314 Slot: 19
	public virtual void to_compelling_run() { }

	// RVA: 0xAB6318 Offset: 0xAB6318 VA: 0xAB6318 Slot: 20
	public virtual void switch_aspect() { }

	// RVA: 0xAB631C Offset: 0xAB631C VA: 0xAB631C Slot: 21
	public virtual void to_jump(IJumpTrigger jumpTrigger, in JumpPoints points) { }

	// RVA: 0xAB6320 Offset: 0xAB6320 VA: 0xAB6320 Slot: 22
	public virtual void OnFall() { }

	// RVA: 0xAB6324 Offset: 0xAB6324 VA: 0xAB6324 Slot: 23
	public virtual void OnLand() { }

	// RVA: 0xAB6328 Offset: 0xAB6328 VA: 0xAB6328 Slot: 24
	public virtual void OnAgonal() { }

	// RVA: 0xAB632C Offset: 0xAB632C VA: 0xAB632C Slot: 25
	public virtual void OnRelive() { }

	// RVA: 0xAB6330 Offset: 0xAB6330 VA: 0xAB6330 Slot: 26
	public virtual void OnStartBeRescued() { }

	// RVA: 0xAB6334 Offset: 0xAB6334 VA: 0xAB6334 Slot: 27
	public virtual void OnBreakBeRescued() { }

	// RVA: 0xAB6338 Offset: 0xAB6338 VA: 0xAB6338 Slot: 28
	public virtual void on_leave_wall_space_by_window(bool isSuccess) { }

	// RVA: 0xAB633C Offset: 0xAB633C VA: 0xAB633C Slot: 29
	public virtual float GetStateChangeDuration(EBodyState targetBodyState) { }

	// RVA: 0xAB6344 Offset: 0xAB6344 VA: 0xAB6344
	public bool CheckStateChange(EBodyState targetBodyState) { }

	// RVA: 0xAB64A4 Offset: 0xAB64A4 VA: 0xAB64A4
	public void ChangeToDefaultBodyState(EBodyState targetBodyState) { }

	// RVA: 0xAB6624 Offset: 0xAB6624 VA: 0xAB6624 Slot: 30
	public virtual bool AllowByToolState(LocalToolBaseCtrlr.State targetToolState) { }
}
