// Namespace: 
public interface GunBase.IView : Weapon.IView, ToolBase.IView // TypeDefIndex: 12825
{
	// Properties
	public abstract Matrix4x4 WorldToDefaultEyes { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void OnAttack(GunFireType gunFireType, bool isLocal);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract Transform GetGunFirePoint();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void OnBeLoadedChange(bool lastIfBeLoaded, bool curIfBeLoaded);

	// RVA: -1 Offset: -1 Slot: 3
	public abstract Matrix4x4 get_WorldToDefaultEyes();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void TryStopFire();
}
