// Namespace: 
public class AkAcousticSurface : IDisposable // TypeDefIndex: 5874
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint textureID { get; set; }
	public uint reflectorChannelMask { get; set; }
	public string strName { get; set; }

	// Methods

	// RVA: 0xFD389C Offset: 0xFD389C VA: 0xFD389C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFD38C4 Offset: 0xFD38C4 VA: 0xFD38C4
	internal static IntPtr getCPtr(AkAcousticSurface obj) { }

	// RVA: 0xFD391C Offset: 0xFD391C VA: 0xFD391C Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFD3948 Offset: 0xFD3948 VA: 0xFD3948 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFD39BC Offset: 0xFD39BC VA: 0xFD39BC Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFD3B40 Offset: 0xFD3B40 VA: 0xFD3B40
	public void .ctor() { }

	// RVA: 0xFD3BDC Offset: 0xFD3BDC VA: 0xFD3BDC
	public void set_textureID(uint value) { }

	// RVA: 0xFD3C6C Offset: 0xFD3C6C VA: 0xFD3C6C
	public uint get_textureID() { }

	// RVA: 0xFD3CF4 Offset: 0xFD3CF4 VA: 0xFD3CF4
	public void set_reflectorChannelMask(uint value) { }

	// RVA: 0xFD3D84 Offset: 0xFD3D84 VA: 0xFD3D84
	public uint get_reflectorChannelMask() { }

	// RVA: 0xFD3E0C Offset: 0xFD3E0C VA: 0xFD3E0C
	public void set_strName(string value) { }

	// RVA: 0xFD3E9C Offset: 0xFD3E9C VA: 0xFD3E9C
	public string get_strName() { }

	// RVA: 0xFD3F60 Offset: 0xFD3F60 VA: 0xFD3F60
	public void Clear() { }

	// RVA: 0xFD3FE8 Offset: 0xFD3FE8 VA: 0xFD3FE8
	public void DeleteName() { }

	// RVA: 0xFD4070 Offset: 0xFD4070 VA: 0xFD4070
	public static int GetSizeOf() { }

	// RVA: 0xFD40EC Offset: 0xFD40EC VA: 0xFD40EC
	public void Clone(AkAcousticSurface other) { }
}
