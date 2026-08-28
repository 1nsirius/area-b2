// Namespace: 
private class BlockingBoard.DefaultActor : IBlockingBoardActor // TypeDefIndex: 11363
{
	// Fields
	private readonly GameObject mGameObject; // 0x8
	private readonly Transform mTransform; // 0xC

	// Methods

	// RVA: 0xA80574 Offset: 0xA80574 VA: 0xA80574
	public void .ctor(GameObject gameObject) { }

	// RVA: 0xA818BC Offset: 0xA818BC VA: 0xA818BC Slot: 4
	public void Deactivate() { }

	// RVA: 0xA818EC Offset: 0xA818EC VA: 0xA818EC Slot: 5
	public void Active() { }

	// RVA: 0xA8191C Offset: 0xA8191C VA: 0xA8191C Slot: 6
	private void Game.Scene.BlockingBoard.IBlockingBoardActor.ResetContent() { }

	// RVA: 0xA81920 Offset: 0xA81920 VA: 0xA81920 Slot: 7
	public void SetLocalPositionAndRotation(Vector3 position, Quaternion rotation) { }

	// RVA: 0xA819B8 Offset: 0xA819B8 VA: 0xA819B8 Slot: 8
	public void RegisterOnActorDestroy(Action action) { }

	// RVA: 0xA819BC Offset: 0xA819BC VA: 0xA819BC
	public void DestroyContentBlocks(int[] indices, in Vector3 damageSource) { }

	// RVA: 0xA819C0 Offset: 0xA819C0 VA: 0xA819C0 Slot: 10
	public void DestroyContentBlocks(int[] indices) { }

	// RVA: 0xA819C4 Offset: 0xA819C4 VA: 0xA819C4 Slot: 11
	public void RecoverWall(int[] indices) { }

	// RVA: 0xA819C8 Offset: 0xA819C8 VA: 0xA819C8 Slot: 12
	public void RevertDestroyContentBlocks(int[] indices) { }

	// RVA: 0xA819CC Offset: 0xA819CC VA: 0xA819CC Slot: 9
	private void Game.Scene.BlockingBoard.IBlockingBoardActor.DestroyContentBlocks(int[] indices, in Vector3 damageSource) { }
}
