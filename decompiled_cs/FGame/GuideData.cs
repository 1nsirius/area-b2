namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553E54 Offset: 0x553E54 VA: 0x553E54
public class GuideData : BaseSingleton<GuideData> // TypeDefIndex: 9901
{
	// Fields
	public long camp; // 0x8
	public long map_id; // 0x10
	public long mode_id; // 0x18
	public long round; // 0x20
	public long team; // 0x28
	public long wait_time; // 0x30

	// Methods

	// RVA: 0xF45F90 Offset: 0xF45F90 VA: 0xF45F90
	public void Reset(game.RspUserGuideRoundStart.request rsp) { }

	// RVA: 0xF46090 Offset: 0xF46090 VA: 0xF46090
	public void Clear() { }

	// RVA: 0xF460A8 Offset: 0xF460A8 VA: 0xF460A8
	public void .ctor() { }
}

} // namespace FGame
