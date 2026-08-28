// Namespace: 
[DefaultMemberAttribute] // RVA: 0x551098 Offset: 0x551098 VA: 0x551098
public class AkMIDIPostArray // TypeDefIndex: 6013
{
	// Fields
	private readonly int m_Count; // 0x8
	private readonly int SIZE_OF; // 0xC
	private IntPtr m_Buffer; // 0x10

	// Properties
	public AkMIDIPost Item { get; set; }

	// Methods

	// RVA: 0x1BB06A8 Offset: 0x1BB06A8 VA: 0x1BB06A8
	public void .ctor(int size) { }

	// RVA: 0x1BB0788 Offset: 0x1BB0788 VA: 0x1BB0788
	public AkMIDIPost get_Item(int index) { }

	// RVA: 0x1BB08C4 Offset: 0x1BB08C4 VA: 0x1BB08C4
	public void set_Item(int index, AkMIDIPost value) { }

	// RVA: 0x1BB0A28 Offset: 0x1BB0A28 VA: 0x1BB0A28 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB0B08 Offset: 0x1BB0B08 VA: 0x1BB0B08
	public void PostOnEvent(uint in_eventID, GameObject gameObject) { }

	// RVA: 0x1BB0C08 Offset: 0x1BB0C08 VA: 0x1BB0C08
	public void PostOnEvent(uint in_eventID, GameObject gameObject, int count) { }

	// RVA: 0x1BB0D6C Offset: 0x1BB0D6C VA: 0x1BB0D6C
	public IntPtr GetBuffer() { }

	// RVA: 0x1BB0D74 Offset: 0x1BB0D74 VA: 0x1BB0D74
	public int Count() { }

	// RVA: 0x1BB088C Offset: 0x1BB088C VA: 0x1BB088C
	private IntPtr GetObjectPtr(int index) { }
}
