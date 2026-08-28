// Namespace: 
public interface SceneStopablePropCtrlr.INetSender // TypeDefIndex: 12131
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void ReqExplosive(ulong u64, int toolIndex, Vector3 pos, Vector3 euler);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void ReqReportTransform(U64Id u64, in Vector3 pos, in Vector3 euler, in Vector3 velocity);

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void ReqReportFinalTransform(ulong u64, Vector3 pos, Vector3 euler, List<U64Id> blocks);
}
