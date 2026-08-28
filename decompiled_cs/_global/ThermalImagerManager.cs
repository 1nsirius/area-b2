// Namespace: 
public class ThermalImagerManager : MonoBehaviour // TypeDefIndex: 5566
{
	// Fields
	public Material EffMat; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x55DED0 Offset: 0x55DED0 VA: 0x55DED0
	private ThermalImagerManager.TopMat <CurTopMat>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55DEE0 Offset: 0x55DEE0 VA: 0x55DEE0
	private Action<ThermalImagerManager.TopMat> SniperSightAimEvent; // 0x18
	private bool isSniperSightAndAiming; // 0x1C

	// Properties
	public ThermalImagerManager.TopMat CurTopMat { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A0CC Offset: 0x57A0CC VA: 0x57A0CC
	// RVA: 0xD84770 Offset: 0xD84770 VA: 0xD84770
	public ThermalImagerManager.TopMat get_CurTopMat() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A0DC Offset: 0x57A0DC VA: 0x57A0DC
	// RVA: 0xD84784 Offset: 0xD84784 VA: 0xD84784
	private void set_CurTopMat(ThermalImagerManager.TopMat value) { }

	// RVA: 0xD84790 Offset: 0xD84790 VA: 0xD84790
	public void add_projector(ThermalImagerManager.IProjector projector) { }

	// RVA: 0xD84980 Offset: 0xD84980 VA: 0xD84980
	public void remove_projector(ThermalImagerManager.IProjector projector) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A0EC Offset: 0x57A0EC VA: 0x57A0EC
	// RVA: 0xD84874 Offset: 0xD84874 VA: 0xD84874
	public void add_SniperSightAimEvent(Action<ThermalImagerManager.TopMat> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A0FC Offset: 0x57A0FC VA: 0x57A0FC
	// RVA: 0xD84A64 Offset: 0xD84A64 VA: 0xD84A64
	public void remove_SniperSightAimEvent(Action<ThermalImagerManager.TopMat> value) { }

	// RVA: 0xD84B70 Offset: 0xD84B70 VA: 0xD84B70
	public void OnSniperSightAim(bool isSightAndAim, BattleCamp camp) { }

	// RVA: 0xD84BF8 Offset: 0xD84BF8 VA: 0xD84BF8
	public bool GetSniperSightAiming() { }

	// RVA: 0xD84C00 Offset: 0xD84C00 VA: 0xD84C00
	public void .ctor() { }
}
