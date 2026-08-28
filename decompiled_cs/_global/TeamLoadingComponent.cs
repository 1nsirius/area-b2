// Namespace: 
public class TeamLoadingComponent : MonoBehaviour // TypeDefIndex: 5605
{
	// Fields
	[SerializeField] // RVA: 0x55DF20 Offset: 0x55DF20 VA: 0x55DF20
	private Image mImgTeamColor; // 0xC
	private readonly ITeamMemberLoadingIconInfo[] mMembers; // 0x10
	[SerializeField] // RVA: 0x55DF30 Offset: 0x55DF30 VA: 0x55DF30
	private bool mSelfTeam; // 0x14
	private BattleTeam mTeam; // 0x18
	private BattleLoadData.TeamData mTeamData; // 0x1C
	[SerializeField] // RVA: 0x55DF40 Offset: 0x55DF40 VA: 0x55DF40
	private RectTransform mTransAttackerFlag; // 0x20
	[SerializeField] // RVA: 0x55DF50 Offset: 0x55DF50 VA: 0x55DF50
	private RectTransform mTransDefenerFlag; // 0x24
	[SerializeField] // RVA: 0x55DF60 Offset: 0x55DF60 VA: 0x55DF60
	private Text mTxtScore; // 0x28

	// Methods

	// RVA: 0xD81404 Offset: 0xD81404 VA: 0xD81404
	private void Awake() { }

	// RVA: 0xD81608 Offset: 0xD81608 VA: 0xD81608
	private Func<RectTransform, ITeamMemberLoadingIconInfo> GetFactory() { }

	// RVA: 0xD81810 Offset: 0xD81810 VA: 0xD81810
	private void Start() { }

	// RVA: 0xD81CB0 Offset: 0xD81CB0 VA: 0xD81CB0
	private void RefreshMembers(BattleLoadData.TeamData teamData) { }

	// RVA: 0xD81B60 Offset: 0xD81B60 VA: 0xD81B60
	private void RefreshTeamColor(BattleLoadData.TeamData teamData) { }

	// RVA: 0xD81AEC Offset: 0xD81AEC VA: 0xD81AEC
	private void RefreshCamp(BattleLoadData.TeamData teamData) { }

	// RVA: 0xD818C0 Offset: 0xD818C0 VA: 0xD818C0
	private BattleLoadData.TeamData GetTeamData(bool isSelfTeam) { }

	// RVA: 0xD81EAC Offset: 0xD81EAC VA: 0xD81EAC
	private void Update() { }

	// RVA: 0xD81EB4 Offset: 0xD81EB4 VA: 0xD81EB4
	public void .ctor() { }
}
