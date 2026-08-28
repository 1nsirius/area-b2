// Namespace: 
public class SprotoRpc.RpcRequest // TypeDefIndex: 8834
{
	// Fields
	private Package package; // 0x8
	private SprotoStream stream; // 0xC
	private SprotoPack spack; // 0x10
	private ProtocolFunctionDictionary protocol; // 0x14
	private SprotoRpc rpc; // 0x18

	// Methods

	// RVA: 0x12AB650 Offset: 0x12AB650 VA: 0x12AB650
	public void .ctor(ProtocolFunctionDictionary protocol, SprotoRpc rpc) { }

	// RVA: -1 Offset: -1
	public byte[] Invoke<T>(SprotoTypeBase request, Nullable<long> session) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xD48F54 Offset: 0xD48F54 VA: 0xD48F54
	|-SprotoRpc.RpcRequest.Invoke<object>
	*/
}
