// Namespace: 
public class TeamInfoControl<T> // TypeDefIndex: 5666
{
	// Fields
	private T[] clients; // 0x0
	private GameObject rootGo; // 0x0
	private RectTransform rootTran; // 0x0
	private Image attacker; // 0x0
	private Image defener; // 0x0
	private Image backImage; // 0x0
	private Transform iconRoot; // 0x0
	private Text score; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void InitView(GameObject _root, GameObject iconPrefab, Func<GameObject, T> creater, int len) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13464 Offset: 0x1B13464 VA: 0x1B13464
	|-TeamInfoControl<object>.InitView
	*/

	// RVA: -1 Offset: -1
	private void InitIcons(GameObject subPrefab, Func<GameObject, T> creater, int len) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B1372C Offset: 0x1B1372C VA: 0x1B1372C
	|-TeamInfoControl<object>.InitIcons
	*/

	// RVA: -1 Offset: -1
	public void RefreshTeamInfo(int camp, int team, int score) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B139A8 Offset: 0x1B139A8 VA: 0x1B139A8
	|-TeamInfoControl<object>.RefreshTeamInfo
	*/

	// RVA: -1 Offset: -1
	public void SetCamp(int camp) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13A64 Offset: 0x1B13A64 VA: 0x1B13A64
	|-TeamInfoControl<object>.SetCamp
	*/

	// RVA: -1 Offset: -1
	public void SetTeam(int team) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13AD0 Offset: 0x1B13AD0 VA: 0x1B13AD0
	|-TeamInfoControl<object>.SetTeam
	*/

	// RVA: -1 Offset: -1
	public void SetScore(int score) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13C0C Offset: 0x1B13C0C VA: 0x1B13C0C
	|-TeamInfoControl<object>.SetScore
	*/

	// RVA: -1 Offset: -1
	public T GetBattlePlayerIcon(int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13C60 Offset: 0x1B13C60 VA: 0x1B13C60
	|-TeamInfoControl<object>.GetBattlePlayerIcon
	*/

	// RVA: -1 Offset: -1
	public T[] GetBattlePlayerIcons() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13CA8 Offset: 0x1B13CA8 VA: 0x1B13CA8
	|-TeamInfoControl<BattlePlayerIcon>.GetBattlePlayerIcons
	|-TeamInfoControl<object>.GetBattlePlayerIcons
	*/

	// RVA: -1 Offset: -1
	public void Hide() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13CB0 Offset: 0x1B13CB0 VA: 0x1B13CB0
	|-TeamInfoControl<object>.Hide
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1B13D3C Offset: 0x1B13D3C VA: 0x1B13D3C
	|-TeamInfoControl<object>..ctor
	*/
}
