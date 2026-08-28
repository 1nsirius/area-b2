// Namespace: 
public class LocalToolBaseCtrlr.State_Equip : LocalToolBaseCtrlr.State // TypeDefIndex: 12902
{
	// Fields
	protected bool mWithAssist; // 0x14
	protected Conduct mConduct; // 0x18
	protected Action mCallback; // 0x1C
	private bool mNeedSendToServer; // 0x20

	// Methods

	// RVA: 0xDB8B98 Offset: 0xDB8B98 VA: 0xDB8B98 Slot: 8
	public override void InitStateTranslate() { }

	// RVA: 0xDB8B9C Offset: 0xDB8B9C VA: 0xDB8B9C Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xDB8F48 Offset: 0xDB8F48 VA: 0xDB8F48 Slot: 41
	protected virtual void OnEquipped() { }

	// RVA: 0xDB9068 Offset: 0xDB9068 VA: 0xDB9068 Slot: 34
	public override void update() { }

	// RVA: 0xDB9090 Offset: 0xDB9090 VA: 0xDB9090
	public void MakeCurrent(Action callback, bool withAssist, bool needSendToServer) { }

	// RVA: 0xDB90A0 Offset: 0xDB90A0 VA: 0xDB90A0 Slot: 33
	public override void leave() { }

	// RVA: 0xDB9130 Offset: 0xDB9130 VA: 0xDB9130
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x668180 Offset: 0x668180 VA: 0x668180
	// RVA: 0xDB9134 Offset: 0xDB9134 VA: 0xDB9134
	private void <enter>b__5_0() { }
}
