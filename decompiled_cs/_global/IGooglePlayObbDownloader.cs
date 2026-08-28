// Namespace: 
public interface IGooglePlayObbDownloader // TypeDefIndex: 5830
{
	// Properties
	public abstract string PublicKey { get; set; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract string get_PublicKey();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void set_PublicKey(string value);

	// RVA: -1 Offset: -1 Slot: 2
	public abstract string GetExpansionFilePath();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract string GetMainOBBPath();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract string GetPatchOBBPath();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void FetchOBB();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract void RestartActivity();
}
