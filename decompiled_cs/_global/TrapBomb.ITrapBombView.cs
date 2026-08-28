// Namespace: 
public interface TrapBomb.ITrapBombView : IScenePropView, IDisposable // TypeDefIndex: 11016
{
	// Properties
	public abstract List<Transform> SorbTargets { get; }
	public abstract List<Collider> SelfColliders { get; }
	public abstract Bounds TriggerBounds { get; }
	public abstract Vector3 BoundsExtents { get; }
	public abstract Vector3 BoundsCenterInWorld { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract List<Transform> get_SorbTargets();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract List<Collider> get_SelfColliders();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract Bounds get_TriggerBounds();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract Vector3 get_BoundsExtents();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Vector3 get_BoundsCenterInWorld();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void OnBlockingBoardChange();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract void OnInstallTypeChange();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract void Explode();

	// RVA: -1 Offset: -1 Slot: 8
	public abstract void Destroy();

	// RVA: -1 Offset: -1 Slot: 9
	public abstract void OnIsForwardChange();

	// RVA: -1 Offset: -1 Slot: 10
	public abstract void OnCreate();
}
