// Namespace: 
[Serializable]
public class AkRTPCPlayableBehaviour : PlayableBehaviour // TypeDefIndex: 6082
{
	// Fields
	private bool m_OverrideTrackObject; // 0x8
	private RTPC m_Parameter; // 0xC
	private GameObject m_RTPCObject; // 0x10
	private bool m_SetRTPCGlobally; // 0x14
	public float RTPCValue; // 0x18

	// Properties
	public bool setRTPCGlobally { set; }
	public bool overrideTrackObject { set; }
	public GameObject rtpcObject { get; set; }
	public RTPC parameter { set; }

	// Methods

	// RVA: 0x1BBD7D8 Offset: 0x1BBD7D8 VA: 0x1BBD7D8
	public void set_setRTPCGlobally(bool value) { }

	// RVA: 0x1BBD7D0 Offset: 0x1BBD7D0 VA: 0x1BBD7D0
	public void set_overrideTrackObject(bool value) { }

	// RVA: 0x1BBD7E0 Offset: 0x1BBD7E0 VA: 0x1BBD7E0
	public void set_rtpcObject(GameObject value) { }

	// RVA: 0x1BBD874 Offset: 0x1BBD874 VA: 0x1BBD874
	public GameObject get_rtpcObject() { }

	// RVA: 0x1BBD7E8 Offset: 0x1BBD7E8 VA: 0x1BBD7E8
	public void set_parameter(RTPC value) { }

	// RVA: 0x1BBD87C Offset: 0x1BBD87C VA: 0x1BBD87C Slot: 20
	public override void ProcessFrame(Playable playable, FrameData info, object playerData) { }

	// RVA: 0x1BBD86C Offset: 0x1BBD86C VA: 0x1BBD86C
	public void .ctor() { }
}
