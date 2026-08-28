// Namespace: 
public class MarkTipComp : MonoBehaviour // TypeDefIndex: 5691
{
	// Fields
	private static readonly int sStateKey; // 0x0
	[SerializeField] // RVA: 0x55E52C Offset: 0x55E52C VA: 0x55E52C
	private Text mDistance; // 0xC
	[SerializeField] // RVA: 0x55E53C Offset: 0x55E53C VA: 0x55E53C
	private Transform mScaleNode; // 0x10
	[SerializeField] // RVA: 0x55E54C Offset: 0x55E54C VA: 0x55E54C
	private Text mPlace; // 0x14
	[HideInInspector] // RVA: 0x55E55C Offset: 0x55E55C VA: 0x55E55C
	[SerializeField] // RVA: 0x55E55C Offset: 0x55E55C VA: 0x55E55C
	private bool mVisible; // 0x18

	// Properties
	public Text Distance { get; }
	public RectTransform RectTransform { get; }
	public Text Place { get; }
	public bool Visible { set; }

	// Methods

	// RVA: 0x2CD89C8 Offset: 0x2CD89C8 VA: 0x2CD89C8
	public Text get_Distance() { }

	// RVA: 0x2CD89D0 Offset: 0x2CD89D0 VA: 0x2CD89D0
	public RectTransform get_RectTransform() { }

	// RVA: 0x2CD8A58 Offset: 0x2CD8A58 VA: 0x2CD8A58
	public Text get_Place() { }

	// RVA: 0x2CD8A60 Offset: 0x2CD8A60 VA: 0x2CD8A60
	public void set_Visible(bool value) { }

	// RVA: 0x2CD8AEC Offset: 0x2CD8AEC VA: 0x2CD8AEC
	public void SetScale(float scale) { }

	// RVA: 0x2CD8BC4 Offset: 0x2CD8BC4 VA: 0x2CD8BC4
	public void .ctor() { }

	// RVA: 0x2CD8BCC Offset: 0x2CD8BCC VA: 0x2CD8BCC
	private static void .cctor() { }
}
