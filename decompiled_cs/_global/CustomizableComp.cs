// Namespace: 
public class CustomizableComp : MonoBehaviour // TypeDefIndex: 5620
{
	// Fields
	public bool NeedExport; // 0xC
	private CanvasGroup mCanvasGroup; // 0x10
	private CustomValue mCustomVal; // 0x14
	private CustomValue mOrigVal; // 0x24
	private RectTransform mRectTrans; // 0x34
	private bool mStarted; // 0x38
	[FormerlySerializedAsAttribute] // RVA: 0x55DFC0 Offset: 0x55DFC0 VA: 0x55DFC0
	[SerializeField] // RVA: 0x55DFC0 Offset: 0x55DFC0 VA: 0x55DFC0
	private uint mUID; // 0x3C

	// Properties
	public uint Uid { get; }

	// Methods

	// RVA: 0xD64434 Offset: 0xD64434 VA: 0xD64434
	public uint get_Uid() { }

	// RVA: 0xD6443C Offset: 0xD6443C VA: 0xD6443C
	public void Apply() { }

	// RVA: 0xD64648 Offset: 0xD64648 VA: 0xD64648
	public F2Vector2 CalcPosByDeltaVector(F2Vector2 delta) { }

	// RVA: 0xD64718 Offset: 0xD64718 VA: 0xD64718
	public CustomValue GetCustomValue() { }

	// RVA: 0xD64728 Offset: 0xD64728 VA: 0xD64728
	public uint GetUid() { }

	// RVA: 0xD64730 Offset: 0xD64730 VA: 0xD64730
	public void ResetValue() { }

	// RVA: 0xD647DC Offset: 0xD647DC VA: 0xD647DC
	public void SetCustomVal(CustomValue val) { }

	// RVA: 0xD6444C Offset: 0xD6444C VA: 0xD6444C
	private void Refresh() { }

	// RVA: 0xD647EC Offset: 0xD647EC VA: 0xD647EC
	private void Awake() { }

	// RVA: 0xD64B20 Offset: 0xD64B20 VA: 0xD64B20
	private void HandleOnChangeLayout() { }

	// RVA: 0xD64CF8 Offset: 0xD64CF8 VA: 0xD64CF8
	private void OnDestroy() { }

	// RVA: 0xD64DFC Offset: 0xD64DFC VA: 0xD64DFC
	private void Start() { }

	// RVA: 0xD64EDC Offset: 0xD64EDC VA: 0xD64EDC
	public void .ctor() { }
}
