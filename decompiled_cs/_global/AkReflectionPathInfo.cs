// Namespace: 
public class AkReflectionPathInfo : IDisposable // TypeDefIndex: 5947
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkVector imageSource { get; set; }
	public uint numPathPoints { get; set; }
	public uint numReflections { get; set; }
	public AkVector occlusionPoint { get; set; }
	public float level { get; set; }
	public bool isOccluded { get; set; }

	// Methods

	// RVA: 0x1BBE9D0 Offset: 0x1BBE9D0 VA: 0x1BBE9D0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BBE9F8 Offset: 0x1BBE9F8 VA: 0x1BBE9F8
	internal static IntPtr getCPtr(AkReflectionPathInfo obj) { }

	// RVA: 0x1BBEA50 Offset: 0x1BBEA50 VA: 0x1BBEA50 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BBEA7C Offset: 0x1BBEA7C VA: 0x1BBEA7C Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BBEAF0 Offset: 0x1BBEAF0 VA: 0x1BBEAF0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BBEC74 Offset: 0x1BBEC74 VA: 0x1BBEC74
	public void set_imageSource(AkVector value) { }

	// RVA: 0x1BBED14 Offset: 0x1BBED14 VA: 0x1BBED14
	public AkVector get_imageSource() { }

	// RVA: 0x1BBEDE4 Offset: 0x1BBEDE4 VA: 0x1BBEDE4
	public void set_numPathPoints(uint value) { }

	// RVA: 0x1BBEE74 Offset: 0x1BBEE74 VA: 0x1BBEE74
	public uint get_numPathPoints() { }

	// RVA: 0x1BBEEFC Offset: 0x1BBEEFC VA: 0x1BBEEFC
	public void set_numReflections(uint value) { }

	// RVA: 0x1BBEF8C Offset: 0x1BBEF8C VA: 0x1BBEF8C
	public uint get_numReflections() { }

	// RVA: 0x1BBF014 Offset: 0x1BBF014 VA: 0x1BBF014
	public void set_occlusionPoint(AkVector value) { }

	// RVA: 0x1BBF0B4 Offset: 0x1BBF0B4 VA: 0x1BBF0B4
	public AkVector get_occlusionPoint() { }

	// RVA: 0x1BBF184 Offset: 0x1BBF184 VA: 0x1BBF184
	public void set_level(float value) { }

	// RVA: 0x1BBF214 Offset: 0x1BBF214 VA: 0x1BBF214
	public float get_level() { }

	// RVA: 0x1BBF29C Offset: 0x1BBF29C VA: 0x1BBF29C
	public void set_isOccluded(bool value) { }

	// RVA: 0x1BBF32C Offset: 0x1BBF32C VA: 0x1BBF32C
	public bool get_isOccluded() { }

	// RVA: 0x1BBF3B4 Offset: 0x1BBF3B4 VA: 0x1BBF3B4
	public static int GetSizeOf() { }

	// RVA: 0x1BBF430 Offset: 0x1BBF430 VA: 0x1BBF430
	public AkVector GetPathPoint(uint idx) { }

	// RVA: 0x1BBF508 Offset: 0x1BBF508 VA: 0x1BBF508
	public AkAcousticSurface GetAcousticSurface(uint idx) { }

	// RVA: 0x1BBF5C8 Offset: 0x1BBF5C8 VA: 0x1BBF5C8
	public float GetDiffraction(uint idx) { }

	// RVA: 0x1BBF658 Offset: 0x1BBF658 VA: 0x1BBF658
	public void Clone(AkReflectionPathInfo other) { }

	// RVA: 0x1BBF730 Offset: 0x1BBF730 VA: 0x1BBF730
	public void .ctor() { }
}
