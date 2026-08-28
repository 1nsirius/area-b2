// Namespace: 
public class AudioUtils.SceneToolSoundsProxy // TypeDefIndex: 11903
{
	// Fields
	private Dictionary<ValueTuple<AudioUtils.ESceneAudioType, ViewType>, List<AudioUtils.SceneToolDelayPostSoundEventNameData>> mSounds; // 0x8
	private int mToolID; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5738CC Offset: 0x5738CC VA: 0x5738CC
	private GameObject <SoundObject>k__BackingField; // 0x10

	// Properties
	public GameObject SoundObject { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667BC0 Offset: 0x667BC0 VA: 0x667BC0
	// RVA: 0x8F77F0 Offset: 0x8F77F0 VA: 0x8F77F0
	public GameObject get_SoundObject() { }

	[CompilerGeneratedAttribute] // RVA: 0x667BD0 Offset: 0x667BD0 VA: 0x667BD0
	// RVA: 0x8F77F8 Offset: 0x8F77F8 VA: 0x8F77F8
	public void set_SoundObject(GameObject value) { }

	// RVA: 0x8F7800 Offset: 0x8F7800 VA: 0x8F7800
	public void .ctor(int toolID) { }

	// RVA: 0x8F7894 Offset: 0x8F7894 VA: 0x8F7894
	public void LoadSound(AudioUtils.ESceneAudioType soundType, ViewType viewType) { }

	// RVA: 0x8F7AB8 Offset: 0x8F7AB8 VA: 0x8F7AB8
	public bool IsSoundLoaded(AudioUtils.ESceneAudioType soundType, ViewType viewType) { }

	// RVA: 0x8F7B70 Offset: 0x8F7B70 VA: 0x8F7B70
	public void PostEvent(AudioUtils.ESceneAudioType soundType, ViewType viewType, GameObject gameObject) { }

	// RVA: 0x8F7E5C Offset: 0x8F7E5C VA: 0x8F7E5C
	public void Clear() { }
}
