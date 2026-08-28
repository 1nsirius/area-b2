// Namespace: 
public interface LocalThrowoutTriggerableCtrlr.INetSender // TypeDefIndex: 13059
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void ReqGetBackPlaceSceneTool(U64Id uid);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void NotifyReqSyncCharacterAction(EAction action, float animDuration, float durationCoefficient);

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void NotifyCharacterActionExplodeExplosive(uint handItemId);

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void ReqItemThrow(U64Id u64, Vector3 pos, Vector3 euler, Vector3 velocityDir);
}
