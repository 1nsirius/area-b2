// Namespace: 
public sealed class AkCallbackManager.BankCallback : MulticastDelegate // TypeDefIndex: 5977
{
	// Methods

	// RVA: 0xFDE05C Offset: 0xFDE05C VA: 0xFDE05C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFDDAD8 Offset: 0xFDDAD8 VA: 0xFDDAD8 Slot: 12
	public virtual void Invoke(uint in_bankID, IntPtr in_InMemoryBankPtr, AKRESULT in_eLoadResult, uint in_memPoolId, object in_Cookie) { }

	// RVA: 0xFE3310 Offset: 0xFE3310 VA: 0xFE3310 Slot: 13
	public virtual IAsyncResult BeginInvoke(uint in_bankID, IntPtr in_InMemoryBankPtr, AKRESULT in_eLoadResult, uint in_memPoolId, object in_Cookie, AsyncCallback callback, object object) { }

	// RVA: 0xFE340C Offset: 0xFE340C VA: 0xFE340C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
