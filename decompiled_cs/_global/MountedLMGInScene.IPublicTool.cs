// Namespace: 
public interface MountedLMGInScene.IPublicTool // TypeDefIndex: 12100
{
	// Properties
	public abstract Character character { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void SetOwner(Character c, ushort index = 255);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract Character get_character();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void OnCharacterViewChange();
}
