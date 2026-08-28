// Namespace: 
public sealed class UIDragPanel.DragTouchesCollection : IEnumerable<UIDragPanel.DragTouch>, IEnumerable // TypeDefIndex: 5810
{
	// Fields
	private static readonly int DefaultCapacity; // 0x0
	private static UIDragPanel.DragTouch[] DefaultTouches; // 0x4
	private UIDragPanel.DragTouch[] mTouches; // 0x8
	private int mMaxTouchCount; // 0xC
	private int mHead; // 0x10
	private int mSize; // 0x14

	// Properties
	public int Head { get; }
	public int Size { get; }
	public UIDragPanel.DragTouch[] Touches { get; }

	// Methods

	// RVA: 0xAF2AE0 Offset: 0xAF2AE0 VA: 0xAF2AE0
	public int get_Head() { }

	// RVA: 0xAF2AE8 Offset: 0xAF2AE8 VA: 0xAF2AE8
	public int get_Size() { }

	// RVA: 0xAF2AF0 Offset: 0xAF2AF0 VA: 0xAF2AF0
	public UIDragPanel.DragTouch[] get_Touches() { }

	// RVA: 0xAF2AF8 Offset: 0xAF2AF8 VA: 0xAF2AF8
	public void .ctor() { }

	// RVA: 0xAF24E4 Offset: 0xAF24E4 VA: 0xAF24E4
	public void .ctor(int capacity) { }

	// RVA: 0xAF2134 Offset: 0xAF2134 VA: 0xAF2134
	public void Insert(UIDragPanel.DragTouch touch) { }

	// RVA: 0xAF224C Offset: 0xAF224C VA: 0xAF224C
	public void Remove(int touchId) { }

	// RVA: 0xAF1A6C Offset: 0xAF1A6C VA: 0xAF1A6C
	public Vector2 Delta() { }

	// RVA: 0xAF1A14 Offset: 0xAF1A14 VA: 0xAF1A14
	public UIDragPanel.DragTouch Peek() { }

	// RVA: 0xAF1E98 Offset: 0xAF1E98 VA: 0xAF1E98
	public UIDragPanel.DragTouch Find(int touchId) { }

	// RVA: 0xAF2094 Offset: 0xAF2094 VA: 0xAF2094
	public UIDragPanel.DragTouch GetUnUsedDragTouch() { }

	// RVA: 0xAF207C Offset: 0xAF207C VA: 0xAF207C
	public bool IsFull() { }

	// RVA: 0xAF1C80 Offset: 0xAF1C80 VA: 0xAF1C80
	public void Clear() { }

	// RVA: 0xAF1A00 Offset: 0xAF1A00 VA: 0xAF1A00
	public bool IsEmpty() { }

	// RVA: 0xAF1D18 Offset: 0xAF1D18 VA: 0xAF1D18
	public UIDragPanel.DragTouchesCollection.Enumerator GetEnumerator() { }

	// RVA: 0xAF2BA0 Offset: 0xAF2BA0 VA: 0xAF2BA0 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	// RVA: 0xAF2C1C Offset: 0xAF2C1C VA: 0xAF2C1C Slot: 4
	private IEnumerator<UIDragPanel.DragTouch> System.Collections.Generic.IEnumerable<UIDragPanel.DragTouch>.GetEnumerator() { }

	// RVA: 0xAF2C98 Offset: 0xAF2C98 VA: 0xAF2C98
	private static void .cctor() { }
}
