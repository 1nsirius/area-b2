// Namespace: 
private class CameraManager.DefaultProvider : CameraManager.IRenderBuffersProvider // TypeDefIndex: 5547
{
	// Fields
	private RenderTexture m_rt; // 0x8

	// Properties
	public RenderTexture color_texture { get; }
	public RenderBuffer depth_buffer { get; }

	// Methods

	// RVA: 0xD50C84 Offset: 0xD50C84 VA: 0xD50C84 Slot: 5
	public RenderTexture get_color_texture() { }

	// RVA: 0xD50C8C Offset: 0xD50C8C VA: 0xD50C8C Slot: 6
	public RenderBuffer get_depth_buffer() { }

	// RVA: 0xD50CC0 Offset: 0xD50CC0 VA: 0xD50CC0 Slot: 7
	public void release() { }

	// RVA: 0xD50CF8 Offset: 0xD50CF8 VA: 0xD50CF8 Slot: 4
	public void resize(Vector2Int size) { }

	// RVA: 0xD50E58 Offset: 0xD50E58 VA: 0xD50E58
	public void .ctor() { }
}
