// Namespace: 
private class AssetManager.AssetItem : IDisposable // TypeDefIndex: 9757
{
	// Fields
	public IAssetProxy AssetProxy; // 0x8
	private float mExpireTime; // 0xC
	private int mRefCnt; // 0x10
	public Action<Object> OnLoadFinish; // 0x14
	public Action<float> OnProgress; // 0x18

	// Methods

	// RVA: 0xF29480 Offset: 0xF29480 VA: 0xF29480 Slot: 4
	public void Dispose() { }

	// RVA: 0xF28EB8 Offset: 0xF28EB8 VA: 0xF28EB8
	public bool RefCntDecrease() { }

	// RVA: 0xF28AB0 Offset: 0xF28AB0 VA: 0xF28AB0
	public void RefCntIncrease() { }

	// RVA: 0xF28FB4 Offset: 0xF28FB4 VA: 0xF28FB4
	public void SetExpireTime(float expireTime) { }

	// RVA: 0xF29248 Offset: 0xF29248 VA: 0xF29248
	public bool Update(float time) { }

	// RVA: 0xF29D2C Offset: 0xF29D2C VA: 0xF29D2C
	private void TryInvokeCb() { }

	// RVA: 0xF2A024 Offset: 0xF2A024 VA: 0xF2A024
	private void TryInvokeFinishCb() { }

	// RVA: 0xF29E1C Offset: 0xF29E1C VA: 0xF29E1C
	private void TryInvokeProgressCb() { }

	// RVA: 0xF2A2A0 Offset: 0xF2A2A0 VA: 0xF2A2A0
	public void .ctor() { }
}
