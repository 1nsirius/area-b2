// Namespace: 
public struct ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<TResult> : ICriticalNotifyCompletion, INotifyCompletion // TypeDefIndex: 1277
{
	// Fields
	private readonly Task<TResult> m_task; // 0x0
	private readonly bool m_continueOnCapturedContext; // 0x0

	// Properties
	public bool IsCompleted { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(Task<TResult> task, bool continueOnCapturedContext) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7A4624 Offset: 0x7A4624 VA: 0x7A4624
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<bool>..ctor
	|
	|-RVA: 0x7A4698 Offset: 0x7A4698 VA: 0x7A4698
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int>..ctor
	|
	|-RVA: 0x7A470C Offset: 0x7A470C VA: 0x7A470C
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Nullable<int>>..ctor
	|
	|-RVA: 0x7A478C Offset: 0x7A478C VA: 0x7A478C
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>..ctor
	|
	|-RVA: 0x7A4800 Offset: 0x7A4800 VA: 0x7A4800
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<VoidTaskResult>..ctor
	*/

	// RVA: -1 Offset: -1
	public bool get_IsCompleted() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7A4798 Offset: 0x7A4798 VA: 0x7A4798
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<AsyncProtocolResult>.get_IsCompleted
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Stream>.get_IsCompleted
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<WebResponse>.get_IsCompleted
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>.get_IsCompleted
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Task>.get_IsCompleted
	|
	|-RVA: 0x7A4630 Offset: 0x7A4630 VA: 0x7A4630
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<bool>.get_IsCompleted
	|
	|-RVA: 0x7A46A4 Offset: 0x7A46A4 VA: 0x7A46A4
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int>.get_IsCompleted
	|
	|-RVA: 0x7A4718 Offset: 0x7A4718 VA: 0x7A4718
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Nullable<int>>.get_IsCompleted
	|
	|-RVA: 0x7A480C Offset: 0x7A480C VA: 0x7A480C
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<VoidTaskResult>.get_IsCompleted
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void OnCompleted(Action continuation) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7A4638 Offset: 0x7A4638 VA: 0x7A4638
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<bool>.OnCompleted
	|
	|-RVA: 0x7A46AC Offset: 0x7A46AC VA: 0x7A46AC
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int>.OnCompleted
	|
	|-RVA: 0x7A4720 Offset: 0x7A4720 VA: 0x7A4720
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Nullable<int>>.OnCompleted
	|
	|-RVA: 0x7A47A0 Offset: 0x7A47A0 VA: 0x7A47A0
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>.OnCompleted
	|
	|-RVA: 0x7A4814 Offset: 0x7A4814 VA: 0x7A4814
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<VoidTaskResult>.OnCompleted
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public void UnsafeOnCompleted(Action continuation) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7A4664 Offset: 0x7A4664 VA: 0x7A4664
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<bool>.UnsafeOnCompleted
	|
	|-RVA: 0x7A46D8 Offset: 0x7A46D8 VA: 0x7A46D8
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int>.UnsafeOnCompleted
	|
	|-RVA: 0x7A474C Offset: 0x7A474C VA: 0x7A474C
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Nullable<int>>.UnsafeOnCompleted
	|
	|-RVA: 0x7A47CC Offset: 0x7A47CC VA: 0x7A47CC
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>.UnsafeOnCompleted
	|
	|-RVA: 0x7A4840 Offset: 0x7A4840 VA: 0x7A4840
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<VoidTaskResult>.UnsafeOnCompleted
	*/

	// RVA: -1 Offset: -1
	public TResult GetResult() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7A47F8 Offset: 0x7A47F8 VA: 0x7A47F8
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<AsyncProtocolResult>.GetResult
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Stream>.GetResult
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<WebResponse>.GetResult
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>.GetResult
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Task>.GetResult
	|
	|-RVA: 0x7A4778 Offset: 0x7A4778 VA: 0x7A4778
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<Nullable<int>>.GetResult
	|
	|-RVA: 0x7A4690 Offset: 0x7A4690 VA: 0x7A4690
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<bool>.GetResult
	|
	|-RVA: 0x7A4704 Offset: 0x7A4704 VA: 0x7A4704
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int>.GetResult
	|
	|-RVA: 0x7A486C Offset: 0x7A486C VA: 0x7A486C
	|-ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<VoidTaskResult>.GetResult
	*/
}
