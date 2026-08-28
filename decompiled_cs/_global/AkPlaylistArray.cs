// Namespace: 
public class AkPlaylistArray : IDisposable // TypeDefIndex: 5939
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Methods

	// RVA: 0x1BB8210 Offset: 0x1BB8210 VA: 0x1BB8210
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BB8B54 Offset: 0x1BB8B54 VA: 0x1BB8B54
	internal static IntPtr getCPtr(AkPlaylistArray obj) { }

	// RVA: 0x1BB8338 Offset: 0x1BB8338 VA: 0x1BB8338 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB83D0 Offset: 0x1BB83D0 VA: 0x1BB83D0 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB85D0 Offset: 0x1BB85D0 VA: 0x1BB85D0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB8BAC Offset: 0x1BB8BAC VA: 0x1BB8BAC
	public void .ctor() { }

	// RVA: 0x1BB8C48 Offset: 0x1BB8C48 VA: 0x1BB8C48
	public AkIterator Begin() { }

	// RVA: 0x1BB8D04 Offset: 0x1BB8D04 VA: 0x1BB8D04
	public AkIterator End() { }

	// RVA: 0x1BB8DC0 Offset: 0x1BB8DC0 VA: 0x1BB8DC0
	public AkIterator FindEx(AkPlaylistItem in_Item) { }

	// RVA: 0x1BB8ECC Offset: 0x1BB8ECC VA: 0x1BB8ECC
	public AkIterator Erase(AkIterator in_rIter) { }

	// RVA: 0x1BB8FD8 Offset: 0x1BB8FD8 VA: 0x1BB8FD8
	public void Erase(uint in_uIndex) { }

	// RVA: 0x1BB9068 Offset: 0x1BB9068 VA: 0x1BB9068
	public AkIterator EraseSwap(AkIterator in_rIter) { }

	// RVA: 0x1BB9174 Offset: 0x1BB9174 VA: 0x1BB9174
	public AKRESULT Reserve(uint in_ulReserve) { }

	// RVA: 0x1BB9204 Offset: 0x1BB9204 VA: 0x1BB9204
	public uint Reserved() { }

	// RVA: 0x1BB928C Offset: 0x1BB928C VA: 0x1BB928C
	public void Term() { }

	// RVA: 0x1BB9314 Offset: 0x1BB9314 VA: 0x1BB9314
	public uint Length() { }

	// RVA: 0x1BB939C Offset: 0x1BB939C VA: 0x1BB939C
	public AkPlaylistItem Data() { }

	// RVA: 0x1BB9470 Offset: 0x1BB9470 VA: 0x1BB9470
	public bool IsEmpty() { }

	// RVA: 0x1BB94F8 Offset: 0x1BB94F8 VA: 0x1BB94F8
	public AkPlaylistItem Exists(AkPlaylistItem in_Item) { }

	// RVA: 0x1BB961C Offset: 0x1BB961C VA: 0x1BB961C
	public AkPlaylistItem AddLast() { }

	// RVA: 0x1BB96F0 Offset: 0x1BB96F0 VA: 0x1BB96F0
	public AkPlaylistItem AddLast(AkPlaylistItem in_rItem) { }

	// RVA: 0x1BB9814 Offset: 0x1BB9814 VA: 0x1BB9814
	public AkPlaylistItem Last() { }

	// RVA: 0x1BB98D0 Offset: 0x1BB98D0 VA: 0x1BB98D0
	public void RemoveLast() { }

	// RVA: 0x1BB9958 Offset: 0x1BB9958 VA: 0x1BB9958
	public AKRESULT Remove(AkPlaylistItem in_rItem) { }

	// RVA: 0x1BB9A30 Offset: 0x1BB9A30 VA: 0x1BB9A30
	public AKRESULT RemoveSwap(AkPlaylistItem in_rItem) { }

	// RVA: 0x1BB9B08 Offset: 0x1BB9B08 VA: 0x1BB9B08
	public void RemoveAll() { }

	// RVA: 0x1BB9B90 Offset: 0x1BB9B90 VA: 0x1BB9B90
	public AkPlaylistItem ItemAtIndex(uint uiIndex) { }

	// RVA: 0x1BB9C54 Offset: 0x1BB9C54 VA: 0x1BB9C54
	public AkPlaylistItem Insert(uint in_uIndex) { }

	// RVA: 0x1BB9D30 Offset: 0x1BB9D30 VA: 0x1BB9D30
	public bool GrowArray(uint in_uGrowBy) { }

	// RVA: 0x1BB9DC0 Offset: 0x1BB9DC0 VA: 0x1BB9DC0
	public bool GrowArray() { }

	// RVA: 0x1BB9E48 Offset: 0x1BB9E48 VA: 0x1BB9E48
	public bool Resize(uint in_uiSize) { }

	// RVA: 0x1BB9ED8 Offset: 0x1BB9ED8 VA: 0x1BB9ED8
	public void Transfer(AkPlaylistArray in_rSource) { }

	// RVA: 0x1BB9FB0 Offset: 0x1BB9FB0 VA: 0x1BB9FB0
	public AKRESULT Copy(AkPlaylistArray in_rSource) { }
}
