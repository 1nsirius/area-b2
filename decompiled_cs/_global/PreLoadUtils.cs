// Namespace: 
public class PreLoadUtils // TypeDefIndex: 5458
{
	// Methods

	// RVA: 0x2CE83C0 Offset: 0x2CE83C0 VA: 0x2CE83C0
	public static int GetContentForSkillId(int skillId) { }

	// RVA: 0x2CE84AC Offset: 0x2CE84AC VA: 0x2CE84AC
	public static void LoadEffByParticleId(AssetLoaderWorker worker, int particleId) { }

	// RVA: 0x2CE84F8 Offset: 0x2CE84F8 VA: 0x2CE84F8
	public static void LoadEffByParticleRecord(AssetLoaderWorker worker, particle_table.Record particleTable) { }

	// RVA: 0x2CE8418 Offset: 0x2CE8418 VA: 0x2CE8418
	public static int GetContentIdForPropsId(int propsId) { }

	// RVA: 0x2CE85F8 Offset: 0x2CE85F8 VA: 0x2CE85F8
	public static void AddGunEffect(List<int> effectIds, int propsId) { }

	// RVA: 0x2CE8744 Offset: 0x2CE8744 VA: 0x2CE8744
	public static CharacterInfo CreateCharacterInfo(int npcId) { }

	// RVA: -1 Offset: -1
	public static void AddAssetLoaderAction<TU>(string path, AssetLoaderWorker worker, int weight = 1) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x101B210 Offset: 0x101B210 VA: 0x101B210
	|-PreLoadUtils.AddAssetLoaderAction<GraphAnimatorController>
	|-PreLoadUtils.AddAssetLoaderAction<SkillScriptBase>
	|-PreLoadUtils.AddAssetLoaderAction<EffectConfiguration>
	|-PreLoadUtils.AddAssetLoaderAction<object>
	|-PreLoadUtils.AddAssetLoaderAction<AnimatorOverrideController>
	|-PreLoadUtils.AddAssetLoaderAction<GameObject>
	|-PreLoadUtils.AddAssetLoaderAction<Material>
	|-PreLoadUtils.AddAssetLoaderAction<Mesh>
	|-PreLoadUtils.AddAssetLoaderAction<ShaderVariantCollection>
	|-PreLoadUtils.AddAssetLoaderAction<Sprite>
	*/

	// RVA: 0x2CE88F0 Offset: 0x2CE88F0 VA: 0x2CE88F0
	public static void AddAssetLoaderAndCacheAction(string path, AssetLoaderWorker worker, int cacheCnt, int weight = 1) { }

	// RVA: 0x2CE8AB0 Offset: 0x2CE8AB0 VA: 0x2CE8AB0
	public static void AddAudioLoaderAction(string path, AssetLoaderWorker worker) { }

	// RVA: 0x2CE855C Offset: 0x2CE855C VA: 0x2CE855C
	public static void LoadEffByName(AssetLoaderWorker worker, string name) { }

	// RVA: 0x2CE8BD8 Offset: 0x2CE8BD8 VA: 0x2CE8BD8
	public static void CreatePreloadFromSkillButtonTable(AssetLoaderWorker worker, int btnId) { }

	// RVA: 0x2CE8DEC Offset: 0x2CE8DEC VA: 0x2CE8DEC
	public void .ctor() { }
}
