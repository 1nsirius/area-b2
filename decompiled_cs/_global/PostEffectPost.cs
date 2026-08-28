// Namespace: 
[RequireComponent] // RVA: 0x550904 Offset: 0x550904 VA: 0x550904
public class PostEffectPost : MonoBehaviour // TypeDefIndex: 5557
{
	// Fields
	private static readonly int mShaderPropertyId_MainTex; // 0x0
	private readonly List<PostEffectElem> mPostEffectRtBuffer; // 0xC
	private readonly List<PostEffectElem> mPostEffectNoRtBuffer; // 0x10
	private PostEffectTarget mPostEffectTarget; // 0x14

	// Methods

	// RVA: 0x2CE6354 Offset: 0x2CE6354 VA: 0x2CE6354
	private void Start() { }

	// RVA: 0x2CE63BC Offset: 0x2CE63BC VA: 0x2CE63BC
	public void PreparePostEffects(out bool isNeedRt, out bool isNeedEffect, out float minScreenRatio) { }

	// RVA: 0x2CE66B0 Offset: 0x2CE66B0 VA: 0x2CE66B0
	private void OnPreRender() { }

	// RVA: 0x2CE6850 Offset: 0x2CE6850 VA: 0x2CE6850
	private void OnPostRender() { }

	// RVA: 0x2CE71DC Offset: 0x2CE71DC VA: 0x2CE71DC
	public void .ctor() { }

	// RVA: 0x2CE7288 Offset: 0x2CE7288 VA: 0x2CE7288
	private static void .cctor() { }
}
