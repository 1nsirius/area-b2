// Namespace: 
public sealed class ConditionalWeakTable.CreateValueCallback<TKey, TValue> : MulticastDelegate // TypeDefIndex: 1298
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209D88C Offset: 0x209D88C VA: 0x209D88C
	|-ConditionalWeakTable.CreateValueCallback<HttpWebRequest, NtlmSession>..ctor
	|-ConditionalWeakTable.CreateValueCallback<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual TValue Invoke(TKey key) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209D8A0 Offset: 0x209D8A0 VA: 0x209D8A0
	|-ConditionalWeakTable.CreateValueCallback<object, object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(TKey key, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209E0F0 Offset: 0x209E0F0 VA: 0x209E0F0
	|-ConditionalWeakTable.CreateValueCallback<object, object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual TValue EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209E11C Offset: 0x209E11C VA: 0x209E11C
	|-ConditionalWeakTable.CreateValueCallback<object, object>.EndInvoke
	*/
}
