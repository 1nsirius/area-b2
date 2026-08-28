// Namespace: 
public class ScoutCarControllerBase.ActionState : ILogicState<ScoutCarControllerBase.ActionState> // TypeDefIndex: 11988
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573CE0 Offset: 0x573CE0 VA: 0x573CE0
	private readonly ScoutCarControllerBase <Owner>k__BackingField; // 0x8

	// Properties
	protected ScoutCarControllerBase Owner { get; }

	// Methods

	// RVA: 0xA0BC94 Offset: 0xA0BC94 VA: 0xA0BC94
	public void .ctor(ScoutCarControllerBase owner) { }

	// RVA: 0xA0A8AC Offset: 0xA0A8AC VA: 0xA0A8AC
	public void MakeCurrent() { }

	// RVA: 0xA0BCBC Offset: 0xA0BCBC VA: 0xA0BCBC Slot: 8
	public virtual void enter(ScoutCarControllerBase.ActionState last) { }

	// RVA: 0xA0BCC0 Offset: 0xA0BCC0 VA: 0xA0BCC0 Slot: 5
	public void post_enter() { }

	// RVA: 0xA0BCC4 Offset: 0xA0BCC4 VA: 0xA0BCC4 Slot: 9
	public virtual void leave() { }

	// RVA: 0xA0BCC8 Offset: 0xA0BCC8 VA: 0xA0BCC8 Slot: 10
	public virtual void update() { }

	// RVA: 0xA0BCCC Offset: 0xA0BCCC VA: 0xA0BCCC Slot: 11
	public virtual void on_scan() { }

	// RVA: 0xA0BCD0 Offset: 0xA0BCD0 VA: 0xA0BCD0 Slot: 12
	public virtual void break_scan() { }

	[CompilerGeneratedAttribute] // RVA: 0x667C40 Offset: 0x667C40 VA: 0x667C40
	// RVA: 0xA0BCB4 Offset: 0xA0BCB4 VA: 0xA0BCB4
	protected ScoutCarControllerBase get_Owner() { }
}
