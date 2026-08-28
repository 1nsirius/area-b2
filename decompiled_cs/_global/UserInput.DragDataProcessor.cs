// Namespace: 
public class UserInput.DragDataProcessor // TypeDefIndex: 11899
{
	// Fields
	private Queue<Vector2> mDragDataLengthHistroy; // 0x8
	[TupleElementNamesAttribute] // RVA: 0x573824 Offset: 0x573824 VA: 0x573824
	private Queue<ValueTuple<float, float>> mHistroyDragPixel; // 0xC

	// Methods

	// RVA: 0xA282E4 Offset: 0xA282E4 VA: 0xA282E4
	public void Clear() { }

	// RVA: 0xA27EEC Offset: 0xA27EEC VA: 0xA27EEC
	public Vector2 GetSmoothDragData() { }

	// RVA: 0xA28388 Offset: 0xA28388 VA: 0xA28388
	public void Update() { }

	// RVA: 0xA2844C Offset: 0xA2844C VA: 0xA2844C
	private void OnDisposeAbruptSpeedUp() { }

	// RVA: 0xA28450 Offset: 0xA28450 VA: 0xA28450
	private void OnTakeDragData() { }

	// RVA: 0xA286F4 Offset: 0xA286F4 VA: 0xA286F4
	public static Vector2 Lerp(Vector2 from, Vector2 to, float t) { }

	// RVA: 0xA2838C Offset: 0xA2838C VA: 0xA2838C
	public void .ctor() { }
}
