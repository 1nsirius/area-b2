// Namespace: 
public class TerrainUtility.TerrainMap // TypeDefIndex: 3859
{
	// Fields
	private Vector3 m_patchSize; // 0x8
	public TerrainUtility.TerrainMap.ErrorCode m_errorCode; // 0x14
	public Dictionary<TerrainUtility.TerrainMap.TileCoord, Terrain> m_terrainTiles; // 0x18

	// Methods

	// RVA: 0x2C9F6B8 Offset: 0x2C9F6B8 VA: 0x2C9F6B8
	public void .ctor() { }

	// RVA: 0x2C9F578 Offset: 0x2C9F578 VA: 0x2C9F578
	public Terrain GetTerrain(int tileX, int tileZ) { }

	// RVA: 0x2C9ED34 Offset: 0x2C9ED34 VA: 0x2C9ED34
	public static TerrainUtility.TerrainMap CreateFromPlacement(Terrain originTerrain, TerrainUtility.TerrainMap.TerrainFilter filter, bool fullValidation = True) { }

	// RVA: 0x2C9F834 Offset: 0x2C9F834 VA: 0x2C9F834
	public static TerrainUtility.TerrainMap CreateFromPlacement(Vector2 gridOrigin, Vector2 gridSize, TerrainUtility.TerrainMap.TerrainFilter filter, bool fullValidation = True) { }

	// RVA: 0x2CA0688 Offset: 0x2CA0688 VA: 0x2CA0688
	private void AddTerrainInternal(int x, int z, Terrain terrain) { }

	// RVA: 0x2CA0390 Offset: 0x2CA0390 VA: 0x2CA0390
	private bool TryToAddTerrain(int tileX, int tileZ, Terrain terrain) { }

	// RVA: 0x2CA0860 Offset: 0x2CA0860 VA: 0x2CA0860
	private void ValidateTerrain(int tileX, int tileZ) { }

	// RVA: 0x2CA0500 Offset: 0x2CA0500 VA: 0x2CA0500
	private TerrainUtility.TerrainMap.ErrorCode Validate() { }
}
