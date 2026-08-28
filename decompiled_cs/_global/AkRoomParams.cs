// Namespace: 
public class AkRoomParams : IDisposable // TypeDefIndex: 5949
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkVector Up { get; set; }
	public AkVector Front { get; set; }
	public uint ReverbAuxBus { get; set; }
	public float ReverbLevel { get; set; }
	public float WallOcclusion { get; set; }
	public float RoomGameObj_AuxSendLevelToSelf { get; set; }
	public bool RoomGameObj_KeepRegistered { get; set; }

	// Methods

	// RVA: 0x1BC103C Offset: 0x1BC103C VA: 0x1BC103C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BC1064 Offset: 0x1BC1064 VA: 0x1BC1064
	internal static IntPtr getCPtr(AkRoomParams obj) { }

	// RVA: 0x1BC10BC Offset: 0x1BC10BC VA: 0x1BC10BC Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BC10E8 Offset: 0x1BC10E8 VA: 0x1BC10E8 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BC115C Offset: 0x1BC115C VA: 0x1BC115C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BC007C Offset: 0x1BC007C VA: 0x1BC007C
	public void .ctor() { }

	// RVA: 0x1BC12E0 Offset: 0x1BC12E0 VA: 0x1BC12E0
	public void set_Up(AkVector value) { }

	// RVA: 0x1BC0118 Offset: 0x1BC0118 VA: 0x1BC0118
	public AkVector get_Up() { }

	// RVA: 0x1BC1380 Offset: 0x1BC1380 VA: 0x1BC1380
	public void set_Front(AkVector value) { }

	// RVA: 0x1BC01E8 Offset: 0x1BC01E8 VA: 0x1BC01E8
	public AkVector get_Front() { }

	// RVA: 0x1BC02B8 Offset: 0x1BC02B8 VA: 0x1BC02B8
	public void set_ReverbAuxBus(uint value) { }

	// RVA: 0x1BC1420 Offset: 0x1BC1420 VA: 0x1BC1420
	public uint get_ReverbAuxBus() { }

	// RVA: 0x1BC0348 Offset: 0x1BC0348 VA: 0x1BC0348
	public void set_ReverbLevel(float value) { }

	// RVA: 0x1BC14A8 Offset: 0x1BC14A8 VA: 0x1BC14A8
	public float get_ReverbLevel() { }

	// RVA: 0x1BC03D8 Offset: 0x1BC03D8 VA: 0x1BC03D8
	public void set_WallOcclusion(float value) { }

	// RVA: 0x1BC1530 Offset: 0x1BC1530 VA: 0x1BC1530
	public float get_WallOcclusion() { }

	// RVA: 0x1BC0468 Offset: 0x1BC0468 VA: 0x1BC0468
	public void set_RoomGameObj_AuxSendLevelToSelf(float value) { }

	// RVA: 0x1BC15B8 Offset: 0x1BC15B8 VA: 0x1BC15B8
	public float get_RoomGameObj_AuxSendLevelToSelf() { }

	// RVA: 0x1BC04F8 Offset: 0x1BC04F8 VA: 0x1BC04F8
	public void set_RoomGameObj_KeepRegistered(bool value) { }

	// RVA: 0x1BC1640 Offset: 0x1BC1640 VA: 0x1BC1640
	public bool get_RoomGameObj_KeepRegistered() { }
}
