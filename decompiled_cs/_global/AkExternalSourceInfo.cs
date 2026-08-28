// Namespace: 
public class AkExternalSourceInfo : IDisposable // TypeDefIndex: 5902
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint iExternalSrcCookie { get; set; }
	public uint idCodec { get; set; }
	public string szFile { get; set; }
	public IntPtr pInMemory { get; set; }
	public uint uiMemorySize { get; set; }
	public uint idFile { get; set; }

	// Methods

	// RVA: 0x1BA2364 Offset: 0x1BA2364 VA: 0x1BA2364
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA238C Offset: 0x1BA238C VA: 0x1BA238C
	internal static IntPtr getCPtr(AkExternalSourceInfo obj) { }

	// RVA: 0x1BA23E4 Offset: 0x1BA23E4 VA: 0x1BA23E4 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BA2410 Offset: 0x1BA2410 VA: 0x1BA2410 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BA2484 Offset: 0x1BA2484 VA: 0x1BA2484 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BA2608 Offset: 0x1BA2608 VA: 0x1BA2608
	public void .ctor() { }

	// RVA: 0x1BA26A4 Offset: 0x1BA26A4 VA: 0x1BA26A4
	public void .ctor(IntPtr in_pInMemory, uint in_uiMemorySize, uint in_iExternalSrcCookie, uint in_idCodec) { }

	// RVA: 0x1BA276C Offset: 0x1BA276C VA: 0x1BA276C
	public void .ctor(string in_pszFileName, uint in_iExternalSrcCookie, uint in_idCodec) { }

	// RVA: 0x1BA2820 Offset: 0x1BA2820 VA: 0x1BA2820
	public void .ctor(uint in_idFile, uint in_iExternalSrcCookie, uint in_idCodec) { }

	// RVA: 0x1BA28D4 Offset: 0x1BA28D4 VA: 0x1BA28D4
	public void Clear() { }

	// RVA: 0x1BA295C Offset: 0x1BA295C VA: 0x1BA295C
	public void Clone(AkExternalSourceInfo other) { }

	// RVA: 0x1BA2A34 Offset: 0x1BA2A34 VA: 0x1BA2A34
	public static int GetSizeOf() { }

	// RVA: 0x1BA2AB0 Offset: 0x1BA2AB0 VA: 0x1BA2AB0
	public void set_iExternalSrcCookie(uint value) { }

	// RVA: 0x1BA2B40 Offset: 0x1BA2B40 VA: 0x1BA2B40
	public uint get_iExternalSrcCookie() { }

	// RVA: 0x1BA2BC8 Offset: 0x1BA2BC8 VA: 0x1BA2BC8
	public void set_idCodec(uint value) { }

	// RVA: 0x1BA2C58 Offset: 0x1BA2C58 VA: 0x1BA2C58
	public uint get_idCodec() { }

	// RVA: 0x1BA2CE0 Offset: 0x1BA2CE0 VA: 0x1BA2CE0
	public void set_szFile(string value) { }

	// RVA: 0x1BA2D70 Offset: 0x1BA2D70 VA: 0x1BA2D70
	public string get_szFile() { }

	// RVA: 0x1BA2E34 Offset: 0x1BA2E34 VA: 0x1BA2E34
	public void set_pInMemory(IntPtr value) { }

	// RVA: 0x1BA2EC4 Offset: 0x1BA2EC4 VA: 0x1BA2EC4
	public IntPtr get_pInMemory() { }

	// RVA: 0x1BA2F4C Offset: 0x1BA2F4C VA: 0x1BA2F4C
	public void set_uiMemorySize(uint value) { }

	// RVA: 0x1BA2FDC Offset: 0x1BA2FDC VA: 0x1BA2FDC
	public uint get_uiMemorySize() { }

	// RVA: 0x1BA3064 Offset: 0x1BA3064 VA: 0x1BA3064
	public void set_idFile(uint value) { }

	// RVA: 0x1BA30F4 Offset: 0x1BA30F4 VA: 0x1BA30F4
	public uint get_idFile() { }
}
