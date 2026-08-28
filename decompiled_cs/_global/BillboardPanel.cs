// Namespace: 
public class BillboardPanel : MonoBehaviour // TypeDefIndex: 5607
{
	// Fields
	[SerializeField] // RVA: 0x55DF70 Offset: 0x55DF70 VA: 0x55DF70
	private Text mTittleText; // 0xC
	[SerializeField] // RVA: 0x55DF80 Offset: 0x55DF80 VA: 0x55DF80
	private Text mContentText; // 0x10
	[SerializeField] // RVA: 0x55DF90 Offset: 0x55DF90 VA: 0x55DF90
	private RawImage mTittleImage; // 0x14
	[SerializeField] // RVA: 0x55DFA0 Offset: 0x55DFA0 VA: 0x55DFA0
	private RawImage mContentImage; // 0x18
	[SerializeField] // RVA: 0x55DFB0 Offset: 0x55DFB0 VA: 0x55DFB0
	private string mConfigRelativePath; // 0x1C

	// Methods

	// RVA: 0xCC34E0 Offset: 0xCC34E0 VA: 0xCC34E0
	private void Start() { }

	// RVA: 0xCC34E4 Offset: 0xCC34E4 VA: 0xCC34E4
	private void LoadConfig() { }

	// RVA: 0xCC369C Offset: 0xCC369C VA: 0xCC369C
	private void GetText(Text uiText, string relativePath) { }

	// RVA: 0xCC385C Offset: 0xCC385C VA: 0xCC385C
	private void GetTittleImage(string relativePath) { }

	// RVA: 0xCC3948 Offset: 0xCC3948 VA: 0xCC3948
	private void GetContentImage(string relativePath) { }

	[IteratorStateMachineAttribute] // RVA: 0x57A394 Offset: 0x57A394 VA: 0x57A394
	// RVA: 0xCC3C28 Offset: 0xCC3C28 VA: 0xCC3C28
	private IEnumerator GetFile(string path, Action<string> onSucceed) { }

	[IteratorStateMachineAttribute] // RVA: 0x57A40C Offset: 0x57A40C VA: 0x57A40C
	// RVA: 0xCC3AD8 Offset: 0xCC3AD8 VA: 0xCC3AD8
	private IEnumerator GetTittleImage_Inner(string relativePath) { }

	[IteratorStateMachineAttribute] // RVA: 0x57A484 Offset: 0x57A484 VA: 0x57A484
	// RVA: 0xCC3B80 Offset: 0xCC3B80 VA: 0xCC3B80
	private IEnumerator GetContentImage_Inner(string relativePath) { }

	// RVA: 0xCC3A1C Offset: 0xCC3A1C VA: 0xCC3A1C
	private void MakeTransparent(RawImage image) { }

	// RVA: 0xCC3D30 Offset: 0xCC3D30 VA: 0xCC3D30
	private void MakeOpacity(RawImage image) { }

	// RVA: 0xCC3DF0 Offset: 0xCC3DF0 VA: 0xCC3DF0
	public void .ctor() { }
}
