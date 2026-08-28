// Namespace: 
public class AkInitSettings : IDisposable // TypeDefIndex: 5909
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint uMaxNumPaths { get; set; }
	public uint uDefaultPoolSize { get; set; }
	public float fDefaultPoolRatioThreshold { get; set; }
	public uint uCommandQueueSize { get; set; }
	public int uPrepareEventMemoryPoolID { get; set; }
	public bool bEnableGameSyncPreparation { get; set; }
	public uint uContinuousPlaybackLookAhead { get; set; }
	public uint uNumSamplesPerFrame { get; set; }
	public uint uMonitorPoolSize { get; set; }
	public uint uMonitorQueuePoolSize { get; set; }
	public AkOutputSettings settingsMainOutput { get; set; }
	public uint uMaxHardwareTimeoutMs { get; set; }
	public bool bUseSoundBankMgrThread { get; set; }
	public bool bUseLEngineThread { get; set; }
	public string szPluginDLLPath { get; set; }
	public AkFloorPlane eFloorPlane { get; set; }

	// Methods

	// RVA: 0x1BA6BD0 Offset: 0x1BA6BD0 VA: 0x1BA6BD0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA6BF8 Offset: 0x1BA6BF8 VA: 0x1BA6BF8
	internal static IntPtr getCPtr(AkInitSettings obj) { }

	// RVA: 0x1BA6C50 Offset: 0x1BA6C50 VA: 0x1BA6C50 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BA6C7C Offset: 0x1BA6C7C VA: 0x1BA6C7C Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BA6CF0 Offset: 0x1BA6CF0 VA: 0x1BA6CF0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BA6E74 Offset: 0x1BA6E74 VA: 0x1BA6E74
	public void set_uMaxNumPaths(uint value) { }

	// RVA: 0x1BA6F04 Offset: 0x1BA6F04 VA: 0x1BA6F04
	public uint get_uMaxNumPaths() { }

	// RVA: 0x1BA6F8C Offset: 0x1BA6F8C VA: 0x1BA6F8C
	public void set_uDefaultPoolSize(uint value) { }

	// RVA: 0x1BA701C Offset: 0x1BA701C VA: 0x1BA701C
	public uint get_uDefaultPoolSize() { }

	// RVA: 0x1BA70A4 Offset: 0x1BA70A4 VA: 0x1BA70A4
	public void set_fDefaultPoolRatioThreshold(float value) { }

	// RVA: 0x1BA7134 Offset: 0x1BA7134 VA: 0x1BA7134
	public float get_fDefaultPoolRatioThreshold() { }

	// RVA: 0x1BA71BC Offset: 0x1BA71BC VA: 0x1BA71BC
	public void set_uCommandQueueSize(uint value) { }

	// RVA: 0x1BA724C Offset: 0x1BA724C VA: 0x1BA724C
	public uint get_uCommandQueueSize() { }

	// RVA: 0x1BA72D4 Offset: 0x1BA72D4 VA: 0x1BA72D4
	public void set_uPrepareEventMemoryPoolID(int value) { }

	// RVA: 0x1BA7364 Offset: 0x1BA7364 VA: 0x1BA7364
	public int get_uPrepareEventMemoryPoolID() { }

	// RVA: 0x1BA73EC Offset: 0x1BA73EC VA: 0x1BA73EC
	public void set_bEnableGameSyncPreparation(bool value) { }

	// RVA: 0x1BA747C Offset: 0x1BA747C VA: 0x1BA747C
	public bool get_bEnableGameSyncPreparation() { }

	// RVA: 0x1BA7504 Offset: 0x1BA7504 VA: 0x1BA7504
	public void set_uContinuousPlaybackLookAhead(uint value) { }

	// RVA: 0x1BA7594 Offset: 0x1BA7594 VA: 0x1BA7594
	public uint get_uContinuousPlaybackLookAhead() { }

	// RVA: 0x1BA761C Offset: 0x1BA761C VA: 0x1BA761C
	public void set_uNumSamplesPerFrame(uint value) { }

	// RVA: 0x1BA76AC Offset: 0x1BA76AC VA: 0x1BA76AC
	public uint get_uNumSamplesPerFrame() { }

	// RVA: 0x1BA7734 Offset: 0x1BA7734 VA: 0x1BA7734
	public void set_uMonitorPoolSize(uint value) { }

	// RVA: 0x1BA77C4 Offset: 0x1BA77C4 VA: 0x1BA77C4
	public uint get_uMonitorPoolSize() { }

	// RVA: 0x1BA784C Offset: 0x1BA784C VA: 0x1BA784C
	public void set_uMonitorQueuePoolSize(uint value) { }

	// RVA: 0x1BA78DC Offset: 0x1BA78DC VA: 0x1BA78DC
	public uint get_uMonitorQueuePoolSize() { }

	// RVA: 0x1BA7964 Offset: 0x1BA7964 VA: 0x1BA7964
	public void set_settingsMainOutput(AkOutputSettings value) { }

	// RVA: 0x1BA7A94 Offset: 0x1BA7A94 VA: 0x1BA7A94
	public AkOutputSettings get_settingsMainOutput() { }

	// RVA: 0x1BA7B90 Offset: 0x1BA7B90 VA: 0x1BA7B90
	public void set_uMaxHardwareTimeoutMs(uint value) { }

	// RVA: 0x1BA7C20 Offset: 0x1BA7C20 VA: 0x1BA7C20
	public uint get_uMaxHardwareTimeoutMs() { }

	// RVA: 0x1BA7CA8 Offset: 0x1BA7CA8 VA: 0x1BA7CA8
	public void set_bUseSoundBankMgrThread(bool value) { }

	// RVA: 0x1BA7D38 Offset: 0x1BA7D38 VA: 0x1BA7D38
	public bool get_bUseSoundBankMgrThread() { }

	// RVA: 0x1BA7DC0 Offset: 0x1BA7DC0 VA: 0x1BA7DC0
	public void set_bUseLEngineThread(bool value) { }

	// RVA: 0x1BA7E50 Offset: 0x1BA7E50 VA: 0x1BA7E50
	public bool get_bUseLEngineThread() { }

	// RVA: 0x1BA7ED8 Offset: 0x1BA7ED8 VA: 0x1BA7ED8
	public void set_szPluginDLLPath(string value) { }

	// RVA: 0x1BA7F68 Offset: 0x1BA7F68 VA: 0x1BA7F68
	public string get_szPluginDLLPath() { }

	// RVA: 0x1BA802C Offset: 0x1BA802C VA: 0x1BA802C
	public void set_eFloorPlane(AkFloorPlane value) { }

	// RVA: 0x1BA80BC Offset: 0x1BA80BC VA: 0x1BA80BC
	public AkFloorPlane get_eFloorPlane() { }

	// RVA: 0x1BA8144 Offset: 0x1BA8144 VA: 0x1BA8144
	public void .ctor() { }
}
