// Namespace: 
public sealed class AnalyticsSessionInfo.SessionStateChanged : MulticastDelegate // TypeDefIndex: 3913
{
	// Methods

	// RVA: 0x2CB5E88 Offset: 0x2CB5E88 VA: 0x2CB5E88
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CB5990 Offset: 0x2CB5990 VA: 0x2CB5990 Slot: 12
	public virtual void Invoke(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged) { }

	// RVA: 0x2CB5E9C Offset: 0x2CB5E9C VA: 0x2CB5E9C Slot: 13
	public virtual IAsyncResult BeginInvoke(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged, AsyncCallback callback, object object) { }

	// RVA: 0x2CB5FA4 Offset: 0x2CB5FA4 VA: 0x2CB5FA4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
