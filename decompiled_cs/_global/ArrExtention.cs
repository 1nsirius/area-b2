// Namespace: 
[ExtensionAttribute] // RVA: 0x550D44 Offset: 0x550D44 VA: 0x550D44
public static class ArrExtention // TypeDefIndex: 5726
{
	// Methods

	[ExtensionAttribute] // RVA: 0x57AB0C Offset: 0x57AB0C VA: 0x57AB0C
	// RVA: -1 Offset: -1
	public static bool TryGetVal<T>(T[] arr, int index, out T val) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CB69E8 Offset: 0x1CB69E8 VA: 0x1CB69E8
	|-ArrExtention.TryGetVal<int>
	|
	|-RVA: 0x1CB6A40 Offset: 0x1CB6A40 VA: 0x1CB6A40
	|-ArrExtention.TryGetVal<object>
	*/
}
