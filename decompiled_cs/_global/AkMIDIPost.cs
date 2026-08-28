// Namespace: 
public class AkMIDIPost : AkMIDIEvent // TypeDefIndex: 5925
{
	// Fields
	private IntPtr swigCPtr; // 0x10

	// Properties
	public uint uOffset { get; set; }

	// Methods

	// RVA: 0x1BAFF0C Offset: 0x1BAFF0C VA: 0x1BAFF0C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BAFFB4 Offset: 0x1BAFFB4 VA: 0x1BAFFB4
	internal static IntPtr getCPtr(AkMIDIPost obj) { }

	// RVA: 0x1BB000C Offset: 0x1BB000C VA: 0x1BB000C Slot: 5
	internal override void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB00B4 Offset: 0x1BB00B4 VA: 0x1BB00B4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB0120 Offset: 0x1BB0120 VA: 0x1BB0120 Slot: 6
	public override void Dispose() { }

	// RVA: 0x1BB02AC Offset: 0x1BB02AC VA: 0x1BB02AC
	public void set_uOffset(uint value) { }

	// RVA: 0x1BB033C Offset: 0x1BB033C VA: 0x1BB033C
	public uint get_uOffset() { }

	// RVA: 0x1BB03C4 Offset: 0x1BB03C4 VA: 0x1BB03C4
	public AKRESULT PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts) { }

	// RVA: 0x1BB04C4 Offset: 0x1BB04C4 VA: 0x1BB04C4
	public void Clone(AkMIDIPost other) { }

	// RVA: 0x1BB059C Offset: 0x1BB059C VA: 0x1BB059C
	public static int GetSizeOf() { }

	// RVA: 0x1BB0618 Offset: 0x1BB0618 VA: 0x1BB0618
	public void .ctor() { }
}
