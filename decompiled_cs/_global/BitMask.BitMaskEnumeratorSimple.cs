// Namespace: 
[Serializable]
private sealed class BitMask.BitMaskEnumeratorSimple : IEnumerator, ICloneable // TypeDefIndex: 9733
{
	// Fields
	private readonly BitMask mBitMask; // 0x8
	private int mIndex; // 0xC
	private readonly int mVersion; // 0x10
	private bool mCurrentElement; // 0x14

	// Properties
	public object Current { get; }

	// Methods

	// RVA: 0x11491A8 Offset: 0x11491A8 VA: 0x11491A8
	internal void .ctor(BitMask bitMask) { }

	// RVA: 0x1149458 Offset: 0x1149458 VA: 0x1149458 Slot: 7
	public object Clone() { }

	// RVA: 0x1149460 Offset: 0x1149460 VA: 0x1149460 Slot: 4
	public bool MoveNext() { }

	// RVA: 0x11495A8 Offset: 0x11495A8 VA: 0x11495A8 Slot: 5
	public object get_Current() { }

	// RVA: 0x11496E4 Offset: 0x11496E4 VA: 0x11496E4 Slot: 6
	public void Reset() { }
}
