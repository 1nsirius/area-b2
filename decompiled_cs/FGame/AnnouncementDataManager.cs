namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553DC8 Offset: 0x553DC8 VA: 0x553DC8
public sealed class AnnouncementDataManager : BaseSingleton<AnnouncementDataManager> // TypeDefIndex: 9877
{
	// Fields
	private bool mTimeSynced; // 0x8
	private int mTick; // 0xC
	public List<AnnouncementDataManager.AnnouncementInfo> AvaliableAnnouncementList; // 0x10
	private AnnouncementDataManager.AnnouncementSorter mSorter; // 0x14

	// Methods

	// RVA: 0xBE7A40 Offset: 0xBE7A40 VA: 0xBE7A40
	public void Initialize() { }

	// RVA: 0xBE7B3C Offset: 0xBE7B3C VA: 0xBE7B3C
	public void Shutdown() { }

	// RVA: 0xBE7B28 Offset: 0xBE7B28 VA: 0xBE7B28
	public void ResetTime() { }

	// RVA: 0xBE7C14 Offset: 0xBE7C14 VA: 0xBE7C14
	private void OnUpdateServerTick(SprotoTypeBase msg) { }

	// RVA: 0xBE7C44 Offset: 0xBE7C44 VA: 0xBE7C44
	public void CheckAvaliable() { }

	// RVA: 0xBE8018 Offset: 0xBE8018 VA: 0xBE8018
	public void .ctor() { }
}

} // namespace FGame
