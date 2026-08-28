// Namespace: 
[Serializable]
public class BattleConfiguration.DragViewCfg // TypeDefIndex: 12350
{
	// Fields
	[HeaderAttribute] // RVA: 0x574D0C Offset: 0x574D0C VA: 0x574D0C
	[SerializeField] // RVA: 0x574D0C Offset: 0x574D0C VA: 0x574D0C
	private float param_p_x; // 0x8
	[HeaderAttribute] // RVA: 0x574D70 Offset: 0x574D70 VA: 0x574D70
	[SerializeField] // RVA: 0x574D70 Offset: 0x574D70 VA: 0x574D70
	private float param_q_x; // 0xC
	[HeaderAttribute] // RVA: 0x574DD4 Offset: 0x574DD4 VA: 0x574DD4
	[SerializeField] // RVA: 0x574DD4 Offset: 0x574DD4 VA: 0x574DD4
	private float param_p_y; // 0x10
	[HeaderAttribute] // RVA: 0x574E38 Offset: 0x574E38 VA: 0x574E38
	[SerializeField] // RVA: 0x574E38 Offset: 0x574E38 VA: 0x574E38
	private float param_q_y; // 0x14
	[HeaderAttribute] // RVA: 0x574E9C Offset: 0x574E9C VA: 0x574E9C
	[RangeAttribute] // RVA: 0x574E9C Offset: 0x574E9C VA: 0x574E9C
	public float sniper_scopestate_aim_x_sensitivity_param; // 0x18
	[HeaderAttribute] // RVA: 0x574EF0 Offset: 0x574EF0 VA: 0x574EF0
	[RangeAttribute] // RVA: 0x574EF0 Offset: 0x574EF0 VA: 0x574EF0
	public float sniper_scopestate_aim_y_sensitivity_param; // 0x1C
	[HeaderAttribute] // RVA: 0x574F44 Offset: 0x574F44 VA: 0x574F44
	[RangeAttribute] // RVA: 0x574F44 Offset: 0x574F44 VA: 0x574F44
	public float shield_expanded_scopestate_aim_x_sensitivity_param; // 0x20
	[HeaderAttribute] // RVA: 0x574F98 Offset: 0x574F98 VA: 0x574F98
	[RangeAttribute] // RVA: 0x574F98 Offset: 0x574F98 VA: 0x574F98
	public float shield_expanded_scopestate_aim_y_sensitivity_param; // 0x24
	[HeaderAttribute] // RVA: 0x574FEC Offset: 0x574FEC VA: 0x574FEC
	public bool offset_drag_by_recoil; // 0x28
	[HeaderAttribute] // RVA: 0x575044 Offset: 0x575044 VA: 0x575044
	public Vector2 autoDragVec; // 0x2C

	// Properties
	public float HorizontalP { get; }
	public float HorizontalQ { get; }
	public float VerticalP { get; }
	public float VerticalQ { get; }
	public float SniperGunScopeStateAimXSensitivityParam { get; }
	public float SniperGunScopeStateAimYSensitivityParam { get; }
	public float ShieldExpandedScopeStateAimXSensitivityParam { get; }
	public float ShieldExpandedScopeStateAimYSensitivityParam { get; }

	// Methods

	// RVA: 0x9A0830 Offset: 0x9A0830 VA: 0x9A0830
	public float get_HorizontalP() { }

	// RVA: 0x9A08FC Offset: 0x9A08FC VA: 0x9A08FC
	public float get_HorizontalQ() { }

	// RVA: 0x9A09C8 Offset: 0x9A09C8 VA: 0x9A09C8
	public float get_VerticalP() { }

	// RVA: 0x9A0A94 Offset: 0x9A0A94 VA: 0x9A0A94
	public float get_VerticalQ() { }

	// RVA: 0x9A0B60 Offset: 0x9A0B60 VA: 0x9A0B60
	public float get_SniperGunScopeStateAimXSensitivityParam() { }

	// RVA: 0x9A0C2C Offset: 0x9A0C2C VA: 0x9A0C2C
	public float get_SniperGunScopeStateAimYSensitivityParam() { }

	// RVA: 0x9A0CF8 Offset: 0x9A0CF8 VA: 0x9A0CF8
	public float get_ShieldExpandedScopeStateAimXSensitivityParam() { }

	// RVA: 0x9A0D00 Offset: 0x9A0D00 VA: 0x9A0D00
	public float get_ShieldExpandedScopeStateAimYSensitivityParam() { }

	// RVA: 0x9A0D08 Offset: 0x9A0D08 VA: 0x9A0D08
	public void .ctor() { }
}
