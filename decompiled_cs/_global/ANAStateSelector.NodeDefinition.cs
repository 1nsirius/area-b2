// Namespace: 
[Serializable]
public class ANAStateSelector.NodeDefinition // TypeDefIndex: 9570
{
	// Fields
	public ANAStateSelector.NodeDefinition.NodeStates States; // 0x8
	public ChildANA NodeAsset; // 0xC
	public AnimNameWithHash WeightStateName; // 0x10
	public FloatValueOrParam DefaultTransitionDuration; // 0x18
	public bool CanReenter; // 0x28
	public bool AlwaysConnect; // 0x29
	public ANAStateSelector.TransitionDefinition[] CustomTransitionArray; // 0x2C
	public int PortIndex; // 0x30
	public Dictionary<int, ANAStateSelector.TransitionDefinition> Transitions; // 0x34

	// Methods

	// RVA: 0xECDF38 Offset: 0xECDF38 VA: 0xECDF38
	public void SetupTransitions(ANAStateSelector asset) { }

	// RVA: 0xECE334 Offset: 0xECE334 VA: 0xECE334
	public void Clear() { }

	// RVA: 0xECE3F8 Offset: 0xECE3F8 VA: 0xECE3F8
	public void .ctor() { }
}
