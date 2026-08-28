// Namespace: 
private class DependencyGraph.Node<T> : IEquatable<DependencyGraph.Node<T>> // TypeDefIndex: 9657
{
	// Fields
	public readonly T Data; // 0x0
	public List<DependencyGraph.Node<T>> Dependencies; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(T data) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AD418 Offset: 0x14AD418 VA: 0x14AD418
	|-DependencyGraph.Node<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public bool Equals(DependencyGraph.Node<T> other) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AD44C Offset: 0x14AD44C VA: 0x14AD44C
	|-DependencyGraph.Node<object>.Equals
	*/

	// RVA: -1 Offset: -1 Slot: 0
	public override bool Equals(object obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AD4CC Offset: 0x14AD4CC VA: 0x14AD4CC
	|-DependencyGraph.Node<object>.Equals
	*/

	// RVA: -1 Offset: -1 Slot: 2
	public override int GetHashCode() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AD688 Offset: 0x14AD688 VA: 0x14AD688
	|-DependencyGraph.Node<object>.GetHashCode
	*/

	// RVA: -1 Offset: -1
	public static bool op_Equality(DependencyGraph.Node<T> left, DependencyGraph.Node<T> right) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AD6DC Offset: 0x14AD6DC VA: 0x14AD6DC
	|-DependencyGraph.Node<object>.op_Equality
	*/

	// RVA: -1 Offset: -1
	public static bool op_Inequality(DependencyGraph.Node<T> left, DependencyGraph.Node<T> right) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AD6E4 Offset: 0x14AD6E4 VA: 0x14AD6E4
	|-DependencyGraph.Node<object>.op_Inequality
	*/
}
