namespace FGame
{

// Namespace: FGame
public class PostEffectElemPool : BaseSingleton<PostEffectElemPool> // TypeDefIndex: 9939
{
	// Fields
	private AssetPool mAssetPool; // 0x8
	private Dictionary<int, PostEffectElem> mElems; // 0xC

	// Methods

	// RVA: 0xB7726C Offset: 0xB7726C VA: 0xB7726C
	public void Create(int postEffId) { }

	// RVA: 0xB7746C Offset: 0xB7746C VA: 0xB7746C
	public PostEffectElem Get(int postEffId) { }

	// RVA: 0xB77520 Offset: 0xB77520 VA: 0xB77520
	public void Clear() { }

	// RVA: 0xB77300 Offset: 0xB77300 VA: 0xB77300
	private PostEffectElem AddElemInner(int postEffId) { }

	// RVA: 0xB775B8 Offset: 0xB775B8 VA: 0xB775B8
	public void .ctor() { }
}

} // namespace FGame
