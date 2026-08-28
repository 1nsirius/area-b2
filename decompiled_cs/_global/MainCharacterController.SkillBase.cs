// Namespace: 
public class MainCharacterController.SkillBase : MainCharacterController.EmptySkillController // TypeDefIndex: 12593
{
	// Fields
	protected readonly MainCharacterController characterCtrlr; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x57905C Offset: 0x57905C VA: 0x57905C
	private int <ButtonId>k__BackingField; // 0x20

	// Properties
	public override int ButtonId { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667DF0 Offset: 0x667DF0 VA: 0x667DF0
	// RVA: 0xAC5FC8 Offset: 0xAC5FC8 VA: 0xAC5FC8 Slot: 17
	public override int get_ButtonId() { }

	[CompilerGeneratedAttribute] // RVA: 0x667E00 Offset: 0x667E00 VA: 0x667E00
	// RVA: 0xAC5FD0 Offset: 0xAC5FD0 VA: 0xAC5FD0 Slot: 18
	public override void set_ButtonId(int value) { }

	// RVA: 0xAB4AF0 Offset: 0xAB4AF0 VA: 0xAB4AF0
	protected void .ctor(MainCharacterController characterCtrlr) { }

	// RVA: 0xAC5268 Offset: 0xAC5268 VA: 0xAC5268 Slot: 30
	public virtual void Update() { }

	// RVA: 0xAC5FD8 Offset: 0xAC5FD8 VA: 0xAC5FD8 Slot: 31
	public virtual void OnTriggerEnter(Collider trigger) { }

	// RVA: 0xAC5FDC Offset: 0xAC5FDC VA: 0xAC5FDC Slot: 32
	public virtual void OnTriggerExit(Collider trigger) { }

	// RVA: 0xAC5FE0 Offset: 0xAC5FE0 VA: 0xAC5FE0 Slot: 33
	public virtual void OnLightweightTriggerEnter(LightweightTriggerBase trigger) { }

	// RVA: 0xAC5FE4 Offset: 0xAC5FE4 VA: 0xAC5FE4 Slot: 34
	public virtual void OnLightweightTriggerExit(LightweightTriggerBase trigger) { }

	// RVA: 0xAC4F3C Offset: 0xAC4F3C VA: 0xAC4F3C Slot: 35
	public virtual void ShutDown() { }
}
