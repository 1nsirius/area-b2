// Namespace: 
public class Collision.EPCollider // TypeDefIndex: 11284
{
	// Fields
	private TempPolygon _polygonB; // 0x8
	private Transform _xf; // 0xC
	private FVector2 _centroidB; // 0x1C
	private FVector2 _v0; // 0x24
	private FVector2 _v1; // 0x2C
	private FVector2 _v2; // 0x34
	private FVector2 _v3; // 0x3C
	private FVector2 _normal0; // 0x44
	private FVector2 _normal1; // 0x4C
	private FVector2 _normal2; // 0x54
	private FVector2 _normal; // 0x5C
	private Collision.EPCollider.VertexType _type1; // 0x64
	private Collision.EPCollider.VertexType _type2; // 0x68
	private FVector2 _lowerLimit; // 0x6C
	private FVector2 _upperLimit; // 0x74
	private float _radius; // 0x7C
	private bool _front; // 0x80

	// Methods

	// RVA: 0x20C64DC Offset: 0x20C64DC VA: 0x20C64DC
	public void Collide(ref Manifold manifold, EdgeShape edgeA, ref Transform xfA, PolygonShape polygonB, ref Transform xfB) { }

	// RVA: 0x20C83C0 Offset: 0x20C83C0 VA: 0x20C83C0
	private EPAxis ComputeEdgeSeparation() { }

	// RVA: 0x20C858C Offset: 0x20C858C VA: 0x20C858C
	private EPAxis ComputePolygonSeparation() { }

	// RVA: 0x20C6464 Offset: 0x20C6464 VA: 0x20C6464
	public void .ctor() { }
}
