// Namespace: 
public sealed class AkCallbackManager.MonitoringCallback : MulticastDelegate // TypeDefIndex: 5976
{
	// Methods

	// RVA: 0xFE38AC Offset: 0xFE38AC VA: 0xFE38AC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFE1FF4 Offset: 0xFE1FF4 VA: 0xFE1FF4 Slot: 12
	public virtual void Invoke(AkMonitorErrorCode in_errorCode, AkMonitorErrorLevel in_errorLevel, uint in_playingID, ulong in_gameObjID, string in_msg) { }

	// RVA: 0xFE38C0 Offset: 0xFE38C0 VA: 0xFE38C0 Slot: 13
	public virtual IAsyncResult BeginInvoke(AkMonitorErrorCode in_errorCode, AkMonitorErrorLevel in_errorLevel, uint in_playingID, ulong in_gameObjID, string in_msg, AsyncCallback callback, object object) { }

	// RVA: 0xFE39D4 Offset: 0xFE39D4 VA: 0xFE39D4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
