// Namespace: 
public class UIBattleCrosshair // TypeDefIndex: 5743
{
	// Fields
	private AssetPool mAssetPool; // 0x8
	public readonly Dictionary<int, BaseCrosshairCtrl> crosshairCtrlDic; // 0xC
	private BaseCrosshairCtrl _curCrosshairCtrl; // 0x10
	private RectTransform crosshairsRt; // 0x14
	private Action<AimPointEvt> _evtSampler; // 0x18
	private readonly Dictionary<string, GameObject> mCrossHairGameObjectCache; // 0x1C

	// Methods

	// RVA: 0xB26418 Offset: 0xB26418 VA: 0xB26418
	public void .ctor(AssetPool assetPool, BehaviorSubject<AimPointEvt> aimPointObservable, Transform cacheTrans, Action<AimPointEvt> evtSampler) { }

	// RVA: 0xB265D4 Offset: 0xB265D4 VA: 0xB265D4
	public void Optimise(List<string> preInstantiateCrossHairNames) { }

	// RVA: 0xB269B8 Offset: 0xB269B8 VA: 0xB269B8
	public void Show(bool needShow) { }

	// RVA: 0xB269D4 Offset: 0xB269D4 VA: 0xB269D4
	public void UpdateSize(float radius) { }

	// RVA: 0xB269F0 Offset: 0xB269F0 VA: 0xB269F0
	public void Tick() { }

	// RVA: 0xB26A0C Offset: 0xB26A0C VA: 0xB26A0C
	private void onAimPointChanged(AimPointEvt evt) { }

	// RVA: 0xB26BB8 Offset: 0xB26BB8 VA: 0xB26BB8
	private void HideCrosshair() { }

	// RVA: 0xB26BF0 Offset: 0xB26BF0 VA: 0xB26BF0
	private void ChangeCrosshair(int typeId) { }

	// RVA: 0xB270C4 Offset: 0xB270C4 VA: 0xB270C4
	private void ChangeCrosshair(BaseCrosshairCtrl ctrl) { }

	// RVA: 0xB26CC4 Offset: 0xB26CC4 VA: 0xB26CC4
	private BaseCrosshairCtrl LoadCrosshirCtrl(int typeId) { }

	// RVA: 0xB2711C Offset: 0xB2711C VA: 0xB2711C
	private void onAimPointCompleted() { }

	// RVA: 0xB27120 Offset: 0xB27120 VA: 0xB27120
	public bool IsCanShoot() { }
}
