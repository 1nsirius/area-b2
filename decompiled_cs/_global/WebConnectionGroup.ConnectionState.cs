// Namespace: 
private class WebConnectionGroup.ConnectionState : IWebConnectionState // TypeDefIndex: 2014
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x4E6E0C Offset: 0x4E6E0C VA: 0x4E6E0C
	private WebConnection <Connection>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x4E6E1C Offset: 0x4E6E1C VA: 0x4E6E1C
	private WebConnectionGroup <Group>k__BackingField; // 0xC
	private bool busy; // 0x10
	private DateTime idleSince; // 0x18

	// Properties
	public WebConnection Connection { get; set; }
	public WebConnectionGroup Group { get; set; }
	public ServicePoint ServicePoint { get; }
	public bool Busy { get; }
	public DateTime IdleSince { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x4E79D0 Offset: 0x4E79D0 VA: 0x4E79D0
	// RVA: 0x155A6A0 Offset: 0x155A6A0 VA: 0x155A6A0
	public WebConnection get_Connection() { }

	[CompilerGeneratedAttribute] // RVA: 0x4E79E0 Offset: 0x4E79E0 VA: 0x4E79E0
	// RVA: 0x155A6A8 Offset: 0x155A6A8 VA: 0x155A6A8
	private void set_Connection(WebConnection value) { }

	[CompilerGeneratedAttribute] // RVA: 0x4E79F0 Offset: 0x4E79F0 VA: 0x4E79F0
	// RVA: 0x155A6B0 Offset: 0x155A6B0 VA: 0x155A6B0 Slot: 4
	public WebConnectionGroup get_Group() { }

	[CompilerGeneratedAttribute] // RVA: 0x4E7A00 Offset: 0x4E7A00 VA: 0x4E7A00
	// RVA: 0x155A6B8 Offset: 0x155A6B8 VA: 0x155A6B8
	private void set_Group(WebConnectionGroup value) { }

	// RVA: 0x155A6C0 Offset: 0x155A6C0 VA: 0x155A6C0 Slot: 7
	public ServicePoint get_ServicePoint() { }

	// RVA: 0x155A6E4 Offset: 0x155A6E4 VA: 0x155A6E4 Slot: 8
	public bool get_Busy() { }

	// RVA: 0x155A6EC Offset: 0x155A6EC VA: 0x155A6EC Slot: 9
	public DateTime get_IdleSince() { }

	// RVA: 0x155A6F8 Offset: 0x155A6F8 VA: 0x155A6F8 Slot: 5
	public bool TrySetBusy() { }

	// RVA: 0x155A914 Offset: 0x155A914 VA: 0x155A914 Slot: 6
	public void SetIdle() { }

	// RVA: 0x155AA50 Offset: 0x155AA50 VA: 0x155AA50
	public void .ctor(WebConnectionGroup group) { }
}
