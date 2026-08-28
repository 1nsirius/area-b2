// Namespace: 
private class RefactorReinforcedWall.DefaultActor : IRefactorReinforcedWallActor // TypeDefIndex: 11338
{
	// Fields
	private readonly GameObject mGameObject; // 0x8
	private readonly Transform mTransform; // 0xC

	// Methods

	// RVA: 0xA8C5A4 Offset: 0xA8C5A4 VA: 0xA8C5A4
	public void .ctor(GameObject game_object) { }

	// RVA: 0xA8E4A0 Offset: 0xA8E4A0 VA: 0xA8E4A0 Slot: 4
	public void Deactive() { }

	// RVA: 0xA8E4D0 Offset: 0xA8E4D0 VA: 0xA8E4D0 Slot: 5
	public void Active() { }

	// RVA: 0xA8E500 Offset: 0xA8E500 VA: 0xA8E500 Slot: 6
	public void SetLocalPositionAndRotation(Vector3 position, Quaternion rotation) { }

	// RVA: 0xA8E598 Offset: 0xA8E598 VA: 0xA8E598 Slot: 7
	public void DestroyMonoBlock(int index) { }

	// RVA: 0xA8E59C Offset: 0xA8E59C VA: 0xA8E59C Slot: 8
	public void DestroyContentBlock(int mono_index, int[] indices) { }

	// RVA: 0xA8E5A0 Offset: 0xA8E5A0 VA: 0xA8E5A0 Slot: 9
	public void RevertDestroyContentBlock(int mono_index, int[] indices) { }

	// RVA: 0xA8E5A4 Offset: 0xA8E5A4 VA: 0xA8E5A4 Slot: 10
	public float GetReinforcedWallCurHp(int mono_index) { }

	// RVA: 0xA8E5AC Offset: 0xA8E5AC VA: 0xA8E5AC Slot: 11
	public void ResHpSync(float sync_blood, int mono_index) { }

	// RVA: 0xA8E5B0 Offset: 0xA8E5B0 VA: 0xA8E5B0 Slot: 12
	public void DestroyAssociatedItem(int index1, int index2) { }

	// RVA: 0xA8E5B4 Offset: 0xA8E5B4 VA: 0xA8E5B4 Slot: 13
	public void RevertDestroyAssociatedItem(int index1, int index2) { }

	// RVA: 0xA8E5B8 Offset: 0xA8E5B8 VA: 0xA8E5B8 Slot: 14
	public void RecoverContentBlock(int mono_index, int[] indices) { }

	// RVA: 0xA8E5BC Offset: 0xA8E5BC VA: 0xA8E5BC Slot: 15
	public void BeginRecover() { }
}
