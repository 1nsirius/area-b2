// Namespace: 
public class ToolBase.ActionSoundCfg // TypeDefIndex: 12807
{
	// Fields
	private readonly hand_props_actionsound_table.Record mActionSoundTable; // 0x8
	private sounds_table.Record[] mStopActionEventCacheP1; // 0xC
	private sounds_table.Record[] mStopActionEventCacheP3; // 0x10
	private sounds_table.Record[] mDryFireActionEventCacheP1; // 0x14
	private Dictionary<int, sounds_table.Record[]> mActionSoundsCacheP1; // 0x18
	private Dictionary<int, sounds_table.Record[]> mActionSoundsCacheP3; // 0x1C
	private Dictionary<int, int[]> _soundsP1; // 0x20
	private Dictionary<int, int[]> _soundsP3; // 0x24

	// Methods

	// RVA: 0xB03D98 Offset: 0xB03D98 VA: 0xB03D98
	public void .ctor(int action_sound_id) { }

	// RVA: 0xB05A60 Offset: 0xB05A60 VA: 0xB05A60
	public sounds_table.Record[] GetStopSounds(ViewType viewType) { }

	// RVA: 0xB05D70 Offset: 0xB05D70 VA: 0xB05D70
	public sounds_table.Record[] GetDryFireSounds() { }

	// RVA: 0xB05F20 Offset: 0xB05F20 VA: 0xB05F20
	public sounds_table.Record[] GetSounds(ViewType viewtype, int action) { }

	// RVA: 0xB05F24 Offset: 0xB05F24 VA: 0xB05F24
	private sounds_table.Record[] GetSoundsInner(ViewType viewtype, int action) { }

	// RVA: 0xB058A4 Offset: 0xB058A4 VA: 0xB058A4
	private void BuildSoundCache() { }

	// RVA: 0xB03F0C Offset: 0xB03F0C VA: 0xB03F0C
	private static Dictionary<int, int[]> CreateCfg_P1(hand_props_actionsound_table.Record action_sound_tb) { }

	// RVA: 0xB04BD8 Offset: 0xB04BD8 VA: 0xB04BD8
	private static Dictionary<int, int[]> CreateCfg_P3(hand_props_actionsound_table.Record action_sound_tb) { }
}
