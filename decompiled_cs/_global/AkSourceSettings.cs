// Namespace: 
public class AkSourceSettings : IDisposable // TypeDefIndex: 5953
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint sourceID { get; set; }
	public IntPtr pMediaMemory { get; set; }
	public uint uMediaSize { get; set; }

	// Methods

	// RVA: 0xCA1928 Offset: 0xCA1928 VA: 0xCA1928
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xCA1950 Offset: 0xCA1950 VA: 0xCA1950
	internal static IntPtr getCPtr(AkSourceSettings obj) { }

	// RVA: 0xCA19A8 Offset: 0xCA19A8 VA: 0xCA19A8 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xCA19D4 Offset: 0xCA19D4 VA: 0xCA19D4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xCA1A48 Offset: 0xCA1A48 VA: 0xCA1A48 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xCA1BCC Offset: 0xCA1BCC VA: 0xCA1BCC
	public void set_sourceID(uint value) { }

	// RVA: 0xCA1C5C Offset: 0xCA1C5C VA: 0xCA1C5C
	public uint get_sourceID() { }

	// RVA: 0xCA1CE4 Offset: 0xCA1CE4 VA: 0xCA1CE4
	public void set_pMediaMemory(IntPtr value) { }

	// RVA: 0xCA1D74 Offset: 0xCA1D74 VA: 0xCA1D74
	public IntPtr get_pMediaMemory() { }

	// RVA: 0xCA1DFC Offset: 0xCA1DFC VA: 0xCA1DFC
	public void set_uMediaSize(uint value) { }

	// RVA: 0xCA1E8C Offset: 0xCA1E8C VA: 0xCA1E8C
	public uint get_uMediaSize() { }

	// RVA: 0xCA1F14 Offset: 0xCA1F14 VA: 0xCA1F14
	public void Clear() { }

	// RVA: 0xCA1F9C Offset: 0xCA1F9C VA: 0xCA1F9C
	public static int GetSizeOf() { }

	// RVA: 0xCA2018 Offset: 0xCA2018 VA: 0xCA2018
	public void Clone(AkSourceSettings other) { }

	// RVA: 0xCA20F0 Offset: 0xCA20F0 VA: 0xCA20F0
	public void .ctor() { }
}
