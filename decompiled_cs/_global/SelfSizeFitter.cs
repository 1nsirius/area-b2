// Namespace: 
[AddComponentMenu] // RVA: 0x550470 Offset: 0x550470 VA: 0x550470
[ExecuteAlways] // RVA: 0x550470 Offset: 0x550470 VA: 0x550470
[RequireComponent] // RVA: 0x550470 Offset: 0x550470 VA: 0x550470
public class SelfSizeFitter : MonoBehaviour, ILayoutSelfController, ILayoutController // TypeDefIndex: 5490
{
	// Fields
	[SerializeField] // RVA: 0x55DB38 Offset: 0x55DB38 VA: 0x55DB38
	protected ContentSizeFitter.FitMode m_HorizontalFit; // 0xC
	[SerializeField] // RVA: 0x55DB48 Offset: 0x55DB48 VA: 0x55DB48
	protected ContentSizeFitter.FitMode m_VerticalFit; // 0x10
	[SerializeField] // RVA: 0x55DB58 Offset: 0x55DB58 VA: 0x55DB58
	private float mHighPadding; // 0x14
	private RectTransform mRectTransform; // 0x18
	[SerializeField] // RVA: 0x55DB68 Offset: 0x55DB68 VA: 0x55DB68
	private float mWidthPadding; // 0x1C
	[SerializeField] // RVA: 0x55DB78 Offset: 0x55DB78 VA: 0x55DB78
	private Graphic target; // 0x20

	// Properties
	private RectTransform RectTransform { get; }

	// Methods

	// RVA: 0xF77E00 Offset: 0xF77E00 VA: 0xF77E00
	private RectTransform get_RectTransform() { }

	// RVA: 0xF77EB4 Offset: 0xF77EB4 VA: 0xF77EB4 Slot: 6
	public virtual void SetLayoutHorizontal() { }

	// RVA: 0xF7805C Offset: 0xF7805C VA: 0xF7805C Slot: 7
	public virtual void SetLayoutVertical() { }

	// RVA: 0xF780FC Offset: 0xF780FC VA: 0xF780FC
	private void HandleOnTargetLayoutChange() { }

	// RVA: 0xF7818C Offset: 0xF7818C VA: 0xF7818C
	private void OnEnable() { }

	// RVA: 0xF782C0 Offset: 0xF782C0 VA: 0xF782C0
	private void OnDisable() { }

	// RVA: 0xF77F54 Offset: 0xF77F54 VA: 0xF77F54
	private void HandleTargetFittingAlongAxis(int axis) { }

	// RVA: 0xF783F4 Offset: 0xF783F4 VA: 0xF783F4
	public void .ctor() { }
}
