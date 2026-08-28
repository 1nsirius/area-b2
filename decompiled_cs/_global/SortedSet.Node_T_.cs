// Namespace: 
[Serializable]
internal sealed class SortedSet.Node<T> // TypeDefIndex: 2115
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x4E6ECC Offset: 0x4E6ECC VA: 0x4E6ECC
	private T <Item>k__BackingField; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x4E6EDC Offset: 0x4E6EDC VA: 0x4E6EDC
	private SortedSet.Node<T> <Left>k__BackingField; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x4E6EEC Offset: 0x4E6EEC VA: 0x4E6EEC
	private SortedSet.Node<T> <Right>k__BackingField; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x4E6EFC Offset: 0x4E6EFC VA: 0x4E6EFC
	private NodeColor <Color>k__BackingField; // 0x0

	// Properties
	public T Item { get; set; }
	public SortedSet.Node<T> Left { get; set; }
	public SortedSet.Node<T> Right { get; set; }
	public NodeColor Color { get; set; }
	public bool IsBlack { get; }
	public bool IsRed { get; }
	public bool Is2Node { get; }
	public bool Is4Node { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(T item, NodeColor color) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5D28 Offset: 0x24F5D28 VA: 0x24F5D28
	|-SortedSet.Node<KeyValuePair<char, char>>..ctor
	|
	|-RVA: 0x24F6B48 Offset: 0x24F6B48 VA: 0x24F6B48
	|-SortedSet.Node<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x2965938 Offset: 0x2965938 VA: 0x2965938
	|-SortedSet.Node<object>..ctor
	*/

	// RVA: -1 Offset: -1
	public static bool IsNonNullRed(SortedSet.Node<T> node) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5DC0 Offset: 0x24F5DC0 VA: 0x24F5DC0
	|-SortedSet.Node<KeyValuePair<char, char>>.IsNonNullRed
	|
	|-RVA: 0x24F6BE8 Offset: 0x24F6BE8 VA: 0x24F6BE8
	|-SortedSet.Node<KeyValuePair<object, object>>.IsNonNullRed
	|
	|-RVA: 0x29659D0 Offset: 0x29659D0 VA: 0x29659D0
	|-SortedSet.Node<object>.IsNonNullRed
	*/

	// RVA: -1 Offset: -1
	public static bool IsNullOrBlack(SortedSet.Node<T> node) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5E3C Offset: 0x24F5E3C VA: 0x24F5E3C
	|-SortedSet.Node<KeyValuePair<char, char>>.IsNullOrBlack
	|
	|-RVA: 0x24F6C64 Offset: 0x24F6C64 VA: 0x24F6C64
	|-SortedSet.Node<KeyValuePair<object, object>>.IsNullOrBlack
	|
	|-RVA: 0x2965A4C Offset: 0x2965A4C VA: 0x2965A4C
	|-SortedSet.Node<object>.IsNullOrBlack
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7B48 Offset: 0x4E7B48 VA: 0x4E7B48
	// RVA: -1 Offset: -1
	public T get_Item() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EB8 Offset: 0x24F5EB8 VA: 0x24F5EB8
	|-SortedSet.Node<KeyValuePair<char, char>>.get_Item
	|
	|-RVA: 0x24F6CE0 Offset: 0x24F6CE0 VA: 0x24F6CE0
	|-SortedSet.Node<KeyValuePair<object, object>>.get_Item
	|
	|-RVA: 0x2965AC8 Offset: 0x2965AC8 VA: 0x2965AC8
	|-SortedSet.Node<object>.get_Item
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7B58 Offset: 0x4E7B58 VA: 0x4E7B58
	// RVA: -1 Offset: -1
	public void set_Item(T value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EC0 Offset: 0x24F5EC0 VA: 0x24F5EC0
	|-SortedSet.Node<KeyValuePair<char, char>>.set_Item
	|
	|-RVA: 0x24F6CF4 Offset: 0x24F6CF4 VA: 0x24F6CF4
	|-SortedSet.Node<KeyValuePair<object, object>>.set_Item
	|
	|-RVA: 0x2965AD0 Offset: 0x2965AD0 VA: 0x2965AD0
	|-SortedSet.Node<object>.set_Item
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7B68 Offset: 0x4E7B68 VA: 0x4E7B68
	// RVA: -1 Offset: -1
	public SortedSet.Node<T> get_Left() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EC8 Offset: 0x24F5EC8 VA: 0x24F5EC8
	|-SortedSet.Node<KeyValuePair<char, char>>.get_Left
	|
	|-RVA: 0x24F6D00 Offset: 0x24F6D00 VA: 0x24F6D00
	|-SortedSet.Node<KeyValuePair<object, object>>.get_Left
	|
	|-RVA: 0x2965AD8 Offset: 0x2965AD8 VA: 0x2965AD8
	|-SortedSet.Node<object>.get_Left
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7B78 Offset: 0x4E7B78 VA: 0x4E7B78
	// RVA: -1 Offset: -1
	public void set_Left(SortedSet.Node<T> value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5ED0 Offset: 0x24F5ED0 VA: 0x24F5ED0
	|-SortedSet.Node<KeyValuePair<char, char>>.set_Left
	|
	|-RVA: 0x24F6D08 Offset: 0x24F6D08 VA: 0x24F6D08
	|-SortedSet.Node<KeyValuePair<object, object>>.set_Left
	|
	|-RVA: 0x2965AE0 Offset: 0x2965AE0 VA: 0x2965AE0
	|-SortedSet.Node<object>.set_Left
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7B88 Offset: 0x4E7B88 VA: 0x4E7B88
	// RVA: -1 Offset: -1
	public SortedSet.Node<T> get_Right() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5ED8 Offset: 0x24F5ED8 VA: 0x24F5ED8
	|-SortedSet.Node<KeyValuePair<char, char>>.get_Right
	|
	|-RVA: 0x24F6D10 Offset: 0x24F6D10 VA: 0x24F6D10
	|-SortedSet.Node<KeyValuePair<object, object>>.get_Right
	|
	|-RVA: 0x2965AE8 Offset: 0x2965AE8 VA: 0x2965AE8
	|-SortedSet.Node<object>.get_Right
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7B98 Offset: 0x4E7B98 VA: 0x4E7B98
	// RVA: -1 Offset: -1
	public void set_Right(SortedSet.Node<T> value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EE0 Offset: 0x24F5EE0 VA: 0x24F5EE0
	|-SortedSet.Node<KeyValuePair<char, char>>.set_Right
	|
	|-RVA: 0x24F6D18 Offset: 0x24F6D18 VA: 0x24F6D18
	|-SortedSet.Node<KeyValuePair<object, object>>.set_Right
	|
	|-RVA: 0x2965AF0 Offset: 0x2965AF0 VA: 0x2965AF0
	|-SortedSet.Node<object>.set_Right
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7BA8 Offset: 0x4E7BA8 VA: 0x4E7BA8
	// RVA: -1 Offset: -1
	public NodeColor get_Color() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EE8 Offset: 0x24F5EE8 VA: 0x24F5EE8
	|-SortedSet.Node<KeyValuePair<char, char>>.get_Color
	|
	|-RVA: 0x24F6D20 Offset: 0x24F6D20 VA: 0x24F6D20
	|-SortedSet.Node<KeyValuePair<object, object>>.get_Color
	|
	|-RVA: 0x2965AF8 Offset: 0x2965AF8 VA: 0x2965AF8
	|-SortedSet.Node<object>.get_Color
	*/

	[CompilerGeneratedAttribute] // RVA: 0x4E7BB8 Offset: 0x4E7BB8 VA: 0x4E7BB8
	// RVA: -1 Offset: -1
	public void set_Color(NodeColor value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EF0 Offset: 0x24F5EF0 VA: 0x24F5EF0
	|-SortedSet.Node<KeyValuePair<char, char>>.set_Color
	|
	|-RVA: 0x24F6D28 Offset: 0x24F6D28 VA: 0x24F6D28
	|-SortedSet.Node<KeyValuePair<object, object>>.set_Color
	|
	|-RVA: 0x2965B00 Offset: 0x2965B00 VA: 0x2965B00
	|-SortedSet.Node<object>.set_Color
	*/

	// RVA: -1 Offset: -1
	public bool get_IsBlack() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5EF8 Offset: 0x24F5EF8 VA: 0x24F5EF8
	|-SortedSet.Node<KeyValuePair<char, char>>.get_IsBlack
	|
	|-RVA: 0x24F6D30 Offset: 0x24F6D30 VA: 0x24F6D30
	|-SortedSet.Node<KeyValuePair<object, object>>.get_IsBlack
	|
	|-RVA: 0x2965B08 Offset: 0x2965B08 VA: 0x2965B08
	|-SortedSet.Node<object>.get_IsBlack
	*/

	// RVA: -1 Offset: -1
	public bool get_IsRed() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5F44 Offset: 0x24F5F44 VA: 0x24F5F44
	|-SortedSet.Node<KeyValuePair<char, char>>.get_IsRed
	|
	|-RVA: 0x24F6D7C Offset: 0x24F6D7C VA: 0x24F6D7C
	|-SortedSet.Node<KeyValuePair<object, object>>.get_IsRed
	|
	|-RVA: 0x2965B54 Offset: 0x2965B54 VA: 0x2965B54
	|-SortedSet.Node<object>.get_IsRed
	*/

	// RVA: -1 Offset: -1
	public bool get_Is2Node() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F5F88 Offset: 0x24F5F88 VA: 0x24F5F88
	|-SortedSet.Node<KeyValuePair<char, char>>.get_Is2Node
	|
	|-RVA: 0x24F6DC0 Offset: 0x24F6DC0 VA: 0x24F6DC0
	|-SortedSet.Node<KeyValuePair<object, object>>.get_Is2Node
	|
	|-RVA: 0x2965B98 Offset: 0x2965B98 VA: 0x2965B98
	|-SortedSet.Node<object>.get_Is2Node
	*/

	// RVA: -1 Offset: -1
	public bool get_Is4Node() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6054 Offset: 0x24F6054 VA: 0x24F6054
	|-SortedSet.Node<KeyValuePair<char, char>>.get_Is4Node
	|
	|-RVA: 0x24F6E8C Offset: 0x24F6E8C VA: 0x24F6E8C
	|-SortedSet.Node<KeyValuePair<object, object>>.get_Is4Node
	|
	|-RVA: 0x2965C64 Offset: 0x2965C64 VA: 0x2965C64
	|-SortedSet.Node<object>.get_Is4Node
	*/

	// RVA: -1 Offset: -1
	public void ColorBlack() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F60EC Offset: 0x24F60EC VA: 0x24F60EC
	|-SortedSet.Node<KeyValuePair<char, char>>.ColorBlack
	|
	|-RVA: 0x24F6F24 Offset: 0x24F6F24 VA: 0x24F6F24
	|-SortedSet.Node<KeyValuePair<object, object>>.ColorBlack
	|
	|-RVA: 0x2965CFC Offset: 0x2965CFC VA: 0x2965CFC
	|-SortedSet.Node<object>.ColorBlack
	*/

	// RVA: -1 Offset: -1
	public void ColorRed() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F612C Offset: 0x24F612C VA: 0x24F612C
	|-SortedSet.Node<KeyValuePair<char, char>>.ColorRed
	|
	|-RVA: 0x24F6F64 Offset: 0x24F6F64 VA: 0x24F6F64
	|-SortedSet.Node<KeyValuePair<object, object>>.ColorRed
	|
	|-RVA: 0x2965D3C Offset: 0x2965D3C VA: 0x2965D3C
	|-SortedSet.Node<object>.ColorRed
	*/

	// RVA: -1 Offset: -1
	public TreeRotation GetRotation(SortedSet.Node<T> current, SortedSet.Node<T> sibling) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F616C Offset: 0x24F616C VA: 0x24F616C
	|-SortedSet.Node<KeyValuePair<char, char>>.GetRotation
	|
	|-RVA: 0x24F6FA4 Offset: 0x24F6FA4 VA: 0x24F6FA4
	|-SortedSet.Node<KeyValuePair<object, object>>.GetRotation
	|
	|-RVA: 0x2965D7C Offset: 0x2965D7C VA: 0x2965D7C
	|-SortedSet.Node<object>.GetRotation
	*/

	// RVA: -1 Offset: -1
	public SortedSet.Node<T> GetSibling(SortedSet.Node<T> node) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6214 Offset: 0x24F6214 VA: 0x24F6214
	|-SortedSet.Node<KeyValuePair<char, char>>.GetSibling
	|
	|-RVA: 0x24F704C Offset: 0x24F704C VA: 0x24F704C
	|-SortedSet.Node<KeyValuePair<object, object>>.GetSibling
	|
	|-RVA: 0x2965E24 Offset: 0x2965E24 VA: 0x2965E24
	|-SortedSet.Node<object>.GetSibling
	*/

	// RVA: -1 Offset: -1
	public void Split4Node() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6288 Offset: 0x24F6288 VA: 0x24F6288
	|-SortedSet.Node<KeyValuePair<char, char>>.Split4Node
	|
	|-RVA: 0x24F70C0 Offset: 0x24F70C0 VA: 0x24F70C0
	|-SortedSet.Node<KeyValuePair<object, object>>.Split4Node
	|
	|-RVA: 0x2965E98 Offset: 0x2965E98 VA: 0x2965E98
	|-SortedSet.Node<object>.Split4Node
	*/

	// RVA: -1 Offset: -1
	public SortedSet.Node<T> Rotate(TreeRotation rotation) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F636C Offset: 0x24F636C VA: 0x24F636C
	|-SortedSet.Node<KeyValuePair<char, char>>.Rotate
	|
	|-RVA: 0x24F71A4 Offset: 0x24F71A4 VA: 0x24F71A4
	|-SortedSet.Node<KeyValuePair<object, object>>.Rotate
	|
	|-RVA: 0x2965F7C Offset: 0x2965F7C VA: 0x2965F7C
	|-SortedSet.Node<object>.Rotate
	*/

	// RVA: -1 Offset: -1
	public SortedSet.Node<T> RotateLeft() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6538 Offset: 0x24F6538 VA: 0x24F6538
	|-SortedSet.Node<KeyValuePair<char, char>>.RotateLeft
	|
	|-RVA: 0x24F7370 Offset: 0x24F7370 VA: 0x24F7370
	|-SortedSet.Node<KeyValuePair<object, object>>.RotateLeft
	|
	|-RVA: 0x2966148 Offset: 0x2966148 VA: 0x2966148
	|-SortedSet.Node<object>.RotateLeft
	*/

	// RVA: -1 Offset: -1
	public SortedSet.Node<T> RotateLeftRight() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6600 Offset: 0x24F6600 VA: 0x24F6600
	|-SortedSet.Node<KeyValuePair<char, char>>.RotateLeftRight
	|
	|-RVA: 0x24F7438 Offset: 0x24F7438 VA: 0x24F7438
	|-SortedSet.Node<KeyValuePair<object, object>>.RotateLeftRight
	|
	|-RVA: 0x2966210 Offset: 0x2966210 VA: 0x2966210
	|-SortedSet.Node<object>.RotateLeftRight
	*/

	// RVA: -1 Offset: -1
	public SortedSet.Node<T> RotateRight() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6790 Offset: 0x24F6790 VA: 0x24F6790
	|-SortedSet.Node<KeyValuePair<char, char>>.RotateRight
	|
	|-RVA: 0x24F75C8 Offset: 0x24F75C8 VA: 0x24F75C8
	|-SortedSet.Node<KeyValuePair<object, object>>.RotateRight
	|
	|-RVA: 0x29663A0 Offset: 0x29663A0 VA: 0x29663A0
	|-SortedSet.Node<object>.RotateRight
	*/

	// RVA: -1 Offset: -1
	public SortedSet.Node<T> RotateRightLeft() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6858 Offset: 0x24F6858 VA: 0x24F6858
	|-SortedSet.Node<KeyValuePair<char, char>>.RotateRightLeft
	|
	|-RVA: 0x24F7690 Offset: 0x24F7690 VA: 0x24F7690
	|-SortedSet.Node<KeyValuePair<object, object>>.RotateRightLeft
	|
	|-RVA: 0x2966468 Offset: 0x2966468 VA: 0x2966468
	|-SortedSet.Node<object>.RotateRightLeft
	*/

	// RVA: -1 Offset: -1
	public void Merge2Nodes() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F69E8 Offset: 0x24F69E8 VA: 0x24F69E8
	|-SortedSet.Node<KeyValuePair<char, char>>.Merge2Nodes
	|
	|-RVA: 0x24F7820 Offset: 0x24F7820 VA: 0x24F7820
	|-SortedSet.Node<KeyValuePair<object, object>>.Merge2Nodes
	|
	|-RVA: 0x29665F8 Offset: 0x29665F8 VA: 0x29665F8
	|-SortedSet.Node<object>.Merge2Nodes
	*/

	// RVA: -1 Offset: -1
	public void ReplaceChild(SortedSet.Node<T> child, SortedSet.Node<T> newChild) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F6ACC Offset: 0x24F6ACC VA: 0x24F6ACC
	|-SortedSet.Node<KeyValuePair<char, char>>.ReplaceChild
	|
	|-RVA: 0x24F7904 Offset: 0x24F7904 VA: 0x24F7904
	|-SortedSet.Node<KeyValuePair<object, object>>.ReplaceChild
	|
	|-RVA: 0x29666DC Offset: 0x29666DC VA: 0x29666DC
	|-SortedSet.Node<object>.ReplaceChild
	*/
}
