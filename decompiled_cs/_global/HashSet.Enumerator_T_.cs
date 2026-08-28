// Namespace: 
[Serializable]
public struct HashSet.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator // TypeDefIndex: 2990
{
	// Fields
	private HashSet<T> _set; // 0x0
	private int _index; // 0x0
	private int _version; // 0x0
	private T _current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(HashSet<T> set) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80C8CC Offset: 0x80C8CC VA: 0x80C8CC
	|-HashSet.Enumerator<FVector2>..ctor
	|
	|-RVA: 0x80C93C Offset: 0x80C93C VA: 0x80C93C
	|-HashSet.Enumerator<int>..ctor
	|
	|-RVA: 0x80C99C Offset: 0x80C99C VA: 0x80C99C
	|-HashSet.Enumerator<object>..ctor
	|
	|-RVA: 0x80C9FC Offset: 0x80C9FC VA: 0x80C9FC
	|-HashSet.Enumerator<uint>..ctor
	|
	|-RVA: 0x80CA5C Offset: 0x80CA5C VA: 0x80CA5C
	|-HashSet.Enumerator<ulong>..ctor
	|
	|-RVA: 0x80CABC Offset: 0x80CABC VA: 0x80CABC
	|-HashSet.Enumerator<ValueTuple<int, int, int>>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80C9D8 Offset: 0x80C9D8 VA: 0x80C9D8
	|-HashSet.Enumerator<CameraAgent>.Dispose
	|-HashSet.Enumerator<ParticleEffectMono>.Dispose
	|-HashSet.Enumerator<ILightweightTrigger>.Dispose
	|-HashSet.Enumerator<IDestruction>.Dispose
	|-HashSet.Enumerator<Point>.Dispose
	|-HashSet.Enumerator<Trapezoid>.Dispose
	|-HashSet.Enumerator<Body>.Dispose
	|-HashSet.Enumerator<FarseerJoint>.Dispose
	|-HashSet.Enumerator<ScreenOutlineRenderer.IProjector>.Dispose
	|-HashSet.Enumerator<ScreenThermalImagerRenderer.IProjector>.Dispose
	|-HashSet.Enumerator<LinkedListNode<ParsingEvent>>.Dispose
	|-HashSet.Enumerator<object>.Dispose
	|-HashSet.Enumerator<IClippable>.Dispose
	|-HashSet.Enumerator<Text>.Dispose
	|
	|-RVA: 0x80C90C Offset: 0x80C90C VA: 0x80C90C
	|-HashSet.Enumerator<FVector2>.Dispose
	|
	|-RVA: 0x80C978 Offset: 0x80C978 VA: 0x80C978
	|-HashSet.Enumerator<int>.Dispose
	|
	|-RVA: 0x80CA38 Offset: 0x80CA38 VA: 0x80CA38
	|-HashSet.Enumerator<uint>.Dispose
	|
	|-RVA: 0x80CA98 Offset: 0x80CA98 VA: 0x80CA98
	|-HashSet.Enumerator<ulong>.Dispose
	|
	|-RVA: 0x80CB00 Offset: 0x80CB00 VA: 0x80CB00
	|-HashSet.Enumerator<ValueTuple<int, int, int>>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80C9DC Offset: 0x80C9DC VA: 0x80C9DC
	|-HashSet.Enumerator<CameraAgent>.MoveNext
	|-HashSet.Enumerator<ParticleEffectMono>.MoveNext
	|-HashSet.Enumerator<ILightweightTrigger>.MoveNext
	|-HashSet.Enumerator<IDestruction>.MoveNext
	|-HashSet.Enumerator<Point>.MoveNext
	|-HashSet.Enumerator<Trapezoid>.MoveNext
	|-HashSet.Enumerator<Body>.MoveNext
	|-HashSet.Enumerator<FarseerJoint>.MoveNext
	|-HashSet.Enumerator<ScreenOutlineRenderer.IProjector>.MoveNext
	|-HashSet.Enumerator<ScreenThermalImagerRenderer.IProjector>.MoveNext
	|-HashSet.Enumerator<LinkedListNode<ParsingEvent>>.MoveNext
	|-HashSet.Enumerator<object>.MoveNext
	|-HashSet.Enumerator<IClippable>.MoveNext
	|-HashSet.Enumerator<Text>.MoveNext
	|
	|-RVA: 0x80C910 Offset: 0x80C910 VA: 0x80C910
	|-HashSet.Enumerator<FVector2>.MoveNext
	|
	|-RVA: 0x80C97C Offset: 0x80C97C VA: 0x80C97C
	|-HashSet.Enumerator<int>.MoveNext
	|
	|-RVA: 0x80CA3C Offset: 0x80CA3C VA: 0x80CA3C
	|-HashSet.Enumerator<uint>.MoveNext
	|
	|-RVA: 0x80CA9C Offset: 0x80CA9C VA: 0x80CA9C
	|-HashSet.Enumerator<ulong>.MoveNext
	|
	|-RVA: 0x80CB04 Offset: 0x80CB04 VA: 0x80CB04
	|-HashSet.Enumerator<ValueTuple<int, int, int>>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80C9E4 Offset: 0x80C9E4 VA: 0x80C9E4
	|-HashSet.Enumerator<CameraAgent>.get_Current
	|-HashSet.Enumerator<ParticleEffectMono>.get_Current
	|-HashSet.Enumerator<ILightweightTrigger>.get_Current
	|-HashSet.Enumerator<IDestruction>.get_Current
	|-HashSet.Enumerator<Point>.get_Current
	|-HashSet.Enumerator<Trapezoid>.get_Current
	|-HashSet.Enumerator<Body>.get_Current
	|-HashSet.Enumerator<FarseerJoint>.get_Current
	|-HashSet.Enumerator<ScreenOutlineRenderer.IProjector>.get_Current
	|-HashSet.Enumerator<ScreenThermalImagerRenderer.IProjector>.get_Current
	|-HashSet.Enumerator<LinkedListNode<ParsingEvent>>.get_Current
	|-HashSet.Enumerator<IClippable>.get_Current
	|-HashSet.Enumerator<Text>.get_Current
	|-HashSet.Enumerator<object>.get_Current
	|
	|-RVA: 0x80C918 Offset: 0x80C918 VA: 0x80C918
	|-HashSet.Enumerator<FVector2>.get_Current
	|
	|-RVA: 0x80C984 Offset: 0x80C984 VA: 0x80C984
	|-HashSet.Enumerator<int>.get_Current
	|
	|-RVA: 0x80CB0C Offset: 0x80CB0C VA: 0x80CB0C
	|-HashSet.Enumerator<ValueTuple<int, int, int>>.get_Current
	|
	|-RVA: 0x80CA44 Offset: 0x80CA44 VA: 0x80CA44
	|-HashSet.Enumerator<uint>.get_Current
	|
	|-RVA: 0x80CAA4 Offset: 0x80CAA4 VA: 0x80CAA4
	|-HashSet.Enumerator<ulong>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80C92C Offset: 0x80C92C VA: 0x80C92C
	|-HashSet.Enumerator<FVector2>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80C98C Offset: 0x80C98C VA: 0x80C98C
	|-HashSet.Enumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80C9EC Offset: 0x80C9EC VA: 0x80C9EC
	|-HashSet.Enumerator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CA4C Offset: 0x80CA4C VA: 0x80CA4C
	|-HashSet.Enumerator<uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CAAC Offset: 0x80CAAC VA: 0x80CAAC
	|-HashSet.Enumerator<ulong>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CB20 Offset: 0x80CB20 VA: 0x80CB20
	|-HashSet.Enumerator<ValueTuple<int, int, int>>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80C934 Offset: 0x80C934 VA: 0x80C934
	|-HashSet.Enumerator<FVector2>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80C994 Offset: 0x80C994 VA: 0x80C994
	|-HashSet.Enumerator<int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80C9F4 Offset: 0x80C9F4 VA: 0x80C9F4
	|-HashSet.Enumerator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CA54 Offset: 0x80CA54 VA: 0x80CA54
	|-HashSet.Enumerator<uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CAB4 Offset: 0x80CAB4 VA: 0x80CAB4
	|-HashSet.Enumerator<ulong>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CB28 Offset: 0x80CB28 VA: 0x80CB28
	|-HashSet.Enumerator<ValueTuple<int, int, int>>.System.Collections.IEnumerator.Reset
	*/
}
