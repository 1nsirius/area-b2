// Namespace: 
private class AssetPool.AssetRequest : IAssetRequest, IEnumerator // TypeDefIndex: 9766
{
	// Fields
	private string mAssetPath; // 0x8
	private float mProgress; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56DF5C Offset: 0x56DF5C VA: 0x56DF5C
	private bool <IsDone>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56DF6C Offset: 0x56DF6C VA: 0x56DF6C
	private Object <Asset>k__BackingField; // 0x14

	// Properties
	public string AssetPath { get; }
	public bool IsDone { get; set; }
	public Object Asset { get; set; }
	public float Progress { get; }
	public object Current { get; }

	// Methods

	// RVA: 0xF2B188 Offset: 0xF2B188 VA: 0xF2B188
	public void .ctor(string assetPath) { }

	// RVA: 0xF2BB18 Offset: 0xF2BB18 VA: 0xF2BB18 Slot: 4
	public string get_AssetPath() { }

	[CompilerGeneratedAttribute] // RVA: 0x65CB20 Offset: 0x65CB20 VA: 0x65CB20
	// RVA: 0xF2BB20 Offset: 0xF2BB20 VA: 0xF2BB20 Slot: 5
	public bool get_IsDone() { }

	[CompilerGeneratedAttribute] // RVA: 0x65CB30 Offset: 0x65CB30 VA: 0x65CB30
	// RVA: 0xF2BB28 Offset: 0xF2BB28 VA: 0xF2BB28
	private void set_IsDone(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65CB40 Offset: 0x65CB40 VA: 0x65CB40
	// RVA: 0xF2BB30 Offset: 0xF2BB30 VA: 0xF2BB30 Slot: 6
	public Object get_Asset() { }

	[CompilerGeneratedAttribute] // RVA: 0x65CB50 Offset: 0x65CB50 VA: 0x65CB50
	// RVA: 0xF2BB38 Offset: 0xF2BB38 VA: 0xF2BB38
	private void set_Asset(Object value) { }

	// RVA: 0xF2BB40 Offset: 0xF2BB40 VA: 0xF2BB40 Slot: 7
	public float get_Progress() { }

	// RVA: 0xF2BB48 Offset: 0xF2BB48 VA: 0xF2BB48 Slot: 8
	public bool MoveNext() { }

	// RVA: 0xF2BB5C Offset: 0xF2BB5C VA: 0xF2BB5C Slot: 10
	public void Reset() { }

	// RVA: 0xF2BB60 Offset: 0xF2BB60 VA: 0xF2BB60 Slot: 9
	public object get_Current() { }

	// RVA: 0xF2B1A8 Offset: 0xF2B1A8 VA: 0xF2B1A8
	public void SetProgress(float progress) { }

	// RVA: 0xF2B1B0 Offset: 0xF2B1B0 VA: 0xF2B1B0
	public void SetAsFinish(Object asset) { }
}
