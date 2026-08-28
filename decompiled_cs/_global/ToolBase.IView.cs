// Namespace: 
public interface ToolBase.IView // TypeDefIndex: 12805
{
	// Properties
	public abstract Transform LeftHandPoint { get; }
	public abstract Transform RightHandPoint { get; }
	public abstract List<Transform> CheckForThroughTransforms { get; }
	public abstract Renderer[] RendererArray { get; }
	public abstract Renderer[] RendererAttachmentArray { get; }
	public abstract IkBase LeftIk { get; }
	public abstract IkBase RightIk { get; }
	public abstract float TurnThresholdMulti { get; }
	public abstract Transform ParentPoint { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract Transform get_LeftHandPoint();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract Transform get_RightHandPoint();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract List<Transform> get_CheckForThroughTransforms();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract Renderer[] get_RendererArray();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Renderer[] get_RendererAttachmentArray();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract IkBase get_LeftIk();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract IkBase get_RightIk();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract float get_TurnThresholdMulti();

	// RVA: -1 Offset: -1 Slot: 8
	public abstract Transform get_ParentPoint();

	// RVA: -1 Offset: -1 Slot: 9
	public abstract void OnAttach(ToolBase tool);

	// RVA: -1 Offset: -1 Slot: 10
	public abstract void OnDetach();

	// RVA: -1 Offset: -1 Slot: 11
	public abstract void OnVisibleChange();

	// RVA: -1 Offset: -1 Slot: 12
	public abstract void OnCharacterViewChange();

	// RVA: -1 Offset: -1 Slot: 13
	public abstract void DetachFromCharacter();

	// RVA: -1 Offset: -1 Slot: 14
	public abstract void RefreshAnimatorController();

	// RVA: -1 Offset: -1 Slot: 15
	public abstract void OnEnablePlaceFactorChange();

	// RVA: -1 Offset: -1 Slot: 16
	public abstract void OnCharacterChange(Character lastCharacter);

	// RVA: -1 Offset: -1 Slot: 17
	public abstract void DestroyView();
}
