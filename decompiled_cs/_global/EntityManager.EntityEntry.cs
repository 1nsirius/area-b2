// Namespace: 
private class EntityManager.EntityEntry // TypeDefIndex: 9665
{
	// Fields
	private readonly Dictionary<int, object> mManagedCptDic; // 0x8
	private readonly Dictionary<int, int> mUnmanagedCptOffsetDic; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56DEBC Offset: 0x56DEBC VA: 0x56DEBC
	private readonly BitMask <ComponentMask>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56DECC Offset: 0x56DECC VA: 0x56DECC
	private bool <IsActive>k__BackingField; // 0x14

	// Properties
	public BitMask ComponentMask { get; }
	public bool IsActive { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65C780 Offset: 0x65C780 VA: 0x65C780
	// RVA: 0x115641C Offset: 0x115641C VA: 0x115641C
	public BitMask get_ComponentMask() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C790 Offset: 0x65C790 VA: 0x65C790
	// RVA: 0x1156414 Offset: 0x1156414 VA: 0x1156414
	public bool get_IsActive() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C7A0 Offset: 0x65C7A0 VA: 0x65C7A0
	// RVA: 0x1156424 Offset: 0x1156424 VA: 0x1156424
	public void set_IsActive(bool value) { }

	// RVA: 0x1155CA0 Offset: 0x1155CA0 VA: 0x1155CA0
	public static EntityManager.EntityEntry Create() { }

	// RVA: 0x11550D8 Offset: 0x11550D8 VA: 0x11550D8
	public void Dispose() { }

	// RVA: -1 Offset: -1
	public bool HasComponent<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CC0314 Offset: 0x1CC0314 VA: 0x1CC0314
	|-EntityManager.EntityEntry.HasComponent<EntityID>
	|
	|-RVA: 0x1CC03D4 Offset: 0x1CC03D4 VA: 0x1CC03D4
	|-EntityManager.EntityEntry.HasComponent<Found>
	|
	|-RVA: 0x1CC0494 Offset: 0x1CC0494 VA: 0x1CC0494
	|-EntityManager.EntityEntry.HasComponent<Head>
	|
	|-RVA: 0x1CC0554 Offset: 0x1CC0554 VA: 0x1CC0554
	|-EntityManager.EntityEntry.HasComponent<LerpPosition>
	|
	|-RVA: 0x1CC0614 Offset: 0x1CC0614 VA: 0x1CC0614
	|-EntityManager.EntityEntry.HasComponent<LerpRotation>
	|
	|-RVA: 0x1CC06D4 Offset: 0x1CC06D4 VA: 0x1CC06D4
	|-EntityManager.EntityEntry.HasComponent<LerpScale>
	|
	|-RVA: 0x1CC0794 Offset: 0x1CC0794 VA: 0x1CC0794
	|-EntityManager.EntityEntry.HasComponent<DontRecordPlayingID>
	|
	|-RVA: 0x1CC0854 Offset: 0x1CC0854 VA: 0x1CC0854
	|-EntityManager.EntityEntry.HasComponent<PositionComponent>
	|
	|-RVA: 0x1CC0914 Offset: 0x1CC0914 VA: 0x1CC0914
	|-EntityManager.EntityEntry.HasComponent<RtpcComponent>
	|
	|-RVA: 0x1CC09D4 Offset: 0x1CC09D4 VA: 0x1CC09D4
	|-EntityManager.EntityEntry.HasComponent<SwitchComponent>
	|
	|-RVA: 0x1CC0A94 Offset: 0x1CC0A94 VA: 0x1CC0A94
	|-EntityManager.EntityEntry.HasComponent<Spawned>
	*/

	// RVA: -1 Offset: -1
	public bool HasComponentObject<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CC0B54 Offset: 0x1CC0B54 VA: 0x1CC0B54
	|-EntityManager.EntityEntry.HasComponentObject<object>
	*/

	// RVA: 0x115650C Offset: 0x115650C VA: 0x115650C
	private bool HasComponent(in int typeIndex) { }

	// RVA: -1 Offset: -1
	public T AddComponentObject<T>(T obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD7980 Offset: 0xCD7980 VA: 0xCD7980
	|-EntityManager.EntityEntry.AddComponentObject<object>
	*/

	// RVA: -1 Offset: -1
	public T AddOrSetComponentObject<T>(T obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD7C48 Offset: 0xCD7C48 VA: 0xCD7C48
	|-EntityManager.EntityEntry.AddOrSetComponentObject<object>
	*/

	// RVA: -1 Offset: -1
	public void AddComponentData<T>(in T data) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFC5BE4 Offset: 0xFC5BE4 VA: 0xFC5BE4
	|-EntityManager.EntityEntry.AddComponentData<EntityID>
	|
	|-RVA: 0xFC5FD0 Offset: 0xFC5FD0 VA: 0xFC5FD0
	|-EntityManager.EntityEntry.AddComponentData<DestroyEvent>
	|
	|-RVA: 0xFC63BC Offset: 0xFC63BC VA: 0xFC63BC
	|-EntityManager.EntityEntry.AddComponentData<DirectDestroyEvent>
	|
	|-RVA: 0xFC67A8 Offset: 0xFC67A8 VA: 0xFC67A8
	|-EntityManager.EntityEntry.AddComponentData<Found>
	|
	|-RVA: 0xFC6B94 Offset: 0xFC6B94 VA: 0xFC6B94
	|-EntityManager.EntityEntry.AddComponentData<LerpPosition>
	|
	|-RVA: 0xFC6F80 Offset: 0xFC6F80 VA: 0xFC6F80
	|-EntityManager.EntityEntry.AddComponentData<LerpRotation>
	|
	|-RVA: 0xFC736C Offset: 0xFC736C VA: 0xFC736C
	|-EntityManager.EntityEntry.AddComponentData<LerpScale>
	|
	|-RVA: 0xFC7758 Offset: 0xFC7758 VA: 0xFC7758
	|-EntityManager.EntityEntry.AddComponentData<ExplosiveComponent>
	|
	|-RVA: 0xFC7B44 Offset: 0xFC7B44 VA: 0xFC7B44
	|-EntityManager.EntityEntry.AddComponentData<SendFoundDefuserSystem.Processed>
	|
	|-RVA: 0xFC7F30 Offset: 0xFC7F30 VA: 0xFC7F30
	|-EntityManager.EntityEntry.AddComponentData<DelayDestroyEntityComponent>
	|
	|-RVA: 0xFC831C Offset: 0xFC831C VA: 0xFC831C
	|-EntityManager.EntityEntry.AddComponentData<LastPositionComponent>
	|
	|-RVA: 0xFC8708 Offset: 0xFC8708 VA: 0xFC8708
	|-EntityManager.EntityEntry.AddComponentData<SoundEventIDComponent>
	|
	|-RVA: 0xFC8AF4 Offset: 0xFC8AF4 VA: 0xFC8AF4
	|-EntityManager.EntityEntry.AddComponentData<ToggleOnForwardToPlayer>
	*/

	// RVA: -1 Offset: -1
	public void AddOrSetComponentData<T>(in T data) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFC8EE0 Offset: 0xFC8EE0 VA: 0xFC8EE0
	|-EntityManager.EntityEntry.AddOrSetComponentData<DisableButtonWhenCountingDownCpt>
	|
	|-RVA: 0xFC91CC Offset: 0xFC91CC VA: 0xFC91CC
	|-EntityManager.EntityEntry.AddOrSetComponentData<Body>
	|
	|-RVA: 0xFC94B8 Offset: 0xFC94B8 VA: 0xFC94B8
	|-EntityManager.EntityEntry.AddOrSetComponentData<ContentConfigCpt>
	|
	|-RVA: 0xFC97A4 Offset: 0xFC97A4 VA: 0xFC97A4
	|-EntityManager.EntityEntry.AddOrSetComponentData<ForwardToPlayerCpt>
	|
	|-RVA: 0xFC9A90 Offset: 0xFC9A90 VA: 0xFC9A90
	|-EntityManager.EntityEntry.AddOrSetComponentData<Found>
	|
	|-RVA: 0xFC9D7C Offset: 0xFC9D7C VA: 0xFC9D7C
	|-EntityManager.EntityEntry.AddOrSetComponentData<Head>
	|
	|-RVA: 0xFCA068 Offset: 0xFCA068 VA: 0xFCA068
	|-EntityManager.EntityEntry.AddOrSetComponentData<FPLODManagerComponent>
	|
	|-RVA: 0xFCA354 Offset: 0xFCA354 VA: 0xFCA354
	|-EntityManager.EntityEntry.AddOrSetComponentData<LODLevelComponent>
	|
	|-RVA: 0xFCA640 Offset: 0xFCA640 VA: 0xFCA640
	|-EntityManager.EntityEntry.AddOrSetComponentData<LerpPositionWhenActiveCpt>
	|
	|-RVA: 0xFCA92C Offset: 0xFCA92C VA: 0xFCA92C
	|-EntityManager.EntityEntry.AddOrSetComponentData<LerpRotationWhenActiveCpt>
	|
	|-RVA: 0xFCAC18 Offset: 0xFCAC18 VA: 0xFCAC18
	|-EntityManager.EntityEntry.AddOrSetComponentData<LerpScaleWhenActiveCpt>
	|
	|-RVA: 0xFCAF04 Offset: 0xFCAF04 VA: 0xFCAF04
	|-EntityManager.EntityEntry.AddOrSetComponentData<PlayEffectWhenDestroyByContentConfig>
	|
	|-RVA: 0xFCB1F0 Offset: 0xFCB1F0 VA: 0xFCB1F0
	|-EntityManager.EntityEntry.AddOrSetComponentData<PlayEffectWhenDestroyCpt>
	|
	|-RVA: 0xFCB4DC Offset: 0xFCB4DC VA: 0xFCB4DC
	|-EntityManager.EntityEntry.AddOrSetComponentData<AmmunitionComponent>
	|
	|-RVA: 0xFCB7C8 Offset: 0xFCB7C8 VA: 0xFCB7C8
	|-EntityManager.EntityEntry.AddOrSetComponentData<AuthComponent>
	|
	|-RVA: 0xFCBAB4 Offset: 0xFCBAB4 VA: 0xFCBAB4
	|-EntityManager.EntityEntry.AddOrSetComponentData<AuthResultComponent>
	|
	|-RVA: 0xFCBDA0 Offset: 0xFCBDA0 VA: 0xFCBDA0
	|-EntityManager.EntityEntry.AddOrSetComponentData<GetBackButtonComponent>
	|
	|-RVA: 0xFCC08C Offset: 0xFCC08C VA: 0xFCC08C
	|-EntityManager.EntityEntry.AddOrSetComponentData<LineCheckComponent>
	|
	|-RVA: 0xFCC378 Offset: 0xFCC378 VA: 0xFCC378
	|-EntityManager.EntityEntry.AddOrSetComponentData<OperateCheckComponent>
	|
	|-RVA: 0xFCC664 Offset: 0xFCC664 VA: 0xFCC664
	|-EntityManager.EntityEntry.AddOrSetComponentData<OperateCheckResult>
	|
	|-RVA: 0xFCC950 Offset: 0xFCC950 VA: 0xFCC950
	|-EntityManager.EntityEntry.AddOrSetComponentData<OwnerComponent>
	|
	|-RVA: 0xFCCC3C Offset: 0xFCCC3C VA: 0xFCCC3C
	|-EntityManager.EntityEntry.AddOrSetComponentData<ReachableCheckComponent>
	|
	|-RVA: 0xFCCF28 Offset: 0xFCCF28 VA: 0xFCCF28
	|-EntityManager.EntityEntry.AddOrSetComponentData<SightClearCheckComponent>
	|
	|-RVA: 0xFCD214 Offset: 0xFCD214 VA: 0xFCD214
	|-EntityManager.EntityEntry.AddOrSetComponentData<Scan>
	|
	|-RVA: 0x1004BF0 Offset: 0x1004BF0 VA: 0x1004BF0
	|-EntityManager.EntityEntry.AddOrSetComponentData<SendFoundBombRegionSystem.Processed>
	|
	|-RVA: 0x1004EDC Offset: 0x1004EDC VA: 0x1004EDC
	|-EntityManager.EntityEntry.AddOrSetComponentData<PositionComponent>
	|
	|-RVA: 0x10051C8 Offset: 0x10051C8 VA: 0x10051C8
	|-EntityManager.EntityEntry.AddOrSetComponentData<SoundEventIDComponent>
	|
	|-RVA: 0x10054B4 Offset: 0x10054B4 VA: 0x10054B4
	|-EntityManager.EntityEntry.AddOrSetComponentData<Spawned>
	|
	|-RVA: 0x10057A0 Offset: 0x10057A0 VA: 0x10057A0
	|-EntityManager.EntityEntry.AddOrSetComponentData<ToggleOnForwardToPlayer>
	|
	|-RVA: 0x1005A8C Offset: 0x1005A8C VA: 0x1005A8C
	|-EntityManager.EntityEntry.AddOrSetComponentData<CountDownCpt>
	*/

	// RVA: -1 Offset: -1
	public ref T GetComponentData<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x138401C Offset: 0x138401C VA: 0x138401C
	|-EntityManager.EntityEntry.GetComponentData<EntityID>
	|
	|-RVA: 0x13843C0 Offset: 0x13843C0 VA: 0x13843C0
	|-EntityManager.EntityEntry.GetComponentData<ContentConfigCpt>
	|
	|-RVA: 0x1384764 Offset: 0x1384764 VA: 0x1384764
	|-EntityManager.EntityEntry.GetComponentData<ForwardToPlayerCpt>
	|
	|-RVA: 0x1384B08 Offset: 0x1384B08 VA: 0x1384B08
	|-EntityManager.EntityEntry.GetComponentData<Found>
	|
	|-RVA: 0x1384EAC Offset: 0x1384EAC VA: 0x1384EAC
	|-EntityManager.EntityEntry.GetComponentData<FPLODManagerComponent>
	|
	|-RVA: 0x1385250 Offset: 0x1385250 VA: 0x1385250
	|-EntityManager.EntityEntry.GetComponentData<LODLevelComponent>
	|
	|-RVA: 0x13855F4 Offset: 0x13855F4 VA: 0x13855F4
	|-EntityManager.EntityEntry.GetComponentData<LerpPosition>
	|
	|-RVA: 0x1385998 Offset: 0x1385998 VA: 0x1385998
	|-EntityManager.EntityEntry.GetComponentData<LerpPositionWhenActiveCpt>
	|
	|-RVA: 0x1385D3C Offset: 0x1385D3C VA: 0x1385D3C
	|-EntityManager.EntityEntry.GetComponentData<LerpRotation>
	|
	|-RVA: 0x13860E0 Offset: 0x13860E0 VA: 0x13860E0
	|-EntityManager.EntityEntry.GetComponentData<LerpRotationWhenActiveCpt>
	|
	|-RVA: 0x1386484 Offset: 0x1386484 VA: 0x1386484
	|-EntityManager.EntityEntry.GetComponentData<LerpScale>
	|
	|-RVA: 0x1386828 Offset: 0x1386828 VA: 0x1386828
	|-EntityManager.EntityEntry.GetComponentData<LerpScaleWhenActiveCpt>
	|
	|-RVA: 0x1386BCC Offset: 0x1386BCC VA: 0x1386BCC
	|-EntityManager.EntityEntry.GetComponentData<PlayEffectWhenDestroyCpt>
	|
	|-RVA: 0x1386F70 Offset: 0x1386F70 VA: 0x1386F70
	|-EntityManager.EntityEntry.GetComponentData<AmmunitionComponent>
	|
	|-RVA: 0x1387314 Offset: 0x1387314 VA: 0x1387314
	|-EntityManager.EntityEntry.GetComponentData<AuthComponent>
	|
	|-RVA: 0x13876B8 Offset: 0x13876B8 VA: 0x13876B8
	|-EntityManager.EntityEntry.GetComponentData<AuthResultComponent>
	|
	|-RVA: 0x1387A5C Offset: 0x1387A5C VA: 0x1387A5C
	|-EntityManager.EntityEntry.GetComponentData<GetBackButtonComponent>
	|
	|-RVA: 0x1387E00 Offset: 0x1387E00 VA: 0x1387E00
	|-EntityManager.EntityEntry.GetComponentData<LineCheckComponent>
	|
	|-RVA: 0x13881A4 Offset: 0x13881A4 VA: 0x13881A4
	|-EntityManager.EntityEntry.GetComponentData<OperateCheckComponent>
	|
	|-RVA: 0x1388548 Offset: 0x1388548 VA: 0x1388548
	|-EntityManager.EntityEntry.GetComponentData<OperateCheckResult>
	|
	|-RVA: 0x13888EC Offset: 0x13888EC VA: 0x13888EC
	|-EntityManager.EntityEntry.GetComponentData<OwnerComponent>
	|
	|-RVA: 0x1388C90 Offset: 0x1388C90 VA: 0x1388C90
	|-EntityManager.EntityEntry.GetComponentData<ReachableCheckComponent>
	|
	|-RVA: 0x1389034 Offset: 0x1389034 VA: 0x1389034
	|-EntityManager.EntityEntry.GetComponentData<SightClearCheckComponent>
	|
	|-RVA: 0x13893D8 Offset: 0x13893D8 VA: 0x13893D8
	|-EntityManager.EntityEntry.GetComponentData<Scan>
	|
	|-RVA: 0x138977C Offset: 0x138977C VA: 0x138977C
	|-EntityManager.EntityEntry.GetComponentData<ExplosiveComponent>
	|
	|-RVA: 0x1389B20 Offset: 0x1389B20 VA: 0x1389B20
	|-EntityManager.EntityEntry.GetComponentData<DelayDestroyEntityComponent>
	|
	|-RVA: 0x1389EC4 Offset: 0x1389EC4 VA: 0x1389EC4
	|-EntityManager.EntityEntry.GetComponentData<DisplacementRecordComponent>
	|
	|-RVA: 0x138A268 Offset: 0x138A268 VA: 0x138A268
	|-EntityManager.EntityEntry.GetComponentData<LastPositionComponent>
	|
	|-RVA: 0x138A60C Offset: 0x138A60C VA: 0x138A60C
	|-EntityManager.EntityEntry.GetComponentData<LoopSoundComponent>
	|
	|-RVA: 0x138A9B0 Offset: 0x138A9B0 VA: 0x138A9B0
	|-EntityManager.EntityEntry.GetComponentData<PositionComponent>
	|
	|-RVA: 0x138AD54 Offset: 0x138AD54 VA: 0x138AD54
	|-EntityManager.EntityEntry.GetComponentData<RtpcComponent>
	|
	|-RVA: 0x138B0F8 Offset: 0x138B0F8 VA: 0x138B0F8
	|-EntityManager.EntityEntry.GetComponentData<SoundEventIDComponent>
	|
	|-RVA: 0x138B49C Offset: 0x138B49C VA: 0x138B49C
	|-EntityManager.EntityEntry.GetComponentData<SwitchComponent>
	|
	|-RVA: 0x138B840 Offset: 0x138B840 VA: 0x138B840
	|-EntityManager.EntityEntry.GetComponentData<CountDownCpt>
	*/

	// RVA: -1 Offset: -1
	public T GetComponentObject<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD7DA4 Offset: 0xCD7DA4 VA: 0xCD7DA4
	|-EntityManager.EntityEntry.GetComponentObject<object>
	*/

	// RVA: -1 Offset: -1
	public ref T TryGetComponentData<T>(out bool hasComponent) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x138BBE4 Offset: 0x138BBE4 VA: 0x138BBE4
	|-EntityManager.EntityEntry.TryGetComponentData<EntityID>
	*/

	// RVA: -1 Offset: -1
	public T TryGetComponentObject<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD7FD0 Offset: 0xCD7FD0 VA: 0xCD7FD0
	|-EntityManager.EntityEntry.TryGetComponentObject<object>
	*/

	// RVA: 0x115653C Offset: 0x115653C VA: 0x115653C
	private object GetComponentObject(int typeIndex) { }

	// RVA: -1 Offset: -1
	public void SetComponentData<T>(T data) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1008560 Offset: 0x1008560 VA: 0x1008560
	|-EntityManager.EntityEntry.SetComponentData<LerpPosition>
	|
	|-RVA: 0x10088B0 Offset: 0x10088B0 VA: 0x10088B0
	|-EntityManager.EntityEntry.SetComponentData<LerpRotation>
	|
	|-RVA: 0x1008C10 Offset: 0x1008C10 VA: 0x1008C10
	|-EntityManager.EntityEntry.SetComponentData<LerpScale>
	*/

	// RVA: -1 Offset: -1
	public void RemoveComponent<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1005D78 Offset: 0x1005D78 VA: 0x1005D78
	|-EntityManager.EntityEntry.RemoveComponent<EntityID>
	|
	|-RVA: 0x1006060 Offset: 0x1006060 VA: 0x1006060
	|-EntityManager.EntityEntry.RemoveComponent<DestroyEvent>
	|
	|-RVA: 0x1006348 Offset: 0x1006348 VA: 0x1006348
	|-EntityManager.EntityEntry.RemoveComponent<DirectDestroyEvent>
	|
	|-RVA: 0x1006630 Offset: 0x1006630 VA: 0x1006630
	|-EntityManager.EntityEntry.RemoveComponent<LODLevelComponent>
	|
	|-RVA: 0x1006918 Offset: 0x1006918 VA: 0x1006918
	|-EntityManager.EntityEntry.RemoveComponent<LerpPosition>
	|
	|-RVA: 0x1006C00 Offset: 0x1006C00 VA: 0x1006C00
	|-EntityManager.EntityEntry.RemoveComponent<LerpPositionWhenActiveCpt>
	|
	|-RVA: 0x1006EE8 Offset: 0x1006EE8 VA: 0x1006EE8
	|-EntityManager.EntityEntry.RemoveComponent<LerpRotation>
	|
	|-RVA: 0x10071D0 Offset: 0x10071D0 VA: 0x10071D0
	|-EntityManager.EntityEntry.RemoveComponent<LerpRotationWhenActiveCpt>
	|
	|-RVA: 0x10074B8 Offset: 0x10074B8 VA: 0x10074B8
	|-EntityManager.EntityEntry.RemoveComponent<LerpScale>
	|
	|-RVA: 0x10077A0 Offset: 0x10077A0 VA: 0x10077A0
	|-EntityManager.EntityEntry.RemoveComponent<LerpScaleWhenActiveCpt>
	|
	|-RVA: 0x1007A88 Offset: 0x1007A88 VA: 0x1007A88
	|-EntityManager.EntityEntry.RemoveComponent<Scan>
	|
	|-RVA: 0x1007D70 Offset: 0x1007D70 VA: 0x1007D70
	|-EntityManager.EntityEntry.RemoveComponent<LoopSoundComponent>
	|
	|-RVA: 0x1008058 Offset: 0x1008058 VA: 0x1008058
	|-EntityManager.EntityEntry.RemoveComponent<ToggleOnForwardToPlayer>
	*/

	// RVA: -1 Offset: -1
	public void TryRemoveComponent<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1008F60 Offset: 0x1008F60 VA: 0x1008F60
	|-EntityManager.EntityEntry.TryRemoveComponent<Found>
	*/

	// RVA: -1 Offset: -1
	public void RemoveComponentObject<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1008340 Offset: 0x1008340 VA: 0x1008340
	|-EntityManager.EntityEntry.RemoveComponentObject<object>
	*/

	// RVA: -1 Offset: -1
	public void TryRemoveComponentObject<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1009174 Offset: 0x1009174 VA: 0x1009174
	|-EntityManager.EntityEntry.TryRemoveComponentObject<object>
	*/

	// RVA: 0x1156660 Offset: 0x1156660 VA: 0x1156660
	public void .ctor() { }
}
