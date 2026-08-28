// Namespace: 
private sealed class TaskFactory.FromAsyncTrimPromise<TResult, TInstance> : Task<TResult> // TypeDefIndex: 833
{
	// Fields
	internal static readonly AsyncCallback s_completeFromAsyncResult; // 0x0
	private TInstance m_thisRef; // 0x0
	private Func<TInstance, IAsyncResult, TResult> m_endMethod; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(TInstance thisRef, Func<TInstance, IAsyncResult, TResult> endMethod) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2272268 Offset: 0x2272268 VA: 0x2272268
	|-TaskFactory.FromAsyncTrimPromise<int, object>..ctor
	|
	|-RVA: 0x2272990 Offset: 0x2272990 VA: 0x2272990
	|-TaskFactory.FromAsyncTrimPromise<object, object>..ctor
	|
	|-RVA: 0x22730B8 Offset: 0x22730B8 VA: 0x22730B8
	|-TaskFactory.FromAsyncTrimPromise<VoidTaskResult, object>..ctor
	*/

	// RVA: -1 Offset: -1
	internal static void CompleteFromAsyncResult(IAsyncResult asyncResult) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2272334 Offset: 0x2272334 VA: 0x2272334
	|-TaskFactory.FromAsyncTrimPromise<int, object>.CompleteFromAsyncResult
	|
	|-RVA: 0x2272A5C Offset: 0x2272A5C VA: 0x2272A5C
	|-TaskFactory.FromAsyncTrimPromise<object, object>.CompleteFromAsyncResult
	|
	|-RVA: 0x2273184 Offset: 0x2273184 VA: 0x2273184
	|-TaskFactory.FromAsyncTrimPromise<VoidTaskResult, object>.CompleteFromAsyncResult
	*/

	// RVA: -1 Offset: -1
	internal void Complete(TInstance thisRef, Func<TInstance, IAsyncResult, TResult> endMethod, IAsyncResult asyncResult, bool requiresSynchronization) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2272690 Offset: 0x2272690 VA: 0x2272690
	|-TaskFactory.FromAsyncTrimPromise<int, object>.Complete
	|
	|-RVA: 0x2272DB8 Offset: 0x2272DB8 VA: 0x2272DB8
	|-TaskFactory.FromAsyncTrimPromise<object, object>.Complete
	|
	|-RVA: 0x22734E0 Offset: 0x22734E0 VA: 0x22734E0
	|-TaskFactory.FromAsyncTrimPromise<VoidTaskResult, object>.Complete
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x22728C0 Offset: 0x22728C0 VA: 0x22728C0
	|-TaskFactory.FromAsyncTrimPromise<int, object>..cctor
	|
	|-RVA: 0x2272FE8 Offset: 0x2272FE8 VA: 0x2272FE8
	|-TaskFactory.FromAsyncTrimPromise<object, object>..cctor
	|
	|-RVA: 0x2273710 Offset: 0x2273710 VA: 0x2273710
	|-TaskFactory.FromAsyncTrimPromise<VoidTaskResult, object>..cctor
	*/
}
