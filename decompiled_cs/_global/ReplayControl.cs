// Namespace: 
public class ReplayControl // TypeDefIndex: 5707
{
	// Fields
	private Text m_name; // 0x8
	private Text m_leftTime; // 0xC
	private TimeCd endTime; // 0x10
	private Transform m_root; // 0x14

	// Methods

	// RVA: 0x2CF11B4 Offset: 0x2CF11B4 VA: 0x2CF11B4
	public void InitViews(Transform _tran) { }

	// RVA: 0x2CF13F4 Offset: 0x2CF13F4 VA: 0x2CF13F4
	public void Refresh(DateTime now, TimeSpan leftTime, string playerName, ReplayMode mode) { }

	// RVA: 0x2CF170C Offset: 0x2CF170C VA: 0x2CF170C
	public void OnTick(DateTime now) { }

	// RVA: 0x2CF17CC Offset: 0x2CF17CC VA: 0x2CF17CC
	public void Hide() { }

	// RVA: 0x2CF1640 Offset: 0x2CF1640 VA: 0x2CF1640
	private static string GetTimeStr(TimeSpan span) { }

	// RVA: 0x2CF181C Offset: 0x2CF181C VA: 0x2CF181C
	public void .ctor() { }
}
