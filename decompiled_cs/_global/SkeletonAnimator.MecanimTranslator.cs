// Namespace: 
[Serializable]
public class SkeletonAnimator.MecanimTranslator // TypeDefIndex: 7224
{
	// Fields
	public bool autoReset; // 0x8
	public SkeletonAnimator.MecanimTranslator.MixMode[] layerMixModes; // 0xC
	private readonly Dictionary<int, Animation> animationTable; // 0x10
	private readonly Dictionary<AnimationClip, int> clipNameHashCodeTable; // 0x14
	private readonly List<Animation> previousAnimations; // 0x18
	private readonly List<AnimatorClipInfo> clipInfoCache; // 0x1C
	private readonly List<AnimatorClipInfo> nextClipInfoCache; // 0x20
	private Animator animator; // 0x24

	// Properties
	public Animator Animator { get; }

	// Methods

	// RVA: 0x11BBB08 Offset: 0x11BBB08 VA: 0x11BBB08
	public Animator get_Animator() { }

	// RVA: 0x11BA444 Offset: 0x11BA444 VA: 0x11BA444
	public void Initialize(Animator animator, SkeletonDataAsset skeletonDataAsset) { }

	// RVA: 0x11BA804 Offset: 0x11BA804 VA: 0x11BA804
	public void Apply(Skeleton skeleton) { }

	// RVA: 0x11BBE54 Offset: 0x11BBE54 VA: 0x11BBE54
	private static float AnimationTime(float normalizedTime, float clipLength, bool loop, bool reversed) { }

	// RVA: 0x11BBEA8 Offset: 0x11BBEA8 VA: 0x11BBEA8
	private static float AnimationTime(float normalizedTime, float clipLength, bool reversed) { }

	// RVA: 0x11BBB10 Offset: 0x11BBB10 VA: 0x11BBB10
	private void GetAnimatorClipInfos(int layer, out int clipInfoCount, out int nextClipInfoCount, out IList<AnimatorClipInfo> clipInfo, out IList<AnimatorClipInfo> nextClipInfo) { }

	// RVA: 0x11BBCF8 Offset: 0x11BBCF8 VA: 0x11BBCF8
	private Animation GetAnimation(AnimationClip clip) { }

	// RVA: 0x11BA250 Offset: 0x11BA250 VA: 0x11BA250
	public void .ctor() { }
}
