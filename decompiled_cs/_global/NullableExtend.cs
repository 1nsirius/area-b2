// Namespace: 
[ExtensionAttribute] // RVA: 0x550258 Offset: 0x550258 VA: 0x550258
public static class NullableExtend // TypeDefIndex: 5470
{
	// Methods

	[ExtensionAttribute] // RVA: 0x579C74 Offset: 0x579C74 VA: 0x579C74
	// RVA: -1 Offset: -1
	public static Nullable<U> and<T, U>(Nullable<T> self, Nullable<U> b) { }

	[ExtensionAttribute] // RVA: 0x579C84 Offset: 0x579C84 VA: 0x579C84
	// RVA: -1 Offset: -1
	public static Nullable<U> and_then<T, U>(Nullable<T> self, Func<T, Nullable<U>> f) { }

	[ExtensionAttribute] // RVA: 0x579C94 Offset: 0x579C94 VA: 0x579C94
	// RVA: -1 Offset: -1
	public static T unwrap_or<T>(Nullable<T> self, T d) { }

	[ExtensionAttribute] // RVA: 0x579CA4 Offset: 0x579CA4 VA: 0x579CA4
	// RVA: -1 Offset: -1
	public static T unwrap_or_default<T>(Nullable<T> self) { }

	[ExtensionAttribute] // RVA: 0x579CB4 Offset: 0x579CB4 VA: 0x579CB4
	// RVA: -1 Offset: -1
	public static T unwrap_or_else<T>(Nullable<T> self, Func<T> f) { }

	[ExtensionAttribute] // RVA: 0x579CC4 Offset: 0x579CC4 VA: 0x579CC4
	// RVA: -1 Offset: -1
	public static Nullable<U> map<T, U>(Nullable<T> self, Func<T, U> f) { }

	[ExtensionAttribute] // RVA: 0x579CD4 Offset: 0x579CD4 VA: 0x579CD4
	// RVA: -1 Offset: -1
	public static U map_or<T, U>(Nullable<T> self, U d, Func<T, U> f) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x13A1744 Offset: 0x13A1744 VA: 0x13A1744
	|-NullableExtend.map_or<int, bool>
	*/

	[ExtensionAttribute] // RVA: 0x579CE4 Offset: 0x579CE4 VA: 0x579CE4
	// RVA: -1 Offset: -1
	public static U map_or_else<T, U>(Nullable<T> self, Func<U> d, Func<T, U> f) { }
}
