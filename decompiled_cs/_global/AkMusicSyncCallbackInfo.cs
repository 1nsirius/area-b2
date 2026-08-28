// Namespace: 
public class AkMusicSyncCallbackInfo : AkCallbackInfo // TypeDefIndex: 5932
{
	// Fields
	private IntPtr swigCPtr; // 0x10

	// Properties
	public uint playingID { get; }
	public int segmentInfo_iCurrentPosition { get; }
	public int segmentInfo_iPreEntryDuration { get; }
	public int segmentInfo_iActiveDuration { get; }
	public int segmentInfo_iPostExitDuration { get; }
	public int segmentInfo_iRemainingLookAheadTime { get; }
	public float segmentInfo_fBeatDuration { get; }
	public float segmentInfo_fBarDuration { get; }
	public float segmentInfo_fGridDuration { get; }
	public float segmentInfo_fGridOffset { get; }
	public AkCallbackType musicSyncType { get; }
	public string userCueName { get; }

	// Methods

	// RVA: 0x1BB335C Offset: 0x1BB335C VA: 0x1BB335C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BB3400 Offset: 0x1BB3400 VA: 0x1BB3400
	internal static IntPtr getCPtr(AkMusicSyncCallbackInfo obj) { }

	// RVA: 0x1BB3458 Offset: 0x1BB3458 VA: 0x1BB3458 Slot: 5
	internal override void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB34F4 Offset: 0x1BB34F4 VA: 0x1BB34F4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB3568 Offset: 0x1BB3568 VA: 0x1BB3568 Slot: 6
	public override void Dispose() { }

	// RVA: 0x1BB36F8 Offset: 0x1BB36F8 VA: 0x1BB36F8
	public uint get_playingID() { }

	// RVA: 0x1BB3780 Offset: 0x1BB3780 VA: 0x1BB3780
	public int get_segmentInfo_iCurrentPosition() { }

	// RVA: 0x1BB3808 Offset: 0x1BB3808 VA: 0x1BB3808
	public int get_segmentInfo_iPreEntryDuration() { }

	// RVA: 0x1BB3890 Offset: 0x1BB3890 VA: 0x1BB3890
	public int get_segmentInfo_iActiveDuration() { }

	// RVA: 0x1BB3918 Offset: 0x1BB3918 VA: 0x1BB3918
	public int get_segmentInfo_iPostExitDuration() { }

	// RVA: 0x1BB39A0 Offset: 0x1BB39A0 VA: 0x1BB39A0
	public int get_segmentInfo_iRemainingLookAheadTime() { }

	// RVA: 0x1BB3A28 Offset: 0x1BB3A28 VA: 0x1BB3A28
	public float get_segmentInfo_fBeatDuration() { }

	// RVA: 0x1BB3AB0 Offset: 0x1BB3AB0 VA: 0x1BB3AB0
	public float get_segmentInfo_fBarDuration() { }

	// RVA: 0x1BB3B38 Offset: 0x1BB3B38 VA: 0x1BB3B38
	public float get_segmentInfo_fGridDuration() { }

	// RVA: 0x1BB3BC0 Offset: 0x1BB3BC0 VA: 0x1BB3BC0
	public float get_segmentInfo_fGridOffset() { }

	// RVA: 0x1BB3C48 Offset: 0x1BB3C48 VA: 0x1BB3C48
	public AkCallbackType get_musicSyncType() { }

	// RVA: 0x1BB3CD0 Offset: 0x1BB3CD0 VA: 0x1BB3CD0
	public string get_userCueName() { }

	// RVA: 0x1BB3D94 Offset: 0x1BB3D94 VA: 0x1BB3D94
	public void .ctor() { }
}
