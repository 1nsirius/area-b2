// Namespace: 
public static class NativeGallery // TypeDefIndex: 5248
{
	// Fields
	private static AndroidJavaClass m_ajc; // 0x0
	private static AndroidJavaObject m_context; // 0x4
	private static string m_temporaryImagePath; // 0x8

	// Properties
	private static AndroidJavaClass AJC { get; }
	private static AndroidJavaObject Context { get; }
	private static string TemporaryImagePath { get; }

	// Methods

	// RVA: 0x2CDA644 Offset: 0x2CDA644 VA: 0x2CDA644
	private static AndroidJavaClass get_AJC() { }

	// RVA: 0x2CDA794 Offset: 0x2CDA794 VA: 0x2CDA794
	private static AndroidJavaObject get_Context() { }

	// RVA: 0x2CDAA00 Offset: 0x2CDAA00 VA: 0x2CDAA00
	private static string get_TemporaryImagePath() { }

	// RVA: 0x2CDAB84 Offset: 0x2CDAB84 VA: 0x2CDAB84
	public static NativeGallery.Permission CheckPermission(bool readPermissionOnly = False) { }

	// RVA: 0x2CDAD68 Offset: 0x2CDAD68 VA: 0x2CDAD68
	public static NativeGallery.Permission RequestPermission(bool readPermissionOnly = False) { }

	// RVA: 0x2CDB248 Offset: 0x2CDB248 VA: 0x2CDB248
	public static bool CanOpenSettings() { }

	// RVA: 0x2CDB250 Offset: 0x2CDB250 VA: 0x2CDB250
	public static void OpenSettings() { }

	// RVA: 0x2CDB380 Offset: 0x2CDB380 VA: 0x2CDB380
	public static NativeGallery.Permission SaveImageToGallery(byte[] mediaBytes, string album, string filenameFormatted, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDB650 Offset: 0x2CDB650 VA: 0x2CDB650
	public static NativeGallery.Permission SaveImageToGallery(string existingMediaPath, string album, string filenameFormatted, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDB94C Offset: 0x2CDB94C VA: 0x2CDB94C
	public static NativeGallery.Permission SaveImageToGallery(Texture2D image, string album, string filenameFormatted, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDBD3C Offset: 0x2CDBD3C VA: 0x2CDBD3C
	public static NativeGallery.Permission SaveVideoToGallery(byte[] mediaBytes, string album, string filenameFormatted, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDBDE0 Offset: 0x2CDBDE0 VA: 0x2CDBDE0
	public static NativeGallery.Permission SaveVideoToGallery(string existingMediaPath, string album, string filenameFormatted, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDBE84 Offset: 0x2CDBE84 VA: 0x2CDBE84
	public static bool CanSelectMultipleFilesFromGallery() { }

	// RVA: 0x2CDBF54 Offset: 0x2CDBF54 VA: 0x2CDBF54
	public static NativeGallery.Permission GetImageFromGallery(NativeGallery.MediaPickCallback callback, string title = "", string mime = "image/*", int maxSize = -1) { }

	// RVA: 0x2CDC3AC Offset: 0x2CDC3AC VA: 0x2CDC3AC
	public static NativeGallery.Permission GetVideoFromGallery(NativeGallery.MediaPickCallback callback, string title = "", string mime = "video/*") { }

	// RVA: 0x2CDC448 Offset: 0x2CDC448 VA: 0x2CDC448
	public static NativeGallery.Permission GetImagesFromGallery(NativeGallery.MediaPickMultipleCallback callback, string title = "", string mime = "image/*", int maxSize = -1) { }

	// RVA: 0x2CDC8EC Offset: 0x2CDC8EC VA: 0x2CDC8EC
	public static NativeGallery.Permission GetVideosFromGallery(NativeGallery.MediaPickMultipleCallback callback, string title = "", string mime = "video/*") { }

	// RVA: 0x2CDC988 Offset: 0x2CDC988 VA: 0x2CDC988
	public static bool IsMediaPickerBusy() { }

	// RVA: 0x2CDB424 Offset: 0x2CDB424 VA: 0x2CDB424
	private static NativeGallery.Permission SaveToGallery(byte[] mediaBytes, string album, string filenameFormatted, bool isImage, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDB6F4 Offset: 0x2CDB6F4 VA: 0x2CDB6F4
	private static NativeGallery.Permission SaveToGallery(string existingMediaPath, string album, string filenameFormatted, bool isImage, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDCBE0 Offset: 0x2CDCBE0 VA: 0x2CDCBE0
	private static void SaveToGalleryInternal(string path, string album, bool isImage, NativeGallery.MediaSaveCallback callback) { }

	// RVA: 0x2CDD5F8 Offset: 0x2CDD5F8 VA: 0x2CDD5F8
	public static string GetAvailableAlbum() { }

	// RVA: 0x2CDC990 Offset: 0x2CDC990 VA: 0x2CDC990
	private static string GetSavePath(string album, string filenameFormatted) { }

	// RVA: 0x2CDBFF0 Offset: 0x2CDBFF0 VA: 0x2CDBFF0
	private static NativeGallery.Permission GetMediaFromGallery(NativeGallery.MediaPickCallback callback, bool imageMode, string mime, string title, int maxSize) { }

	// RVA: 0x2CDC4E4 Offset: 0x2CDC4E4 VA: 0x2CDC4E4
	private static NativeGallery.Permission GetMultipleMediaFromGallery(NativeGallery.MediaPickMultipleCallback callback, bool imageMode, string mime, string title, int maxSize) { }

	// RVA: 0x2CDBBC8 Offset: 0x2CDBBC8 VA: 0x2CDBBC8
	private static byte[] GetTextureBytes(Texture2D texture, bool isJpeg) { }

	// RVA: 0x2CDE348 Offset: 0x2CDE348 VA: 0x2CDE348
	private static byte[] GetTextureBytesFromCopy(Texture2D texture, bool isJpeg) { }

	// RVA: 0x2CDE9A4 Offset: 0x2CDE9A4 VA: 0x2CDE9A4
	public static Texture2D LoadImageAtPath(string imagePath, int maxSize = -1, bool markTextureNonReadable = True, bool generateMipmaps = True, bool linearColorSpace = False) { }

	// RVA: 0x2CDF0CC Offset: 0x2CDF0CC VA: 0x2CDF0CC
	public static NativeGallery.ImageProperties GetImageProperties(string imagePath) { }

	// RVA: 0x2CDF658 Offset: 0x2CDF658 VA: 0x2CDF658
	public static NativeGallery.VideoProperties GetVideoProperties(string videoPath) { }

	// RVA: 0x2CDFAF4 Offset: 0x2CDFAF4 VA: 0x2CDFAF4
	private static void .cctor() { }
}
