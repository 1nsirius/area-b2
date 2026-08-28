// Namespace: 
private class LocalPadCtrlr.State_Active : LocalToolBaseCtrlr.State // TypeDefIndex: 12889
{
	// Fields
	private float mDuration; // 0x14
	private float mActionTime; // 0x18
	private Action mAction; // 0x1C
	private Conduct mConduct; // 0x20

	// Properties
	private LocalPadCtrlr ToolCtrlr { get; }
	public override bool AllowUnequip { get; }

	// Methods

	// RVA: 0xC3C5FC Offset: 0xC3C5FC VA: 0xC3C5FC
	private LocalPadCtrlr get_ToolCtrlr() { }

	// RVA: 0xC3C6FC Offset: 0xC3C6FC VA: 0xC3C6FC Slot: 28
	public override bool get_AllowUnequip() { }

	// RVA: 0xC3C704 Offset: 0xC3C704 VA: 0xC3C704 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xC3C954 Offset: 0xC3C954 VA: 0xC3C954 Slot: 34
	public override void update() { }

	// RVA: 0xC3C980 Offset: 0xC3C980 VA: 0xC3C980 Slot: 33
	public override void leave() { }

	// RVA: 0xC3CA14 Offset: 0xC3CA14 VA: 0xC3CA14
	public void MakeCurrent(float duration, float actionTime, Action action) { }

	// RVA: 0xC3CA24 Offset: 0xC3CA24 VA: 0xC3CA24
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x668100 Offset: 0x668100 VA: 0x668100
	// RVA: 0xC3CA2C Offset: 0xC3CA2C VA: 0xC3CA2C
	private void <enter>b__8_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x668110 Offset: 0x668110 VA: 0x668110
	// RVA: 0xC3CB58 Offset: 0xC3CB58 VA: 0xC3CB58
	private void <enter>b__8_1() { }
}
