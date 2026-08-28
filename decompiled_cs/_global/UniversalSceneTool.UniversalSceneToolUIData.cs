// Namespace: 
private class UniversalSceneTool.UniversalSceneToolUIData : ISceneItemSceneUIData, ITipUiProxy, IDisposable // TypeDefIndex: 12143
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573CF0 Offset: 0x573CF0 VA: 0x573CF0
	private Vector3 <UIImgPivotWorldPos>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x573D00 Offset: 0x573D00 VA: 0x573D00
	private Vector3 <UIActivePivotWorldPos>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x573D10 Offset: 0x573D10 VA: 0x573D10
	private bool <IsVisible>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x573D20 Offset: 0x573D20 VA: 0x573D20
	private bool <IsDestroyed>k__BackingField; // 0x21
	[CompilerGeneratedAttribute] // RVA: 0x573D30 Offset: 0x573D30 VA: 0x573D30
	private byte <OwnerBID>k__BackingField; // 0x22
	[CompilerGeneratedAttribute] // RVA: 0x573D40 Offset: 0x573D40 VA: 0x573D40
	private content_table.Record <SceneItemCfg>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x573D50 Offset: 0x573D50 VA: 0x573D50
	private IBuffOwner <SelfBuffOwner>k__BackingField; // 0x28

	// Properties
	public Vector3 UIImgPivotWorldPos { get; set; }
	public Vector3 UIActivePivotWorldPos { get; set; }
	public bool IsVisible { get; set; }
	public bool IsDestroyed { get; set; }
	public byte OwnerBID { get; set; }
	public content_table.Record SceneItemCfg { get; set; }
	public IBuffOwner SelfBuffOwner { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667C50 Offset: 0x667C50 VA: 0x667C50
	// RVA: 0xB60220 Offset: 0xB60220 VA: 0xB60220 Slot: 4
	public Vector3 get_UIImgPivotWorldPos() { }

	[CompilerGeneratedAttribute] // RVA: 0x667C60 Offset: 0x667C60 VA: 0x667C60
	// RVA: 0xB5EF88 Offset: 0xB5EF88 VA: 0xB5EF88
	public void set_UIImgPivotWorldPos(Vector3 value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667C70 Offset: 0x667C70 VA: 0x667C70
	// RVA: 0xB60234 Offset: 0xB60234 VA: 0xB60234 Slot: 5
	public Vector3 get_UIActivePivotWorldPos() { }

	[CompilerGeneratedAttribute] // RVA: 0x667C80 Offset: 0x667C80 VA: 0x667C80
	// RVA: 0xB5F09C Offset: 0xB5F09C VA: 0xB5F09C
	public void set_UIActivePivotWorldPos(Vector3 value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667C90 Offset: 0x667C90 VA: 0x667C90
	// RVA: 0xB60248 Offset: 0xB60248 VA: 0xB60248 Slot: 6
	public bool get_IsVisible() { }

	[CompilerGeneratedAttribute] // RVA: 0x667CA0 Offset: 0x667CA0 VA: 0x667CA0
	// RVA: 0xB5EE78 Offset: 0xB5EE78 VA: 0xB5EE78
	public void set_IsVisible(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667CB0 Offset: 0x667CB0 VA: 0x667CB0
	// RVA: 0xB60250 Offset: 0xB60250 VA: 0xB60250 Slot: 7
	public bool get_IsDestroyed() { }

	[CompilerGeneratedAttribute] // RVA: 0x667CC0 Offset: 0x667CC0 VA: 0x667CC0
	// RVA: 0xB5F0C0 Offset: 0xB5F0C0 VA: 0xB5F0C0
	public void set_IsDestroyed(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667CD0 Offset: 0x667CD0 VA: 0x667CD0
	// RVA: 0xB60258 Offset: 0xB60258 VA: 0xB60258 Slot: 8
	public byte get_OwnerBID() { }

	[CompilerGeneratedAttribute] // RVA: 0x667CE0 Offset: 0x667CE0 VA: 0x667CE0
	// RVA: 0xB5F0B8 Offset: 0xB5F0B8 VA: 0xB5F0B8
	public void set_OwnerBID(byte value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667CF0 Offset: 0x667CF0 VA: 0x667CF0
	// RVA: 0xB60260 Offset: 0xB60260 VA: 0xB60260 Slot: 9
	public content_table.Record get_SceneItemCfg() { }

	[CompilerGeneratedAttribute] // RVA: 0x667D00 Offset: 0x667D00 VA: 0x667D00
	// RVA: 0xB5F0A8 Offset: 0xB5F0A8 VA: 0xB5F0A8
	public void set_SceneItemCfg(content_table.Record value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667D10 Offset: 0x667D10 VA: 0x667D10
	// RVA: 0xB60268 Offset: 0xB60268 VA: 0xB60268 Slot: 10
	public IBuffOwner get_SelfBuffOwner() { }

	[CompilerGeneratedAttribute] // RVA: 0x667D20 Offset: 0x667D20 VA: 0x667D20
	// RVA: 0xB5F0B0 Offset: 0xB5F0B0 VA: 0xB5F0B0
	public void set_SelfBuffOwner(IBuffOwner value) { }

	// RVA: 0xB60270 Offset: 0xB60270 VA: 0xB60270 Slot: 11
	public void Dispose() { }

	// RVA: 0xB5EE70 Offset: 0xB5EE70 VA: 0xB5EE70
	public void .ctor() { }
}
