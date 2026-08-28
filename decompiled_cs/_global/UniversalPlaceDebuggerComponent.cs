// Namespace: 
public class UniversalPlaceDebuggerComponent : MonoBehaviour // TypeDefIndex: 5585
{
	// Fields
	private readonly Queue<Action> _gizmosActions; // 0xC
	private readonly List<UniversalPlaceDebuggerComponent.FrameAction> guis_; // 0x10

	// Methods

	// RVA: 0x12FCA90 Offset: 0x12FCA90 VA: 0x12FCA90
	public void WrapGizmos(Action action) { }

	// RVA: 0x12FCA94 Offset: 0x12FCA94 VA: 0x12FCA94
	public void WrapGui(Action action) { }

	// RVA: 0x12FCA98 Offset: 0x12FCA98 VA: 0x12FCA98
	public void DrawString(string text, Vector3 worldPos, Nullable<Color> color) { }

	// RVA: 0x12FCA9C Offset: 0x12FCA9C VA: 0x12FCA9C
	private void DrawDebugString(string text, Nullable<Color> color) { }

	// RVA: 0x12FCAA0 Offset: 0x12FCAA0 VA: 0x12FCAA0
	private void DrawString_Inner(string text, Vector3 worldPos, Nullable<Color> color) { }

	// RVA: 0x12FCE54 Offset: 0x12FCE54 VA: 0x12FCE54
	public void .ctor() { }
}
