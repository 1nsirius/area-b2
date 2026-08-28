// Namespace: 
public sealed class ObjectPool : MonoBehaviour // TypeDefIndex: 5574
{
	// Fields
	private static ObjectPool mInstance; // 0x0
	[SerializeField] // RVA: 0x55DEF0 Offset: 0x55DEF0 VA: 0x55DEF0
	private ObjectPool.StartupPoolMode mStartupPoolMode; // 0xC
	[SerializeField] // RVA: 0x55DF00 Offset: 0x55DF00 VA: 0x55DF00
	private ObjectPool.StartupPool[] mStartupPools; // 0x10
	private readonly Dictionary<GameObject, List<GameObject>> mPooledObjectsOfPrefabDict; // 0x14
	private readonly Dictionary<GameObject, GameObject> mPrefabOfSpawnedObjectsDict; // 0x18
	private bool mStartupPoolsCreated; // 0x1C

	// Properties
	public static bool HasInstance { get; }
	public static ObjectPool Instance { get; }

	// Methods

	// RVA: 0x2CE1088 Offset: 0x2CE1088 VA: 0x2CE1088
	private void Awake() { }

	// RVA: 0x2CE119C Offset: 0x2CE119C VA: 0x2CE119C
	private void Start() { }

	// RVA: 0x2CE1100 Offset: 0x2CE1100 VA: 0x2CE1100
	private void CreateStartupPools() { }

	// RVA: -1 Offset: -1
	public void CreatePool<T>(T prefab, int initialPoolSize) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101AECC Offset: 0x101AECC VA: 0x101AECC
	|-ObjectPool.CreatePool<object>
	*/

	// RVA: 0x2CE11AC Offset: 0x2CE11AC VA: 0x2CE11AC
	public void CreatePool(GameObject prefab, int initialPoolSize) { }

	// RVA: 0x2CE148C Offset: 0x2CE148C VA: 0x2CE148C
	private List<GameObject> GetOrCreatePool(GameObject prefab) { }

	// RVA: 0x2CE1290 Offset: 0x2CE1290 VA: 0x2CE1290
	private List<GameObject> CreatePool_Inner(GameObject prefab, int initialPoolSize) { }

	// RVA: -1 Offset: -1
	public T Spawn<T>(T prefab, in Vector3 position, in Quaternion rotation, Transform parent, bool inWorldSpace = False) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCE0294 Offset: 0xCE0294 VA: 0xCE0294
	|-ObjectPool.Spawn<object>
	*/

	// RVA: 0x2CE1544 Offset: 0x2CE1544 VA: 0x2CE1544
	public GameObject Spawn(GameObject prefab, in Vector3 position, in Quaternion rotation, Transform parent, bool inWorldSpace = False) { }

	// RVA: -1 Offset: -1
	public void Recycle<T>(T obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101AFD0 Offset: 0x101AFD0 VA: 0x101AFD0
	|-ObjectPool.Recycle<object>
	*/

	// RVA: 0x2CE1904 Offset: 0x2CE1904 VA: 0x2CE1904
	public void Recycle(GameObject obj) { }

	// RVA: -1 Offset: -1
	public void RecycleAll<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B024 Offset: 0x101B024 VA: 0x101B024
	|-ObjectPool.RecycleAll<object>
	*/

	// RVA: 0x2CE1B04 Offset: 0x2CE1B04 VA: 0x2CE1B04
	public void RecycleAll(GameObject prefab) { }

	// RVA: 0x2CE1E74 Offset: 0x2CE1E74 VA: 0x2CE1E74
	public void RecycleAll() { }

	// RVA: 0x2CE2054 Offset: 0x2CE2054 VA: 0x2CE2054
	public bool IsSpawned(GameObject obj) { }

	// RVA: -1 Offset: -1
	public int CountPooled<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xA08534 Offset: 0xA08534 VA: 0xA08534
	|-ObjectPool.CountPooled<object>
	*/

	// RVA: 0x2CE20D4 Offset: 0x2CE20D4 VA: 0x2CE20D4
	public int CountPooled(GameObject prefab) { }

	// RVA: -1 Offset: -1
	public int CountSpawned<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xA08588 Offset: 0xA08588 VA: 0xA08588
	|-ObjectPool.CountSpawned<object>
	*/

	// RVA: 0x2CE21A4 Offset: 0x2CE21A4 VA: 0x2CE21A4
	public int CountSpawned(GameObject prefab) { }

	// RVA: 0x2CE235C Offset: 0x2CE235C VA: 0x2CE235C
	public int CountAllPooled() { }

	// RVA: 0x2CE24FC Offset: 0x2CE24FC VA: 0x2CE24FC
	public List<GameObject> GetPooled(GameObject prefab, List<GameObject> list, bool appendList) { }

	// RVA: -1 Offset: -1
	public List<T> GetPooled<T>(T prefab, List<T> list, bool appendList) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FEDF8 Offset: 0x9FEDF8 VA: 0x9FEDF8
	|-ObjectPool.GetPooled<object>
	*/

	// RVA: 0x2CE263C Offset: 0x2CE263C VA: 0x2CE263C
	public List<GameObject> GetSpawned(GameObject prefab, List<GameObject> list, bool appendList) { }

	// RVA: -1 Offset: -1
	public List<T> GetSpawned<T>(T prefab, List<T> list, bool appendList) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9FEFF8 Offset: 0x9FEFF8 VA: 0x9FEFF8
	|-ObjectPool.GetSpawned<object>
	*/

	// RVA: 0x2CE28E8 Offset: 0x2CE28E8 VA: 0x2CE28E8
	public void DestroyPooled(GameObject prefab) { }

	// RVA: -1 Offset: -1
	public void DestroyPooled<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101AF7C Offset: 0x101AF7C VA: 0x101AF7C
	|-ObjectPool.DestroyPooled<object>
	*/

	// RVA: 0x2CE2A4C Offset: 0x2CE2A4C VA: 0x2CE2A4C
	public void DestroyAll(GameObject prefab) { }

	// RVA: -1 Offset: -1
	public void DestroyAll<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101AF28 Offset: 0x101AF28 VA: 0x101AF28
	|-ObjectPool.DestroyAll<object>
	*/

	// RVA: 0x2CE2AF8 Offset: 0x2CE2AF8 VA: 0x2CE2AF8
	public static bool get_HasInstance() { }

	// RVA: 0x2CE2B94 Offset: 0x2CE2B94 VA: 0x2CE2B94
	public static ObjectPool get_Instance() { }

	// RVA: 0x2CE2F60 Offset: 0x2CE2F60 VA: 0x2CE2F60
	public void .ctor() { }
}
