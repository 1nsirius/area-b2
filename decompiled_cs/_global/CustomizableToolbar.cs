// Namespace: 
public class CustomizableToolbar : MonoBehaviour // TypeDefIndex: 5626
{
	// Fields
	[SerializeField] // RVA: 0x55E034 Offset: 0x55E034 VA: 0x55E034
	private Slider alphaSlider; // 0xC
	[SerializeField] // RVA: 0x55E044 Offset: 0x55E044 VA: 0x55E044
	private Slider scaleSlider; // 0x10
	[SerializeField] // RVA: 0x55E054 Offset: 0x55E054 VA: 0x55E054
	private Button left; // 0x14
	[SerializeField] // RVA: 0x55E064 Offset: 0x55E064 VA: 0x55E064
	private Button right; // 0x18
	[SerializeField] // RVA: 0x55E074 Offset: 0x55E074 VA: 0x55E074
	private Button up; // 0x1C
	[SerializeField] // RVA: 0x55E084 Offset: 0x55E084 VA: 0x55E084
	private Button down; // 0x20
	[SerializeField] // RVA: 0x55E094 Offset: 0x55E094 VA: 0x55E094
	private Text alphaText; // 0x24
	[SerializeField] // RVA: 0x55E0A4 Offset: 0x55E0A4 VA: 0x55E0A4
	private Text scaleText; // 0x28
	[SerializeField] // RVA: 0x55E0B4 Offset: 0x55E0B4 VA: 0x55E0B4
	private Vector2 moveSensitive; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x55E0C4 Offset: 0x55E0C4 VA: 0x55E0C4
	private Action<Vector2> OnMove; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x55E0D4 Offset: 0x55E0D4 VA: 0x55E0D4
	private Action<float> OnSetAlpha; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x55E0E4 Offset: 0x55E0E4 VA: 0x55E0E4
	private Action<float> OnSetScale; // 0x3C

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A5DC Offset: 0x57A5DC VA: 0x57A5DC
	// RVA: 0xD66848 Offset: 0xD66848 VA: 0xD66848
	public void add_OnMove(Action<Vector2> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A5EC Offset: 0x57A5EC VA: 0x57A5EC
	// RVA: 0xD693A4 Offset: 0xD693A4 VA: 0xD693A4
	public void remove_OnMove(Action<Vector2> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A5FC Offset: 0x57A5FC VA: 0x57A5FC
	// RVA: 0xD66954 Offset: 0xD66954 VA: 0xD66954
	public void add_OnSetAlpha(Action<float> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A60C Offset: 0x57A60C VA: 0x57A60C
	// RVA: 0xD694B0 Offset: 0xD694B0 VA: 0xD694B0
	public void remove_OnSetAlpha(Action<float> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A61C Offset: 0x57A61C VA: 0x57A61C
	// RVA: 0xD66A60 Offset: 0xD66A60 VA: 0xD66A60
	public void add_OnSetScale(Action<float> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A62C Offset: 0x57A62C VA: 0x57A62C
	// RVA: 0xD695BC Offset: 0xD695BC VA: 0xD695BC
	public void remove_OnSetScale(Action<float> value) { }

	// RVA: 0xD696C8 Offset: 0xD696C8 VA: 0xD696C8
	private void Awake() { }

	// RVA: 0xD69A08 Offset: 0xD69A08 VA: 0xD69A08
	private void AddScaleListener() { }

	// RVA: 0xD69928 Offset: 0xD69928 VA: 0xD69928
	private void AddAlphaListener() { }

	// RVA: 0xD696EC Offset: 0xD696EC VA: 0xD696EC
	private void AddMoveListeners() { }

	// RVA: 0xD6733C Offset: 0xD6733C VA: 0xD6733C
	public void Refresh(CustomValue val) { }

	// RVA: 0xD69AE8 Offset: 0xD69AE8 VA: 0xD69AE8
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A63C Offset: 0x57A63C VA: 0x57A63C
	// RVA: 0xD69B3C Offset: 0xD69B3C VA: 0xD69B3C
	private void <AddScaleListener>g__OnScaleChange|19_0(float v) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A64C Offset: 0x57A64C VA: 0x57A64C
	// RVA: 0xD69C38 Offset: 0xD69C38 VA: 0xD69C38
	private void <AddAlphaListener>g__OnAlphaChange|20_0(float v) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A65C Offset: 0x57A65C VA: 0x57A65C
	// RVA: 0xD69D34 Offset: 0xD69D34 VA: 0xD69D34
	private void <AddMoveListeners>g__OnClickLeft|21_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A66C Offset: 0x57A66C VA: 0x57A66C
	// RVA: 0xD69E14 Offset: 0xD69E14 VA: 0xD69E14
	private void <AddMoveListeners>g__OnClickRight|21_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A67C Offset: 0x57A67C VA: 0x57A67C
	// RVA: 0xD69EF4 Offset: 0xD69EF4 VA: 0xD69EF4
	private void <AddMoveListeners>g__OnClickUp|21_2() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A68C Offset: 0x57A68C VA: 0x57A68C
	// RVA: 0xD69FD4 Offset: 0xD69FD4 VA: 0xD69FD4
	private void <AddMoveListeners>g__OnClickDown|21_3() { }
}
