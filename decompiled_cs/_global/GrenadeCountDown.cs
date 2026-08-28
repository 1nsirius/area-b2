// Namespace: 
public class GrenadeCountDown // TypeDefIndex: 5647
{
	// Fields
	private Transform mRoot; // 0x8
	private Image progress; // 0xC
	private Text leftTime; // 0x10
	private float m_leftTime; // 0x14
	private float m_cd; // 0x18
	private int m_lastTime; // 0x1C
	private bool visiable; // 0x20
	private ulong _token; // 0x28

	// Methods

	// RVA: 0x2CCD20C Offset: 0x2CCD20C VA: 0x2CCD20C
	public void Init(Transform root) { }

	// RVA: 0x2CCD31C Offset: 0x2CCD31C VA: 0x2CCD31C
	public void HandleOnBeginCountDown(float leftTime, ulong token) { }

	// RVA: 0x2CCD368 Offset: 0x2CCD368 VA: 0x2CCD368
	public void HandleOnStopCountDown(ulong token) { }

	// RVA: 0x2CCD3A8 Offset: 0x2CCD3A8 VA: 0x2CCD3A8
	public void OnTick() { }

	// RVA: 0x2CCD350 Offset: 0x2CCD350 VA: 0x2CCD350
	public void SetVisiable(bool visiable) { }

	// RVA: 0x2CCD2C4 Offset: 0x2CCD2C4 VA: 0x2CCD2C4
	private void _SetVisiableInner(bool visiable) { }

	// RVA: 0x2CCD544 Offset: 0x2CCD544 VA: 0x2CCD544
	public void .ctor() { }
}
