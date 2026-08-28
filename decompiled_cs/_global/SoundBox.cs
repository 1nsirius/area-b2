// Namespace: 
public class SoundBox : MonoBehaviour // TypeDefIndex: 5225
{
	// Fields
	[HeaderAttribute] // RVA: 0x55D488 Offset: 0x55D488 VA: 0x55D488
	public int SoundBoxId; // 0xC
	[HeaderAttribute] // RVA: 0x55D4C0 Offset: 0x55D4C0 VA: 0x55D4C0
	public uint SoundEvent; // 0x10
	[HeaderAttribute] // RVA: 0x55D4F8 Offset: 0x55D4F8 VA: 0x55D4F8
	public uint StopEvent; // 0x14
	[HeaderAttribute] // RVA: 0x55D530 Offset: 0x55D530 VA: 0x55D530
	public SoundBox.SoundBoxType TheType; // 0x18
	[HeaderAttribute] // RVA: 0x55D56C Offset: 0x55D56C VA: 0x55D56C
	[RangeAttribute] // RVA: 0x55D56C Offset: 0x55D56C VA: 0x55D56C
	public float OutPermeability; // 0x1C
	[HeaderAttribute] // RVA: 0x55D5C4 Offset: 0x55D5C4 VA: 0x55D5C4
	[RangeAttribute] // RVA: 0x55D5C4 Offset: 0x55D5C4 VA: 0x55D5C4
	public float InPermeability; // 0x20
	[HeaderAttribute] // RVA: 0x55D61C Offset: 0x55D61C VA: 0x55D61C
	public uint MapLocationId; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x55D654 Offset: 0x55D654 VA: 0x55D654
	private Bounds <SoundBounds>k__BackingField; // 0x28
	private int soundBoxTask; // 0x40

	// Properties
	public Bounds SoundBounds { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57979C Offset: 0x57979C VA: 0x57979C
	// RVA: 0xF801C4 Offset: 0xF801C4 VA: 0xF801C4
	public Bounds get_SoundBounds() { }

	[CompilerGeneratedAttribute] // RVA: 0x5797AC Offset: 0x5797AC VA: 0x5797AC
	// RVA: 0xF801DC Offset: 0xF801DC VA: 0xF801DC
	private void set_SoundBounds(Bounds value) { }

	// RVA: 0xF80200 Offset: 0xF80200 VA: 0xF80200
	private void Awake() { }

	// RVA: 0xF806CC Offset: 0xF806CC VA: 0xF806CC
	private void OnDestroy() { }

	// RVA: 0xF8080C Offset: 0xF8080C VA: 0xF8080C
	public void .ctor() { }
}
