// Namespace: 
private abstract class SecurityCamera.Command // TypeDefIndex: 11961
{
	// Fields
	public float start_time; // 0x8
	public float end_time; // 0xC

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void start(SecurityCamera self);

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void update(SecurityCamera self);

	// RVA: -1 Offset: -1 Slot: 6
	public abstract void end(SecurityCamera self);

	// RVA: -1 Offset: -1 Slot: 7
	public abstract void process(SecurityCamera self);

	// RVA: 0xA16B1C Offset: 0xA16B1C VA: 0xA16B1C
	protected void .ctor() { }
}
