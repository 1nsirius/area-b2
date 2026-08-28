// Namespace: 
private enum TSPacketLink.Core.InteriorState // TypeDefIndex: 8810
{
	// Fields
	public int value__; // 0x0
	public const TSPacketLink.Core.InteriorState ReceiveSecretFlag = 0;
	public const TSPacketLink.Core.InteriorState ReceivePublicKey = 1;
	public const TSPacketLink.Core.InteriorState CalSecretKeyAndSendPublicKey = 2;
	public const TSPacketLink.Core.InteriorState Running = 3;
	public const TSPacketLink.Core.InteriorState Disposed = 4;
}
