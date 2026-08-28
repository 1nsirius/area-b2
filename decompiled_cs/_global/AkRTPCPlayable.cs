// Namespace: 
[Serializable]
public class AkRTPCPlayable : PlayableAsset, ITimelineClipAsset // TypeDefIndex: 6081
{
	// Fields
	public bool overrideTrackObject; // 0xC
	public ExposedReference<GameObject> RTPCObject; // 0x10
	public bool setRTPCGlobally; // 0x18
	public AkRTPCPlayableBehaviour template; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x55FFC0 Offset: 0x55FFC0 VA: 0x55FFC0
	private RTPC <Parameter>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x55FFD0 Offset: 0x55FFD0 VA: 0x55FFD0
	private TimelineClip <OwningClip>k__BackingField; // 0x24

	// Properties
	public RTPC Parameter { get; set; }
	public TimelineClip OwningClip { get; set; }
	public ClipCaps clipCaps { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57B464 Offset: 0x57B464 VA: 0x57B464
	// RVA: 0x1BBD574 Offset: 0x1BBD574 VA: 0x1BBD574
	public RTPC get_Parameter() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B474 Offset: 0x57B474 VA: 0x57B474
	// RVA: 0x1BBD57C Offset: 0x1BBD57C VA: 0x1BBD57C
	public void set_Parameter(RTPC value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57B484 Offset: 0x57B484 VA: 0x57B484
	// RVA: 0x1BBD584 Offset: 0x1BBD584 VA: 0x1BBD584
	public TimelineClip get_OwningClip() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B494 Offset: 0x57B494 VA: 0x57B494
	// RVA: 0x1BBD58C Offset: 0x1BBD58C VA: 0x1BBD58C
	public void set_OwningClip(TimelineClip value) { }

	// RVA: 0x1BBD594 Offset: 0x1BBD594 VA: 0x1BBD594 Slot: 9
	public ClipCaps get_clipCaps() { }

	// RVA: 0x1BBD59C Offset: 0x1BBD59C VA: 0x1BBD59C Slot: 6
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go) { }

	// RVA: 0x1BBD6C4 Offset: 0x1BBD6C4 VA: 0x1BBD6C4
	public void InitializeBehavior(PlayableGraph graph, ref AkRTPCPlayableBehaviour b, GameObject owner) { }

	// RVA: 0x1BBD7F0 Offset: 0x1BBD7F0 VA: 0x1BBD7F0
	public void .ctor() { }
}
