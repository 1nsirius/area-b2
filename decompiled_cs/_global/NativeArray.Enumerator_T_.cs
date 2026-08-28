// Namespace: 
[ExcludeFromDocsAttribute] // RVA: 0x4F72F4 Offset: 0x4F72F4 VA: 0x4F72F4
public struct NativeArray.Enumerator<T> : IEnumerator<T>, IEnumerator, IDisposable // TypeDefIndex: 3518
{
	// Fields
	private NativeArray<T> m_Array; // 0x0
	private int m_Index; // 0x0

	// Properties
	private object System.Collections.IEnumerator.Current { get; }
	public T Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(ref NativeArray<T> array) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x777158 Offset: 0x777158 VA: 0x777158
	|-NativeArray.Enumerator<BoneState>..ctor
	|
	|-RVA: 0x7771DC Offset: 0x7771DC VA: 0x7771DC
	|-NativeArray.Enumerator<RagdollState>..ctor
	|
	|-RVA: 0x77724C Offset: 0x77724C VA: 0x77724C
	|-NativeArray.Enumerator<WallAsset_Job.Block>..ctor
	|
	|-RVA: 0x7772D0 Offset: 0x7772D0 VA: 0x7772D0
	|-NativeArray.Enumerator<WallAsset_Job.Edge>..ctor
	|
	|-RVA: 0x77734C Offset: 0x77734C VA: 0x77734C
	|-NativeArray.Enumerator<int>..ctor
	|
	|-RVA: 0x7773B4 Offset: 0x7773B4 VA: 0x7773B4
	|-NativeArray.Enumerator<float>..ctor
	|
	|-RVA: 0x77741C Offset: 0x77741C VA: 0x77741C
	|-NativeArray.Enumerator<Bounds>..ctor
	|
	|-RVA: 0x777498 Offset: 0x777498 VA: 0x777498
	|-NativeArray.Enumerator<Color32>..ctor
	|
	|-RVA: 0x777500 Offset: 0x777500 VA: 0x777500
	|-NativeArray.Enumerator<TransformSceneHandle>..ctor
	|
	|-RVA: 0x777570 Offset: 0x777570 VA: 0x777570
	|-NativeArray.Enumerator<TransformStreamHandle>..ctor
	|
	|-RVA: 0x7775EC Offset: 0x7775EC VA: 0x7775EC
	|-NativeArray.Enumerator<Ray>..ctor
	|
	|-RVA: 0x777668 Offset: 0x777668 VA: 0x777668
	|-NativeArray.Enumerator<RaycastCommand>..ctor
	|
	|-RVA: 0x7776EC Offset: 0x7776EC VA: 0x7776EC
	|-NativeArray.Enumerator<RaycastHit>..ctor
	|
	|-RVA: 0x777770 Offset: 0x777770 VA: 0x777770
	|-NativeArray.Enumerator<Vector2>..ctor
	|
	|-RVA: 0x7777E0 Offset: 0x7777E0 VA: 0x7777E0
	|-NativeArray.Enumerator<Vector3>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x777178 Offset: 0x777178 VA: 0x777178
	|-NativeArray.Enumerator<BoneState>.Dispose
	|
	|-RVA: 0x7771FC Offset: 0x7771FC VA: 0x7771FC
	|-NativeArray.Enumerator<RagdollState>.Dispose
	|
	|-RVA: 0x77726C Offset: 0x77726C VA: 0x77726C
	|-NativeArray.Enumerator<WallAsset_Job.Block>.Dispose
	|
	|-RVA: 0x7772F0 Offset: 0x7772F0 VA: 0x7772F0
	|-NativeArray.Enumerator<WallAsset_Job.Edge>.Dispose
	|
	|-RVA: 0x77736C Offset: 0x77736C VA: 0x77736C
	|-NativeArray.Enumerator<int>.Dispose
	|
	|-RVA: 0x7773D4 Offset: 0x7773D4 VA: 0x7773D4
	|-NativeArray.Enumerator<float>.Dispose
	|
	|-RVA: 0x77743C Offset: 0x77743C VA: 0x77743C
	|-NativeArray.Enumerator<Bounds>.Dispose
	|
	|-RVA: 0x7774B8 Offset: 0x7774B8 VA: 0x7774B8
	|-NativeArray.Enumerator<Color32>.Dispose
	|
	|-RVA: 0x777520 Offset: 0x777520 VA: 0x777520
	|-NativeArray.Enumerator<TransformSceneHandle>.Dispose
	|
	|-RVA: 0x777590 Offset: 0x777590 VA: 0x777590
	|-NativeArray.Enumerator<TransformStreamHandle>.Dispose
	|
	|-RVA: 0x77760C Offset: 0x77760C VA: 0x77760C
	|-NativeArray.Enumerator<Ray>.Dispose
	|
	|-RVA: 0x777688 Offset: 0x777688 VA: 0x777688
	|-NativeArray.Enumerator<RaycastCommand>.Dispose
	|
	|-RVA: 0x77770C Offset: 0x77770C VA: 0x77770C
	|-NativeArray.Enumerator<RaycastHit>.Dispose
	|
	|-RVA: 0x777790 Offset: 0x777790 VA: 0x777790
	|-NativeArray.Enumerator<Vector2>.Dispose
	|
	|-RVA: 0x777800 Offset: 0x777800 VA: 0x777800
	|-NativeArray.Enumerator<Vector3>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x77717C Offset: 0x77717C VA: 0x77717C
	|-NativeArray.Enumerator<BoneState>.MoveNext
	|
	|-RVA: 0x777200 Offset: 0x777200 VA: 0x777200
	|-NativeArray.Enumerator<RagdollState>.MoveNext
	|
	|-RVA: 0x777270 Offset: 0x777270 VA: 0x777270
	|-NativeArray.Enumerator<WallAsset_Job.Block>.MoveNext
	|
	|-RVA: 0x7772F4 Offset: 0x7772F4 VA: 0x7772F4
	|-NativeArray.Enumerator<WallAsset_Job.Edge>.MoveNext
	|
	|-RVA: 0x777370 Offset: 0x777370 VA: 0x777370
	|-NativeArray.Enumerator<int>.MoveNext
	|
	|-RVA: 0x7773D8 Offset: 0x7773D8 VA: 0x7773D8
	|-NativeArray.Enumerator<float>.MoveNext
	|
	|-RVA: 0x777440 Offset: 0x777440 VA: 0x777440
	|-NativeArray.Enumerator<Bounds>.MoveNext
	|
	|-RVA: 0x7774BC Offset: 0x7774BC VA: 0x7774BC
	|-NativeArray.Enumerator<Color32>.MoveNext
	|
	|-RVA: 0x777524 Offset: 0x777524 VA: 0x777524
	|-NativeArray.Enumerator<TransformSceneHandle>.MoveNext
	|
	|-RVA: 0x777594 Offset: 0x777594 VA: 0x777594
	|-NativeArray.Enumerator<TransformStreamHandle>.MoveNext
	|
	|-RVA: 0x777610 Offset: 0x777610 VA: 0x777610
	|-NativeArray.Enumerator<Ray>.MoveNext
	|
	|-RVA: 0x77768C Offset: 0x77768C VA: 0x77768C
	|-NativeArray.Enumerator<RaycastCommand>.MoveNext
	|
	|-RVA: 0x777710 Offset: 0x777710 VA: 0x777710
	|-NativeArray.Enumerator<RaycastHit>.MoveNext
	|
	|-RVA: 0x777794 Offset: 0x777794 VA: 0x777794
	|-NativeArray.Enumerator<Vector2>.MoveNext
	|
	|-RVA: 0x777804 Offset: 0x777804 VA: 0x777804
	|-NativeArray.Enumerator<Vector3>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 8
	public void Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x77719C Offset: 0x77719C VA: 0x77719C
	|-NativeArray.Enumerator<BoneState>.Reset
	|
	|-RVA: 0x777220 Offset: 0x777220 VA: 0x777220
	|-NativeArray.Enumerator<RagdollState>.Reset
	|
	|-RVA: 0x777290 Offset: 0x777290 VA: 0x777290
	|-NativeArray.Enumerator<WallAsset_Job.Block>.Reset
	|
	|-RVA: 0x777314 Offset: 0x777314 VA: 0x777314
	|-NativeArray.Enumerator<WallAsset_Job.Edge>.Reset
	|
	|-RVA: 0x777390 Offset: 0x777390 VA: 0x777390
	|-NativeArray.Enumerator<int>.Reset
	|
	|-RVA: 0x7773F8 Offset: 0x7773F8 VA: 0x7773F8
	|-NativeArray.Enumerator<float>.Reset
	|
	|-RVA: 0x777460 Offset: 0x777460 VA: 0x777460
	|-NativeArray.Enumerator<Bounds>.Reset
	|
	|-RVA: 0x7774DC Offset: 0x7774DC VA: 0x7774DC
	|-NativeArray.Enumerator<Color32>.Reset
	|
	|-RVA: 0x777544 Offset: 0x777544 VA: 0x777544
	|-NativeArray.Enumerator<TransformSceneHandle>.Reset
	|
	|-RVA: 0x7775B4 Offset: 0x7775B4 VA: 0x7775B4
	|-NativeArray.Enumerator<TransformStreamHandle>.Reset
	|
	|-RVA: 0x777630 Offset: 0x777630 VA: 0x777630
	|-NativeArray.Enumerator<Ray>.Reset
	|
	|-RVA: 0x7776AC Offset: 0x7776AC VA: 0x7776AC
	|-NativeArray.Enumerator<RaycastCommand>.Reset
	|
	|-RVA: 0x777730 Offset: 0x777730 VA: 0x777730
	|-NativeArray.Enumerator<RaycastHit>.Reset
	|
	|-RVA: 0x7777B4 Offset: 0x7777B4 VA: 0x7777B4
	|-NativeArray.Enumerator<Vector2>.Reset
	|
	|-RVA: 0x777824 Offset: 0x777824 VA: 0x777824
	|-NativeArray.Enumerator<Vector3>.Reset
	*/

	[CompilerGeneratedAttribute] // RVA: 0x5064B8 Offset: 0x5064B8 VA: 0x5064B8
	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7771A8 Offset: 0x7771A8 VA: 0x7771A8
	|-NativeArray.Enumerator<BoneState>.get_Current
	|
	|-RVA: 0x77722C Offset: 0x77722C VA: 0x77722C
	|-NativeArray.Enumerator<RagdollState>.get_Current
	|
	|-RVA: 0x77729C Offset: 0x77729C VA: 0x77729C
	|-NativeArray.Enumerator<WallAsset_Job.Block>.get_Current
	|
	|-RVA: 0x777320 Offset: 0x777320 VA: 0x777320
	|-NativeArray.Enumerator<WallAsset_Job.Edge>.get_Current
	|
	|-RVA: 0x77739C Offset: 0x77739C VA: 0x77739C
	|-NativeArray.Enumerator<int>.get_Current
	|
	|-RVA: 0x777404 Offset: 0x777404 VA: 0x777404
	|-NativeArray.Enumerator<float>.get_Current
	|
	|-RVA: 0x77746C Offset: 0x77746C VA: 0x77746C
	|-NativeArray.Enumerator<Bounds>.get_Current
	|
	|-RVA: 0x7774E8 Offset: 0x7774E8 VA: 0x7774E8
	|-NativeArray.Enumerator<Color32>.get_Current
	|
	|-RVA: 0x777550 Offset: 0x777550 VA: 0x777550
	|-NativeArray.Enumerator<TransformSceneHandle>.get_Current
	|
	|-RVA: 0x7775C0 Offset: 0x7775C0 VA: 0x7775C0
	|-NativeArray.Enumerator<TransformStreamHandle>.get_Current
	|
	|-RVA: 0x77763C Offset: 0x77763C VA: 0x77763C
	|-NativeArray.Enumerator<Ray>.get_Current
	|
	|-RVA: 0x7776B8 Offset: 0x7776B8 VA: 0x7776B8
	|-NativeArray.Enumerator<RaycastCommand>.get_Current
	|
	|-RVA: 0x77773C Offset: 0x77773C VA: 0x77773C
	|-NativeArray.Enumerator<RaycastHit>.get_Current
	|
	|-RVA: 0x7777C0 Offset: 0x7777C0 VA: 0x7777C0
	|-NativeArray.Enumerator<Vector2>.get_Current
	|
	|-RVA: 0x777830 Offset: 0x777830 VA: 0x777830
	|-NativeArray.Enumerator<Vector3>.get_Current
	*/

	[CompilerGeneratedAttribute] // RVA: 0x5064C8 Offset: 0x5064C8 VA: 0x5064C8
	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7771D4 Offset: 0x7771D4 VA: 0x7771D4
	|-NativeArray.Enumerator<BoneState>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777244 Offset: 0x777244 VA: 0x777244
	|-NativeArray.Enumerator<RagdollState>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7772C8 Offset: 0x7772C8 VA: 0x7772C8
	|-NativeArray.Enumerator<WallAsset_Job.Block>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777344 Offset: 0x777344 VA: 0x777344
	|-NativeArray.Enumerator<WallAsset_Job.Edge>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7773AC Offset: 0x7773AC VA: 0x7773AC
	|-NativeArray.Enumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777414 Offset: 0x777414 VA: 0x777414
	|-NativeArray.Enumerator<float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777490 Offset: 0x777490 VA: 0x777490
	|-NativeArray.Enumerator<Bounds>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7774F8 Offset: 0x7774F8 VA: 0x7774F8
	|-NativeArray.Enumerator<Color32>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777568 Offset: 0x777568 VA: 0x777568
	|-NativeArray.Enumerator<TransformSceneHandle>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7775E4 Offset: 0x7775E4 VA: 0x7775E4
	|-NativeArray.Enumerator<TransformStreamHandle>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777660 Offset: 0x777660 VA: 0x777660
	|-NativeArray.Enumerator<Ray>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7776E4 Offset: 0x7776E4 VA: 0x7776E4
	|-NativeArray.Enumerator<RaycastCommand>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777768 Offset: 0x777768 VA: 0x777768
	|-NativeArray.Enumerator<RaycastHit>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7777D8 Offset: 0x7777D8 VA: 0x7777D8
	|-NativeArray.Enumerator<Vector2>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x777854 Offset: 0x777854 VA: 0x777854
	|-NativeArray.Enumerator<Vector3>.System.Collections.IEnumerator.get_Current
	*/
}
