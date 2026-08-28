// Namespace: 
public class WwiseSwitchReference : WwiseGroupValueObjectReference // TypeDefIndex: 6033
{
	// Fields
	private static readonly WwiseObjectType MyWwiseObjectType; // 0x0
	private static readonly WwiseObjectType MyGroupWwiseObjectType; // 0x4
	[AkShowOnlyAttribute] // RVA: 0x55F9D0 Offset: 0x55F9D0 VA: 0x55F9D0
	[SerializeField] // RVA: 0x55F9D0 Offset: 0x55F9D0 VA: 0x55F9D0
	private WwiseSwitchGroupReference WwiseSwitchGroupReference; // 0x18

	// Properties
	public override WwiseObjectType WwiseObjectType { get; }
	public override WwiseObjectReference GroupObjectReference { get; set; }
	public override WwiseObjectType GroupWwiseObjectType { get; }

	// Methods

	// RVA: 0x1301CF4 Offset: 0x1301CF4 VA: 0x1301CF4 Slot: 5
	public override WwiseObjectType get_WwiseObjectType() { }

	// RVA: 0x1301D80 Offset: 0x1301D80 VA: 0x1301D80 Slot: 6
	public override WwiseObjectReference get_GroupObjectReference() { }

	// RVA: 0x1301D88 Offset: 0x1301D88 VA: 0x1301D88 Slot: 7
	public override void set_GroupObjectReference(WwiseObjectReference value) { }

	// RVA: 0x1301E24 Offset: 0x1301E24 VA: 0x1301E24 Slot: 8
	public override WwiseObjectType get_GroupWwiseObjectType() { }

	// RVA: 0x1301EB0 Offset: 0x1301EB0 VA: 0x1301EB0
	public void .ctor() { }

	// RVA: 0x1301EB4 Offset: 0x1301EB4 VA: 0x1301EB4
	private static void .cctor() { }
}
