// Namespace: 
public interface Actor.IController // TypeDefIndex: 11645
{
	// Properties
	public abstract Actor.ICameraControl CameraControl { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract Actor.ICameraControl get_CameraControl();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void activate();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void update();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void onActorUpdate();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void deactivate();
}
