// Namespace: 
internal struct SimpleCollator.Context // TypeDefIndex: 57
{
	// Fields
	public readonly CompareOptions Option; // 0x0
	public readonly byte* NeverMatchFlags; // 0x4
	public readonly byte* AlwaysMatchFlags; // 0x8
	public byte* Buffer1; // 0xC
	public byte* Buffer2; // 0x10
	public int PrevCode; // 0x14
	public byte* PrevSortKey; // 0x18

	// Methods

	// RVA: 0x778564 Offset: 0x778564 VA: 0x778564
	public void .ctor(CompareOptions opt, byte* alwaysMatchFlags, byte* neverMatchFlags, byte* buffer1, byte* buffer2, byte* prev1) { }
}
