// Namespace: 
internal class UIBattleFPControl.Node // TypeDefIndex: 5755
{
	// Fields
	public Image Bg; // 0x8
	public UIEventListener EventListener; // 0xC
	public Image Fg; // 0x10
	protected bool mEnable; // 0x14
	protected Action mOnTickAction; // 0x18
	protected RectTransform mRoot; // 0x1C
	protected bool mVisible; // 0x20
	public Text Txt; // 0x24

	// Methods

	// RVA: 0xB34F4C Offset: 0xB34F4C VA: 0xB34F4C Slot: 4
	internal virtual void Init(RectTransform root, Action ontick) { }

	// RVA: 0xB33624 Offset: 0xB33624 VA: 0xB33624
	internal void OnTick() { }

	// RVA: 0xB32BD8 Offset: 0xB32BD8 VA: 0xB32BD8
	internal void SetEnable(bool enable) { }

	// RVA: 0xB30AE0 Offset: 0xB30AE0 VA: 0xB30AE0
	internal void SetVisible(bool visible) { }

	// RVA: 0xB30408 Offset: 0xB30408 VA: 0xB30408
	public void .ctor() { }
}
