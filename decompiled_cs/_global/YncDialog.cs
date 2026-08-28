// Namespace: 
public class YncDialog : BaseView // TypeDefIndex: 5824
{
	// Fields
	private Button mCloseBtn; // 0x30
	private Text mContext; // 0x34
	private Button mNoBtn; // 0x38
	private AlertManager.Param mParam; // 0x3C
	private Text mTitle; // 0x40
	private Button mYesBtn; // 0x44
	private float mAutoCloseTime; // 0x48

	// Methods

	// RVA: 0x1345090 Offset: 0x1345090 VA: 0x1345090
	public void .ctor() { }

	// RVA: 0x1345108 Offset: 0x1345108 VA: 0x1345108 Slot: 19
	public override void InitViews() { }

	// RVA: 0x134510C Offset: 0x134510C VA: 0x134510C Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0x13457D8 Offset: 0x13457D8 VA: 0x13457D8 Slot: 26
	public override void OnViewClose() { }

	// RVA: 0x13459BC Offset: 0x13459BC VA: 0x13459BC Slot: 23
	public override void OnViewOpen(object[] args) { }

	// RVA: 0x13459C0 Offset: 0x13459C0 VA: 0x13459C0 Slot: 24
	public override void OnTick() { }

	// RVA: 0x1345ABC Offset: 0x1345ABC VA: 0x1345ABC
	private void AddBtnListener(Button btn, UnityAction action) { }

	// RVA: 0x1345C94 Offset: 0x1345C94 VA: 0x1345C94
	private void RefreshAsYesAndNo() { }

	// RVA: 0x1345FC8 Offset: 0x1345FC8 VA: 0x1345FC8
	private void RefreshAsYesOnly() { }

	// RVA: 0x1346250 Offset: 0x1346250 VA: 0x1346250
	private void RefreshAsTextOnly() { }

	// RVA: 0x1345114 Offset: 0x1345114 VA: 0x1345114
	private void ResetParam(object[] args) { }

	// RVA: 0x13463AC Offset: 0x13463AC VA: 0x13463AC Slot: 30
	protected override void Esc() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AF4C Offset: 0x57AF4C VA: 0x57AF4C
	// RVA: 0x1346650 Offset: 0x1346650 VA: 0x1346650
	private void <ResetParam>b__17_0(Transform root) { }
}
