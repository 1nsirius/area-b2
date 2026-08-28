// Namespace: 
public class ImgCDControl : MonoBehaviour // TypeDefIndex: 5648
{
	// Fields
	[SerializeField] // RVA: 0x55E344 Offset: 0x55E344 VA: 0x55E344
	protected Image _cdImg; // 0xC
	[SerializeField] // RVA: 0x55E354 Offset: 0x55E354 VA: 0x55E354
	private Color _enbleFgColor; // 0x10
	[SerializeField] // RVA: 0x55E364 Offset: 0x55E364 VA: 0x55E364
	private Color _disableFgColor; // 0x20
	[SerializeField] // RVA: 0x55E374 Offset: 0x55E374 VA: 0x55E374
	protected Image _fgImg; // 0x30
	[SerializeField] // RVA: 0x55E384 Offset: 0x55E384 VA: 0x55E384
	private Color _enbleBgColor; // 0x34
	[SerializeField] // RVA: 0x55E394 Offset: 0x55E394 VA: 0x55E394
	private Color _disableBgColor; // 0x44
	[SerializeField] // RVA: 0x55E3A4 Offset: 0x55E3A4 VA: 0x55E3A4
	protected Image _bgImg; // 0x54
	[SerializeField] // RVA: 0x55E3B4 Offset: 0x55E3B4 VA: 0x55E3B4
	private Color _enbleCycleTimesColor; // 0x58
	[SerializeField] // RVA: 0x55E3C4 Offset: 0x55E3C4 VA: 0x55E3C4
	private Color _disableCycleTimesColor; // 0x68
	[SerializeField] // RVA: 0x55E3D4 Offset: 0x55E3D4 VA: 0x55E3D4
	protected Text _cycleConter; // 0x78
	protected Transform _tran; // 0x7C

	// Methods

	// RVA: 0x2CD2554 Offset: 0x2CD2554 VA: 0x2CD2554
	protected void Awake() { }

	// RVA: 0x2CD2820 Offset: 0x2CD2820 VA: 0x2CD2820
	public void SetTimes(int remainCount, bool showNum) { }

	// RVA: 0x2CD28D4 Offset: 0x2CD28D4 VA: 0x2CD28D4
	public void SetProgress(float progress) { }

	// RVA: 0x2CD2984 Offset: 0x2CD2984 VA: 0x2CD2984
	public void .ctor() { }
}
