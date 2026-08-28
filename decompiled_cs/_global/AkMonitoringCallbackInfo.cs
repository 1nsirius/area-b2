// Namespace: 
public class AkMonitoringCallbackInfo : IDisposable // TypeDefIndex: 5928
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkMonitorErrorCode errorCode { get; }
	public AkMonitorErrorLevel errorLevel { get; }
	public uint playingID { get; }
	public ulong gameObjID { get; }
	public string message { get; }

	// Methods

	// RVA: 0x1BB227C Offset: 0x1BB227C VA: 0x1BB227C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BB22A4 Offset: 0x1BB22A4 VA: 0x1BB22A4
	internal static IntPtr getCPtr(AkMonitoringCallbackInfo obj) { }

	// RVA: 0x1BB22FC Offset: 0x1BB22FC VA: 0x1BB22FC Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB2328 Offset: 0x1BB2328 VA: 0x1BB2328 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB239C Offset: 0x1BB239C VA: 0x1BB239C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB2520 Offset: 0x1BB2520 VA: 0x1BB2520
	public AkMonitorErrorCode get_errorCode() { }

	// RVA: 0x1BB25A8 Offset: 0x1BB25A8 VA: 0x1BB25A8
	public AkMonitorErrorLevel get_errorLevel() { }

	// RVA: 0x1BB2630 Offset: 0x1BB2630 VA: 0x1BB2630
	public uint get_playingID() { }

	// RVA: 0x1BB26B8 Offset: 0x1BB26B8 VA: 0x1BB26B8
	public ulong get_gameObjID() { }

	// RVA: 0x1BB2740 Offset: 0x1BB2740 VA: 0x1BB2740
	public string get_message() { }

	// RVA: 0x1BB2804 Offset: 0x1BB2804 VA: 0x1BB2804
	public void .ctor() { }
}
