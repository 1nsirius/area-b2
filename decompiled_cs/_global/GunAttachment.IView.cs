// Namespace: 
public interface GunAttachment.IView // TypeDefIndex: 12815
{
	// Properties
	public abstract GameObject Parent { get; }
	public abstract Renderer[] RendererArray { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void Attach(GunAttachment attachment);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void Detach();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract GameObject get_Parent();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void OnCharacterViewChange();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Renderer[] get_RendererArray();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void OnToolAnimatorControllerChange();
}
