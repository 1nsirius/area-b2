// Namespace: 
[Serializable]
public class BattleConfiguration.DragPanCfg // TypeDefIndex: 12351
{
	// Fields
	[HeaderAttribute] // RVA: 0x57509C Offset: 0x57509C VA: 0x57509C
	[SerializeField] // RVA: 0x57509C Offset: 0x57509C VA: 0x57509C
	private float eyes_rot_smooth_param; // 0x8
	[SerializeField] // RVA: 0x5750F4 Offset: 0x5750F4 VA: 0x5750F4
	private BattleConfiguration.DragPanCfg.DragPanType dragPanType; // 0xC
	[HeaderAttribute] // RVA: 0x575104 Offset: 0x575104 VA: 0x575104
	[SerializeField] // RVA: 0x575104 Offset: 0x575104 VA: 0x575104
	private float drag_pan_speed_param_basic_x; // 0x10
	[SerializeField] // RVA: 0x57514C Offset: 0x57514C VA: 0x57514C
	private float drag_pan_speed_param_basic_y; // 0x14
	[HeaderAttribute] // RVA: 0x57515C Offset: 0x57515C VA: 0x57515C
	[TooltipAttribute] // RVA: 0x57515C Offset: 0x57515C VA: 0x57515C
	[SerializeField] // RVA: 0x57515C Offset: 0x57515C VA: 0x57515C
	private float drag_pan_slope_param; // 0x18
	[SerializeField] // RVA: 0x5751E4 Offset: 0x5751E4 VA: 0x5751E4
	private float drag_pan_speed_param_x; // 0x1C
	[SerializeField] // RVA: 0x5751F4 Offset: 0x5751F4 VA: 0x5751F4
	private float drag_pan_speed_param_y; // 0x20
	[SerializeField] // RVA: 0x575204 Offset: 0x575204 VA: 0x575204
	private float drag_pan_min_speed; // 0x24
	[SerializeField] // RVA: 0x575214 Offset: 0x575214 VA: 0x575214
	private float drag_pan_max_speed; // 0x28
	[SerializeField] // RVA: 0x575224 Offset: 0x575224 VA: 0x575224
	private float aiming_drag_pan_slope_param; // 0x2C
	[SerializeField] // RVA: 0x575234 Offset: 0x575234 VA: 0x575234
	private float aiming_drag_pan_speed_param_x; // 0x30
	[SerializeField] // RVA: 0x575244 Offset: 0x575244 VA: 0x575244
	private float aiming_drag_pan_speed_param_y; // 0x34
	[SerializeField] // RVA: 0x575254 Offset: 0x575254 VA: 0x575254
	private float aiming_drag_pan_min_speed; // 0x38
	[SerializeField] // RVA: 0x575264 Offset: 0x575264 VA: 0x575264
	private float aiming_drag_pan_max_speed; // 0x3C
	[SerializeField] // RVA: 0x575274 Offset: 0x575274 VA: 0x575274
	private float max_first_drag_pan_delta; // 0x40
	[SerializeField] // RVA: 0x575284 Offset: 0x575284 VA: 0x575284
	[HeaderAttribute] // RVA: 0x575284 Offset: 0x575284 VA: 0x575284
	public float ignore_value_lower_bound_for_dragspeed; // 0x44
	[SerializeField] // RVA: 0x5752EC Offset: 0x5752EC VA: 0x5752EC
	[HeaderAttribute] // RVA: 0x5752EC Offset: 0x5752EC VA: 0x5752EC
	public float ignore_value_max_multiple_for_dragspeed; // 0x48
	[SerializeField] // RVA: 0x57534C Offset: 0x57534C VA: 0x57534C
	[HeaderAttribute] // RVA: 0x57534C Offset: 0x57534C VA: 0x57534C
	public float ignore_value_min_change_for_dragspeed; // 0x4C
	[HeaderAttribute] // RVA: 0x5753C0 Offset: 0x5753C0 VA: 0x5753C0
	public bool if_debug_no_lerp_reason; // 0x50
	[HeaderAttribute] // RVA: 0x57540C Offset: 0x57540C VA: 0x57540C
	public bool mStartIfDirty; // 0x51
	[HeaderAttribute] // RVA: 0x575458 Offset: 0x575458 VA: 0x575458
	public bool mStopIfDirty; // 0x52
	[HeaderAttribute] // RVA: 0x5754A0 Offset: 0x5754A0 VA: 0x5754A0
	public bool if_close_drag_lerp; // 0x53
	[HeaderAttribute] // RVA: 0x5754F4 Offset: 0x5754F4 VA: 0x5754F4
	public int max_drag_pan_history_count; // 0x54
	[HeaderAttribute] // RVA: 0x57554C Offset: 0x57554C VA: 0x57554C
	public BattleConfiguration.DragPanCfg.DragPanDataOptimiseMode dragPanDataOptimiseMode; // 0x58

	// Properties
	public float EyesRotSmoothParam { get; }
	public BattleConfiguration.DragPanCfg.DragPanType GetDragPanType { get; }
	public float DragPanSpeedParamBasicX { get; }
	public float DragPanSpeedParamBasicY { get; }
	public float DragPanSlopeParam { get; }
	public float DragPanSpeedParamX { get; }
	public float DragPanSpeedParamY { get; }
	public float DragPanMinSpeed { get; }
	public float DragPanMaxSpeed { get; }
	public float AimingDragPanSlopeParam { get; }
	public float AimingDragPanSpeedParamX { get; }
	public float AimingDragPanSpeedParamY { get; }
	public float AimingDragPanMinSpeed { get; }
	public float AimingDragPanMaxSpeed { get; }
	public float MaxFirstDragPanDelta { get; }
	public float IgnoreValueLowerBoundForDragspeed { get; }
	public float IgnoreValueMaxMultipleForDragspeed { get; }
	public float IgnoreValueMinChangeForDragspeed { get; }
	public int MaxDragPanHistoryCount { get; }

	// Methods

	// RVA: 0x99F86C Offset: 0x99F86C VA: 0x99F86C
	public float get_EyesRotSmoothParam() { }

	// RVA: 0x99F938 Offset: 0x99F938 VA: 0x99F938
	public BattleConfiguration.DragPanCfg.DragPanType get_GetDragPanType() { }

	// RVA: 0x99F9FC Offset: 0x99F9FC VA: 0x99F9FC
	public float get_DragPanSpeedParamBasicX() { }

	// RVA: 0x99FAC8 Offset: 0x99FAC8 VA: 0x99FAC8
	public float get_DragPanSpeedParamBasicY() { }

	// RVA: 0x99FB94 Offset: 0x99FB94 VA: 0x99FB94
	public float get_DragPanSlopeParam() { }

	// RVA: 0x99FC60 Offset: 0x99FC60 VA: 0x99FC60
	public float get_DragPanSpeedParamX() { }

	// RVA: 0x99FD2C Offset: 0x99FD2C VA: 0x99FD2C
	public float get_DragPanSpeedParamY() { }

	// RVA: 0x99FDF8 Offset: 0x99FDF8 VA: 0x99FDF8
	public float get_DragPanMinSpeed() { }

	// RVA: 0x99FEC4 Offset: 0x99FEC4 VA: 0x99FEC4
	public float get_DragPanMaxSpeed() { }

	// RVA: 0x99FF90 Offset: 0x99FF90 VA: 0x99FF90
	public float get_AimingDragPanSlopeParam() { }

	// RVA: 0x9A005C Offset: 0x9A005C VA: 0x9A005C
	public float get_AimingDragPanSpeedParamX() { }

	// RVA: 0x9A0128 Offset: 0x9A0128 VA: 0x9A0128
	public float get_AimingDragPanSpeedParamY() { }

	// RVA: 0x9A01F4 Offset: 0x9A01F4 VA: 0x9A01F4
	public float get_AimingDragPanMinSpeed() { }

	// RVA: 0x9A02C0 Offset: 0x9A02C0 VA: 0x9A02C0
	public float get_AimingDragPanMaxSpeed() { }

	// RVA: 0x9A038C Offset: 0x9A038C VA: 0x9A038C
	public float get_MaxFirstDragPanDelta() { }

	// RVA: 0x9A0458 Offset: 0x9A0458 VA: 0x9A0458
	public float get_IgnoreValueLowerBoundForDragspeed() { }

	// RVA: 0x9A0524 Offset: 0x9A0524 VA: 0x9A0524
	public float get_IgnoreValueMaxMultipleForDragspeed() { }

	// RVA: 0x9A05F0 Offset: 0x9A05F0 VA: 0x9A05F0
	public float get_IgnoreValueMinChangeForDragspeed() { }

	// RVA: 0x9A06BC Offset: 0x9A06BC VA: 0x9A06BC
	public int get_MaxDragPanHistoryCount() { }

	// RVA: 0x9A0780 Offset: 0x9A0780 VA: 0x9A0780
	public void .ctor() { }
}
