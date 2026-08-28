namespace FGame
{

// Namespace: FGame
public class PostEffectManager : BaseSingleton<PostEffectManager> // TypeDefIndex: 9940
{
	// Fields
	private const int LayerMax = 16;
	private readonly int[] mBlendEffArrray; // 0x8
	private readonly int[] mRtEffArray; // 0xC
	private HashSet<int> mAllEffs; // 0x10

	// Methods

	// RVA: 0xB776A0 Offset: 0xB776A0 VA: 0xB776A0 Slot: 3
	public override string ToString() { }

	// RVA: 0xB779DC Offset: 0xB779DC VA: 0xB779DC
	public void GetBlendEffList(List<PostEffectElem> list) { }

	// RVA: 0xB77B74 Offset: 0xB77B74 VA: 0xB77B74
	public void GetRtEffList(List<PostEffectElem> list) { }

	// RVA: 0xB77BF8 Offset: 0xB77BF8 VA: 0xB77BF8
	public void Add(int id) { }

	// RVA: 0xB7831C Offset: 0xB7831C VA: 0xB7831C
	public void SetFloat(int id, int keyId, float value) { }

	// RVA: 0xB7840C Offset: 0xB7840C VA: 0xB7840C
	public void SetColor(int id, int keyId, in Color value) { }

	// RVA: 0xB7851C Offset: 0xB7851C VA: 0xB7851C
	public void Clear() { }

	// RVA: 0xB779E4 Offset: 0xB779E4 VA: 0xB779E4
	private void CopyToList(List<PostEffectElem> list, int[] array) { }

	// RVA: 0xB77FE8 Offset: 0xB77FE8 VA: 0xB77FE8
	private void AddEff(int[] effArray, int id, post_effect_table.Record record) { }

	// RVA: 0xB785E4 Offset: 0xB785E4 VA: 0xB785E4
	public void .ctor() { }
}

} // namespace FGame
