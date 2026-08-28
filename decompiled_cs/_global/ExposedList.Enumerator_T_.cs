// Namespace: 
public struct ExposedList.Enumerator<T> : IEnumerator<T>, IEnumerator, IDisposable // TypeDefIndex: 7183
{
	// Fields
	private ExposedList<T> l; // 0x0
	private int next; // 0x0
	private int ver; // 0x0
	private T current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(ExposedList<T> l) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CD88 Offset: 0x80CD88 VA: 0x80CD88
	|-ExposedList.Enumerator<SubmeshInstruction>..ctor
	|
	|-RVA: 0x80CE20 Offset: 0x80CE20 VA: 0x80CE20
	|-ExposedList.Enumerator<bool>..ctor
	|
	|-RVA: 0x80CE94 Offset: 0x80CE94 VA: 0x80CE94
	|-ExposedList.Enumerator<int>..ctor
	|
	|-RVA: 0x80CF08 Offset: 0x80CF08 VA: 0x80CF08
	|-ExposedList.Enumerator<object>..ctor
	|
	|-RVA: 0x80CF7C Offset: 0x80CF7C VA: 0x80CF7C
	|-ExposedList.Enumerator<float>..ctor
	|
	|-RVA: 0x80CFF0 Offset: 0x80CFF0 VA: 0x80CFF0
	|-ExposedList.Enumerator<Color32>..ctor
	|
	|-RVA: 0x80D064 Offset: 0x80D064 VA: 0x80D064
	|-ExposedList.Enumerator<Vector2>..ctor
	|
	|-RVA: 0x80D0E0 Offset: 0x80D0E0 VA: 0x80D0E0
	|-ExposedList.Enumerator<Vector3>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CF48 Offset: 0x80CF48 VA: 0x80CF48
	|-ExposedList.Enumerator<Animation>.Dispose
	|-ExposedList.Enumerator<Bone>.Dispose
	|-ExposedList.Enumerator<BoneData>.Dispose
	|-ExposedList.Enumerator<EventData>.Dispose
	|-ExposedList.Enumerator<ExposedList<float>>.Dispose
	|-ExposedList.Enumerator<IkConstraintData>.Dispose
	|-ExposedList.Enumerator<PathConstraintData>.Dispose
	|-ExposedList.Enumerator<Skin>.Dispose
	|-ExposedList.Enumerator<Slot>.Dispose
	|-ExposedList.Enumerator<SlotData>.Dispose
	|-ExposedList.Enumerator<Timeline>.Dispose
	|-ExposedList.Enumerator<TransformConstraintData>.Dispose
	|-ExposedList.Enumerator<object>.Dispose
	|
	|-RVA: 0x80CDD4 Offset: 0x80CDD4 VA: 0x80CDD4
	|-ExposedList.Enumerator<SubmeshInstruction>.Dispose
	|
	|-RVA: 0x80CE60 Offset: 0x80CE60 VA: 0x80CE60
	|-ExposedList.Enumerator<bool>.Dispose
	|
	|-RVA: 0x80CED4 Offset: 0x80CED4 VA: 0x80CED4
	|-ExposedList.Enumerator<int>.Dispose
	|
	|-RVA: 0x80CFBC Offset: 0x80CFBC VA: 0x80CFBC
	|-ExposedList.Enumerator<float>.Dispose
	|
	|-RVA: 0x80D030 Offset: 0x80D030 VA: 0x80D030
	|-ExposedList.Enumerator<Color32>.Dispose
	|
	|-RVA: 0x80D0A0 Offset: 0x80D0A0 VA: 0x80D0A0
	|-ExposedList.Enumerator<Vector2>.Dispose
	|
	|-RVA: 0x80D124 Offset: 0x80D124 VA: 0x80D124
	|-ExposedList.Enumerator<Vector3>.Dispose
	*/

	// RVA: -1 Offset: -1
	private void VerifyState() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CDE0 Offset: 0x80CDE0 VA: 0x80CDE0
	|-ExposedList.Enumerator<SubmeshInstruction>.VerifyState
	|
	|-RVA: 0x80CE6C Offset: 0x80CE6C VA: 0x80CE6C
	|-ExposedList.Enumerator<bool>.VerifyState
	|
	|-RVA: 0x80CEE0 Offset: 0x80CEE0 VA: 0x80CEE0
	|-ExposedList.Enumerator<int>.VerifyState
	|
	|-RVA: 0x80CF54 Offset: 0x80CF54 VA: 0x80CF54
	|-ExposedList.Enumerator<object>.VerifyState
	|
	|-RVA: 0x80CFC8 Offset: 0x80CFC8 VA: 0x80CFC8
	|-ExposedList.Enumerator<float>.VerifyState
	|
	|-RVA: 0x80D03C Offset: 0x80D03C VA: 0x80D03C
	|-ExposedList.Enumerator<Color32>.VerifyState
	|
	|-RVA: 0x80D0AC Offset: 0x80D0AC VA: 0x80D0AC
	|-ExposedList.Enumerator<Vector2>.VerifyState
	|
	|-RVA: 0x80D130 Offset: 0x80D130 VA: 0x80D130
	|-ExposedList.Enumerator<Vector3>.VerifyState
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CF5C Offset: 0x80CF5C VA: 0x80CF5C
	|-ExposedList.Enumerator<Animation>.MoveNext
	|-ExposedList.Enumerator<Bone>.MoveNext
	|-ExposedList.Enumerator<BoneData>.MoveNext
	|-ExposedList.Enumerator<EventData>.MoveNext
	|-ExposedList.Enumerator<ExposedList<float>>.MoveNext
	|-ExposedList.Enumerator<IkConstraintData>.MoveNext
	|-ExposedList.Enumerator<PathConstraintData>.MoveNext
	|-ExposedList.Enumerator<Skin>.MoveNext
	|-ExposedList.Enumerator<Slot>.MoveNext
	|-ExposedList.Enumerator<SlotData>.MoveNext
	|-ExposedList.Enumerator<Timeline>.MoveNext
	|-ExposedList.Enumerator<TransformConstraintData>.MoveNext
	|-ExposedList.Enumerator<object>.MoveNext
	|
	|-RVA: 0x80CDE8 Offset: 0x80CDE8 VA: 0x80CDE8
	|-ExposedList.Enumerator<SubmeshInstruction>.MoveNext
	|
	|-RVA: 0x80CE74 Offset: 0x80CE74 VA: 0x80CE74
	|-ExposedList.Enumerator<bool>.MoveNext
	|
	|-RVA: 0x80CEE8 Offset: 0x80CEE8 VA: 0x80CEE8
	|-ExposedList.Enumerator<int>.MoveNext
	|
	|-RVA: 0x80CFD0 Offset: 0x80CFD0 VA: 0x80CFD0
	|-ExposedList.Enumerator<float>.MoveNext
	|
	|-RVA: 0x80D044 Offset: 0x80D044 VA: 0x80D044
	|-ExposedList.Enumerator<Color32>.MoveNext
	|
	|-RVA: 0x80D0B4 Offset: 0x80D0B4 VA: 0x80D0B4
	|-ExposedList.Enumerator<Vector2>.MoveNext
	|
	|-RVA: 0x80D138 Offset: 0x80D138 VA: 0x80D138
	|-ExposedList.Enumerator<Vector3>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CF64 Offset: 0x80CF64 VA: 0x80CF64
	|-ExposedList.Enumerator<Animation>.get_Current
	|-ExposedList.Enumerator<Bone>.get_Current
	|-ExposedList.Enumerator<BoneData>.get_Current
	|-ExposedList.Enumerator<EventData>.get_Current
	|-ExposedList.Enumerator<ExposedList<float>>.get_Current
	|-ExposedList.Enumerator<IkConstraintData>.get_Current
	|-ExposedList.Enumerator<PathConstraintData>.get_Current
	|-ExposedList.Enumerator<Skin>.get_Current
	|-ExposedList.Enumerator<Slot>.get_Current
	|-ExposedList.Enumerator<SlotData>.get_Current
	|-ExposedList.Enumerator<Timeline>.get_Current
	|-ExposedList.Enumerator<TransformConstraintData>.get_Current
	|-ExposedList.Enumerator<object>.get_Current
	|
	|-RVA: 0x80CDF0 Offset: 0x80CDF0 VA: 0x80CDF0
	|-ExposedList.Enumerator<SubmeshInstruction>.get_Current
	|
	|-RVA: 0x80CE7C Offset: 0x80CE7C VA: 0x80CE7C
	|-ExposedList.Enumerator<bool>.get_Current
	|
	|-RVA: 0x80CEF0 Offset: 0x80CEF0 VA: 0x80CEF0
	|-ExposedList.Enumerator<int>.get_Current
	|
	|-RVA: 0x80CFD8 Offset: 0x80CFD8 VA: 0x80CFD8
	|-ExposedList.Enumerator<float>.get_Current
	|
	|-RVA: 0x80D04C Offset: 0x80D04C VA: 0x80D04C
	|-ExposedList.Enumerator<Color32>.get_Current
	|
	|-RVA: 0x80D0BC Offset: 0x80D0BC VA: 0x80D0BC
	|-ExposedList.Enumerator<Vector2>.get_Current
	|
	|-RVA: 0x80D140 Offset: 0x80D140 VA: 0x80D140
	|-ExposedList.Enumerator<Vector3>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CE10 Offset: 0x80CE10 VA: 0x80CE10
	|-ExposedList.Enumerator<SubmeshInstruction>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CE84 Offset: 0x80CE84 VA: 0x80CE84
	|-ExposedList.Enumerator<bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CEF8 Offset: 0x80CEF8 VA: 0x80CEF8
	|-ExposedList.Enumerator<int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CF6C Offset: 0x80CF6C VA: 0x80CF6C
	|-ExposedList.Enumerator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CFE0 Offset: 0x80CFE0 VA: 0x80CFE0
	|-ExposedList.Enumerator<float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80D054 Offset: 0x80D054 VA: 0x80D054
	|-ExposedList.Enumerator<Color32>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80D0D0 Offset: 0x80D0D0 VA: 0x80D0D0
	|-ExposedList.Enumerator<Vector2>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80D154 Offset: 0x80D154 VA: 0x80D154
	|-ExposedList.Enumerator<Vector3>.System.Collections.IEnumerator.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CE18 Offset: 0x80CE18 VA: 0x80CE18
	|-ExposedList.Enumerator<SubmeshInstruction>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CE8C Offset: 0x80CE8C VA: 0x80CE8C
	|-ExposedList.Enumerator<bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CF00 Offset: 0x80CF00 VA: 0x80CF00
	|-ExposedList.Enumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CF74 Offset: 0x80CF74 VA: 0x80CF74
	|-ExposedList.Enumerator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CFE8 Offset: 0x80CFE8 VA: 0x80CFE8
	|-ExposedList.Enumerator<float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80D05C Offset: 0x80D05C VA: 0x80D05C
	|-ExposedList.Enumerator<Color32>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80D0D8 Offset: 0x80D0D8 VA: 0x80D0D8
	|-ExposedList.Enumerator<Vector2>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80D15C Offset: 0x80D15C VA: 0x80D15C
	|-ExposedList.Enumerator<Vector3>.System.Collections.IEnumerator.get_Current
	*/
}
