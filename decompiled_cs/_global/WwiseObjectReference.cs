// Namespace: 
public abstract class WwiseObjectReference : ScriptableObject // TypeDefIndex: 6026
{
	// Fields
	[AkShowOnlyAttribute] // RVA: 0x55F910 Offset: 0x55F910 VA: 0x55F910
	[SerializeField] // RVA: 0x55F910 Offset: 0x55F910 VA: 0x55F910
	private string objectName; // 0xC
	[AkShowOnlyAttribute] // RVA: 0x55F940 Offset: 0x55F940 VA: 0x55F940
	[SerializeField] // RVA: 0x55F940 Offset: 0x55F940 VA: 0x55F940
	private uint id; // 0x10
	[AkShowOnlyAttribute] // RVA: 0x55F970 Offset: 0x55F970 VA: 0x55F970
	[SerializeField] // RVA: 0x55F970 Offset: 0x55F970 VA: 0x55F970
	private string guid; // 0x14

	// Properties
	public Guid Guid { get; }
	public string ObjectName { get; }
	public virtual string DisplayName { get; }
	public uint Id { get; }
	public abstract WwiseObjectType WwiseObjectType { get; }

	// Methods

	// RVA: 0x13016FC Offset: 0x13016FC VA: 0x13016FC
	public Guid get_Guid() { }

	// RVA: 0x13016F0 Offset: 0x13016F0 VA: 0x13016F0
	public string get_ObjectName() { }

	// RVA: 0x13017C4 Offset: 0x13017C4 VA: 0x13017C4 Slot: 4
	public virtual string get_DisplayName() { }

	// RVA: 0x13017CC Offset: 0x13017CC VA: 0x13017CC
	public uint get_Id() { }

	// RVA: -1 Offset: -1 Slot: 5
	public abstract WwiseObjectType get_WwiseObjectType();

	// RVA: 0x13010FC Offset: 0x13010FC VA: 0x13010FC
	protected void .ctor() { }
}
