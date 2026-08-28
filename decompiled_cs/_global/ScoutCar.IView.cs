// Namespace: 
public interface ScoutCar.IView : IScoutCarSound // TypeDefIndex: 11971
{
	// Properties
	public abstract Vector3 CameraPosition { get; }
	public abstract Vector3 BulletLineStart { get; }
	public abstract List<Transform> Bones { get; }
	public abstract GameObject GameObject { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract Vector3 get_CameraPosition();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract Vector3 get_BulletLineStart();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract List<Transform> get_Bones();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract GameObject get_GameObject();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void PostAttach(bool isSpawn);

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void Attach(ScoutCar c);

	// RVA: -1 Offset: -1 Slot: 6
	public abstract void Detach();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract void update();

	// RVA: -1 Offset: -1 Slot: 8
	public abstract void OnPositionChanged();

	// RVA: -1 Offset: -1 Slot: 9
	public abstract void OnRotationChanged();

	// RVA: -1 Offset: -1 Slot: 10
	public abstract void OnEyesRotationChanged();

	// RVA: -1 Offset: -1 Slot: 11
	public abstract Transform GetTransform();

	// RVA: -1 Offset: -1 Slot: 12
	public abstract void Dispose();

	// RVA: -1 Offset: -1 Slot: 13
	public abstract void OnIsTpChange();

	// RVA: -1 Offset: -1 Slot: 14
	public abstract void OnIsInSceneChange();
}
