// Namespace: 
[Serializable]
public struct Queue.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator // TypeDefIndex: 2096
{
	// Fields
	private readonly Queue<T> _q; // 0x0
	private readonly int _version; // 0x0
	private int _index; // 0x0
	private T _currentElement; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(Queue<T> q) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x777D3C Offset: 0x777D3C VA: 0x777D3C
	|-Queue.Enumerator<RoutedEventMessage>..ctor
	|
	|-RVA: 0x777DE8 Offset: 0x777DE8 VA: 0x777DE8
	|-Queue.Enumerator<UnityWebRequestData>..ctor
	|
	|-RVA: 0x777EA4 Offset: 0x777EA4 VA: 0x777EA4
	|-Queue.Enumerator<WriteToFileData>..ctor
	|
	|-RVA: 0x777F50 Offset: 0x777F50 VA: 0x777F50
	|-Queue.Enumerator<LangMonoData>..ctor
	|
	|-RVA: 0x777FD8 Offset: 0x777FD8 VA: 0x777FD8
	|-Queue.Enumerator<RtpcData>..ctor
	|
	|-RVA: 0x77807C Offset: 0x77807C VA: 0x77807C
	|-Queue.Enumerator<SharedGameObjectData>..ctor
	|
	|-RVA: 0x778118 Offset: 0x778118 VA: 0x778118
	|-Queue.Enumerator<SoundEventIDData>..ctor
	|
	|-RVA: 0x7781B4 Offset: 0x7781B4 VA: 0x7781B4
	|-Queue.Enumerator<SwitchData>..ctor
	|
	|-RVA: 0x778258 Offset: 0x778258 VA: 0x778258
	|-Queue.Enumerator<int>..ctor
	|
	|-RVA: 0x7782E0 Offset: 0x7782E0 VA: 0x7782E0
	|-Queue.Enumerator<object>..ctor
	|
	|-RVA: 0x778368 Offset: 0x778368 VA: 0x778368
	|-Queue.Enumerator<ValueTuple<float, float>>..ctor
	|
	|-RVA: 0x778404 Offset: 0x778404 VA: 0x778404
	|-Queue.Enumerator<Vector2>..ctor
	|
	|-RVA: 0x7784A0 Offset: 0x7784A0 VA: 0x7784A0
	|-Queue.Enumerator<LuaEnv.GCAction>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x778320 Offset: 0x778320 VA: 0x778320
	|-Queue.Enumerator<ILoadStage>.Dispose
	|-Queue.Enumerator<Action>.Dispose
	|-Queue.Enumerator<ITextEntity>.Dispose
	|-Queue.Enumerator<object>.Dispose
	|-Queue.Enumerator<GameObject>.Dispose
	|-Queue.Enumerator<ParsingEvent>.Dispose
	|
	|-RVA: 0x777D88 Offset: 0x777D88 VA: 0x777D88
	|-Queue.Enumerator<RoutedEventMessage>.Dispose
	|
	|-RVA: 0x777E3C Offset: 0x777E3C VA: 0x777E3C
	|-Queue.Enumerator<UnityWebRequestData>.Dispose
	|
	|-RVA: 0x777EF0 Offset: 0x777EF0 VA: 0x777EF0
	|-Queue.Enumerator<WriteToFileData>.Dispose
	|
	|-RVA: 0x777F90 Offset: 0x777F90 VA: 0x777F90
	|-Queue.Enumerator<LangMonoData>.Dispose
	|
	|-RVA: 0x778020 Offset: 0x778020 VA: 0x778020
	|-Queue.Enumerator<RtpcData>.Dispose
	|
	|-RVA: 0x7780C0 Offset: 0x7780C0 VA: 0x7780C0
	|-Queue.Enumerator<SharedGameObjectData>.Dispose
	|
	|-RVA: 0x77815C Offset: 0x77815C VA: 0x77815C
	|-Queue.Enumerator<SoundEventIDData>.Dispose
	|
	|-RVA: 0x7781FC Offset: 0x7781FC VA: 0x7781FC
	|-Queue.Enumerator<SwitchData>.Dispose
	|
	|-RVA: 0x778298 Offset: 0x778298 VA: 0x778298
	|-Queue.Enumerator<int>.Dispose
	|
	|-RVA: 0x7783AC Offset: 0x7783AC VA: 0x7783AC
	|-Queue.Enumerator<ValueTuple<float, float>>.Dispose
	|
	|-RVA: 0x778448 Offset: 0x778448 VA: 0x778448
	|-Queue.Enumerator<Vector2>.Dispose
	|
	|-RVA: 0x7784E4 Offset: 0x7784E4 VA: 0x7784E4
	|-Queue.Enumerator<LuaEnv.GCAction>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x778334 Offset: 0x778334 VA: 0x778334
	|-Queue.Enumerator<ILoadStage>.MoveNext
	|-Queue.Enumerator<Action>.MoveNext
	|-Queue.Enumerator<ITextEntity>.MoveNext
	|-Queue.Enumerator<object>.MoveNext
	|-Queue.Enumerator<GameObject>.MoveNext
	|-Queue.Enumerator<ParsingEvent>.MoveNext
	|
	|-RVA: 0x777DA8 Offset: 0x777DA8 VA: 0x777DA8
	|-Queue.Enumerator<RoutedEventMessage>.MoveNext
	|
	|-RVA: 0x777E64 Offset: 0x777E64 VA: 0x777E64
	|-Queue.Enumerator<UnityWebRequestData>.MoveNext
	|
	|-RVA: 0x777F10 Offset: 0x777F10 VA: 0x777F10
	|-Queue.Enumerator<WriteToFileData>.MoveNext
	|
	|-RVA: 0x777FA4 Offset: 0x777FA4 VA: 0x777FA4
	|-Queue.Enumerator<LangMonoData>.MoveNext
	|
	|-RVA: 0x77803C Offset: 0x77803C VA: 0x77803C
	|-Queue.Enumerator<RtpcData>.MoveNext
	|
	|-RVA: 0x7780D8 Offset: 0x7780D8 VA: 0x7780D8
	|-Queue.Enumerator<SharedGameObjectData>.MoveNext
	|
	|-RVA: 0x778174 Offset: 0x778174 VA: 0x778174
	|-Queue.Enumerator<SoundEventIDData>.MoveNext
	|
	|-RVA: 0x778218 Offset: 0x778218 VA: 0x778218
	|-Queue.Enumerator<SwitchData>.MoveNext
	|
	|-RVA: 0x7782AC Offset: 0x7782AC VA: 0x7782AC
	|-Queue.Enumerator<int>.MoveNext
	|
	|-RVA: 0x7783C4 Offset: 0x7783C4 VA: 0x7783C4
	|-Queue.Enumerator<ValueTuple<float, float>>.MoveNext
	|
	|-RVA: 0x778460 Offset: 0x778460 VA: 0x778460
	|-Queue.Enumerator<Vector2>.MoveNext
	|
	|-RVA: 0x7784FC Offset: 0x7784FC VA: 0x7784FC
	|-Queue.Enumerator<LuaEnv.GCAction>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x77833C Offset: 0x77833C VA: 0x77833C
	|-Queue.Enumerator<ILoadStage>.get_Current
	|-Queue.Enumerator<Action>.get_Current
	|-Queue.Enumerator<ITextEntity>.get_Current
	|-Queue.Enumerator<GameObject>.get_Current
	|-Queue.Enumerator<ParsingEvent>.get_Current
	|-Queue.Enumerator<object>.get_Current
	|
	|-RVA: 0x777DB0 Offset: 0x777DB0 VA: 0x777DB0
	|-Queue.Enumerator<RoutedEventMessage>.get_Current
	|
	|-RVA: 0x777E6C Offset: 0x777E6C VA: 0x777E6C
	|-Queue.Enumerator<UnityWebRequestData>.get_Current
	|
	|-RVA: 0x777F18 Offset: 0x777F18 VA: 0x777F18
	|-Queue.Enumerator<WriteToFileData>.get_Current
	|
	|-RVA: 0x777FAC Offset: 0x777FAC VA: 0x777FAC
	|-Queue.Enumerator<LangMonoData>.get_Current
	|
	|-RVA: 0x778044 Offset: 0x778044 VA: 0x778044
	|-Queue.Enumerator<RtpcData>.get_Current
	|
	|-RVA: 0x7780E0 Offset: 0x7780E0 VA: 0x7780E0
	|-Queue.Enumerator<SharedGameObjectData>.get_Current
	|
	|-RVA: 0x77817C Offset: 0x77817C VA: 0x77817C
	|-Queue.Enumerator<SoundEventIDData>.get_Current
	|
	|-RVA: 0x778220 Offset: 0x778220 VA: 0x778220
	|-Queue.Enumerator<SwitchData>.get_Current
	|
	|-RVA: 0x7782B4 Offset: 0x7782B4 VA: 0x7782B4
	|-Queue.Enumerator<int>.get_Current
	|
	|-RVA: 0x7783CC Offset: 0x7783CC VA: 0x7783CC
	|-Queue.Enumerator<ValueTuple<float, float>>.get_Current
	|
	|-RVA: 0x778468 Offset: 0x778468 VA: 0x778468
	|-Queue.Enumerator<Vector2>.get_Current
	|
	|-RVA: 0x778504 Offset: 0x778504 VA: 0x778504
	|-Queue.Enumerator<LuaEnv.GCAction>.get_Current
	*/

	// RVA: -1 Offset: -1
	private void ThrowEnumerationNotStartedOrEnded() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x777DC4 Offset: 0x777DC4 VA: 0x777DC4
	|-Queue.Enumerator<RoutedEventMessage>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x777E80 Offset: 0x777E80 VA: 0x777E80
	|-Queue.Enumerator<UnityWebRequestData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x777F2C Offset: 0x777F2C VA: 0x777F2C
	|-Queue.Enumerator<WriteToFileData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x777FB4 Offset: 0x777FB4 VA: 0x777FB4
	|-Queue.Enumerator<LangMonoData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x778058 Offset: 0x778058 VA: 0x778058
	|-Queue.Enumerator<RtpcData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x7780F4 Offset: 0x7780F4 VA: 0x7780F4
	|-Queue.Enumerator<SharedGameObjectData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x778190 Offset: 0x778190 VA: 0x778190
	|-Queue.Enumerator<SoundEventIDData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x778234 Offset: 0x778234 VA: 0x778234
	|-Queue.Enumerator<SwitchData>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x7782BC Offset: 0x7782BC VA: 0x7782BC
	|-Queue.Enumerator<int>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x778344 Offset: 0x778344 VA: 0x778344
	|-Queue.Enumerator<object>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x7783E0 Offset: 0x7783E0 VA: 0x7783E0
	|-Queue.Enumerator<ValueTuple<float, float>>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x77847C Offset: 0x77847C VA: 0x77847C
	|-Queue.Enumerator<Vector2>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x778518 Offset: 0x778518 VA: 0x778518
	|-Queue.Enumerator<LuaEnv.GCAction>.ThrowEnumerationNotStartedOrEnded
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x777DD8 Offset: 0x777DD8 VA: 0x777DD8
	|-Queue.Enumerator<RoutedEventMessage>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777E94 Offset: 0x777E94 VA: 0x777E94
	|-Queue.Enumerator<UnityWebRequestData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777F40 Offset: 0x777F40 VA: 0x777F40
	|-Queue.Enumerator<WriteToFileData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777FC8 Offset: 0x777FC8 VA: 0x777FC8
	|-Queue.Enumerator<LangMonoData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x77806C Offset: 0x77806C VA: 0x77806C
	|-Queue.Enumerator<RtpcData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x778108 Offset: 0x778108 VA: 0x778108
	|-Queue.Enumerator<SharedGameObjectData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7781A4 Offset: 0x7781A4 VA: 0x7781A4
	|-Queue.Enumerator<SoundEventIDData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x778248 Offset: 0x778248 VA: 0x778248
	|-Queue.Enumerator<SwitchData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7782D0 Offset: 0x7782D0 VA: 0x7782D0
	|-Queue.Enumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x778358 Offset: 0x778358 VA: 0x778358
	|-Queue.Enumerator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7783F4 Offset: 0x7783F4 VA: 0x7783F4
	|-Queue.Enumerator<ValueTuple<float, float>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x778490 Offset: 0x778490 VA: 0x778490
	|-Queue.Enumerator<Vector2>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x77852C Offset: 0x77852C VA: 0x77852C
	|-Queue.Enumerator<LuaEnv.GCAction>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x777DE0 Offset: 0x777DE0 VA: 0x777DE0
	|-Queue.Enumerator<RoutedEventMessage>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x777E9C Offset: 0x777E9C VA: 0x777E9C
	|-Queue.Enumerator<UnityWebRequestData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x777F48 Offset: 0x777F48 VA: 0x777F48
	|-Queue.Enumerator<WriteToFileData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x777FD0 Offset: 0x777FD0 VA: 0x777FD0
	|-Queue.Enumerator<LangMonoData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x778074 Offset: 0x778074 VA: 0x778074
	|-Queue.Enumerator<RtpcData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x778110 Offset: 0x778110 VA: 0x778110
	|-Queue.Enumerator<SharedGameObjectData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7781AC Offset: 0x7781AC VA: 0x7781AC
	|-Queue.Enumerator<SoundEventIDData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x778250 Offset: 0x778250 VA: 0x778250
	|-Queue.Enumerator<SwitchData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7782D8 Offset: 0x7782D8 VA: 0x7782D8
	|-Queue.Enumerator<int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x778360 Offset: 0x778360 VA: 0x778360
	|-Queue.Enumerator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7783FC Offset: 0x7783FC VA: 0x7783FC
	|-Queue.Enumerator<ValueTuple<float, float>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x778498 Offset: 0x778498 VA: 0x778498
	|-Queue.Enumerator<Vector2>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x778534 Offset: 0x778534 VA: 0x778534
	|-Queue.Enumerator<LuaEnv.GCAction>.System.Collections.IEnumerator.Reset
	*/
}
