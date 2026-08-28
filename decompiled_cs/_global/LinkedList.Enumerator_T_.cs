// Namespace: 
[Serializable]
public struct LinkedList.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator, ISerializable, IDeserializationCallback // TypeDefIndex: 2093
{
	// Fields
	private LinkedList<T> _list; // 0x0
	private LinkedListNode<T> _node; // 0x0
	private int _version; // 0x0
	private T _current; // 0x0
	private int _index; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(LinkedList<T> list) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781CB4 Offset: 0x781CB4 VA: 0x781CB4
	|-LinkedList.Enumerator<DelayInvoker.Node>..ctor
	|
	|-RVA: 0x781D24 Offset: 0x781D24 VA: 0x781D24
	|-LinkedList.Enumerator<object>..ctor
	|
	|-RVA: 0x781D88 Offset: 0x781D88 VA: 0x781D88
	|-LinkedList.Enumerator<TSPacketLink.Event>..ctor
	*/

	// RVA: -1 Offset: -1
	private void .ctor(SerializationInfo info, StreamingContext context) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781CBC Offset: 0x781CBC VA: 0x781CBC
	|-LinkedList.Enumerator<DelayInvoker.Node>..ctor
	|
	|-RVA: 0x781D2C Offset: 0x781D2C VA: 0x781D2C
	|-LinkedList.Enumerator<object>..ctor
	|
	|-RVA: 0x781D90 Offset: 0x781D90 VA: 0x781D90
	|-LinkedList.Enumerator<TSPacketLink.Event>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781D40 Offset: 0x781D40 VA: 0x781D40
	|-LinkedList.Enumerator<NaviPathVolume.Outlet>.get_Current
	|-LinkedList.Enumerator<WebConnectionGroup.ConnectionState>.get_Current
	|-LinkedList.Enumerator<object>.get_Current
	|
	|-RVA: 0x781CD0 Offset: 0x781CD0 VA: 0x781CD0
	|-LinkedList.Enumerator<DelayInvoker.Node>.get_Current
	|
	|-RVA: 0x781DA4 Offset: 0x781DA4 VA: 0x781DA4
	|-LinkedList.Enumerator<TSPacketLink.Event>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781CE4 Offset: 0x781CE4 VA: 0x781CE4
	|-LinkedList.Enumerator<DelayInvoker.Node>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x781D48 Offset: 0x781D48 VA: 0x781D48
	|-LinkedList.Enumerator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x781DB4 Offset: 0x781DB4 VA: 0x781DB4
	|-LinkedList.Enumerator<TSPacketLink.Event>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781D50 Offset: 0x781D50 VA: 0x781D50
	|-LinkedList.Enumerator<NaviPathVolume.Outlet>.MoveNext
	|-LinkedList.Enumerator<WebConnectionGroup.ConnectionState>.MoveNext
	|-LinkedList.Enumerator<object>.MoveNext
	|
	|-RVA: 0x781CEC Offset: 0x781CEC VA: 0x781CEC
	|-LinkedList.Enumerator<DelayInvoker.Node>.MoveNext
	|
	|-RVA: 0x781DBC Offset: 0x781DBC VA: 0x781DBC
	|-LinkedList.Enumerator<TSPacketLink.Event>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781CF4 Offset: 0x781CF4 VA: 0x781CF4
	|-LinkedList.Enumerator<DelayInvoker.Node>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x781D58 Offset: 0x781D58 VA: 0x781D58
	|-LinkedList.Enumerator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x781DC4 Offset: 0x781DC4 VA: 0x781DC4
	|-LinkedList.Enumerator<TSPacketLink.Event>.System.Collections.IEnumerator.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781D60 Offset: 0x781D60 VA: 0x781D60
	|-LinkedList.Enumerator<NaviPathVolume.Outlet>.Dispose
	|-LinkedList.Enumerator<WebConnectionGroup.ConnectionState>.Dispose
	|-LinkedList.Enumerator<object>.Dispose
	|
	|-RVA: 0x781CFC Offset: 0x781CFC VA: 0x781CFC
	|-LinkedList.Enumerator<DelayInvoker.Node>.Dispose
	|
	|-RVA: 0x781DCC Offset: 0x781DCC VA: 0x781DCC
	|-LinkedList.Enumerator<TSPacketLink.Event>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 9
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781D00 Offset: 0x781D00 VA: 0x781D00
	|-LinkedList.Enumerator<DelayInvoker.Node>.System.Runtime.Serialization.ISerializable.GetObjectData
	|
	|-RVA: 0x781D64 Offset: 0x781D64 VA: 0x781D64
	|-LinkedList.Enumerator<object>.System.Runtime.Serialization.ISerializable.GetObjectData
	|
	|-RVA: 0x781DD0 Offset: 0x781DD0 VA: 0x781DD0
	|-LinkedList.Enumerator<TSPacketLink.Event>.System.Runtime.Serialization.ISerializable.GetObjectData
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x781D14 Offset: 0x781D14 VA: 0x781D14
	|-LinkedList.Enumerator<DelayInvoker.Node>.System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
	|
	|-RVA: 0x781D78 Offset: 0x781D78 VA: 0x781D78
	|-LinkedList.Enumerator<object>.System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
	|
	|-RVA: 0x781DE4 Offset: 0x781DE4 VA: 0x781DE4
	|-LinkedList.Enumerator<TSPacketLink.Event>.System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
	*/
}
