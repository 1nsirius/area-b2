// Namespace: 
public static class Character.SkillResolver // TypeDefIndex: 13251
{
	// Fields
	private static readonly Dictionary<byte, List<int>> mCharacterSkills; // 0x0

	// Methods

	// RVA: 0x96C2AC Offset: 0x96C2AC VA: 0x96C2AC
	private static void LoadAllRelatedSkillsOnce(RspRoomLoading pkt) { }

	// RVA: 0x96C9A4 Offset: 0x96C9A4 VA: 0x96C9A4
	public static void LoadAllRelatedSkills(RspRoomLoading pkt) { }

	// RVA: 0x96CD68 Offset: 0x96CD68 VA: 0x96CD68
	private static void LoadBattleModeAdditionalSkills(RspRoomLoading pkt) { }

	// RVA: 0x96CA74 Offset: 0x96CA74 VA: 0x96CA74
	private static void LoadInitSkills(RspRoomLoading pkt) { }

	// RVA: 0x96D588 Offset: 0x96D588 VA: 0x96D588
	public static List<int> GetInitSkills(CharacterInfo characterInfo) { }

	// RVA: 0x96D894 Offset: 0x96D894 VA: 0x96D894
	public static List<int> GetSkills(byte bid) { }

	// RVA: 0x96D4D4 Offset: 0x96D4D4 VA: 0x96D4D4
	public static void Clear() { }

	// RVA: 0x96D1C0 Offset: 0x96D1C0 VA: 0x96D1C0
	private static int GetSkillsCount() { }

	// RVA: 0x96C85C Offset: 0x96C85C VA: 0x96C85C
	private static void LoadAllRelatedSkillsFromAtoB(byte aBID, BattleCamp aCamp, byte bBID, BattleCamp bCamp) { }

	// RVA: 0x96DA40 Offset: 0x96DA40 VA: 0x96DA40
	private static void LoadRelatedSkillsOfCertainSkillFor(int aSkillId, byte aBID, BattleCamp aCamp, byte bBID, BattleCamp bCamp) { }

	// RVA: 0x96D39C Offset: 0x96D39C VA: 0x96D39C
	private static void AddSkills(byte bid, int[] addList) { }

	// RVA: 0x96DBEC Offset: 0x96DBEC VA: 0x96DBEC
	private static void .cctor() { }
}
