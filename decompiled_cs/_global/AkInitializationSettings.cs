// Namespace: 
public class AkInitializationSettings : IDisposable // TypeDefIndex: 5908
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkMemSettings memSettings { get; set; }
	public AkStreamMgrSettings streamMgrSettings { get; set; }
	public AkDeviceSettings deviceSettings { get; set; }
	public AkInitSettings initSettings { get; set; }
	public AkPlatformInitSettings platformSettings { get; set; }
	public AkMusicSettings musicSettings { get; set; }
	public uint preparePoolSize { get; set; }
	public AkCommunicationSettings communicationSettings { get; set; }
	public AkUnityPlatformSpecificSettings unityPlatformSpecificSettings { get; set; }

	// Methods

	// RVA: 0x1BA81E0 Offset: 0x1BA81E0 VA: 0x1BA81E0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA8208 Offset: 0x1BA8208 VA: 0x1BA8208
	internal static IntPtr getCPtr(AkInitializationSettings obj) { }

	// RVA: 0x1BA8260 Offset: 0x1BA8260 VA: 0x1BA8260 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BA828C Offset: 0x1BA828C VA: 0x1BA828C Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BA8300 Offset: 0x1BA8300 VA: 0x1BA8300 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BA8484 Offset: 0x1BA8484 VA: 0x1BA8484
	public void .ctor() { }

	// RVA: 0x1BA8520 Offset: 0x1BA8520 VA: 0x1BA8520
	public void set_memSettings(AkMemSettings value) { }

	// RVA: 0x1BA8650 Offset: 0x1BA8650 VA: 0x1BA8650
	public AkMemSettings get_memSettings() { }

	// RVA: 0x1BA874C Offset: 0x1BA874C VA: 0x1BA874C
	public void set_streamMgrSettings(AkStreamMgrSettings value) { }

	// RVA: 0x1BA87EC Offset: 0x1BA87EC VA: 0x1BA87EC
	public AkStreamMgrSettings get_streamMgrSettings() { }

	// RVA: 0x1BA88BC Offset: 0x1BA88BC VA: 0x1BA88BC
	public void set_deviceSettings(AkDeviceSettings value) { }

	// RVA: 0x1BA895C Offset: 0x1BA895C VA: 0x1BA895C
	public AkDeviceSettings get_deviceSettings() { }

	// RVA: 0x1BA8A2C Offset: 0x1BA8A2C VA: 0x1BA8A2C
	public void set_initSettings(AkInitSettings value) { }

	// RVA: 0x1BA8B04 Offset: 0x1BA8B04 VA: 0x1BA8B04
	public AkInitSettings get_initSettings() { }

	// RVA: 0x1BA8BD8 Offset: 0x1BA8BD8 VA: 0x1BA8BD8
	public void set_platformSettings(AkPlatformInitSettings value) { }

	// RVA: 0x1BA8D08 Offset: 0x1BA8D08 VA: 0x1BA8D08
	public AkPlatformInitSettings get_platformSettings() { }

	// RVA: 0x1BA8E04 Offset: 0x1BA8E04 VA: 0x1BA8E04
	public void set_musicSettings(AkMusicSettings value) { }

	// RVA: 0x1BA8F34 Offset: 0x1BA8F34 VA: 0x1BA8F34
	public AkMusicSettings get_musicSettings() { }

	// RVA: 0x1BA9030 Offset: 0x1BA9030 VA: 0x1BA9030
	public void set_preparePoolSize(uint value) { }

	// RVA: 0x1BA90C0 Offset: 0x1BA90C0 VA: 0x1BA90C0
	public uint get_preparePoolSize() { }

	// RVA: 0x1BA9148 Offset: 0x1BA9148 VA: 0x1BA9148
	public void set_communicationSettings(AkCommunicationSettings value) { }

	// RVA: 0x1BA91E8 Offset: 0x1BA91E8 VA: 0x1BA91E8
	public AkCommunicationSettings get_communicationSettings() { }

	// RVA: 0x1BA92B8 Offset: 0x1BA92B8 VA: 0x1BA92B8
	public void set_unityPlatformSpecificSettings(AkUnityPlatformSpecificSettings value) { }

	// RVA: 0x1BA9358 Offset: 0x1BA9358 VA: 0x1BA9358
	public AkUnityPlatformSpecificSettings get_unityPlatformSpecificSettings() { }
}
