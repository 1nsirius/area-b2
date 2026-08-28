// Namespace: 
public interface CameraManager.IRenderBuffersProvider // TypeDefIndex: 5546
{
	// Properties
	public abstract RenderTexture color_texture { get; }
	public abstract RenderBuffer depth_buffer { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void resize(Vector2Int size);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract RenderTexture get_color_texture();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract RenderBuffer get_depth_buffer();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void release();
}
