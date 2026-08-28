// Namespace: 
public class CustomizableController : BaseView // TypeDefIndex: 5621
{
	// Fields
	private Canvas mCanvas; // 0x30
	private CustomizableProxy mCurrentComp; // 0x34
	private bool mDirty; // 0x38
	private Button mExitBtn; // 0x3C
	private bool mIgnoreDirty; // 0x40
	private Button mResetBtn; // 0x44
	private Button mSaveBtn; // 0x48
	private CustomizableToolbar mToolbar; // 0x4C
	private LanguageMono mTitle; // 0x50
	private bool mUserClose; // 0x54

	// Properties
	private bool Dirty { get; set; }

	// Methods

	// RVA: 0xD64F88 Offset: 0xD64F88 VA: 0xD64F88
	public void .ctor() { }

	// RVA: 0xD64FF4 Offset: 0xD64FF4 VA: 0xD64FF4
	private bool get_Dirty() { }

	// RVA: 0xD64FFC Offset: 0xD64FFC VA: 0xD64FFC
	private void set_Dirty(bool value) { }

	// RVA: 0xD6500C Offset: 0xD6500C VA: 0xD6500C Slot: 19
	public override void InitViews() { }

	// RVA: 0xD65EF8 Offset: 0xD65EF8 VA: 0xD65EF8 Slot: 24
	public override void OnTick() { }

	// RVA: 0xD667DC Offset: 0xD667DC VA: 0xD667DC Slot: 26
	public override void OnViewClose() { }

	// RVA: 0xD667FC Offset: 0xD667FC VA: 0xD667FC Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xD66828 Offset: 0xD66828 VA: 0xD66828 Slot: 23
	public override void OnViewOpen(object[] args) { }

	// RVA: 0xD65D80 Offset: 0xD65D80 VA: 0xD65D80
	private void AddToolbarListeners() { }

	// RVA: 0xD66B6C Offset: 0xD66B6C VA: 0xD66B6C
	private void CloseUi() { }

	// RVA: 0xD66CE4 Offset: 0xD66CE4 VA: 0xD66CE4
	private void HandleOnDragComp(Vector2 deltaVector2) { }

	// RVA: 0xD66ED4 Offset: 0xD66ED4 VA: 0xD66ED4
	private void HandleOnSelectComp(CustomizableProxy comp) { }

	// RVA: 0xD656C0 Offset: 0xD656C0 VA: 0xD656C0
	private void InitBtns() { }

	// RVA: 0xD667EC Offset: 0xD667EC VA: 0xD667EC
	private void OnDispose() { }

	// RVA: 0xD65C4C Offset: 0xD65C4C VA: 0xD65C4C
	private void OnFocusChange(CustomizableProxy comp) { }

	// RVA: 0xD65D1C Offset: 0xD65D1C VA: 0xD65D1C
	private void RefreshToolbar(CustomValue val) { }

	// RVA: 0xD66FC0 Offset: 0xD66FC0 VA: 0xD66FC0
	private void Save() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A4FC Offset: 0x57A4FC VA: 0x57A4FC
	// RVA: 0xD67618 Offset: 0xD67618 VA: 0xD67618
	private void <AddToolbarListeners>g__HandleOnMove|19_0(Vector2 step) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A50C Offset: 0x57A50C VA: 0x57A50C
	// RVA: 0xD677E8 Offset: 0xD677E8 VA: 0xD677E8
	private void <AddToolbarListeners>g__HandleOnSetAlpha|19_1(float alpha) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A51C Offset: 0x57A51C VA: 0x57A51C
	// RVA: 0xD67900 Offset: 0xD67900 VA: 0xD67900
	private void <AddToolbarListeners>g__HandleOnSetScale|19_2(float scale) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A52C Offset: 0x57A52C VA: 0x57A52C
	// RVA: 0xD67A20 Offset: 0xD67A20 VA: 0xD67A20
	private void <InitBtns>g__OnSave|23_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A53C Offset: 0x57A53C VA: 0x57A53C
	// RVA: 0xD67A24 Offset: 0xD67A24 VA: 0xD67A24
	private void <InitBtns>g__OnReset|23_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A54C Offset: 0x57A54C VA: 0x57A54C
	// RVA: 0xD67D28 Offset: 0xD67D28 VA: 0xD67D28
	private void <InitBtns>g__OnExit|23_2() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A55C Offset: 0x57A55C VA: 0x57A55C
	// RVA: 0xD6807C Offset: 0xD6807C VA: 0xD6807C
	private void <InitBtns>g__OnYes|23_3() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A56C Offset: 0x57A56C VA: 0x57A56C
	// RVA: 0xD68098 Offset: 0xD68098 VA: 0xD68098
	private void <InitBtns>g__OnNo|23_4() { }
}
