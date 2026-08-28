// Namespace: 
[LuaCallCSharpAttribute] // RVA: 0x550AF4 Offset: 0x550AF4 VA: 0x550AF4
public class PrefabCache : MonoSingleton<PrefabCache> // TypeDefIndex: 5578
{
	// Fields
	private readonly Dictionary<string, GameObject> mCacheObjects; // 0xC

	// Methods

	// RVA: 0x2CE8DF4 Offset: 0x2CE8DF4 VA: 0x2CE8DF4
	public static bool Contain(string path) { }

	// RVA: 0x2CE8E98 Offset: 0x2CE8E98 VA: 0x2CE8E98
	public static GameObject Cache(string path, GameObject prefab, int count) { }

	// RVA: -1 Offset: -1
	public static T Get<T>(string path, Transform parent) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCE04C4 Offset: 0xCE04C4 VA: 0xCE04C4
	|-PrefabCache.Get<object>
	|-PrefabCache.Get<RectTransform>
	*/

	// RVA: -1 Offset: -1
	public static T Get<T>(string path, Transform parent, in Vector3 position, in Quaternion rotation, bool inWorldSpace = False) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCE05F4 Offset: 0xCE05F4 VA: 0xCE05F4
	|-PrefabCache.Get<ScenePropRigidbody>
	|-PrefabCache.Get<ScenePropViewBase>
	|-PrefabCache.Get<ParticleEffectMono>
	|-PrefabCache.Get<object>
	|-PrefabCache.Get<Transform>
	*/

	// RVA: 0x2CE909C Offset: 0x2CE909C VA: 0x2CE909C
	public static void Clear() { }

	// RVA: 0x2CE929C Offset: 0x2CE929C VA: 0x2CE929C
	public void .ctor() { }
}
