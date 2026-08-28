// Namespace: 
public class AkIterator : IDisposable // TypeDefIndex: 5910
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkPlaylistItem pItem { get; set; }

	// Methods

	// RVA: 0x1BA9B80 Offset: 0x1BA9B80 VA: 0x1BA9B80
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA9BA8 Offset: 0x1BA9BA8 VA: 0x1BA9BA8
	internal static IntPtr getCPtr(AkIterator obj) { }

	// RVA: 0x1BA9C00 Offset: 0x1BA9C00 VA: 0x1BA9C00 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BA9C2C Offset: 0x1BA9C2C VA: 0x1BA9C2C Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BA9CA0 Offset: 0x1BA9CA0 VA: 0x1BA9CA0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BA9E24 Offset: 0x1BA9E24 VA: 0x1BA9E24
	public void set_pItem(AkPlaylistItem value) { }

	// RVA: 0x1BA9F54 Offset: 0x1BA9F54 VA: 0x1BA9F54
	public AkPlaylistItem get_pItem() { }

	// RVA: 0x1BAA050 Offset: 0x1BAA050 VA: 0x1BAA050
	public AkIterator NextIter() { }

	// RVA: 0x1BAA10C Offset: 0x1BAA10C VA: 0x1BAA10C
	public AkIterator PrevIter() { }

	// RVA: 0x1BAA1C8 Offset: 0x1BAA1C8 VA: 0x1BAA1C8
	public AkPlaylistItem GetItem() { }

	// RVA: 0x1BAA284 Offset: 0x1BAA284 VA: 0x1BAA284
	public bool IsEqualTo(AkIterator in_rOp) { }

	// RVA: 0x1BAA35C Offset: 0x1BAA35C VA: 0x1BAA35C
	public bool IsDifferentFrom(AkIterator in_rOp) { }

	// RVA: 0x1BAA434 Offset: 0x1BAA434 VA: 0x1BAA434
	public void .ctor() { }
}
