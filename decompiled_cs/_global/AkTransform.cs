// Namespace: 
public class AkTransform : IDisposable // TypeDefIndex: 5958
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Methods

	// RVA: 0xCA6F14 Offset: 0xCA6F14 VA: 0xCA6F14
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xCA6F3C Offset: 0xCA6F3C VA: 0xCA6F3C
	internal static IntPtr getCPtr(AkTransform obj) { }

	// RVA: 0xCA6F94 Offset: 0xCA6F94 VA: 0xCA6F94 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xCA6FC0 Offset: 0xCA6FC0 VA: 0xCA6FC0 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xCA7034 Offset: 0xCA7034 VA: 0xCA7034 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xCA71B8 Offset: 0xCA71B8 VA: 0xCA71B8
	public AkVector Position() { }

	// RVA: 0xCA729C Offset: 0xCA729C VA: 0xCA729C
	public AkVector OrientationFront() { }

	// RVA: 0xCA7358 Offset: 0xCA7358 VA: 0xCA7358
	public AkVector OrientationTop() { }

	// RVA: 0xCA7414 Offset: 0xCA7414 VA: 0xCA7414
	public void Set(AkVector in_position, AkVector in_orientationFront, AkVector in_orientationTop) { }

	// RVA: 0xCA7578 Offset: 0xCA7578 VA: 0xCA7578
	public void Set(float in_positionX, float in_positionY, float in_positionZ, float in_orientFrontX, float in_orientFrontY, float in_orientFrontZ, float in_orientTopX, float in_orientTopY, float in_orientTopZ) { }

	// RVA: 0xCA765C Offset: 0xCA765C VA: 0xCA765C
	public void SetPosition(AkVector in_position) { }

	// RVA: 0xCA7734 Offset: 0xCA7734 VA: 0xCA7734
	public void SetPosition(float in_x, float in_y, float in_z) { }

	// RVA: 0xCA77E0 Offset: 0xCA77E0 VA: 0xCA77E0
	public void SetOrientation(AkVector in_orientationFront, AkVector in_orientationTop) { }

	// RVA: 0xCA78CC Offset: 0xCA78CC VA: 0xCA78CC
	public void SetOrientation(float in_orientFrontX, float in_orientFrontY, float in_orientFrontZ, float in_orientTopX, float in_orientTopY, float in_orientTopZ) { }

	// RVA: 0xCA7998 Offset: 0xCA7998 VA: 0xCA7998
	public void .ctor() { }
}
