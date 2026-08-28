// Namespace: 
public class AkPlaylist : AkPlaylistArray // TypeDefIndex: 5938
{
	// Fields
	private IntPtr swigCPtr; // 0x10

	// Methods

	// RVA: 0x1BB8168 Offset: 0x1BB8168 VA: 0x1BB8168
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BB8238 Offset: 0x1BB8238 VA: 0x1BB8238
	internal static IntPtr getCPtr(AkPlaylist obj) { }

	// RVA: 0x1BB8290 Offset: 0x1BB8290 VA: 0x1BB8290 Slot: 5
	internal override void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB8364 Offset: 0x1BB8364 VA: 0x1BB8364 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB8444 Offset: 0x1BB8444 VA: 0x1BB8444 Slot: 6
	public override void Dispose() { }

	// RVA: 0x1BB8754 Offset: 0x1BB8754 VA: 0x1BB8754
	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay, IntPtr in_pCustomInfo, uint in_cExternals, AkExternalSourceInfoArray in_pExternalSources) { }

	// RVA: 0x1BB883C Offset: 0x1BB883C VA: 0x1BB883C
	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay, IntPtr in_pCustomInfo, uint in_cExternals) { }

	// RVA: 0x1BB88F0 Offset: 0x1BB88F0 VA: 0x1BB88F0
	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay, IntPtr in_pCustomInfo) { }

	// RVA: 0x1BB899C Offset: 0x1BB899C VA: 0x1BB899C
	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay) { }

	// RVA: 0x1BB8A34 Offset: 0x1BB8A34 VA: 0x1BB8A34
	public AKRESULT Enqueue(uint in_audioNodeID) { }

	// RVA: 0x1BB8AC4 Offset: 0x1BB8AC4 VA: 0x1BB8AC4
	public void .ctor() { }
}
