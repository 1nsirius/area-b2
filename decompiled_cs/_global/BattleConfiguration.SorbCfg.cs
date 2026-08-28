// Namespace: 
[Serializable]
public class BattleConfiguration.SorbCfg // TypeDefIndex: 12347
{
	// Fields
	[HeaderAttribute] // RVA: 0x5749CC Offset: 0x5749CC VA: 0x5749CC
	public float sorb_with_fire_waiting; // 0x8
	[HeaderAttribute] // RVA: 0x574A20 Offset: 0x574A20 VA: 0x574A20
	public float check_free_target_distance; // 0xC
	[HeaderAttribute] // RVA: 0x574A54 Offset: 0x574A54 VA: 0x574A54
	[SerializeField] // RVA: 0x574A54 Offset: 0x574A54 VA: 0x574A54
	private float area_param_rotation_param; // 0x10
	[HeaderAttribute] // RVA: 0x574A9C Offset: 0x574A9C VA: 0x574A9C
	[SerializeField] // RVA: 0x574A9C Offset: 0x574A9C VA: 0x574A9C
	private float area_param_constant_param; // 0x14
	[HeaderAttribute] // RVA: 0x574AE4 Offset: 0x574AE4 VA: 0x574AE4
	[SerializeField] // RVA: 0x574AE4 Offset: 0x574AE4 VA: 0x574AE4
	private float sorb_param_normal_a; // 0x18
	[HeaderAttribute] // RVA: 0x574B48 Offset: 0x574B48 VA: 0x574B48
	[SerializeField] // RVA: 0x574B48 Offset: 0x574B48 VA: 0x574B48
	private float sorb_param_normal_b; // 0x1C
	[HeaderAttribute] // RVA: 0x574BAC Offset: 0x574BAC VA: 0x574BAC
	[SerializeField] // RVA: 0x574BAC Offset: 0x574BAC VA: 0x574BAC
	private float sorb_param_aim_a; // 0x20
	[HeaderAttribute] // RVA: 0x574C10 Offset: 0x574C10 VA: 0x574C10
	[SerializeField] // RVA: 0x574C10 Offset: 0x574C10 VA: 0x574C10
	private float sorb_param_aim_b; // 0x24
	[HeaderAttribute] // RVA: 0x574C74 Offset: 0x574C74 VA: 0x574C74
	public float sorb_param_angle; // 0x28
	[HeaderAttribute] // RVA: 0x574CB8 Offset: 0x574CB8 VA: 0x574CB8
	public float offsetRadius; // 0x2C

	// Properties
	public float SorbParamNormalA { get; }
	public float SorbParamNormalB { get; }
	public float SorbParamAimA { get; }
	public float SorbParamAimB { get; }
	public float AreaParamRotationParam { get; }
	public float AreaParamConstantParam { get; }

	// Methods

	// RVA: 0x9A1D2C Offset: 0x9A1D2C VA: 0x9A1D2C
	public float get_SorbParamNormalA() { }

	// RVA: 0x9A1DF8 Offset: 0x9A1DF8 VA: 0x9A1DF8
	public float get_SorbParamNormalB() { }

	// RVA: 0x9A1EC4 Offset: 0x9A1EC4 VA: 0x9A1EC4
	public float get_SorbParamAimA() { }

	// RVA: 0x9A1F90 Offset: 0x9A1F90 VA: 0x9A1F90
	public float get_SorbParamAimB() { }

	// RVA: 0x9A205C Offset: 0x9A205C VA: 0x9A205C
	public float get_AreaParamRotationParam() { }

	// RVA: 0x9A2128 Offset: 0x9A2128 VA: 0x9A2128
	public float get_AreaParamConstantParam() { }

	// RVA: 0x9A21F8 Offset: 0x9A21F8 VA: 0x9A21F8
	public void .ctor() { }
}
