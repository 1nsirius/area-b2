namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553FDC Offset: 0x553FDC VA: 0x553FDC
public class PlayerMessenger // TypeDefIndex: 9935
{
	// Fields
	private static PlayerMessenger Instance; // 0x0
	private Dictionary<int, PlayerMessenger.PlayerActions> mEvents; // 0x8

	// Methods

	// RVA: 0xB768B8 Offset: 0xB768B8 VA: 0xB768B8
	public static void AddListener(uint uid, int localMsgId, Action<uint> action) { }

	// RVA: 0xB76DB8 Offset: 0xB76DB8 VA: 0xB76DB8
	public static void RemoveListener(uint uid, int localMsgId, Action<uint> action) { }

	// RVA: 0xB71B58 Offset: 0xB71B58 VA: 0xB71B58
	public static void Dispatch(uint uid, int localMsgId) { }

	// RVA: 0xB77160 Offset: 0xB77160 VA: 0xB77160
	public void .ctor() { }

	// RVA: 0xB771EC Offset: 0xB771EC VA: 0xB771EC
	private static void .cctor() { }
}

} // namespace FGame
