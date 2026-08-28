// Namespace: 
public class AkChannelEmitterArray : IDisposable // TypeDefIndex: 6010
{
	// Fields
	public IntPtr m_Buffer; // 0x8
	private IntPtr m_Current; // 0xC
	private uint m_MaxCount; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55F8E0 Offset: 0x55F8E0 VA: 0x55F8E0
	private uint <Count>k__BackingField; // 0x14

	// Properties
	public uint Count { get; set; }

	// Methods

	// RVA: 0xFE502C Offset: 0xFE502C VA: 0xFE502C
	public void .ctor(uint in_Count) { }

	[CompilerGeneratedAttribute] // RVA: 0x57B2E4 Offset: 0x57B2E4 VA: 0x57B2E4
	// RVA: 0xFE50DC Offset: 0xFE50DC VA: 0xFE50DC
	public uint get_Count() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B2F4 Offset: 0x57B2F4 VA: 0x57B2F4
	// RVA: 0xFE50D4 Offset: 0xFE50D4 VA: 0xFE50D4
	private void set_Count(uint value) { }

	// RVA: 0xFE50E4 Offset: 0xFE50E4 VA: 0xFE50E4 Slot: 4
	public void Dispose() { }

	// RVA: 0xFE5190 Offset: 0xFE5190 VA: 0xFE5190 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE51F4 Offset: 0xFE51F4 VA: 0xFE51F4
	public void Reset() { }

	// RVA: 0xFE5208 Offset: 0xFE5208 VA: 0xFE5208
	public void Add(Vector3 in_Pos, Vector3 in_Forward, Vector3 in_Top, uint in_ChannelMask) { }
}
