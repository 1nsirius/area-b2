// Namespace: 
public class PressButton : IDisposable // TypeDefIndex: 5632
{
	// Fields
	private static readonly float threshold; // 0x0
	private UIEventListener mListener; // 0x8
	private PressButton.EPressButtonMode mMode; // 0xC
	private float mPressTime; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55E1B4 Offset: 0x55E1B4 VA: 0x55E1B4
	private Action OnToggleEvt; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x55E1C4 Offset: 0x55E1C4 VA: 0x55E1C4
	private Action OnToggleOffEvt; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x55E1D4 Offset: 0x55E1D4 VA: 0x55E1D4
	private Action OnToggleOnEvt; // 0x1C

	// Methods

	// RVA: 0x2CE9334 Offset: 0x2CE9334 VA: 0x2CE9334 Slot: 4
	public void Dispose() { }

	// RVA: 0x2CE94A0 Offset: 0x2CE94A0 VA: 0x2CE94A0
	public PressButton Init(UIEventListener listener) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A71C Offset: 0x57A71C VA: 0x57A71C
	// RVA: 0x2CE95C0 Offset: 0x2CE95C0 VA: 0x2CE95C0
	public void add_OnToggleEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A72C Offset: 0x57A72C VA: 0x57A72C
	// RVA: 0x2CE96CC Offset: 0x2CE96CC VA: 0x2CE96CC
	public void remove_OnToggleEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A73C Offset: 0x57A73C VA: 0x57A73C
	// RVA: 0x2CE97D8 Offset: 0x2CE97D8 VA: 0x2CE97D8
	public void add_OnToggleOffEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A74C Offset: 0x57A74C VA: 0x57A74C
	// RVA: 0x2CE98E4 Offset: 0x2CE98E4 VA: 0x2CE98E4
	public void remove_OnToggleOffEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A75C Offset: 0x57A75C VA: 0x57A75C
	// RVA: 0x2CE99F0 Offset: 0x2CE99F0 VA: 0x2CE99F0
	public void add_OnToggleOnEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A76C Offset: 0x57A76C VA: 0x57A76C
	// RVA: 0x2CE9AFC Offset: 0x2CE9AFC VA: 0x2CE9AFC
	public void remove_OnToggleOnEvt(Action value) { }

	// RVA: 0x2CE9C08 Offset: 0x2CE9C08 VA: 0x2CE9C08
	public void SetMode(PressButton.EPressButtonMode mode) { }

	// RVA: 0x2CE9C10 Offset: 0x2CE9C10 VA: 0x2CE9C10
	private void HandleOnPressDown(BaseEventData eventData) { }

	// RVA: 0x2CE9C68 Offset: 0x2CE9C68 VA: 0x2CE9C68
	private void HandleOnPressUp(BaseEventData eventData) { }

	// RVA: 0x2CE9D58 Offset: 0x2CE9D58 VA: 0x2CE9D58
	public void .ctor() { }

	// RVA: 0x2CE9D60 Offset: 0x2CE9D60 VA: 0x2CE9D60
	private static void .cctor() { }
}
