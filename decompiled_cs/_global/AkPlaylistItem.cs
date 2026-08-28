// Namespace: 
public class AkPlaylistItem : IDisposable // TypeDefIndex: 5940
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint audioNodeID { get; set; }
	public int msDelay { get; set; }
	public IntPtr pCustomInfo { get; set; }

	// Methods

	// RVA: 0x1BAA028 Offset: 0x1BAA028 VA: 0x1BAA028
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA9EFC Offset: 0x1BA9EFC VA: 0x1BA9EFC
	internal static IntPtr getCPtr(AkPlaylistItem obj) { }

	// RVA: 0x1BBA088 Offset: 0x1BBA088 VA: 0x1BBA088 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BBA0B4 Offset: 0x1BBA0B4 VA: 0x1BBA0B4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BBA128 Offset: 0x1BBA128 VA: 0x1BBA128 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BBA2AC Offset: 0x1BBA2AC VA: 0x1BBA2AC
	public void .ctor() { }

	// RVA: 0x1BBA348 Offset: 0x1BBA348 VA: 0x1BBA348
	public void .ctor(AkPlaylistItem in_rCopy) { }

	// RVA: 0x1BBA434 Offset: 0x1BBA434 VA: 0x1BBA434
	public AkPlaylistItem Assign(AkPlaylistItem in_rCopy) { }

	// RVA: 0x1BBA540 Offset: 0x1BBA540 VA: 0x1BBA540
	public bool IsEqualTo(AkPlaylistItem in_rCopy) { }

	// RVA: 0x1BBA618 Offset: 0x1BBA618 VA: 0x1BBA618
	public AKRESULT SetExternalSources(uint in_nExternalSrc, AkExternalSourceInfoArray in_pExternalSrc) { }

	// RVA: 0x1BBA6DC Offset: 0x1BBA6DC VA: 0x1BBA6DC
	public void set_audioNodeID(uint value) { }

	// RVA: 0x1BBA76C Offset: 0x1BBA76C VA: 0x1BBA76C
	public uint get_audioNodeID() { }

	// RVA: 0x1BBA7F4 Offset: 0x1BBA7F4 VA: 0x1BBA7F4
	public void set_msDelay(int value) { }

	// RVA: 0x1BBA884 Offset: 0x1BBA884 VA: 0x1BBA884
	public int get_msDelay() { }

	// RVA: 0x1BBA90C Offset: 0x1BBA90C VA: 0x1BBA90C
	public void set_pCustomInfo(IntPtr value) { }

	// RVA: 0x1BBA99C Offset: 0x1BBA99C VA: 0x1BBA99C
	public IntPtr get_pCustomInfo() { }
}
