// Namespace: 
[ExecuteInEditMode] // RVA: 0x55033C Offset: 0x55033C VA: 0x55033C
public class GrayGroup : MonoBehaviour, IOnTransformGrandChildrenChanged // TypeDefIndex: 5481
{
	// Fields
	private static Material sGrayMat; // 0x0
	private readonly List<Graphic> mGraphics; // 0xC
	private bool mDirty; // 0x10

	// Properties
	private static Material GrayMat { get; }
	private bool Dirty { get; set; }

	// Methods

	// RVA: 0x2CCCD10 Offset: 0x2CCCD10 VA: 0x2CCCD10
	private static Material get_GrayMat() { }

	// RVA: 0x2CCCEB8 Offset: 0x2CCCEB8 VA: 0x2CCCEB8
	private bool get_Dirty() { }

	// RVA: 0x2CCCEC0 Offset: 0x2CCCEC0 VA: 0x2CCCEC0
	private void set_Dirty(bool value) { }

	// RVA: 0x2CCCF40 Offset: 0x2CCCF40 VA: 0x2CCCF40
	private void LateUpdate() { }

	// RVA: 0x2CCD064 Offset: 0x2CCD064 VA: 0x2CCD064
	private void OnDisable() { }

	// RVA: 0x2CCD168 Offset: 0x2CCD168 VA: 0x2CCD168
	private void OnEnable() { }

	// RVA: 0x2CCD170 Offset: 0x2CCD170 VA: 0x2CCD170
	private void OnTransformChildrenChanged() { }

	// RVA: 0x2CCD178 Offset: 0x2CCD178 VA: 0x2CCD178 Slot: 4
	public void OnTransformGrandChildrenChanged() { }

	// RVA: 0x2CCD180 Offset: 0x2CCD180 VA: 0x2CCD180
	public void .ctor() { }
}
