// Namespace: 
public class AkEventPlayableBehavior : PlayableBehaviour // TypeDefIndex: 6062
{
	// Fields
	public static int scrubPlaybackLengthMs; // 0x0
	public Event akEvent; // 0x8
	public float akEventMaxDuration; // 0xC
	public float akEventMinDuration; // 0x10
	public float blendInDuration; // 0x14
	public float blendOutDuration; // 0x18
	public float easeInDuration; // 0x1C
	public float easeOutDuration; // 0x20
	public GameObject eventObject; // 0x24
	public bool eventShouldRetrigger; // 0x28
	public WwiseEventTracker eventTracker; // 0x2C
	public float lastEffectiveWeight; // 0x30
	public bool overrideTrackEmittorObject; // 0x34
	public AkEventPlayableBehavior.AkPlayableAction requiredActions; // 0x38

	// Methods

	// RVA: 0x1B9F130 Offset: 0x1B9F130 VA: 0x1B9F130 Slot: 19
	public override void PrepareFrame(Playable playable, FrameData info) { }

	// RVA: 0x1B9F554 Offset: 0x1B9F554 VA: 0x1B9F554 Slot: 17
	public override void OnBehaviourPlay(Playable playable, FrameData info) { }

	// RVA: 0x1B9F884 Offset: 0x1B9F884 VA: 0x1B9F884 Slot: 18
	public override void OnBehaviourPause(Playable playable, FrameData info) { }

	// RVA: 0x1B9FA30 Offset: 0x1B9FA30 VA: 0x1B9FA30 Slot: 20
	public override void ProcessFrame(Playable playable, FrameData info, object playerData) { }

	// RVA: 0x1B9FD0C Offset: 0x1B9FD0C VA: 0x1B9FD0C
	private bool actionIsRequired(AkEventPlayableBehavior.AkPlayableAction actionType) { }

	// RVA: 0x1B9F378 Offset: 0x1B9F378 VA: 0x1B9F378
	private bool ShouldPlay(Playable playable) { }

	// RVA: 0x1BA0484 Offset: 0x1BA0484 VA: 0x1BA0484
	private bool fadeInRequired(float currentClipTime) { }

	// RVA: 0x1B9F4D8 Offset: 0x1B9F4D8 VA: 0x1B9F4D8
	private void checkForFadeIn(float currentClipTime) { }

	// RVA: 0x1BA04C0 Offset: 0x1BA04C0 VA: 0x1BA04C0
	private void checkForFadeInImmediate(float currentClipTime) { }

	// RVA: 0x1BA04F0 Offset: 0x1BA04F0 VA: 0x1BA04F0
	private bool fadeOutRequired(Playable playable) { }

	// RVA: 0x1BA05C8 Offset: 0x1BA05C8 VA: 0x1BA05C8
	private void checkForFadeOutImmediate(Playable playable) { }

	// RVA: 0x1B9F510 Offset: 0x1B9F510 VA: 0x1B9F510
	private void checkForFadeOut(Playable playable) { }

	// RVA: 0x1BA01CC Offset: 0x1BA01CC VA: 0x1BA01CC
	protected void triggerFadeIn(float currentClipTime) { }

	// RVA: 0x1BA0360 Offset: 0x1BA0360 VA: 0x1BA0360
	protected void triggerFadeOut(float fadeDuration) { }

	// RVA: 0x1B9F924 Offset: 0x1B9F924 VA: 0x1B9F924
	protected void stopEvent(int transition = 0) { }

	// RVA: 0x1B9FD24 Offset: 0x1B9FD24 VA: 0x1B9FD24
	protected void playEvent() { }

	// RVA: 0x1B9FEA8 Offset: 0x1B9FEA8 VA: 0x1B9FEA8
	protected void retriggerEvent(Playable playable) { }

	// RVA: 0x1B9F720 Offset: 0x1B9F720 VA: 0x1B9F720
	protected float getProportionalTime(Playable playable) { }

	// RVA: 0x1BA007C Offset: 0x1BA007C VA: 0x1BA007C
	protected float seekToTime(Playable playable) { }

	// RVA: 0x1BA06B0 Offset: 0x1BA06B0 VA: 0x1BA06B0
	public void .ctor() { }

	// RVA: 0x1BA06D0 Offset: 0x1BA06D0 VA: 0x1BA06D0
	private static void .cctor() { }
}
