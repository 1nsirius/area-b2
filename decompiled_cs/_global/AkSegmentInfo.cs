// Namespace: 
public class AkSegmentInfo : IDisposable // TypeDefIndex: 5950
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public int iCurrentPosition { get; set; }
	public int iPreEntryDuration { get; set; }
	public int iActiveDuration { get; set; }
	public int iPostExitDuration { get; set; }
	public int iRemainingLookAheadTime { get; set; }
	public float fBeatDuration { get; set; }
	public float fBarDuration { get; set; }
	public float fGridDuration { get; set; }
	public float fGridOffset { get; set; }

	// Methods

	// RVA: 0x1672580 Offset: 0x1672580 VA: 0x1672580
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x16725A8 Offset: 0x16725A8 VA: 0x16725A8
	internal static IntPtr getCPtr(AkSegmentInfo obj) { }

	// RVA: 0x1672600 Offset: 0x1672600 VA: 0x1672600 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x167262C Offset: 0x167262C VA: 0x167262C Slot: 1
	protected override void Finalize() { }

	// RVA: 0x16726A0 Offset: 0x16726A0 VA: 0x16726A0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x16728FC Offset: 0x16728FC VA: 0x16728FC
	public void set_iCurrentPosition(int value) { }

	// RVA: 0x1672A7C Offset: 0x1672A7C VA: 0x1672A7C
	public int get_iCurrentPosition() { }

	// RVA: 0x1672BEC Offset: 0x1672BEC VA: 0x1672BEC
	public void set_iPreEntryDuration(int value) { }

	// RVA: 0x1672D6C Offset: 0x1672D6C VA: 0x1672D6C
	public int get_iPreEntryDuration() { }

	// RVA: 0x1672EDC Offset: 0x1672EDC VA: 0x1672EDC
	public void set_iActiveDuration(int value) { }

	// RVA: 0x167305C Offset: 0x167305C VA: 0x167305C
	public int get_iActiveDuration() { }

	// RVA: 0x16731CC Offset: 0x16731CC VA: 0x16731CC
	public void set_iPostExitDuration(int value) { }

	// RVA: 0x167334C Offset: 0x167334C VA: 0x167334C
	public int get_iPostExitDuration() { }

	// RVA: 0x16734BC Offset: 0x16734BC VA: 0x16734BC
	public void set_iRemainingLookAheadTime(int value) { }

	// RVA: 0x1673644 Offset: 0x1673644 VA: 0x1673644
	public int get_iRemainingLookAheadTime() { }

	// RVA: 0x16737BC Offset: 0x16737BC VA: 0x16737BC
	public void set_fBeatDuration(float value) { }

	// RVA: 0x1673938 Offset: 0x1673938 VA: 0x1673938
	public float get_fBeatDuration() { }

	// RVA: 0x1673AA8 Offset: 0x1673AA8 VA: 0x1673AA8
	public void set_fBarDuration(float value) { }

	// RVA: 0x1673C28 Offset: 0x1673C28 VA: 0x1673C28
	public float get_fBarDuration() { }

	// RVA: 0x1673D98 Offset: 0x1673D98 VA: 0x1673D98
	public void set_fGridDuration(float value) { }

	// RVA: 0x1673F18 Offset: 0x1673F18 VA: 0x1673F18
	public float get_fGridDuration() { }

	// RVA: 0x1674088 Offset: 0x1674088 VA: 0x1674088
	public void set_fGridOffset(float value) { }

	// RVA: 0x1674208 Offset: 0x1674208 VA: 0x1674208
	public float get_fGridOffset() { }

	// RVA: 0x1674378 Offset: 0x1674378 VA: 0x1674378
	public void .ctor() { }
}
