// Namespace: 
public class SecurityCamera.ActionState : ILogicState<SecurityCamera.ActionState> // TypeDefIndex: 11958
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573CB0 Offset: 0x573CB0 VA: 0x573CB0
	private SecurityCamera <Owner>k__BackingField; // 0x8

	// Properties
	protected SecurityCamera Owner { get; set; }

	// Methods

	// RVA: 0xA16528 Offset: 0xA16528 VA: 0xA16528
	public void .ctor(SecurityCamera owner) { }

	// RVA: 0xA1338C Offset: 0xA1338C VA: 0xA1338C
	public void MakeCurrent() { }

	// RVA: 0xA16558 Offset: 0xA16558 VA: 0xA16558 Slot: 8
	public virtual void enter(SecurityCamera.ActionState last) { }

	// RVA: 0xA1655C Offset: 0xA1655C VA: 0xA1655C Slot: 5
	public void post_enter() { }

	// RVA: 0xA16560 Offset: 0xA16560 VA: 0xA16560 Slot: 9
	public virtual void leave() { }

	// RVA: 0xA16564 Offset: 0xA16564 VA: 0xA16564 Slot: 10
	public virtual void update() { }

	// RVA: 0xA16568 Offset: 0xA16568 VA: 0xA16568 Slot: 11
	public virtual void on_scan() { }

	// RVA: 0xA1656C Offset: 0xA1656C VA: 0xA1656C Slot: 12
	public virtual void break_scan() { }

	[CompilerGeneratedAttribute] // RVA: 0x667BE0 Offset: 0x667BE0 VA: 0x667BE0
	// RVA: 0xA16550 Offset: 0xA16550 VA: 0xA16550
	protected SecurityCamera get_Owner() { }

	[CompilerGeneratedAttribute] // RVA: 0x667BF0 Offset: 0x667BF0 VA: 0x667BF0
	// RVA: 0xA16548 Offset: 0xA16548 VA: 0xA16548
	private void set_Owner(SecurityCamera value) { }
}
