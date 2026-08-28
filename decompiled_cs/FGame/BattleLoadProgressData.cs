namespace FGame
{

// Namespace: FGame
public class BattleLoadProgressData : BaseSingleton<BattleLoadProgressData> // TypeDefIndex: 9881
{
	// Fields
	private readonly Dictionary<byte, float> mProgress; // 0x8

	// Methods

	// RVA: 0xBE82FC Offset: 0xBE82FC VA: 0xBE82FC
	public void SetProgress(byte bid, float progress) { }

	// RVA: 0xBE8384 Offset: 0xBE8384 VA: 0xBE8384
	public float GetProgress(byte bid) { }

	// RVA: 0xBE8430 Offset: 0xBE8430 VA: 0xBE8430
	public void Clear() { }

	// RVA: 0xBE84A8 Offset: 0xBE84A8 VA: 0xBE84A8
	public void .ctor() { }
}

} // namespace FGame
