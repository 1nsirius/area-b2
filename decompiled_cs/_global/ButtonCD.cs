// Namespace: 
public class ButtonCD : MonoBehaviour // TypeDefIndex: 5636
{
	// Fields
	[SerializeField] // RVA: 0x55E1E4 Offset: 0x55E1E4 VA: 0x55E1E4
	private ButtonCD.CD_CLICK_TYPE clickType; // 0xC
	[SerializeField] // RVA: 0x55E1F4 Offset: 0x55E1F4 VA: 0x55E1F4
	protected Button _button; // 0x10
	[SerializeField] // RVA: 0x55E204 Offset: 0x55E204 VA: 0x55E204
	protected Image _cdImg; // 0x14
	[SerializeField] // RVA: 0x55E214 Offset: 0x55E214 VA: 0x55E214
	private Color _enbleFgColor; // 0x18
	[SerializeField] // RVA: 0x55E224 Offset: 0x55E224 VA: 0x55E224
	private Color _disableFgColor; // 0x28
	[SerializeField] // RVA: 0x55E234 Offset: 0x55E234 VA: 0x55E234
	protected Image _fgImg; // 0x38
	[SerializeField] // RVA: 0x55E244 Offset: 0x55E244 VA: 0x55E244
	private Color _enbleBgColor; // 0x3C
	[SerializeField] // RVA: 0x55E254 Offset: 0x55E254 VA: 0x55E254
	private Color _disableBgColor; // 0x4C
	[SerializeField] // RVA: 0x55E264 Offset: 0x55E264 VA: 0x55E264
	protected Image _bgImg; // 0x5C
	[SerializeField] // RVA: 0x55E274 Offset: 0x55E274 VA: 0x55E274
	private Color _enbleCycleTimesColor; // 0x60
	[SerializeField] // RVA: 0x55E284 Offset: 0x55E284 VA: 0x55E284
	private Color _disableCycleTimesColor; // 0x70
	[SerializeField] // RVA: 0x55E294 Offset: 0x55E294 VA: 0x55E294
	protected Text _cycleConter; // 0x80
	[SerializeField] // RVA: 0x55E2A4 Offset: 0x55E2A4 VA: 0x55E2A4
	protected bool ignoreTimeScale; // 0x84
	private int _totalCdTimes; // 0x88
	private int _remainTimes; // 0x8C
	private float _duration; // 0x90
	private float _startTime; // 0x94
	private float _totalTime; // 0x98
	private bool _fill; // 0x9C
	private bool _clockwise; // 0x9D
	private bool _setColor; // 0x9E
	[CompilerGeneratedAttribute] // RVA: 0x55E2B4 Offset: 0x55E2B4 VA: 0x55E2B4
	private float <Progress>k__BackingField; // 0xA0
	protected Transform _tran; // 0xA4
	protected ButtonCD.CD_STATE _cdState; // 0xA8
	public UnityAction<PointerEventData> onPointClickEvent; // 0xAC
	public UnityAction<PointerEventData> onPointClickUpEvent; // 0xB0
	public UnityAction<PointerEventData> onPointClickDownEvent; // 0xB4
	public UnityAction onButtonClickEvent; // 0xB8
	public UnityAction onCDCompletedEvent; // 0xBC

	// Properties
	public float Progress { get; set; }
	protected ButtonCD.CD_STATE CDState { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A77C Offset: 0x57A77C VA: 0x57A77C
	// RVA: 0xD4AE08 Offset: 0xD4AE08 VA: 0xD4AE08
	protected void set_Progress(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A78C Offset: 0x57A78C VA: 0x57A78C
	// RVA: 0xD4AE10 Offset: 0xD4AE10 VA: 0xD4AE10
	public float get_Progress() { }

	// RVA: 0xD4AE18 Offset: 0xD4AE18 VA: 0xD4AE18
	protected void set_CDState(ButtonCD.CD_STATE value) { }

	// RVA: 0xD4AE68 Offset: 0xD4AE68 VA: 0xD4AE68
	protected ButtonCD.CD_STATE get_CDState() { }

	// RVA: 0xD4AE70 Offset: 0xD4AE70 VA: 0xD4AE70 Slot: 4
	protected virtual void Awake() { }

	// RVA: 0xD4B1C8 Offset: 0xD4B1C8 VA: 0xD4B1C8
	private void AddListener() { }

	// RVA: 0xD4B458 Offset: 0xD4B458 VA: 0xD4B458
	private void Update() { }

	// RVA: 0xD4B48C Offset: 0xD4B48C VA: 0xD4B48C Slot: 5
	protected virtual void OnBeforeCDStateChanged(ButtonCD.CD_STATE curState, ButtonCD.CD_STATE targetState) { }

	// RVA: 0xD4B490 Offset: 0xD4B490 VA: 0xD4B490 Slot: 6
	protected virtual void OnAfterCDStateChanged() { }

	// RVA: 0xD4B494 Offset: 0xD4B494 VA: 0xD4B494 Slot: 7
	protected virtual void OnCDingState() { }

	// RVA: 0xD4B7F8 Offset: 0xD4B7F8 VA: 0xD4B7F8 Slot: 8
	protected virtual void OnCDCompletedState() { }

	// RVA: 0xD4B938 Offset: 0xD4B938 VA: 0xD4B938 Slot: 9
	protected virtual void SetWidgetsColor(bool enableState = True) { }

	// RVA: 0xD4B700 Offset: 0xD4B700 VA: 0xD4B700
	private void SetCDText() { }

	// RVA: 0xD4BCC0 Offset: 0xD4BCC0 VA: 0xD4BCC0
	private void SetCDMode(bool clockWise) { }

	// RVA: 0xD4BDAC Offset: 0xD4BDAC VA: 0xD4BDAC
	private void OnEnable() { }

	// RVA: 0xD4BDBC Offset: 0xD4BDBC VA: 0xD4BDBC
	private void CheckActive() { }

	// RVA: 0xD4BEC8 Offset: 0xD4BEC8 VA: 0xD4BEC8
	private void OnDisable() { }

	// RVA: 0xD4BECC Offset: 0xD4BECC VA: 0xD4BECC
	public static ButtonCD PerformCDOperation(GameObject go, float duration, bool fill = True, bool clockwise = True, bool setColor = True, bool ignoreTimeScale = True) { }

	// RVA: 0xD4B6E4 Offset: 0xD4B6E4 VA: 0xD4B6E4
	private float GetCurrentTime() { }

	// RVA: 0xD4C1B8 Offset: 0xD4C1B8 VA: 0xD4C1B8
	public static void CancleCDOperation(GameObject go) { }

	// RVA: 0xD4C298 Offset: 0xD4C298 VA: 0xD4C298
	public void Take(int cdTimes) { }

	// RVA: 0xD4C3FC Offset: 0xD4C3FC VA: 0xD4C3FC
	public bool IsInCDing() { }

	// RVA: 0xD4B820 Offset: 0xD4B820 VA: 0xD4B820
	private void ResetSelf() { }

	// RVA: 0xD4C40C Offset: 0xD4C40C VA: 0xD4C40C
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A79C Offset: 0x57A79C VA: 0x57A79C
	// RVA: 0xD4C580 Offset: 0xD4C580 VA: 0xD4C580
	private void <AddListener>b__38_0(PointerEventData pointEvtData) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A7AC Offset: 0x57A7AC VA: 0x57A7AC
	// RVA: 0xD4C60C Offset: 0xD4C60C VA: 0xD4C60C
	private void <AddListener>b__38_1(PointerEventData pointEvtData) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A7BC Offset: 0x57A7BC VA: 0x57A7BC
	// RVA: 0xD4C698 Offset: 0xD4C698 VA: 0xD4C698
	private void <AddListener>b__38_2(PointerEventData pointEvtData) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A7CC Offset: 0x57A7CC VA: 0x57A7CC
	// RVA: 0xD4C724 Offset: 0xD4C724 VA: 0xD4C724
	private void <AddListener>b__38_3() { }
}
