// Namespace: 
public interface TrapBomb.ITrapBomb : ISceneProp, ISceneItem, IDisposable, IBuffOwner, IVisible, IPosition, IRotation, IU64IdContainer // TypeDefIndex: 11017
{
	// Properties
	public abstract BlockingBoard BlockingBoard { get; }
	public abstract TrapBombInstallType InstallType { get; }
	public abstract bool IsForward { get; }
	[TupleElementNamesAttribute] // RVA: 0x66EECC Offset: 0x66EECC VA: 0x66EECC
	public abstract ValueTuple<float, float> RedLineShowTime { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract BlockingBoard get_BlockingBoard();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract TrapBombInstallType get_InstallType();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract bool get_IsForward();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract ValueTuple<float, float> get_RedLineShowTime();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void OnTriggerEnter(Collider other);
}
