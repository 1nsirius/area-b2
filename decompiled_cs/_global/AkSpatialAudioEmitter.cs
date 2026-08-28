// Namespace: 
[AddComponentMenu] // RVA: 0x551998 Offset: 0x551998 VA: 0x551998
[RequireComponent] // RVA: 0x551998 Offset: 0x551998 VA: 0x551998
public class AkSpatialAudioEmitter : AkSpatialAudioBase // TypeDefIndex: 6086
{
	// Fields
	[HeaderAttribute] // RVA: 0x55FFE0 Offset: 0x55FFE0 VA: 0x55FFE0
	[TooltipAttribute] // RVA: 0x55FFE0 Offset: 0x55FFE0 VA: 0x55FFE0
	public AuxBus reflectAuxBus; // 0x10
	[TooltipAttribute] // RVA: 0x560080 Offset: 0x560080 VA: 0x560080
	public float reflectionMaxPathLength; // 0x14
	[RangeAttribute] // RVA: 0x5600B4 Offset: 0x5600B4 VA: 0x5600B4
	[TooltipAttribute] // RVA: 0x5600B4 Offset: 0x5600B4 VA: 0x5600B4
	public float reflectionsAuxBusGain; // 0x18
	[RangeAttribute] // RVA: 0x560134 Offset: 0x560134 VA: 0x560134
	[TooltipAttribute] // RVA: 0x560134 Offset: 0x560134 VA: 0x560134
	public uint reflectionsOrder; // 0x1C
	[HeaderAttribute] // RVA: 0x560188 Offset: 0x560188 VA: 0x560188
	[RangeAttribute] // RVA: 0x560188 Offset: 0x560188 VA: 0x560188
	[TooltipAttribute] // RVA: 0x560188 Offset: 0x560188 VA: 0x560188
	public float roomReverbAuxBusGain; // 0x20
	[HeaderAttribute] // RVA: 0x560200 Offset: 0x560200 VA: 0x560200
	[TooltipAttribute] // RVA: 0x560200 Offset: 0x560200 VA: 0x560200
	public uint diffractionMaxEdges; // 0x24
	[TooltipAttribute] // RVA: 0x560260 Offset: 0x560260 VA: 0x560260
	public uint diffractionMaxPaths; // 0x28
	[TooltipAttribute] // RVA: 0x560294 Offset: 0x560294 VA: 0x560294
	public uint diffractionMaxPathLength; // 0x2C

	// Methods

	// RVA: 0xCA27C4 Offset: 0xCA27C4 VA: 0xCA27C4
	private void OnEnable() { }

	// RVA: 0xCA2A68 Offset: 0xCA2A68 VA: 0xCA2A68
	private void OnDisable() { }

	// RVA: 0xCA2AFC Offset: 0xCA2AFC VA: 0xCA2AFC
	public void .ctor() { }
}
