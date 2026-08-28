namespace FGame
{

// Namespace: FGame
public sealed class WarehouseDataManager : BaseSingleton<WarehouseDataManager> // TypeDefIndex: 9957
{
	// Fields
	private ILuaFunctionWrap mSetWarehouseSkinDataFunc; // 0x8
	private ILuaFunctionWrap mAddSkinDataFunc; // 0xC
	private ILuaFunctionWrap mSkinUpdateFunc; // 0x10
	private ILuaFunctionWrap mSaveSkinIdFunc; // 0x14
	private ILuaFunctionWrap mSaveWeaponSkinIdFunc; // 0x18
	private ILuaFunctionWrap mGetSkinIdFunc; // 0x1C
	private ILuaFunctionWrap mGetWeaponSkinIdFunc; // 0x20
	private ILuaFunctionWrap mGetAllPersistentSkin; // 0x24
	private Callback mDismantleFinish; // 0x28
	public List<WarehouseDataManager.DismantleInfo> DismantleSuccessList; // 0x2C

	// Methods

	// RVA: 0xD94B64 Offset: 0xD94B64 VA: 0xD94B64
	public void Initialize() { }

	// RVA: 0xD94D80 Offset: 0xD94D80 VA: 0xD94D80
	public void Shutdown() { }

	// RVA: 0xD94FB0 Offset: 0xD94FB0 VA: 0xD94FB0
	public void CheckFuncBinding() { }

	// RVA: 0xD952BC Offset: 0xD952BC VA: 0xD952BC
	private void OnGetWarehouseSkins(SprotoTypeBase msg) { }

	// RVA: 0xD9544C Offset: 0xD9544C VA: 0xD9544C
	public List<long> GetAllPersistentSkin() { }

	// RVA: 0xD955E4 Offset: 0xD955E4 VA: 0xD955E4
	private void OnUseSkin(SprotoTypeBase msg) { }

	// RVA: 0xD955E8 Offset: 0xD955E8 VA: 0xD955E8
	private void OnAddSkin(SprotoTypeBase msg) { }

	// RVA: 0xD958B4 Offset: 0xD958B4 VA: 0xD958B4
	private void OnSkinUpdate(SprotoTypeBase msg) { }

	// RVA: 0xD95A44 Offset: 0xD95A44 VA: 0xD95A44
	public void EquipSkinToAllWeapon(int skinId, int[] charIds) { }

	// RVA: 0xD96558 Offset: 0xD96558 VA: 0xD96558
	public void EquipPendantToAllWeapon(int skinId, int[] charIds) { }

	// RVA: 0xD96B88 Offset: 0xD96B88 VA: 0xD96B88
	private void OnUseSkinToWeapons(SprotoTypeBase msg) { }

	// RVA: 0xD96CE4 Offset: 0xD96CE4 VA: 0xD96CE4
	public void DismantleSkins(int[] ids, int[] nums, Callback OnFinish) { }

	// RVA: 0xD96F6C Offset: 0xD96F6C VA: 0xD96F6C
	private void OnDismantleSkinsRsp(SprotoTypeBase msg) { }

	// RVA: 0xD9727C Offset: 0xD9727C VA: 0xD9727C
	public void .ctor() { }
}

} // namespace FGame
