// Namespace: 
private interface RemoteCharacterController.ICommand : IDisposable // TypeDefIndex: 12630
{
	// Properties
	public abstract float EndTime { get; set; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract float get_EndTime();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void set_EndTime(float value);

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void Start(RemoteCharacterController self);

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void End(RemoteCharacterController self);

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void EndDirectly(RemoteCharacterController self);
}
