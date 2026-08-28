// Namespace: 
[Serializable]
public class AkEventPlayable : PlayableAsset, ITimelineClipAsset // TypeDefIndex: 6061
{
	// Fields
	private readonly WwiseEventTracker eventTracker; // 0xC
	public Event akEvent; // 0x10
	private float blendInDuration; // 0x14
	private float blendOutDuration; // 0x18
	private float easeInDuration; // 0x1C
	private float easeOutDuration; // 0x20
	public ExposedReference<GameObject> emitterObjectRef; // 0x24
	[SerializeField] // RVA: 0x55FD08 Offset: 0x55FD08 VA: 0x55FD08
	private float eventDurationMax; // 0x2C
	[SerializeField] // RVA: 0x55FD18 Offset: 0x55FD18 VA: 0x55FD18
	private float eventDurationMin; // 0x30
	public bool overrideTrackEmitterObject; // 0x34
	private TimelineClip owningClip; // 0x38
	public bool retriggerEvent; // 0x3C

	// Properties
	public TimelineClip OwningClip { get; set; }
	public override double duration { get; }
	public ClipCaps clipCaps { get; }

	// Methods

	// RVA: 0x1B9ED5C Offset: 0x1B9ED5C VA: 0x1B9ED5C
	public TimelineClip get_OwningClip() { }

	// RVA: 0x1B9ED64 Offset: 0x1B9ED64 VA: 0x1B9ED64
	public void set_OwningClip(TimelineClip value) { }

	// RVA: 0x1B9ED6C Offset: 0x1B9ED6C VA: 0x1B9ED6C Slot: 7
	public override double get_duration() { }

	// RVA: 0x1B9ED90 Offset: 0x1B9ED90 VA: 0x1B9ED90 Slot: 9
	public ClipCaps get_clipCaps() { }

	// RVA: 0x1B9EDA0 Offset: 0x1B9EDA0 VA: 0x1B9EDA0
	public void setEaseInDuration(float d) { }

	// RVA: 0x1B9EDA8 Offset: 0x1B9EDA8 VA: 0x1B9EDA8
	public void setEaseOutDuration(float d) { }

	// RVA: 0x1B9EDB0 Offset: 0x1B9EDB0 VA: 0x1B9EDB0
	public void setBlendInDuration(float d) { }

	// RVA: 0x1B9EDB8 Offset: 0x1B9EDB8 VA: 0x1B9EDB8
	public void setBlendOutDuration(float d) { }

	// RVA: 0x1B9EDC0 Offset: 0x1B9EDC0 VA: 0x1B9EDC0 Slot: 6
	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) { }

	// RVA: 0x1B9EF1C Offset: 0x1B9EF1C VA: 0x1B9EF1C
	public void initializeBehaviour(PlayableGraph graph, AkEventPlayableBehavior b, GameObject owner) { }

	// RVA: 0x1B9F0A4 Offset: 0x1B9F0A4 VA: 0x1B9F0A4
	public void .ctor() { }
}
