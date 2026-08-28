// Namespace: 
public sealed class SimpleSingleton<T> // TypeDefIndex: 5531
{
	// Fields
	private static readonly Lazy<T> mInstance; // 0x0

	// Properties
	public static T Instance { get; }

	// Methods

	// RVA: -1 Offset: -1
	public static T get_Instance() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2A374A4 Offset: 0x2A374A4 VA: 0x2A374A4
	|-SimpleSingleton<GetBackButtonSystem>.get_Instance
	|-SimpleSingleton<GetBackCheckSystem>.get_Instance
	|-SimpleSingleton<object>.get_Instance
	*/

	// RVA: -1 Offset: -1
	private void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2A37614 Offset: 0x2A37614 VA: 0x2A37614
	|-SimpleSingleton<object>..ctor
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2A37640 Offset: 0x2A37640 VA: 0x2A37640
	|-SimpleSingleton<object>..cctor
	*/
}
