// Namespace: 
public class TransformGrandChildrenChangeTrigger : MonoBehaviour // TypeDefIndex: 5495
{
	// Fields
	[SerializeField] // RVA: 0x55DD90 Offset: 0x55DD90 VA: 0x55DD90
	private Transform mTarget; // 0xC
	private IOnTransformGrandChildrenChanged mReceiver; // 0x10

	// Properties
	public IOnTransformGrandChildrenChanged Receiver { get; }

	// Methods

	// RVA: 0xD85C60 Offset: 0xD85C60 VA: 0xD85C60
	public IOnTransformGrandChildrenChanged get_Receiver() { }

	// RVA: 0xD85D3C Offset: 0xD85D3C VA: 0xD85D3C
	private void OnTransformChildrenChanged() { }

	// RVA: 0xD85E60 Offset: 0xD85E60 VA: 0xD85E60
	public void .ctor() { }
}
