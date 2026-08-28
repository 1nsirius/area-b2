// Namespace: 
public class FingerPosListener : IDisposable // TypeDefIndex: 5686
{
	// Fields
	private UIEventListener mListener; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x55E4FC Offset: 0x55E4FC VA: 0x55E4FC
	private Action<Vector2> OnFingerMove; // 0xC

	// Methods

	// RVA: 0xF9E85C Offset: 0xF9E85C VA: 0xF9E85C Slot: 4
	public void Dispose() { }

	// RVA: 0xF9E9C8 Offset: 0xF9E9C8 VA: 0xF9E9C8
	public void Init(UIEventListener listener) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA6C Offset: 0x57AA6C VA: 0x57AA6C
	// RVA: 0xF9EBFC Offset: 0xF9EBFC VA: 0xF9EBFC
	public void add_OnFingerMove(Action<Vector2> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA7C Offset: 0x57AA7C VA: 0x57AA7C
	// RVA: 0xF9ED08 Offset: 0xF9ED08 VA: 0xF9ED08
	public void remove_OnFingerMove(Action<Vector2> value) { }

	// RVA: 0xF9EE14 Offset: 0xF9EE14 VA: 0xF9EE14
	private void HandleOnDrag(PointerEventData eventData) { }

	// RVA: 0xF9EEB4 Offset: 0xF9EEB4 VA: 0xF9EEB4
	private void HandleOnPressDown(PointerEventData eventData) { }

	// RVA: 0xF9EF54 Offset: 0xF9EF54 VA: 0xF9EF54
	public void .ctor() { }
}
