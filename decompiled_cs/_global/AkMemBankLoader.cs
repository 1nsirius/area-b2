// Namespace: 
public class AkMemBankLoader : MonoBehaviour // TypeDefIndex: 6072
{
	// Fields
	private const int WaitMs = 50;
	private const long AK_BANK_PLATFORM_DATA_ALIGNMENT = 16;
	private const long AK_BANK_PLATFORM_DATA_ALIGNMENT_MASK = 15;
	public string bankName; // 0xC
	public bool isLocalizedBank; // 0x10
	private string m_bankPath; // 0x14
	[HideInInspector] // RVA: 0x55FDC8 Offset: 0x55FDC8 VA: 0x55FDC8
	public uint ms_bankID; // 0x18
	private IntPtr ms_pInMemoryBankPtr; // 0x1C
	private GCHandle ms_pinnedArray; // 0x20
	private UnityWebRequest ms_www; // 0x24

	// Methods

	// RVA: 0x1BB1384 Offset: 0x1BB1384 VA: 0x1BB1384
	private void Start() { }

	// RVA: 0x1BB14DC Offset: 0x1BB14DC VA: 0x1BB14DC
	public void LoadNonLocalizedBank(string in_bankFilename) { }

	// RVA: 0x1BB139C Offset: 0x1BB139C VA: 0x1BB139C
	public void LoadLocalizedBank(string in_bankFilename) { }

	// RVA: 0x1BB1600 Offset: 0x1BB1600 VA: 0x1BB1600
	private uint AllocateAlignedBuffer(byte[] data) { }

	[IteratorStateMachineAttribute] // RVA: 0x57B3EC Offset: 0x57B3EC VA: 0x57B3EC
	// RVA: 0x1BB18D8 Offset: 0x1BB18D8 VA: 0x1BB18D8
	private IEnumerator LoadFile() { }

	// RVA: 0x1BB15D8 Offset: 0x1BB15D8 VA: 0x1BB15D8
	private void DoLoadBank(string in_bankPath) { }

	// RVA: 0x1BB1984 Offset: 0x1BB1984 VA: 0x1BB1984
	private void OnDestroy() { }

	// RVA: 0x1BB1A44 Offset: 0x1BB1A44 VA: 0x1BB1A44
	public void .ctor() { }
}
