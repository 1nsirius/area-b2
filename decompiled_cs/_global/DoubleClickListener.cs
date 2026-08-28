// Namespace: 
public class DoubleClickListener : IDisposable // TypeDefIndex: 5685
{
	// Fields
	private Func<float> mDoubleClickTimeGetter; // 0x8
	private float mLastPressTime; // 0xC
	private UIEventListener mListener; // 0x10
	private Func<float> mThresholdGetter; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x55E4EC Offset: 0x55E4EC VA: 0x55E4EC
	private Action HandleOnDoubleClick; // 0x18

	// Methods

	// RVA: 0xD144A8 Offset: 0xD144A8 VA: 0xD144A8 Slot: 4
	public void Dispose() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA4C Offset: 0x57AA4C VA: 0x57AA4C
	// RVA: 0xD14614 Offset: 0xD14614 VA: 0xD14614
	public void add_HandleOnDoubleClick(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA5C Offset: 0x57AA5C VA: 0x57AA5C
	// RVA: 0xD14720 Offset: 0xD14720 VA: 0xD14720
	public void remove_HandleOnDoubleClick(Action value) { }

	// RVA: 0xD1482C Offset: 0xD1482C VA: 0xD1482C
	public void Init(UIEventListener listener, Func<float> thrGetter, Func<float> timeGetter) { }

	// RVA: 0xD149E0 Offset: 0xD149E0 VA: 0xD149E0
	private void HandleOnDrag(PointerEventData eventData) { }

	// RVA: 0xD14B64 Offset: 0xD14B64 VA: 0xD14B64
	private void HandleOnPressDown(PointerEventData eventData) { }

	// RVA: 0xD14C3C Offset: 0xD14C3C VA: 0xD14C3C
	public void .ctor() { }
}
