// Namespace: 
public abstract class AkObstructionOcclusion : MonoBehaviour // TypeDefIndex: 6074
{
	// Fields
	private readonly List<AkAudioListener> listenersToRemove; // 0xC
	protected readonly List<AkAudioListener> currentListenerList; // 0x10
	private readonly Dictionary<AkAudioListener, AkObstructionOcclusion.ObstructionOcclusionValue> ObstructionOcclusionValues; // 0x14
	protected float fadeRate; // 0x18
	[TooltipAttribute] // RVA: 0x55FDD8 Offset: 0x55FDD8 VA: 0x55FDD8
	public float fadeTime; // 0x1C
	[TooltipAttribute] // RVA: 0x55FE1C Offset: 0x55FE1C VA: 0x55FE1C
	public LayerMask LayerMask; // 0x20
	[TooltipAttribute] // RVA: 0x55FE68 Offset: 0x55FE68 VA: 0x55FE68
	public float maxDistance; // 0x24
	[TooltipAttribute] // RVA: 0x55FE9C Offset: 0x55FE9C VA: 0x55FE9C
	public float refreshInterval; // 0x28
	private float refreshTime; // 0x2C

	// Methods

	// RVA: 0x1BB4944 Offset: 0x1BB4944 VA: 0x1BB4944
	protected void InitIntervalsAndFadeRates() { }

	// RVA: -1 Offset: -1 Slot: 4
	protected abstract void UpdateCurrentListenerList();

	// RVA: 0x1BB4978 Offset: 0x1BB4978 VA: 0x1BB4978
	private void UpdateObstructionOcclusionValues() { }

	// RVA: 0x1BB4DAC Offset: 0x1BB4DAC VA: 0x1BB4DAC
	private void CastRays() { }

	// RVA: -1 Offset: -1 Slot: 5
	protected abstract void SetObstructionOcclusion(KeyValuePair<AkAudioListener, AkObstructionOcclusion.ObstructionOcclusionValue> ObsOccPair);

	// RVA: 0x1BB5258 Offset: 0x1BB5258 VA: 0x1BB5258
	private void Update() { }

	// RVA: 0x1BB55B4 Offset: 0x1BB55B4 VA: 0x1BB55B4
	protected void .ctor() { }
}
