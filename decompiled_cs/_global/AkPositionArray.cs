// Namespace: 
public class AkPositionArray : IDisposable // TypeDefIndex: 6016
{
	// Fields
	public IntPtr m_Buffer; // 0x8
	private IntPtr m_Current; // 0xC
	private uint m_MaxCount; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55F8F0 Offset: 0x55F8F0 VA: 0x55F8F0
	private uint <Count>k__BackingField; // 0x14

	// Properties
	public uint Count { get; set; }

	// Methods

	// RVA: 0x1BBAA24 Offset: 0x1BBAA24 VA: 0x1BBAA24
	public void .ctor(uint in_Count) { }

	[CompilerGeneratedAttribute] // RVA: 0x57B304 Offset: 0x57B304 VA: 0x57B304
	// RVA: 0x1BBAAD4 Offset: 0x1BBAAD4 VA: 0x1BBAAD4
	public uint get_Count() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B314 Offset: 0x57B314 VA: 0x57B314
	// RVA: 0x1BBAACC Offset: 0x1BBAACC VA: 0x1BBAACC
	private void set_Count(uint value) { }

	// RVA: 0x1BBAADC Offset: 0x1BBAADC VA: 0x1BBAADC Slot: 4
	public void Dispose() { }

	// RVA: 0x1BBAB88 Offset: 0x1BBAB88 VA: 0x1BBAB88 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BBABEC Offset: 0x1BBABEC VA: 0x1BBABEC
	public void Reset() { }

	// RVA: 0x1BBAC00 Offset: 0x1BBAC00 VA: 0x1BBAC00
	public void Add(Vector3 in_Pos, Vector3 in_Forward, Vector3 in_Top) { }
}
