// Namespace: 
public class AkObjectInfo : IDisposable // TypeDefIndex: 5933
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint objID { get; set; }
	public uint parentID { get; set; }
	public int iDepth { get; set; }

	// Methods

	// RVA: 0x1BB3E24 Offset: 0x1BB3E24 VA: 0x1BB3E24
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BB3E4C Offset: 0x1BB3E4C VA: 0x1BB3E4C
	internal static IntPtr getCPtr(AkObjectInfo obj) { }

	// RVA: 0x1BB3EA4 Offset: 0x1BB3EA4 VA: 0x1BB3EA4 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB3ED0 Offset: 0x1BB3ED0 VA: 0x1BB3ED0 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB3F44 Offset: 0x1BB3F44 VA: 0x1BB3F44 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB40C8 Offset: 0x1BB40C8 VA: 0x1BB40C8
	public void set_objID(uint value) { }

	// RVA: 0x1BB4158 Offset: 0x1BB4158 VA: 0x1BB4158
	public uint get_objID() { }

	// RVA: 0x1BB41E0 Offset: 0x1BB41E0 VA: 0x1BB41E0
	public void set_parentID(uint value) { }

	// RVA: 0x1BB4270 Offset: 0x1BB4270 VA: 0x1BB4270
	public uint get_parentID() { }

	// RVA: 0x1BB42F8 Offset: 0x1BB42F8 VA: 0x1BB42F8
	public void set_iDepth(int value) { }

	// RVA: 0x1BB4388 Offset: 0x1BB4388 VA: 0x1BB4388
	public int get_iDepth() { }

	// RVA: 0x1BB4410 Offset: 0x1BB4410 VA: 0x1BB4410
	public void Clear() { }

	// RVA: 0x1BB4498 Offset: 0x1BB4498 VA: 0x1BB4498
	public static int GetSizeOf() { }

	// RVA: 0x1BB4514 Offset: 0x1BB4514 VA: 0x1BB4514
	public void Clone(AkObjectInfo other) { }

	// RVA: 0x1BB45EC Offset: 0x1BB45EC VA: 0x1BB45EC
	public void .ctor() { }
}
