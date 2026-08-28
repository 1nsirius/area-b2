// Namespace: 
[ExtensionAttribute] // RVA: 0x550AE4 Offset: 0x550AE4 VA: 0x550AE4
public static class ObjectPoolExtensions // TypeDefIndex: 5577
{
	// Methods

	[ExtensionAttribute] // RVA: 0x57A10C Offset: 0x57A10C VA: 0x57A10C
	// RVA: -1 Offset: -1
	public static void CreatePool<T>(T prefab, int initialPoolSize = 0) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B078 Offset: 0x101B078 VA: 0x101B078
	|-ObjectPoolExtensions.CreatePool<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A11C Offset: 0x57A11C VA: 0x57A11C
	// RVA: 0x2CE3028 Offset: 0x2CE3028 VA: 0x2CE3028
	public static void CreatePool(GameObject prefab, int initialPoolSize = 0) { }

	[ExtensionAttribute] // RVA: 0x57A12C Offset: 0x57A12C VA: 0x57A12C
	// RVA: -1 Offset: -1
	public static T Spawn<T>(T prefab, in Vector3 position, in Quaternion rotation, Transform parent, bool inWorldSpace = False) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCE0448 Offset: 0xCE0448 VA: 0xCE0448
	|-ObjectPoolExtensions.Spawn<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A13C Offset: 0x57A13C VA: 0x57A13C
	// RVA: 0x2CE3064 Offset: 0x2CE3064 VA: 0x2CE3064
	public static GameObject Spawn(GameObject prefab, in Vector3 position, in Quaternion rotation, Transform parent, bool inWorldSpace = False) { }

	[ExtensionAttribute] // RVA: 0x57A14C Offset: 0x57A14C VA: 0x57A14C
	// RVA: -1 Offset: -1
	public static T Spawn<T>(T prefab, Transform parent, bool worldPositionStays = False) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCE0340 Offset: 0xCE0340 VA: 0xCE0340
	|-ObjectPoolExtensions.Spawn<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A15C Offset: 0x57A15C VA: 0x57A15C
	// RVA: 0x2CE30BC Offset: 0x2CE30BC VA: 0x2CE30BC
	public static GameObject Spawn(GameObject prefab, Transform parent, bool worldPositionStays = False) { }

	[ExtensionAttribute] // RVA: 0x57A16C Offset: 0x57A16C VA: 0x57A16C
	// RVA: -1 Offset: -1
	public static void Recycle<T>(T obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B180 Offset: 0x101B180 VA: 0x101B180
	|-ObjectPoolExtensions.Recycle<ScenePropRigidbody>
	|-ObjectPoolExtensions.Recycle<ScenePropViewBase>
	|-ObjectPoolExtensions.Recycle<ParticleEffectMono>
	|-ObjectPoolExtensions.Recycle<object>
	|-ObjectPoolExtensions.Recycle<Transform>
	*/

	[ExtensionAttribute] // RVA: 0x57A17C Offset: 0x57A17C VA: 0x57A17C
	// RVA: 0x2CE31A8 Offset: 0x2CE31A8 VA: 0x2CE31A8
	public static void Recycle(GameObject obj) { }

	[ExtensionAttribute] // RVA: 0x57A18C Offset: 0x57A18C VA: 0x57A18C
	// RVA: -1 Offset: -1
	public static void RecycleAll<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B1C8 Offset: 0x101B1C8 VA: 0x101B1C8
	|-ObjectPoolExtensions.RecycleAll<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A19C Offset: 0x57A19C VA: 0x57A19C
	// RVA: 0x2CE326C Offset: 0x2CE326C VA: 0x2CE326C
	public static void RecycleAll(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A1AC Offset: 0x57A1AC VA: 0x57A1AC
	// RVA: -1 Offset: -1
	public static int CountPooled<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xA085DC Offset: 0xA085DC VA: 0xA085DC
	|-ObjectPoolExtensions.CountPooled<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A1BC Offset: 0x57A1BC VA: 0x57A1BC
	// RVA: 0x2CE32A0 Offset: 0x2CE32A0 VA: 0x2CE32A0
	public static int CountPooled(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A1CC Offset: 0x57A1CC VA: 0x57A1CC
	// RVA: -1 Offset: -1
	public static int CountSpawned<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xA08624 Offset: 0xA08624 VA: 0xA08624
	|-ObjectPoolExtensions.CountSpawned<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A1DC Offset: 0x57A1DC VA: 0x57A1DC
	// RVA: 0x2CE32D4 Offset: 0x2CE32D4 VA: 0x2CE32D4
	public static int CountSpawned(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A1EC Offset: 0x57A1EC VA: 0x57A1EC
	// RVA: 0x2CE3308 Offset: 0x2CE3308 VA: 0x2CE3308
	public static List<GameObject> GetSpawned(GameObject prefab, List<GameObject> list, bool appendList) { }

	[ExtensionAttribute] // RVA: 0x57A1FC Offset: 0x57A1FC VA: 0x57A1FC
	// RVA: 0x2CE3354 Offset: 0x2CE3354 VA: 0x2CE3354
	public static List<GameObject> GetSpawned(GameObject prefab, List<GameObject> list) { }

	[ExtensionAttribute] // RVA: 0x57A20C Offset: 0x57A20C VA: 0x57A20C
	// RVA: 0x2CE339C Offset: 0x2CE339C VA: 0x2CE339C
	public static List<GameObject> GetSpawned(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A21C Offset: 0x57A21C VA: 0x57A21C
	// RVA: -1 Offset: -1
	public static List<T> GetSpawned<T>(T prefab, List<T> list, bool appendList) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FF5A4 Offset: 0x9FF5A4 VA: 0x9FF5A4
	|-ObjectPoolExtensions.GetSpawned<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A22C Offset: 0x57A22C VA: 0x57A22C
	// RVA: -1 Offset: -1
	public static List<T> GetSpawned<T>(T prefab, List<T> list) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FF544 Offset: 0x9FF544 VA: 0x9FF544
	|-ObjectPoolExtensions.GetSpawned<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A23C Offset: 0x57A23C VA: 0x57A23C
	// RVA: -1 Offset: -1
	public static List<T> GetSpawned<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FF4E8 Offset: 0x9FF4E8 VA: 0x9FF4E8
	|-ObjectPoolExtensions.GetSpawned<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A24C Offset: 0x57A24C VA: 0x57A24C
	// RVA: 0x2CE33E0 Offset: 0x2CE33E0 VA: 0x2CE33E0
	public static List<GameObject> GetPooled(GameObject prefab, List<GameObject> list, bool appendList) { }

	[ExtensionAttribute] // RVA: 0x57A25C Offset: 0x57A25C VA: 0x57A25C
	// RVA: 0x2CE342C Offset: 0x2CE342C VA: 0x2CE342C
	public static List<GameObject> GetPooled(GameObject prefab, List<GameObject> list) { }

	[ExtensionAttribute] // RVA: 0x57A26C Offset: 0x57A26C VA: 0x57A26C
	// RVA: 0x2CE3474 Offset: 0x2CE3474 VA: 0x2CE3474
	public static List<GameObject> GetPooled(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A27C Offset: 0x57A27C VA: 0x57A27C
	// RVA: -1 Offset: -1
	public static List<T> GetPooled<T>(T prefab, List<T> list, bool appendList) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FF484 Offset: 0x9FF484 VA: 0x9FF484
	|-ObjectPoolExtensions.GetPooled<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A28C Offset: 0x57A28C VA: 0x57A28C
	// RVA: -1 Offset: -1
	public static List<T> GetPooled<T>(T prefab, List<T> list) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FF424 Offset: 0x9FF424 VA: 0x9FF424
	|-ObjectPoolExtensions.GetPooled<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A29C Offset: 0x57A29C VA: 0x57A29C
	// RVA: -1 Offset: -1
	public static List<T> GetPooled<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FF3C8 Offset: 0x9FF3C8 VA: 0x9FF3C8
	|-ObjectPoolExtensions.GetPooled<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A2AC Offset: 0x57A2AC VA: 0x57A2AC
	// RVA: 0x2CE34B8 Offset: 0x2CE34B8 VA: 0x2CE34B8
	public static void DestroyPooled(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A2BC Offset: 0x57A2BC VA: 0x57A2BC
	// RVA: -1 Offset: -1
	public static void DestroyPooled<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B124 Offset: 0x101B124 VA: 0x101B124
	|-ObjectPoolExtensions.DestroyPooled<object>
	*/

	[ExtensionAttribute] // RVA: 0x57A2CC Offset: 0x57A2CC VA: 0x57A2CC
	// RVA: 0x2CE34EC Offset: 0x2CE34EC VA: 0x2CE34EC
	public static void DestroyAll(GameObject prefab) { }

	[ExtensionAttribute] // RVA: 0x57A2DC Offset: 0x57A2DC VA: 0x57A2DC
	// RVA: -1 Offset: -1
	public static void DestroyAll<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B0C8 Offset: 0x101B0C8 VA: 0x101B0C8
	|-ObjectPoolExtensions.DestroyAll<object>
	*/
}
