// Namespace: 
public abstract class WwiseGroupValueObjectReference : WwiseObjectReference // TypeDefIndex: 6027
{
	// Properties
	public abstract WwiseObjectReference GroupObjectReference { get; set; }
	public abstract WwiseObjectType GroupWwiseObjectType { get; }
	public override string DisplayName { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 6
	public abstract WwiseObjectReference get_GroupObjectReference();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract void set_GroupObjectReference(WwiseObjectReference value);

	// RVA: -1 Offset: -1 Slot: 8
	public abstract WwiseObjectType get_GroupWwiseObjectType();

	// RVA: 0x1301618 Offset: 0x1301618 VA: 0x1301618 Slot: 4
	public override string get_DisplayName() { }

	// RVA: 0x13016F8 Offset: 0x13016F8 VA: 0x13016F8
	protected void .ctor() { }
}
