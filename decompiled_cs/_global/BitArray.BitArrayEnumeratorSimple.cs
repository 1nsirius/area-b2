// Namespace: 
[Serializable]
private class BitArray.BitArrayEnumeratorSimple : IEnumerator, ICloneable // TypeDefIndex: 1360
{
	// Fields
	private BitArray bitarray; // 0x8
	private int index; // 0xC
	private int version; // 0x10
	private bool currentElement; // 0x14

	// Properties
	public virtual object Current { get; }

	// Methods

	// RVA: 0x1B794C0 Offset: 0x1B794C0 VA: 0x1B794C0
	internal void .ctor(BitArray bitarray) { }

	// RVA: 0x1B79500 Offset: 0x1B79500 VA: 0x1B79500 Slot: 7
	public object Clone() { }

	// RVA: 0x1B79508 Offset: 0x1B79508 VA: 0x1B79508 Slot: 8
	public virtual bool MoveNext() { }

	// RVA: 0x1B7965C Offset: 0x1B7965C VA: 0x1B7965C Slot: 9
	public virtual object get_Current() { }

	// RVA: 0x1B797B0 Offset: 0x1B797B0 VA: 0x1B797B0 Slot: 6
	public void Reset() { }
}
