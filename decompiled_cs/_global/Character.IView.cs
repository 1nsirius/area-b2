// Namespace: 
public interface Character.IView // TypeDefIndex: 13249
{
	// Properties
	public abstract Transform WeaponTransform { get; }
	public abstract Transform ShieldParent { get; }
	public abstract Vector3 HeadPosition { get; }
	public abstract Vector3 CameraPosition { get; }
	public abstract Quaternion CameraRotation { get; }
	public abstract GameObject Knife { get; set; }
	public abstract Transform RightHand { get; }
	public abstract ViewType ViewType { get; }
	public abstract Transform HeadBoneTransform { get; }
	public abstract Character Character { get; }
	public abstract Transform[] Bones { get; }
	public abstract Renderer[] RendererList { get; }
	public abstract bool IsOccluded { get; }
	public abstract Quaternion CentroidRot { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract Transform get_WeaponTransform();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract Transform get_ShieldParent();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract Vector3 get_HeadPosition();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract Vector3 get_CameraPosition();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Quaternion get_CameraRotation();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract GameObject get_Knife();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract void set_Knife(GameObject value);

	// RVA: -1 Offset: -1 Slot: 7
	public abstract Transform get_RightHand();

	// RVA: -1 Offset: -1 Slot: 8
	public abstract ViewType get_ViewType();

	// RVA: -1 Offset: -1 Slot: 9
	public abstract Transform get_HeadBoneTransform();

	// RVA: -1 Offset: -1 Slot: 10
	public abstract Character get_Character();

	// RVA: -1 Offset: -1 Slot: 11
	public abstract Transform[] get_Bones();

	// RVA: -1 Offset: -1 Slot: 12
	public abstract Renderer[] get_RendererList();

	// RVA: -1 Offset: -1 Slot: 13
	public abstract bool get_IsOccluded();

	// RVA: -1 Offset: -1 Slot: 14
	public abstract Quaternion get_CentroidRot();

	// RVA: -1 Offset: -1 Slot: 15
	public abstract void Attach(Character c);

	// RVA: -1 Offset: -1 Slot: 16
	public abstract void Detach();

	// RVA: -1 Offset: -1 Slot: 17
	public abstract void OnCharacterUpdate();

	// RVA: -1 Offset: -1 Slot: 18
	public abstract void OnCharacterLateUpdate();

	// RVA: -1 Offset: -1 Slot: 19
	public abstract void OnBodyStateChanged(EBodyState last);

	// RVA: -1 Offset: -1 Slot: 20
	public abstract void OnAction();

	// RVA: -1 Offset: -1 Slot: 21
	public abstract void OnPositionChanged();

	// RVA: -1 Offset: -1 Slot: 22
	public abstract void OnRotationChanged();

	// RVA: -1 Offset: -1 Slot: 23
	public abstract void OnEyesPositionChanged();

	// RVA: -1 Offset: -1 Slot: 24
	public abstract void OnEyesRotationChanged();

	// RVA: -1 Offset: -1 Slot: 25
	public abstract void OnSilenceChanged();

	// RVA: -1 Offset: -1 Slot: 26
	public abstract void OnStrafeForwardChanged();

	// RVA: -1 Offset: -1 Slot: 27
	public abstract Vector3 GetRopePosBody();

	// RVA: -1 Offset: -1 Slot: 28
	public abstract void OnHitByGun(byte partIndex, in Nullable<ValueTuple<Vector3, Vector3>> hitPointInCollider, in Vector3 sourcePos, in Vector3 sourceDir);

	// RVA: -1 Offset: -1 Slot: 29
	public abstract void OnDead();

	// RVA: -1 Offset: -1 Slot: 30
	public abstract void OnDeadEvent();

	// RVA: -1 Offset: -1 Slot: 31
	public abstract void OnDeadUndo();

	// RVA: -1 Offset: -1 Slot: 32
	public abstract void OnToolChange();

	// RVA: -1 Offset: -1 Slot: 33
	public abstract Transform GetPointOfName(string pointName);

	// RVA: -1 Offset: -1 Slot: 34
	public abstract void OnCanCollideChange();

	// RVA: -1 Offset: -1 Slot: 35
	public abstract void OnVisibleChange();

	// RVA: -1 Offset: -1 Slot: 36
	public abstract byte GetColliderIndex(Collider c);

	// RVA: -1 Offset: -1 Slot: 37
	public abstract void OnEnablePlaceFactorChange();

	// RVA: -1 Offset: -1 Slot: 38
	public abstract void OnHitByTracker(ref Vector3 start, ref Vector3 end);

	// RVA: -1 Offset: -1 Slot: 39
	public abstract void OnHpChange(Character.HealthPoint last, Nullable<EffectType> damageType, in Nullable<Vector3> damageSource);

	// RVA: -1 Offset: -1 Slot: 40
	public abstract bool PointCanBeHit(Vector3 point);

	// RVA: -1 Offset: -1 Slot: 41
	public abstract void OnAssistantToolChange();

	// RVA: -1 Offset: -1 Slot: 42
	public abstract void RefreshAnimatorController();

	// RVA: -1 Offset: -1 Slot: 43
	public abstract void OnToolViewInit(ToolBase tool);

	// RVA: -1 Offset: -1 Slot: 44
	public abstract void OnHitEnemy();

	[CompilerGeneratedAttribute] // RVA: 0x668600 Offset: 0x668600 VA: 0x668600
	// RVA: -1 Offset: -1 Slot: 45
	public abstract void add_OnIsOccludedChange(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x668610 Offset: 0x668610 VA: 0x668610
	// RVA: -1 Offset: -1 Slot: 46
	public abstract void remove_OnIsOccludedChange(Action value);

	// RVA: -1 Offset: -1 Slot: 47
	public abstract void StartBuffLoopSound(string eventName);

	// RVA: -1 Offset: -1 Slot: 48
	public abstract void StopBuffLoopSound(string eventName);

	// RVA: -1 Offset: -1 Slot: 49
	public abstract void OnPlayerShoot(RspEventCharacterGunFire obj, Vector3[] targets);

	// RVA: -1 Offset: -1 Slot: 50
	public abstract void OnKillCharacter();

	// RVA: -1 Offset: -1 Slot: 51
	public abstract void DestroyView();

	// RVA: -1 Offset: -1 Slot: 52
	public abstract void RefreshAimingOffset();

	// RVA: -1 Offset: -1 Slot: 53
	public abstract void OnAttack(GunFireType gunFireType, bool isLocal);

	// RVA: -1 Offset: -1 Slot: 54
	public abstract void OnTiltValueChange();

	// RVA: -1 Offset: -1 Slot: 55
	public abstract Vector3 GetViewPos();
}
