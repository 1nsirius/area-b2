// Namespace: 
public class UIDragPanel.DragTouch : IEqualityComparer<UIDragPanel.DragTouch> // TypeDefIndex: 5808
{
	// Fields
	public static readonly int DefaultTouchId; // 0x0
	public static readonly UIDragPanel.DragTouch DefaultTouch; // 0x4
	public int touchId; // 0x8
	public Vector2 last; // 0xC
	public Vector2 current; // 0x14
	public Vector2 delta; // 0x1C
	public float timeStart; // 0x24
	public Vector2 fingerPoint; // 0x28

	// Methods

	// RVA: 0xAF2708 Offset: 0xAF2708 VA: 0xAF2708
	public void .ctor(int touchId) { }

	// RVA: 0xAF280C Offset: 0xAF280C VA: 0xAF280C Slot: 4
	public bool Equals(UIDragPanel.DragTouch x, UIDragPanel.DragTouch y) { }

	// RVA: 0xAF2870 Offset: 0xAF2870 VA: 0xAF2870 Slot: 5
	public int GetHashCode(UIDragPanel.DragTouch obj) { }

	// RVA: 0xAF28A4 Offset: 0xAF28A4 VA: 0xAF28A4
	public void Reset() { }

	// RVA: 0xAF29DC Offset: 0xAF29DC VA: 0xAF29DC
	private static void .cctor() { }
}
