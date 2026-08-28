// Namespace: 
public class MVPSceneManager : MonoBehaviourSingleton<MVPSceneManager> // TypeDefIndex: 5536
{
	// Fields
	public Transform PlayerPos1; // 0xC
	public Transform PlayerPos2; // 0x10
	public Transform PlayerPos3; // 0x14
	public Transform PlayerPos4; // 0x18
	public Transform PlayerPos5; // 0x1C
	public Transform CameraTrans; // 0x20
	public Transform MvpBgParent; // 0x24
	private game.RspBattleFinalResult.request mPkt; // 0x28
	private List<GameObject> _view_characters; // 0x2C
	public Camera mainCamera; // 0x30

	// Properties
	public List<GameObject> ViewCharacters { get; }
	public int WinnerIndex { get; }

	// Methods

	// RVA: 0x2CD6FD8 Offset: 0x2CD6FD8 VA: 0x2CD6FD8
	public List<GameObject> get_ViewCharacters() { }

	// RVA: 0x2CD6FE0 Offset: 0x2CD6FE0 VA: 0x2CD6FE0
	public int get_WinnerIndex() { }

	// RVA: 0x2CD6FE8 Offset: 0x2CD6FE8 VA: 0x2CD6FE8 Slot: 4
	protected override void onInit() { }

	// RVA: 0x2CD7248 Offset: 0x2CD7248 VA: 0x2CD7248 Slot: 5
	protected override void onFini() { }

	// RVA: 0x2CD6FEC Offset: 0x2CD6FEC VA: 0x2CD6FEC
	public void ShowSelf() { }

	// RVA: 0x2CD7334 Offset: 0x2CD7334 VA: 0x2CD7334
	private void LoadCharacterView(ref MVPCharacterData mvpCharacterData) { }

	// RVA: 0x2CD7DC4 Offset: 0x2CD7DC4 VA: 0x2CD7DC4
	private void LoadBg(MVPCharacterData firstPerson) { }

	// RVA: 0x2CD7ED0 Offset: 0x2CD7ED0 VA: 0x2CD7ED0
	public void .ctor() { }
}
