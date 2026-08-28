// Namespace: 
[DefaultMemberAttribute] // RVA: 0x551030 Offset: 0x551030 VA: 0x551030
public class AkAuxSendArray : IDisposable // TypeDefIndex: 6008
{
	// Fields
	private const int MAX_COUNT = 4;
	private readonly int SIZE_OF_AKAUXSENDVALUE; // 0x8
	private IntPtr m_Buffer; // 0xC
	private int m_Count; // 0x10

	// Properties
	public AkAuxSendValue Item { get; }
	public bool isFull { get; }

	// Methods

	// RVA: 0xFDAD94 Offset: 0xFDAD94 VA: 0xFDAD94
	public void .ctor() { }

	// RVA: 0xFDAE6C Offset: 0xFDAE6C VA: 0xFDAE6C
	public AkAuxSendValue get_Item(int index) { }

	// RVA: 0xFDAFD8 Offset: 0xFDAFD8 VA: 0xFDAFD8
	public bool get_isFull() { }

	// RVA: 0xFDB044 Offset: 0xFDB044 VA: 0xFDB044 Slot: 4
	public void Dispose() { }

	// RVA: 0xFDB0F0 Offset: 0xFDB0F0 VA: 0xFDB0F0 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFDB154 Offset: 0xFDB154 VA: 0xFDB154
	public void Reset() { }

	// RVA: 0xFDB160 Offset: 0xFDB160 VA: 0xFDB160
	public bool Add(GameObject in_listenerGameObj, uint in_AuxBusID, float in_fValue) { }

	// RVA: 0xFDB2AC Offset: 0xFDB2AC VA: 0xFDB2AC
	public bool Add(uint in_AuxBusID, float in_fValue) { }

	// RVA: 0xFDB3B4 Offset: 0xFDB3B4 VA: 0xFDB3B4
	public bool Contains(GameObject in_listenerGameObj, uint in_AuxBusID) { }

	// RVA: 0xFDB524 Offset: 0xFDB524 VA: 0xFDB524
	public bool Contains(uint in_AuxBusID) { }

	// RVA: 0xFDB644 Offset: 0xFDB644 VA: 0xFDB644
	public AKRESULT SetValues(GameObject gameObject) { }

	// RVA: 0xFDB72C Offset: 0xFDB72C VA: 0xFDB72C
	public AKRESULT GetValues(GameObject gameObject) { }

	// RVA: 0xFDB820 Offset: 0xFDB820 VA: 0xFDB820
	public IntPtr GetBuffer() { }

	// RVA: 0xFDB828 Offset: 0xFDB828 VA: 0xFDB828
	public int Count() { }

	// RVA: 0xFDAF78 Offset: 0xFDAF78 VA: 0xFDAF78
	private IntPtr GetObjectPtr(int index) { }
}
