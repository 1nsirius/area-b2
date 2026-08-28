// Namespace: 
private class BlockingBoardCfg.Wrapper // TypeDefIndex: 11368
{
	// Fields
	private readonly BlockingBoardCfg _config; // 0x8
	private readonly Vector3 mColliderSize; // 0xC
	public readonly Vector3 ForwardPosition; // 0x18
	public readonly Vector3 BackwardPosition; // 0x24
	public readonly Vector3 ForwardBorderPosition; // 0x30
	public readonly Vector3 BackwardBorderPosition; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x573774 Offset: 0x573774 VA: 0x573774
	private readonly Vector3 <ForwardColliderPosition>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x573784 Offset: 0x573784 VA: 0x573784
	private readonly Vector3 <BlockingBoundsSize>k__BackingField; // 0x54

	// Properties
	public Vector3 TriggerSize { get; }
	public Vector3 TriggerCenter { get; }
	public Vector3 ForwardColliderPosition { get; }
	public Vector3 ForwardBlockingPosition { get; }
	public Vector3 BackwardColliderPosition { get; }
	public Vector3 BackwardBlockingPosition { get; }
	[IsReadOnlyAttribute] // RVA: 0x66EF6C Offset: 0x66EF6C VA: 0x66EF6C
	public Vector3 ColliderSize { get; }
	public Vector3 BlockingBoundsSize { get; }

	// Methods

	// RVA: 0xA81D80 Offset: 0xA81D80 VA: 0xA81D80
	public Vector3 get_TriggerSize() { }

	// RVA: 0xA81E20 Offset: 0xA81E20 VA: 0xA81E20
	public Vector3 get_TriggerCenter() { }

	[CompilerGeneratedAttribute] // RVA: 0x667A30 Offset: 0x667A30 VA: 0x667A30
	// RVA: 0xA81E58 Offset: 0xA81E58 VA: 0xA81E58
	public Vector3 get_ForwardColliderPosition() { }

	// RVA: 0xA81EC8 Offset: 0xA81EC8 VA: 0xA81EC8
	public Vector3 get_ForwardBlockingPosition() { }

	// RVA: 0xA81E6C Offset: 0xA81E6C VA: 0xA81E6C
	public Vector3 get_BackwardColliderPosition() { }

	// RVA: 0xA81F14 Offset: 0xA81F14 VA: 0xA81F14
	public Vector3 get_BackwardBlockingPosition() { }

	// RVA: 0xA81EAC Offset: 0xA81EAC VA: 0xA81EAC
	public ref Vector3 get_ColliderSize() { }

	[CompilerGeneratedAttribute] // RVA: 0x667A40 Offset: 0x667A40 VA: 0x667A40
	// RVA: 0xA81EB4 Offset: 0xA81EB4 VA: 0xA81EB4
	public Vector3 get_BlockingBoundsSize() { }

	// RVA: 0xA81F98 Offset: 0xA81F98 VA: 0xA81F98
	public Bounds CalcTrapBombTriggerBounds(ref Vector3 extend) { }

	// RVA: 0xA81A50 Offset: 0xA81A50 VA: 0xA81A50
	public void .ctor(BlockingBoardCfg config) { }
}
