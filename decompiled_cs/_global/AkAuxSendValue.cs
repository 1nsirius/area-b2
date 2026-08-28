// Namespace: 
public class AkAuxSendValue : IDisposable // TypeDefIndex: 5881
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public ulong listenerID { get; set; }
	public uint auxBusID { get; set; }
	public float fControlValue { get; set; }

	// Methods

	// RVA: 0xFDAFB0 Offset: 0xFDAFB0 VA: 0xFDAFB0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFDB830 Offset: 0xFDB830 VA: 0xFDB830
	internal static IntPtr getCPtr(AkAuxSendValue obj) { }

	// RVA: 0xFDB888 Offset: 0xFDB888 VA: 0xFDB888 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFDB8B4 Offset: 0xFDB8B4 VA: 0xFDB8B4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFDB928 Offset: 0xFDB928 VA: 0xFDB928 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFDBAAC Offset: 0xFDBAAC VA: 0xFDBAAC
	public void set_listenerID(ulong value) { }

	// RVA: 0xFDBB50 Offset: 0xFDBB50 VA: 0xFDBB50
	public ulong get_listenerID() { }

	// RVA: 0xFDBBD8 Offset: 0xFDBBD8 VA: 0xFDBBD8
	public void set_auxBusID(uint value) { }

	// RVA: 0xFDBC68 Offset: 0xFDBC68 VA: 0xFDBC68
	public uint get_auxBusID() { }

	// RVA: 0xFDBCF0 Offset: 0xFDBCF0 VA: 0xFDBCF0
	public void set_fControlValue(float value) { }

	// RVA: 0xFDBD80 Offset: 0xFDBD80 VA: 0xFDBD80
	public float get_fControlValue() { }

	// RVA: 0xFDBE08 Offset: 0xFDBE08 VA: 0xFDBE08
	public void Set(GameObject listener, uint id, float value) { }

	// RVA: 0xFDBF18 Offset: 0xFDBF18 VA: 0xFDBF18
	public bool IsSame(GameObject listener, uint id) { }

	// RVA: 0xFDC010 Offset: 0xFDC010 VA: 0xFDC010
	public static int GetSizeOf() { }
}
