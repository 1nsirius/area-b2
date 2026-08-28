// Namespace: 
public class AkPlatformInitSettings : IDisposable // TypeDefIndex: 5862
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkThreadProperties threadLEngine { get; set; }
	public AkThreadProperties threadOutputMgr { get; set; }
	public AkThreadProperties threadBankManager { get; set; }
	public AkThreadProperties threadMonitor { get; set; }
	public float fLEngineDefaultPoolRatioThreshold { get; set; }
	public uint uLEngineDefaultPoolSize { get; set; }
	public uint uSampleRate { get; set; }
	public ushort uNumRefillsInVoice { get; set; }
	public uint uChannelMask { get; set; }
	public bool bRoundFrameSizeToHWSize { get; set; }

	// Methods

	// RVA: 0x1BA8DDC Offset: 0x1BA8DDC VA: 0x1BA8DDC
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA8CB0 Offset: 0x1BA8CB0 VA: 0x1BA8CB0
	internal static IntPtr getCPtr(AkPlatformInitSettings obj) { }

	// RVA: 0x1BB7258 Offset: 0x1BB7258 VA: 0x1BB7258 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB7284 Offset: 0x1BB7284 VA: 0x1BB7284 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB72F8 Offset: 0x1BB72F8 VA: 0x1BB72F8 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB747C Offset: 0x1BB747C VA: 0x1BB747C
	public void set_threadLEngine(AkThreadProperties value) { }

	// RVA: 0x1BB751C Offset: 0x1BB751C VA: 0x1BB751C
	public AkThreadProperties get_threadLEngine() { }

	// RVA: 0x1BB75EC Offset: 0x1BB75EC VA: 0x1BB75EC
	public void set_threadOutputMgr(AkThreadProperties value) { }

	// RVA: 0x1BB768C Offset: 0x1BB768C VA: 0x1BB768C
	public AkThreadProperties get_threadOutputMgr() { }

	// RVA: 0x1BB775C Offset: 0x1BB775C VA: 0x1BB775C
	public void set_threadBankManager(AkThreadProperties value) { }

	// RVA: 0x1BB77FC Offset: 0x1BB77FC VA: 0x1BB77FC
	public AkThreadProperties get_threadBankManager() { }

	// RVA: 0x1BB78CC Offset: 0x1BB78CC VA: 0x1BB78CC
	public void set_threadMonitor(AkThreadProperties value) { }

	// RVA: 0x1BB796C Offset: 0x1BB796C VA: 0x1BB796C
	public AkThreadProperties get_threadMonitor() { }

	// RVA: 0x1BB7A3C Offset: 0x1BB7A3C VA: 0x1BB7A3C
	public void set_fLEngineDefaultPoolRatioThreshold(float value) { }

	// RVA: 0x1BB7ACC Offset: 0x1BB7ACC VA: 0x1BB7ACC
	public float get_fLEngineDefaultPoolRatioThreshold() { }

	// RVA: 0x1BB7B54 Offset: 0x1BB7B54 VA: 0x1BB7B54
	public void set_uLEngineDefaultPoolSize(uint value) { }

	// RVA: 0x1BB7BE4 Offset: 0x1BB7BE4 VA: 0x1BB7BE4
	public uint get_uLEngineDefaultPoolSize() { }

	// RVA: 0x1BB7C6C Offset: 0x1BB7C6C VA: 0x1BB7C6C
	public void set_uSampleRate(uint value) { }

	// RVA: 0x1BB7CFC Offset: 0x1BB7CFC VA: 0x1BB7CFC
	public uint get_uSampleRate() { }

	// RVA: 0x1BB7D84 Offset: 0x1BB7D84 VA: 0x1BB7D84
	public void set_uNumRefillsInVoice(ushort value) { }

	// RVA: 0x1BB7E14 Offset: 0x1BB7E14 VA: 0x1BB7E14
	public ushort get_uNumRefillsInVoice() { }

	// RVA: 0x1BB7E9C Offset: 0x1BB7E9C VA: 0x1BB7E9C
	public void set_uChannelMask(uint value) { }

	// RVA: 0x1BB7F2C Offset: 0x1BB7F2C VA: 0x1BB7F2C
	public uint get_uChannelMask() { }

	// RVA: 0x1BB7FB4 Offset: 0x1BB7FB4 VA: 0x1BB7FB4
	public void set_bRoundFrameSizeToHWSize(bool value) { }

	// RVA: 0x1BB8044 Offset: 0x1BB8044 VA: 0x1BB8044
	public bool get_bRoundFrameSizeToHWSize() { }

	// RVA: 0x1BB80CC Offset: 0x1BB80CC VA: 0x1BB80CC
	public void .ctor() { }
}
