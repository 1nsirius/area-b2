// Namespace: 
public class WwiseStateReference : WwiseGroupValueObjectReference // TypeDefIndex: 6031
{
	// Fields
	private static readonly WwiseObjectType MyWwiseObjectType; // 0x0
	private static readonly WwiseObjectType MyGroupWwiseObjectType; // 0x4
	[AkShowOnlyAttribute] // RVA: 0x55F9A0 Offset: 0x55F9A0 VA: 0x55F9A0
	[SerializeField] // RVA: 0x55F9A0 Offset: 0x55F9A0 VA: 0x55F9A0
	private WwiseStateGroupReference WwiseStateGroupReference; // 0x18

	// Properties
	public override WwiseObjectType WwiseObjectType { get; }
	public override WwiseObjectReference GroupObjectReference { get; set; }
	public override WwiseObjectType GroupWwiseObjectType { get; }

	// Methods

	// RVA: 0x13019C4 Offset: 0x13019C4 VA: 0x13019C4 Slot: 5
	public override WwiseObjectType get_WwiseObjectType() { }

	// RVA: 0x1301A50 Offset: 0x1301A50 VA: 0x1301A50 Slot: 6
	public override WwiseObjectReference get_GroupObjectReference() { }

	// RVA: 0x1301A58 Offset: 0x1301A58 VA: 0x1301A58 Slot: 7
	public override void set_GroupObjectReference(WwiseObjectReference value) { }

	// RVA: 0x1301AF4 Offset: 0x1301AF4 VA: 0x1301AF4 Slot: 8
	public override WwiseObjectType get_GroupWwiseObjectType() { }

	// RVA: 0x1301B80 Offset: 0x1301B80 VA: 0x1301B80
	public void .ctor() { }

	// RVA: 0x1301B84 Offset: 0x1301B84 VA: 0x1301B84
	private static void .cctor() { }
}
