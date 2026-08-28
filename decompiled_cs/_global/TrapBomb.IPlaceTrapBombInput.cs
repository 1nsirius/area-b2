// Namespace: 
public interface TrapBomb.IPlaceTrapBombInput // TypeDefIndex: 11019
{
	// Properties
	public abstract bool IsForward { get; }
	public abstract bool IsLeft { get; }
	public abstract bool IsUpper { get; }
	public abstract Vector3 TrapBombPos { get; }
	public abstract Quaternion TrapBombRot { get; }
	public abstract byte TrapBombIndex { get; }
	public abstract BlockingBoard BlockingBoard { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract bool get_IsForward();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract bool get_IsLeft();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract bool get_IsUpper();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract Vector3 get_TrapBombPos();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Quaternion get_TrapBombRot();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract byte get_TrapBombIndex();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract BlockingBoard get_BlockingBoard();
}
