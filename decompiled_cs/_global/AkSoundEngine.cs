// Namespace: 
public class AkSoundEngine // TypeDefIndex: 5863
{
	// Fields
	public const int AK_SIMD_ALIGNMENT = 16;
	public const int AK_BUFFER_ALIGNMENT = 16;
	public const int AK_MAX_PATH = 260;
	public const int AK_BANK_PLATFORM_DATA_ALIGNMENT = 16;
	public const uint AK_INVALID_PLUGINID = 4294967295;
	public const ulong AK_INVALID_GAME_OBJECT = 18446744073709551615;
	public const uint AK_INVALID_UNIQUE_ID = 0;
	public const uint AK_INVALID_RTPC_ID = 0;
	public const uint AK_INVALID_LISTENER_INDEX = 4294967295;
	public const uint AK_INVALID_PLAYING_ID = 0;
	public const uint AK_DEFAULT_SWITCH_STATE = 0;
	public const int AK_INVALID_POOL_ID = -1;
	public const int AK_DEFAULT_POOL_ID = -1;
	public const uint AK_INVALID_AUX_ID = 0;
	public const uint AK_INVALID_FILE_ID = 4294967295;
	public const uint AK_INVALID_DEVICE_ID = 4294967295;
	public const uint AK_INVALID_BANK_ID = 0;
	public const uint AK_FALLBACK_ARGUMENTVALUE_ID = 0;
	public const uint AK_INVALID_CHANNELMASK = 0;
	public const uint AK_INVALID_OUTPUT_DEVICE_ID = 0;
	public const uint AK_MIXER_FX_SLOT = 4294967295;
	public const ulong AK_DEFAULT_LISTENER_OBJ = 0;
	public const uint AK_DEFAULT_PRIORITY = 50;
	public const uint AK_MIN_PRIORITY = 0;
	public const uint AK_MAX_PRIORITY = 100;
	public const uint AK_DEFAULT_BANK_IO_PRIORITY = 50;
	public const double AK_DEFAULT_BANK_THROUGHPUT = 1048,576;
	public const uint AKCOMPANYID_AUDIOKINETIC = 0;
	public const uint AK_LISTENERS_MASK_ALL = 4294967295;
	public const int NULL = 0;
	public const int AKCURVEINTERPOLATION_NUM_STORAGE_BIT = 5;
	public const int AK_MAX_LANGUAGE_NAME_SIZE = 32;
	public const int AKCOMPANYID_AUDIOKINETIC_EXTERNAL = 1;
	public const int AKCOMPANYID_MCDSP = 256;
	public const int AKCOMPANYID_WAVEARTS = 257;
	public const int AKCOMPANYID_PHONETICARTS = 258;
	public const int AKCOMPANYID_IZOTOPE = 259;
	public const int AKCOMPANYID_CRANKCASEAUDIO = 261;
	public const int AKCOMPANYID_IOSONO = 262;
	public const int AKCOMPANYID_AUROTECHNOLOGIES = 263;
	public const int AKCOMPANYID_DOLBY = 264;
	public const int AKCOMPANYID_TWOBIGEARS = 265;
	public const int AKCOMPANYID_OCULUS = 266;
	public const int AKCOMPANYID_BLUERIPPLESOUND = 267;
	public const int AKCOMPANYID_ENZIEN = 268;
	public const int AKCOMPANYID_KROTOS = 269;
	public const int AKCOMPANYID_NURULIZE = 270;
	public const int AKCOMPANYID_SUPERPOWERED = 271;
	public const int AKCOMPANYID_GOOGLE = 272;
	public const int AKCOMPANYID_VISISONICS = 277;
	public const int AKCODECID_BANK = 0;
	public const int AKCODECID_PCM = 1;
	public const int AKCODECID_ADPCM = 2;
	public const int AKCODECID_XMA = 3;
	public const int AKCODECID_VORBIS = 4;
	public const int AKCODECID_WIIADPCM = 5;
	public const int AKCODECID_PCMEX = 7;
	public const int AKCODECID_EXTERNAL_SOURCE = 8;
	public const int AKCODECID_XWMA = 9;
	public const int AKCODECID_AAC = 10;
	public const int AKCODECID_FILE_PACKAGE = 11;
	public const int AKCODECID_ATRAC9 = 12;
	public const int AKCODECID_VAG = 13;
	public const int AKCODECID_PROFILERCAPTURE = 14;
	public const int AKCODECID_ANALYSISFILE = 15;
	public const int AKCODECID_MIDI = 16;
	public const int AKCODECID_OPUSNX = 17;
	public const int AKCODECID_CAF = 18;
	public const int AKCODECID_AKOPUS = 19;
	public const int AKPLUGINID_METER = 129;
	public const int AKPLUGINID_RECORDER = 132;
	public const int AKEXTENSIONID_SPATIALAUDIO = 800;
	public const int AKEXTENSIONID_INTERACTIVEMUSIC = 801;
	public const int AK_WAVE_FORMAT_VAG = 65531;
	public const int AK_WAVE_FORMAT_AT9 = 65532;
	public const int AK_WAVE_FORMAT_VORBIS = 65535;
	public const int AK_WAVE_FORMAT_AAC = 43712;
	public const int AK_WAVE_FORMAT_OPUSNX = 12345;
	public const int AK_WAVE_FORMAT_OPUS = 12352;
	public const int WAVE_FORMAT_XMA2 = 358;
	public const int AK_PANNER_NUM_STORAGE_BITS = 3;
	public const int AK_POSSOURCE_NUM_STORAGE_BITS = 3;
	public const int AK_SPAT_NUM_STORAGE_BITS = 3;
	public const int AK_MAX_BITS_METERING_FLAGS = 5;
	public const int AK_OS_STRUCT_ALIGN = 4;
	public const int AK_64B_OS_STRUCT_ALIGN = 8;
	public const bool AK_ASYNC_OPEN_DEFAULT = False;
	public const int AK_COMM_DEFAULT_DISCOVERY_PORT = 24024;
	public const int AK_MIDI_EVENT_TYPE_INVALID = 0;
	public const int AK_MIDI_EVENT_TYPE_NOTE_OFF = 128;
	public const int AK_MIDI_EVENT_TYPE_NOTE_ON = 144;
	public const int AK_MIDI_EVENT_TYPE_NOTE_AFTERTOUCH = 160;
	public const int AK_MIDI_EVENT_TYPE_CONTROLLER = 176;
	public const int AK_MIDI_EVENT_TYPE_PROGRAM_CHANGE = 192;
	public const int AK_MIDI_EVENT_TYPE_CHANNEL_AFTERTOUCH = 208;
	public const int AK_MIDI_EVENT_TYPE_PITCH_BEND = 224;
	public const int AK_MIDI_EVENT_TYPE_SYSEX = 240;
	public const int AK_MIDI_EVENT_TYPE_ESCAPE = 247;
	public const int AK_MIDI_EVENT_TYPE_META = 255;
	public const int AK_MIDI_CC_BANK_SELECT_COARSE = 0;
	public const int AK_MIDI_CC_MOD_WHEEL_COARSE = 1;
	public const int AK_MIDI_CC_BREATH_CTRL_COARSE = 2;
	public const int AK_MIDI_CC_CTRL_3_COARSE = 3;
	public const int AK_MIDI_CC_FOOT_PEDAL_COARSE = 4;
	public const int AK_MIDI_CC_PORTAMENTO_COARSE = 5;
	public const int AK_MIDI_CC_DATA_ENTRY_COARSE = 6;
	public const int AK_MIDI_CC_VOLUME_COARSE = 7;
	public const int AK_MIDI_CC_BALANCE_COARSE = 8;
	public const int AK_MIDI_CC_CTRL_9_COARSE = 9;
	public const int AK_MIDI_CC_PAN_POSITION_COARSE = 10;
	public const int AK_MIDI_CC_EXPRESSION_COARSE = 11;
	public const int AK_MIDI_CC_EFFECT_CTRL_1_COARSE = 12;
	public const int AK_MIDI_CC_EFFECT_CTRL_2_COARSE = 13;
	public const int AK_MIDI_CC_CTRL_14_COARSE = 14;
	public const int AK_MIDI_CC_CTRL_15_COARSE = 15;
	public const int AK_MIDI_CC_GEN_SLIDER_1 = 16;
	public const int AK_MIDI_CC_GEN_SLIDER_2 = 17;
	public const int AK_MIDI_CC_GEN_SLIDER_3 = 18;
	public const int AK_MIDI_CC_GEN_SLIDER_4 = 19;
	public const int AK_MIDI_CC_CTRL_20_COARSE = 20;
	public const int AK_MIDI_CC_CTRL_21_COARSE = 21;
	public const int AK_MIDI_CC_CTRL_22_COARSE = 22;
	public const int AK_MIDI_CC_CTRL_23_COARSE = 23;
	public const int AK_MIDI_CC_CTRL_24_COARSE = 24;
	public const int AK_MIDI_CC_CTRL_25_COARSE = 25;
	public const int AK_MIDI_CC_CTRL_26_COARSE = 26;
	public const int AK_MIDI_CC_CTRL_27_COARSE = 27;
	public const int AK_MIDI_CC_CTRL_28_COARSE = 28;
	public const int AK_MIDI_CC_CTRL_29_COARSE = 29;
	public const int AK_MIDI_CC_CTRL_30_COARSE = 30;
	public const int AK_MIDI_CC_CTRL_31_COARSE = 31;
	public const int AK_MIDI_CC_BANK_SELECT_FINE = 32;
	public const int AK_MIDI_CC_MOD_WHEEL_FINE = 33;
	public const int AK_MIDI_CC_BREATH_CTRL_FINE = 34;
	public const int AK_MIDI_CC_CTRL_3_FINE = 35;
	public const int AK_MIDI_CC_FOOT_PEDAL_FINE = 36;
	public const int AK_MIDI_CC_PORTAMENTO_FINE = 37;
	public const int AK_MIDI_CC_DATA_ENTRY_FINE = 38;
	public const int AK_MIDI_CC_VOLUME_FINE = 39;
	public const int AK_MIDI_CC_BALANCE_FINE = 40;
	public const int AK_MIDI_CC_CTRL_9_FINE = 41;
	public const int AK_MIDI_CC_PAN_POSITION_FINE = 42;
	public const int AK_MIDI_CC_EXPRESSION_FINE = 43;
	public const int AK_MIDI_CC_EFFECT_CTRL_1_FINE = 44;
	public const int AK_MIDI_CC_EFFECT_CTRL_2_FINE = 45;
	public const int AK_MIDI_CC_CTRL_14_FINE = 46;
	public const int AK_MIDI_CC_CTRL_15_FINE = 47;
	public const int AK_MIDI_CC_CTRL_20_FINE = 52;
	public const int AK_MIDI_CC_CTRL_21_FINE = 53;
	public const int AK_MIDI_CC_CTRL_22_FINE = 54;
	public const int AK_MIDI_CC_CTRL_23_FINE = 55;
	public const int AK_MIDI_CC_CTRL_24_FINE = 56;
	public const int AK_MIDI_CC_CTRL_25_FINE = 57;
	public const int AK_MIDI_CC_CTRL_26_FINE = 58;
	public const int AK_MIDI_CC_CTRL_27_FINE = 59;
	public const int AK_MIDI_CC_CTRL_28_FINE = 60;
	public const int AK_MIDI_CC_CTRL_29_FINE = 61;
	public const int AK_MIDI_CC_CTRL_30_FINE = 62;
	public const int AK_MIDI_CC_CTRL_31_FINE = 63;
	public const int AK_MIDI_CC_HOLD_PEDAL = 64;
	public const int AK_MIDI_CC_PORTAMENTO_ON_OFF = 65;
	public const int AK_MIDI_CC_SUSTENUTO_PEDAL = 66;
	public const int AK_MIDI_CC_SOFT_PEDAL = 67;
	public const int AK_MIDI_CC_LEGATO_PEDAL = 68;
	public const int AK_MIDI_CC_HOLD_PEDAL_2 = 69;
	public const int AK_MIDI_CC_SOUND_VARIATION = 70;
	public const int AK_MIDI_CC_SOUND_TIMBRE = 71;
	public const int AK_MIDI_CC_SOUND_RELEASE_TIME = 72;
	public const int AK_MIDI_CC_SOUND_ATTACK_TIME = 73;
	public const int AK_MIDI_CC_SOUND_BRIGHTNESS = 74;
	public const int AK_MIDI_CC_SOUND_CTRL_6 = 75;
	public const int AK_MIDI_CC_SOUND_CTRL_7 = 76;
	public const int AK_MIDI_CC_SOUND_CTRL_8 = 77;
	public const int AK_MIDI_CC_SOUND_CTRL_9 = 78;
	public const int AK_MIDI_CC_SOUND_CTRL_10 = 79;
	public const int AK_MIDI_CC_GENERAL_BUTTON_1 = 80;
	public const int AK_MIDI_CC_GENERAL_BUTTON_2 = 81;
	public const int AK_MIDI_CC_GENERAL_BUTTON_3 = 82;
	public const int AK_MIDI_CC_GENERAL_BUTTON_4 = 83;
	public const int AK_MIDI_CC_REVERB_LEVEL = 91;
	public const int AK_MIDI_CC_TREMOLO_LEVEL = 92;
	public const int AK_MIDI_CC_CHORUS_LEVEL = 93;
	public const int AK_MIDI_CC_CELESTE_LEVEL = 94;
	public const int AK_MIDI_CC_PHASER_LEVEL = 95;
	public const int AK_MIDI_CC_DATA_BUTTON_P1 = 96;
	public const int AK_MIDI_CC_DATA_BUTTON_M1 = 97;
	public const int AK_MIDI_CC_NON_REGISTER_COARSE = 98;
	public const int AK_MIDI_CC_NON_REGISTER_FINE = 99;
	public const int AK_MIDI_CC_ALL_SOUND_OFF = 120;
	public const int AK_MIDI_CC_ALL_CONTROLLERS_OFF = 121;
	public const int AK_MIDI_CC_LOCAL_KEYBOARD = 122;
	public const int AK_MIDI_CC_ALL_NOTES_OFF = 123;
	public const int AK_MIDI_CC_OMNI_MODE_OFF = 124;
	public const int AK_MIDI_CC_OMNI_MODE_ON = 125;
	public const int AK_MIDI_CC_OMNI_MONOPHONIC_ON = 126;
	public const int AK_MIDI_CC_OMNI_POLYPHONIC_ON = 127;
	public const int AK_SPEAKER_FRONT_LEFT = 1;
	public const int AK_SPEAKER_FRONT_RIGHT = 2;
	public const int AK_SPEAKER_FRONT_CENTER = 4;
	public const int AK_SPEAKER_LOW_FREQUENCY = 8;
	public const int AK_SPEAKER_BACK_LEFT = 16;
	public const int AK_SPEAKER_BACK_RIGHT = 32;
	public const int AK_SPEAKER_BACK_CENTER = 256;
	public const int AK_SPEAKER_SIDE_LEFT = 512;
	public const int AK_SPEAKER_SIDE_RIGHT = 1024;
	public const int AK_SPEAKER_TOP = 2048;
	public const int AK_SPEAKER_HEIGHT_FRONT_LEFT = 4096;
	public const int AK_SPEAKER_HEIGHT_FRONT_CENTER = 8192;
	public const int AK_SPEAKER_HEIGHT_FRONT_RIGHT = 16384;
	public const int AK_SPEAKER_HEIGHT_BACK_LEFT = 32768;
	public const int AK_SPEAKER_HEIGHT_BACK_CENTER = 65536;
	public const int AK_SPEAKER_HEIGHT_BACK_RIGHT = 131072;
	public const int AK_SPEAKER_SETUP_MONO = 4;
	public const int AK_SPEAKER_SETUP_0POINT1 = 8;
	public const int AK_SPEAKER_SETUP_1POINT1 = 12;
	public const int AK_SPEAKER_SETUP_STEREO = 3;
	public const int AK_SPEAKER_SETUP_2POINT1 = 11;
	public const int AK_SPEAKER_SETUP_3STEREO = 7;
	public const int AK_SPEAKER_SETUP_3POINT1 = 15;
	public const int AK_SPEAKER_SETUP_4 = 1539;
	public const int AK_SPEAKER_SETUP_4POINT1 = 1547;
	public const int AK_SPEAKER_SETUP_5 = 1543;
	public const int AK_SPEAKER_SETUP_5POINT1 = 1551;
	public const int AK_SPEAKER_SETUP_6 = 1587;
	public const int AK_SPEAKER_SETUP_6POINT1 = 1595;
	public const int AK_SPEAKER_SETUP_7 = 1591;
	public const int AK_SPEAKER_SETUP_7POINT1 = 1599;
	public const int AK_SPEAKER_SETUP_SURROUND = 259;
	public const int AK_SPEAKER_SETUP_DPL2 = 1539;
	public const int AK_SPEAKER_SETUP_HEIGHT_4 = 184320;
	public const int AK_SPEAKER_SETUP_HEIGHT_5 = 192512;
	public const int AK_SPEAKER_SETUP_HEIGHT_ALL = 258048;
	public const int AK_SPEAKER_SETUP_AURO_222 = 22019;
	public const int AK_SPEAKER_SETUP_AURO_8 = 185859;
	public const int AK_SPEAKER_SETUP_AURO_9 = 185863;
	public const int AK_SPEAKER_SETUP_AURO_9POINT1 = 185871;
	public const int AK_SPEAKER_SETUP_AURO_10 = 187911;
	public const int AK_SPEAKER_SETUP_AURO_10POINT1 = 187919;
	public const int AK_SPEAKER_SETUP_AURO_11 = 196103;
	public const int AK_SPEAKER_SETUP_AURO_11POINT1 = 196111;
	public const int AK_SPEAKER_SETUP_AURO_11_740 = 185911;
	public const int AK_SPEAKER_SETUP_AURO_11POINT1_740 = 185919;
	public const int AK_SPEAKER_SETUP_AURO_13_751 = 196151;
	public const int AK_SPEAKER_SETUP_AURO_13POINT1_751 = 196159;
	public const int AK_SPEAKER_SETUP_DOLBY_5_0_2 = 22023;
	public const int AK_SPEAKER_SETUP_DOLBY_5_1_2 = 22031;
	public const int AK_SPEAKER_SETUP_DOLBY_6_0_2 = 22067;
	public const int AK_SPEAKER_SETUP_DOLBY_6_1_2 = 22075;
	public const int AK_SPEAKER_SETUP_DOLBY_6_0_4 = 185907;
	public const int AK_SPEAKER_SETUP_DOLBY_6_1_4 = 185915;
	public const int AK_SPEAKER_SETUP_DOLBY_7_0_2 = 22071;
	public const int AK_SPEAKER_SETUP_DOLBY_7_1_2 = 22079;
	public const int AK_SPEAKER_SETUP_DOLBY_7_0_4 = 185911;
	public const int AK_SPEAKER_SETUP_DOLBY_7_1_4 = 185919;
	public const int AK_SPEAKER_SETUP_ALL_SPEAKERS = 261951;
	public const int AK_IDX_SETUP_FRONT_LEFT = 0;
	public const int AK_IDX_SETUP_FRONT_RIGHT = 1;
	public const int AK_IDX_SETUP_CENTER = 2;
	public const int AK_IDX_SETUP_NOCENTER_BACK_LEFT = 2;
	public const int AK_IDX_SETUP_NOCENTER_BACK_RIGHT = 3;
	public const int AK_IDX_SETUP_NOCENTER_SIDE_LEFT = 4;
	public const int AK_IDX_SETUP_NOCENTER_SIDE_RIGHT = 5;
	public const int AK_IDX_SETUP_WITHCENTER_BACK_LEFT = 3;
	public const int AK_IDX_SETUP_WITHCENTER_BACK_RIGHT = 4;
	public const int AK_IDX_SETUP_WITHCENTER_SIDE_LEFT = 5;
	public const int AK_IDX_SETUP_WITHCENTER_SIDE_RIGHT = 6;
	public const int AK_IDX_SETUP_0_LFE = 0;
	public const int AK_IDX_SETUP_1_CENTER = 0;
	public const int AK_IDX_SETUP_1_LFE = 1;
	public const int AK_IDX_SETUP_2_LEFT = 0;
	public const int AK_IDX_SETUP_2_RIGHT = 1;
	public const int AK_IDX_SETUP_2_LFE = 2;
	public const int AK_IDX_SETUP_3_LEFT = 0;
	public const int AK_IDX_SETUP_3_RIGHT = 1;
	public const int AK_IDX_SETUP_3_CENTER = 2;
	public const int AK_IDX_SETUP_3_LFE = 3;
	public const int AK_IDX_SETUP_4_FRONTLEFT = 0;
	public const int AK_IDX_SETUP_4_FRONTRIGHT = 1;
	public const int AK_IDX_SETUP_4_REARLEFT = 2;
	public const int AK_IDX_SETUP_4_REARRIGHT = 3;
	public const int AK_IDX_SETUP_4_LFE = 4;
	public const int AK_IDX_SETUP_5_FRONTLEFT = 0;
	public const int AK_IDX_SETUP_5_FRONTRIGHT = 1;
	public const int AK_IDX_SETUP_5_CENTER = 2;
	public const int AK_IDX_SETUP_5_REARLEFT = 3;
	public const int AK_IDX_SETUP_5_REARRIGHT = 4;
	public const int AK_IDX_SETUP_5_LFE = 5;
	public const int AK_IDX_SETUP_6_FRONTLEFT = 0;
	public const int AK_IDX_SETUP_6_FRONTRIGHT = 1;
	public const int AK_IDX_SETUP_6_REARLEFT = 2;
	public const int AK_IDX_SETUP_6_REARRIGHT = 3;
	public const int AK_IDX_SETUP_6_SIDELEFT = 4;
	public const int AK_IDX_SETUP_6_SIDERIGHT = 5;
	public const int AK_IDX_SETUP_6_LFE = 6;
	public const int AK_IDX_SETUP_7_FRONTLEFT = 0;
	public const int AK_IDX_SETUP_7_FRONTRIGHT = 1;
	public const int AK_IDX_SETUP_7_CENTER = 2;
	public const int AK_IDX_SETUP_7_REARLEFT = 3;
	public const int AK_IDX_SETUP_7_REARRIGHT = 4;
	public const int AK_IDX_SETUP_7_SIDELEFT = 5;
	public const int AK_IDX_SETUP_7_SIDERIGHT = 6;
	public const int AK_IDX_SETUP_7_LFE = 7;
	public const int AK_SPEAKER_SETUP_0_1 = 8;
	public const int AK_SPEAKER_SETUP_1_0_CENTER = 4;
	public const int AK_SPEAKER_SETUP_1_1_CENTER = 12;
	public const int AK_SPEAKER_SETUP_2_0 = 3;
	public const int AK_SPEAKER_SETUP_2_1 = 11;
	public const int AK_SPEAKER_SETUP_3_0 = 7;
	public const int AK_SPEAKER_SETUP_3_1 = 15;
	public const int AK_SPEAKER_SETUP_FRONT = 7;
	public const int AK_SPEAKER_SETUP_4_0 = 1539;
	public const int AK_SPEAKER_SETUP_4_1 = 1547;
	public const int AK_SPEAKER_SETUP_5_0 = 1543;
	public const int AK_SPEAKER_SETUP_5_1 = 1551;
	public const int AK_SPEAKER_SETUP_6_0 = 1587;
	public const int AK_SPEAKER_SETUP_6_1 = 1595;
	public const int AK_SPEAKER_SETUP_7_0 = 1591;
	public const int AK_SPEAKER_SETUP_7_1 = 1599;
	public const int AK_SPEAKER_SETUP_DEFAULT_PLANE = 1599;
	public const int AK_SUPPORTED_STANDARD_CHANNEL_MASK = 261951;
	public const int AK_STANDARD_MAX_NUM_CHANNELS = 8;
	public const int AK_NUM_SAMPLED_SPHERE_POINTS = 32;
	public const int AK_MAX_NUM_TEXTURE = 4;
	public const int AK_MAX_REFLECT_ORDER = 4;
	public const int AK_MAX_REFLECTION_PATH_LENGTH = 6;
	public const int AK_MAX_SOUND_PROPAGATION_DEPTH = 8;
	public const double AK_DEFAULT_DIFFR_SHADOW_DEGREES = 30;
	public const double AK_DEFAULT_DIFFR_SHADOW_ATTEN = 2;
	public const double AK_SA_EPSILON = 0,001;
	public const double AK_SA_PLANE_THICKNESS_RATIO = 0,005;
	private static AkSoundEngine.GameObjectHashFunction gameObjectHash; // 0x0
	public const string Deprecation_2018_1_2 = "This functionality is deprecated as of Wwise v2018.1.2 and will be removed in a future release.";
	public const string Deprecation_2018_1_6 = "This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.";
	public const string Deprecation_2018_1_8 = "This functionality is deprecated as of Wwise v2018.1.8 and will be removed in a future release.";
	private static readonly HashSet<ulong> RegisteredGameObjects; // 0x4

	// Properties
	public static uint AK_SOUNDBANK_VERSION { get; }
	public static ushort AK_INT { get; }
	public static ushort AK_FLOAT { get; }
	public static byte AK_INTERLEAVED { get; }
	public static byte AK_NONINTERLEAVED { get; }
	public static uint AK_LE_NATIVE_BITSPERSAMPLE { get; }
	public static uint AK_LE_NATIVE_SAMPLETYPE { get; }
	public static uint AK_LE_NATIVE_INTERLEAVE { get; }
	public static byte AK_INVALID_MIDI_CHANNEL { get; }
	public static byte AK_INVALID_MIDI_NOTE { get; }
	public static float kDefaultMaxPathLength { get; }
	public static float kMaxDiffraction { get; }
	public static int g_SpatialAudioPoolId { get; set; }
	public static AkSoundEngine.GameObjectHashFunction GameObjectHash { set; }

	// Methods

	// RVA: 0x1675044 Offset: 0x1675044 VA: 0x1675044
	public static uint get_AK_SOUNDBANK_VERSION() { }

	// RVA: 0x1675198 Offset: 0x1675198 VA: 0x1675198
	public static ushort get_AK_INT() { }

	// RVA: 0x1675308 Offset: 0x1675308 VA: 0x1675308
	public static ushort get_AK_FLOAT() { }

	// RVA: 0x167547C Offset: 0x167547C VA: 0x167547C
	public static byte get_AK_INTERLEAVED() { }

	// RVA: 0x1675600 Offset: 0x1675600 VA: 0x1675600
	public static byte get_AK_NONINTERLEAVED() { }

	// RVA: 0x1675750 Offset: 0x1675750 VA: 0x1675750
	public static uint get_AK_LE_NATIVE_BITSPERSAMPLE() { }

	// RVA: 0x16758A8 Offset: 0x16758A8 VA: 0x16758A8
	public static uint get_AK_LE_NATIVE_SAMPLETYPE() { }

	// RVA: 0x16759FC Offset: 0x16759FC VA: 0x16759FC
	public static uint get_AK_LE_NATIVE_INTERLEAVE() { }

	// RVA: 0x1675B54 Offset: 0x1675B54 VA: 0x1675B54
	public static uint DynamicSequenceOpen(GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, AkDynamicSequenceType in_eDynamicSequenceType) { }

	// RVA: 0x1675F3C Offset: 0x1675F3C VA: 0x1675F3C
	public static uint DynamicSequenceOpen(GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie) { }

	// RVA: 0x16761D4 Offset: 0x16761D4 VA: 0x16761D4
	public static uint DynamicSequenceOpen(GameObject in_gameObjectID) { }

	// RVA: 0x16763DC Offset: 0x16763DC VA: 0x16763DC
	public static AKRESULT DynamicSequenceClose(uint in_playingID) { }

	// RVA: 0x167653C Offset: 0x167653C VA: 0x167653C
	public static AKRESULT DynamicSequencePlay(uint in_playingID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x16766C4 Offset: 0x16766C4 VA: 0x16766C4
	public static AKRESULT DynamicSequencePlay(uint in_playingID, int in_uTransitionDuration) { }

	// RVA: 0x167683C Offset: 0x167683C VA: 0x167683C
	public static AKRESULT DynamicSequencePlay(uint in_playingID) { }

	// RVA: 0x16769A4 Offset: 0x16769A4 VA: 0x16769A4
	public static AKRESULT DynamicSequencePause(uint in_playingID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x1676B2C Offset: 0x1676B2C VA: 0x1676B2C
	public static AKRESULT DynamicSequencePause(uint in_playingID, int in_uTransitionDuration) { }

	// RVA: 0x1676CA4 Offset: 0x1676CA4 VA: 0x1676CA4
	public static AKRESULT DynamicSequencePause(uint in_playingID) { }

	// RVA: 0x1676E0C Offset: 0x1676E0C VA: 0x1676E0C
	public static AKRESULT DynamicSequenceResume(uint in_playingID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x1676F98 Offset: 0x1676F98 VA: 0x1676F98
	public static AKRESULT DynamicSequenceResume(uint in_playingID, int in_uTransitionDuration) { }

	// RVA: 0x1677110 Offset: 0x1677110 VA: 0x1677110
	public static AKRESULT DynamicSequenceResume(uint in_playingID) { }

	// RVA: 0x1677278 Offset: 0x1677278 VA: 0x1677278
	public static AKRESULT DynamicSequenceStop(uint in_playingID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x16773FC Offset: 0x16773FC VA: 0x16773FC
	public static AKRESULT DynamicSequenceStop(uint in_playingID, int in_uTransitionDuration) { }

	// RVA: 0x1677574 Offset: 0x1677574 VA: 0x1677574
	public static AKRESULT DynamicSequenceStop(uint in_playingID) { }

	// RVA: 0x16776DC Offset: 0x16776DC VA: 0x16776DC
	public static AKRESULT DynamicSequenceBreak(uint in_playingID) { }

	// RVA: 0x167783C Offset: 0x167783C VA: 0x167783C
	public static AKRESULT DynamicSequenceGetPauseTimes(uint in_playingID, out uint out_uTime, out uint out_uDuration) { }

	// RVA: 0x16779C4 Offset: 0x16779C4 VA: 0x16779C4
	public static AkPlaylist DynamicSequenceLockPlaylist(uint in_playingID) { }

	// RVA: 0x1677B74 Offset: 0x1677B74 VA: 0x1677B74
	public static AKRESULT DynamicSequenceUnlockPlaylist(uint in_playingID) { }

	// RVA: 0x1677CE0 Offset: 0x1677CE0 VA: 0x1677CE0
	public static bool IsInitialized() { }

	// RVA: 0x1677E60 Offset: 0x1677E60 VA: 0x1677E60
	public static AKRESULT GetAudioSettings(AkAudioSettings out_audioSettings) { }

	// RVA: 0x1678004 Offset: 0x1678004 VA: 0x1678004
	public static AkChannelConfig GetSpeakerConfiguration(ulong in_idOutput) { }

	// RVA: 0x16781B0 Offset: 0x16781B0 VA: 0x16781B0
	public static AkChannelConfig GetSpeakerConfiguration() { }

	// RVA: 0x1678338 Offset: 0x1678338 VA: 0x1678338
	public static AKRESULT GetPanningRule(out int out_ePanningRule, ulong in_idOutput) { }

	// RVA: 0x16784C0 Offset: 0x16784C0 VA: 0x16784C0
	public static AKRESULT GetPanningRule(out int out_ePanningRule) { }

	// RVA: 0x1678620 Offset: 0x1678620 VA: 0x1678620
	public static AKRESULT SetPanningRule(AkPanningRule in_ePanningRule, ulong in_idOutput) { }

	// RVA: 0x16787A8 Offset: 0x16787A8 VA: 0x16787A8
	public static AKRESULT SetPanningRule(AkPanningRule in_ePanningRule) { }

	// RVA: 0x1678908 Offset: 0x1678908 VA: 0x1678908
	public static AKRESULT GetSpeakerAngles(float[] io_pfSpeakerAngles, ref uint io_uNumAngles, out float out_fHeightAngle, ulong in_idOutput) { }

	// RVA: 0x1678AB8 Offset: 0x1678AB8 VA: 0x1678AB8
	public static AKRESULT GetSpeakerAngles(float[] io_pfSpeakerAngles, ref uint io_uNumAngles, out float out_fHeightAngle) { }

	// RVA: 0x1678C40 Offset: 0x1678C40 VA: 0x1678C40
	public static AKRESULT SetSpeakerAngles(float[] in_pfSpeakerAngles, uint in_uNumAngles, float in_fHeightAngle, ulong in_idOutput) { }

	// RVA: 0x1678DF0 Offset: 0x1678DF0 VA: 0x1678DF0
	public static AKRESULT SetSpeakerAngles(float[] in_pfSpeakerAngles, uint in_uNumAngles, float in_fHeightAngle) { }

	// RVA: 0x1678F78 Offset: 0x1678F78 VA: 0x1678F78
	public static AKRESULT SetVolumeThreshold(float in_fVolumeThresholdDB) { }

	// RVA: 0x1679110 Offset: 0x1679110 VA: 0x1679110
	public static AKRESULT SetMaxNumVoicesLimit(ushort in_maxNumberVoices) { }

	// RVA: 0x167926C Offset: 0x167926C VA: 0x167926C
	public static AKRESULT RenderAudio(bool in_bAllowSyncRender) { }

	// RVA: 0x16793CC Offset: 0x16793CC VA: 0x16793CC
	public static AKRESULT RenderAudio() { }

	// RVA: 0x167951C Offset: 0x167951C VA: 0x167951C
	public static AKRESULT RegisterPluginDLL(string in_DllName, string in_DllPath) { }

	// RVA: 0x16796D0 Offset: 0x16796D0 VA: 0x16796D0
	public static AKRESULT RegisterPluginDLL(string in_DllName) { }

	// RVA: 0x1679858 Offset: 0x1679858 VA: 0x1679858
	public static uint GetIDFromString(string in_pszString) { }

	// RVA: 0x1679A10 Offset: 0x1679A10 VA: 0x1679A10
	public static uint PostEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_cExternals, AkExternalSourceInfoArray in_pExternalSources, uint in_PlayingID) { }

	// RVA: 0x1679D40 Offset: 0x1679D40 VA: 0x1679D40
	public static uint PostEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_cExternals, AkExternalSourceInfoArray in_pExternalSources) { }

	// RVA: 0x167A068 Offset: 0x167A068 VA: 0x167A068
	public static uint PostEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie) { }

	// RVA: 0x167A340 Offset: 0x167A340 VA: 0x167A340
	public static uint PostEvent(uint in_eventID, GameObject in_gameObjectID) { }

	// RVA: 0x167A588 Offset: 0x167A588 VA: 0x167A588
	public static uint PostEvent(string in_pszEventName, GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_cExternals, AkExternalSourceInfoArray in_pExternalSources, uint in_PlayingID) { }

	// RVA: 0x167A8E4 Offset: 0x167A8E4 VA: 0x167A8E4
	public static uint PostEvent(string in_pszEventName, GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_cExternals, AkExternalSourceInfoArray in_pExternalSources) { }

	// RVA: 0x167AC24 Offset: 0x167AC24 VA: 0x167AC24
	public static uint PostEvent(string in_pszEventName, GameObject in_gameObjectID, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie) { }

	// RVA: 0x167AF1C Offset: 0x167AF1C VA: 0x167AF1C
	public static uint PostEvent(string in_pszEventName, GameObject in_gameObjectID) { }

	// RVA: 0x167B18C Offset: 0x167B18C VA: 0x167B18C
	public static AKRESULT ExecuteActionOnEvent(uint in_eventID, AkActionOnEventType in_ActionType, GameObject in_gameObjectID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve, uint in_PlayingID) { }

	// RVA: 0x167B39C Offset: 0x167B39C VA: 0x167B39C
	public static AKRESULT ExecuteActionOnEvent(uint in_eventID, AkActionOnEventType in_ActionType, GameObject in_gameObjectID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x167B59C Offset: 0x167B59C VA: 0x167B59C
	public static AKRESULT ExecuteActionOnEvent(uint in_eventID, AkActionOnEventType in_ActionType, GameObject in_gameObjectID, int in_uTransitionDuration) { }

	// RVA: 0x167B794 Offset: 0x167B794 VA: 0x167B794
	public static AKRESULT ExecuteActionOnEvent(uint in_eventID, AkActionOnEventType in_ActionType, GameObject in_gameObjectID) { }

	// RVA: 0x167B97C Offset: 0x167B97C VA: 0x167B97C
	public static AKRESULT ExecuteActionOnEvent(uint in_eventID, AkActionOnEventType in_ActionType) { }

	// RVA: 0x167BAF4 Offset: 0x167BAF4 VA: 0x167BAF4
	public static AKRESULT ExecuteActionOnEvent(string in_pszEventName, AkActionOnEventType in_ActionType, GameObject in_gameObjectID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve, uint in_PlayingID) { }

	// RVA: 0x167BD28 Offset: 0x167BD28 VA: 0x167BD28
	public static AKRESULT ExecuteActionOnEvent(string in_pszEventName, AkActionOnEventType in_ActionType, GameObject in_gameObjectID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x167BF50 Offset: 0x167BF50 VA: 0x167BF50
	public static AKRESULT ExecuteActionOnEvent(string in_pszEventName, AkActionOnEventType in_ActionType, GameObject in_gameObjectID, int in_uTransitionDuration) { }

	// RVA: 0x167C168 Offset: 0x167C168 VA: 0x167C168
	public static AKRESULT ExecuteActionOnEvent(string in_pszEventName, AkActionOnEventType in_ActionType, GameObject in_gameObjectID) { }

	// RVA: 0x167C370 Offset: 0x167C370 VA: 0x167C370
	public static AKRESULT ExecuteActionOnEvent(string in_pszEventName, AkActionOnEventType in_ActionType) { }

	// RVA: 0x167C508 Offset: 0x167C508 VA: 0x167C508
	public static AKRESULT PostMIDIOnEvent(uint in_eventID, GameObject in_gameObjectID, AkMIDIPostArray in_pPosts, ushort in_uNumPosts) { }

	// RVA: 0x167C74C Offset: 0x167C74C VA: 0x167C74C
	public static AKRESULT StopMIDIOnEvent(uint in_eventID, GameObject in_gameObjectID) { }

	// RVA: 0x167C920 Offset: 0x167C920 VA: 0x167C920
	public static AKRESULT StopMIDIOnEvent(uint in_eventID) { }

	// RVA: 0x167CA80 Offset: 0x167CA80 VA: 0x167CA80
	public static AKRESULT StopMIDIOnEvent() { }

	// RVA: 0x167CBD0 Offset: 0x167CBD0 VA: 0x167CBD0
	public static AKRESULT PinEventInStreamCache(uint in_eventID, sbyte in_uActivePriority, sbyte in_uInactivePriority) { }

	// RVA: 0x167CD58 Offset: 0x167CD58 VA: 0x167CD58
	public static AKRESULT PinEventInStreamCache(string in_pszEventName, sbyte in_uActivePriority, sbyte in_uInactivePriority) { }

	// RVA: 0x167CF04 Offset: 0x167CF04 VA: 0x167CF04
	public static AKRESULT UnpinEventInStreamCache(uint in_eventID) { }

	// RVA: 0x167D070 Offset: 0x167D070 VA: 0x167D070
	public static AKRESULT UnpinEventInStreamCache(string in_pszEventName) { }

	// RVA: 0x167D1FC Offset: 0x167D1FC VA: 0x167D1FC
	public static AKRESULT GetBufferStatusForPinnedEvent(uint in_eventID, out float out_fPercentBuffered, out int out_bCachePinnedMemoryFull) { }

	// RVA: 0x167D390 Offset: 0x167D390 VA: 0x167D390
	public static AKRESULT GetBufferStatusForPinnedEvent(string in_pszEventName, out float out_fPercentBuffered, out int out_bCachePinnedMemoryFull) { }

	// RVA: 0x167D544 Offset: 0x167D544 VA: 0x167D544
	public static AKRESULT SeekOnEvent(uint in_eventID, GameObject in_gameObjectID, int in_iPosition, bool in_bSeekToNearestMarker, uint in_PlayingID) { }

	// RVA: 0x167D73C Offset: 0x167D73C VA: 0x167D73C
	public static AKRESULT SeekOnEvent(uint in_eventID, GameObject in_gameObjectID, int in_iPosition, bool in_bSeekToNearestMarker) { }

	// RVA: 0x167D924 Offset: 0x167D924 VA: 0x167D924
	public static AKRESULT SeekOnEvent(uint in_eventID, GameObject in_gameObjectID, int in_iPosition) { }

	// RVA: 0x167DB04 Offset: 0x167DB04 VA: 0x167DB04
	public static AKRESULT SeekOnEvent(string in_pszEventName, GameObject in_gameObjectID, int in_iPosition, bool in_bSeekToNearestMarker, uint in_PlayingID) { }

	// RVA: 0x167DD20 Offset: 0x167DD20 VA: 0x167DD20
	public static AKRESULT SeekOnEvent(string in_pszEventName, GameObject in_gameObjectID, int in_iPosition, bool in_bSeekToNearestMarker) { }

	// RVA: 0x167DF30 Offset: 0x167DF30 VA: 0x167DF30
	public static AKRESULT SeekOnEvent(string in_pszEventName, GameObject in_gameObjectID, int in_iPosition) { }

	// RVA: 0x167E130 Offset: 0x167E130 VA: 0x167E130
	public static AKRESULT SeekOnEvent(uint in_eventID, GameObject in_gameObjectID, float in_fPercent, bool in_bSeekToNearestMarker, uint in_PlayingID) { }

	// RVA: 0x167E334 Offset: 0x167E334 VA: 0x167E334
	public static AKRESULT SeekOnEvent(uint in_eventID, GameObject in_gameObjectID, float in_fPercent, bool in_bSeekToNearestMarker) { }

	// RVA: 0x167E52C Offset: 0x167E52C VA: 0x167E52C
	public static AKRESULT SeekOnEvent(uint in_eventID, GameObject in_gameObjectID, float in_fPercent) { }

	// RVA: 0x167E714 Offset: 0x167E714 VA: 0x167E714
	public static AKRESULT SeekOnEvent(string in_pszEventName, GameObject in_gameObjectID, float in_fPercent, bool in_bSeekToNearestMarker, uint in_PlayingID) { }

	// RVA: 0x167E948 Offset: 0x167E948 VA: 0x167E948
	public static AKRESULT SeekOnEvent(string in_pszEventName, GameObject in_gameObjectID, float in_fPercent, bool in_bSeekToNearestMarker) { }

	// RVA: 0x167EB70 Offset: 0x167EB70 VA: 0x167EB70
	public static AKRESULT SeekOnEvent(string in_pszEventName, GameObject in_gameObjectID, float in_fPercent) { }

	// RVA: 0x167ED88 Offset: 0x167ED88 VA: 0x167ED88
	public static void CancelEventCallbackCookie(object in_pCookie) { }

	// RVA: 0x167EE0C Offset: 0x167EE0C VA: 0x167EE0C
	public static void CancelEventCallbackGameObject(GameObject in_gameObjectID) { }

	// RVA: 0x167EFD8 Offset: 0x167EFD8 VA: 0x167EFD8
	public static void CancelEventCallback(uint in_playingID) { }

	// RVA: 0x167F05C Offset: 0x167F05C VA: 0x167F05C
	public static AKRESULT GetSourcePlayPosition(uint in_PlayingID, out int out_puPosition, bool in_bExtrapolate) { }

	// RVA: 0x167F1E8 Offset: 0x167F1E8 VA: 0x167F1E8
	public static AKRESULT GetSourcePlayPosition(uint in_PlayingID, out int out_puPosition) { }

	// RVA: 0x167F360 Offset: 0x167F360 VA: 0x167F360
	public static AKRESULT GetSourceStreamBuffering(uint in_PlayingID, out int out_buffering, out int out_bIsBuffering) { }

	// RVA: 0x167F4E0 Offset: 0x167F4E0 VA: 0x167F4E0
	public static void StopAll(GameObject in_gameObjectID) { }

	// RVA: 0x167F6D4 Offset: 0x167F6D4 VA: 0x167F6D4
	public static void StopAll() { }

	// RVA: 0x167F854 Offset: 0x167F854 VA: 0x167F854
	public static void StopPlayingID(uint in_playingID, int in_uTransitionDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x167F9D8 Offset: 0x167F9D8 VA: 0x167F9D8
	public static void StopPlayingID(uint in_playingID, int in_uTransitionDuration) { }

	// RVA: 0x167FB48 Offset: 0x167FB48 VA: 0x167FB48
	public static void StopPlayingID(uint in_playingID) { }

	// RVA: 0x167FCA8 Offset: 0x167FCA8 VA: 0x167FCA8
	public static void SetRandomSeed(uint in_uSeed) { }

	// RVA: 0x167FE38 Offset: 0x167FE38 VA: 0x167FE38
	public static void MuteBackgroundMusic(bool in_bMute) { }

	// RVA: 0x167FF94 Offset: 0x167FF94 VA: 0x167FF94
	public static bool GetBackgroundMusicMute() { }

	// RVA: 0x16800F0 Offset: 0x16800F0 VA: 0x16800F0
	public static AKRESULT SendPluginCustomGameData(uint in_busID, GameObject in_busObjectID, AkPluginType in_eType, uint in_uCompanyID, uint in_uPluginID, IntPtr in_pData, uint in_uSizeInBytes) { }

	// RVA: 0x1680308 Offset: 0x1680308 VA: 0x1680308
	public static AKRESULT UnregisterAllGameObj() { }

	// RVA: 0x1680454 Offset: 0x1680454 VA: 0x1680454
	public static AKRESULT SetMultiplePositions(GameObject in_GameObjectID, AkPositionArray in_pPositions, ushort in_NumPositions, AkMultiPositionType in_eMultiPositionType) { }

	// RVA: 0x168064C Offset: 0x168064C VA: 0x168064C
	public static AKRESULT SetMultiplePositions(GameObject in_GameObjectID, AkPositionArray in_pPositions, ushort in_NumPositions) { }

	// RVA: 0x1680834 Offset: 0x1680834 VA: 0x1680834
	public static AKRESULT SetMultiplePositions(GameObject in_GameObjectID, AkChannelEmitterArray in_pPositions, ushort in_NumPositions, AkMultiPositionType in_eMultiPositionType) { }

	// RVA: 0x1680A2C Offset: 0x1680A2C VA: 0x1680A2C
	public static AKRESULT SetMultiplePositions(GameObject in_GameObjectID, AkChannelEmitterArray in_pPositions, ushort in_NumPositions) { }

	// RVA: 0x1680C14 Offset: 0x1680C14 VA: 0x1680C14
	public static AKRESULT SetScalingFactor(GameObject in_GameObjectID, float in_fAttenuationScalingFactor) { }

	// RVA: 0x1680E04 Offset: 0x1680E04 VA: 0x1680E04
	public static AKRESULT ClearBanks() { }

	// RVA: 0x1680F78 Offset: 0x1680F78 VA: 0x1680F78
	public static AKRESULT SetBankLoadIOSettings(float in_fThroughput, sbyte in_priority) { }

	// RVA: 0x16810E8 Offset: 0x16810E8 VA: 0x16810E8
	public static AKRESULT LoadBank(string in_pszString, int in_memPoolId, out uint out_bankID) { }

	// RVA: 0x16812C0 Offset: 0x16812C0 VA: 0x16812C0
	public static AKRESULT LoadBank(uint in_bankID, int in_memPoolId) { }

	// RVA: 0x1681464 Offset: 0x1681464 VA: 0x1681464
	public static AKRESULT LoadBank(IntPtr in_pInMemoryBankPtr, uint in_uInMemoryBankSize, out uint out_bankID) { }

	// RVA: 0x168161C Offset: 0x168161C VA: 0x168161C
	public static AKRESULT LoadBank(IntPtr in_pInMemoryBankPtr, uint in_uInMemoryBankSize, int in_uPoolForBankMedia, out uint out_bankID) { }

	// RVA: 0x16817EC Offset: 0x16817EC VA: 0x16817EC
	public static AKRESULT LoadBank(string in_pszString, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie, int in_memPoolId, out uint out_bankID) { }

	// RVA: 0x1681A40 Offset: 0x1681A40 VA: 0x1681A40
	public static AKRESULT LoadBank(uint in_bankID, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie, int in_memPoolId) { }

	// RVA: 0x1681C64 Offset: 0x1681C64 VA: 0x1681C64
	public static AKRESULT LoadBank(IntPtr in_pInMemoryBankPtr, uint in_uInMemoryBankSize, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie, out uint out_bankID) { }

	// RVA: 0x1681E94 Offset: 0x1681E94 VA: 0x1681E94
	public static AKRESULT LoadBank(IntPtr in_pInMemoryBankPtr, uint in_uInMemoryBankSize, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie, int in_uPoolForBankMedia, out uint out_bankID) { }

	// RVA: 0x16820D4 Offset: 0x16820D4 VA: 0x16820D4
	public static AKRESULT UnloadBank(string in_pszString, IntPtr in_pInMemoryBankPtr, out int out_pMemPoolId) { }

	// RVA: 0x16822B4 Offset: 0x16822B4 VA: 0x16822B4
	public static AKRESULT UnloadBank(string in_pszString, IntPtr in_pInMemoryBankPtr) { }

	// RVA: 0x1682484 Offset: 0x1682484 VA: 0x1682484
	public static AKRESULT UnloadBank(uint in_bankID, IntPtr in_pInMemoryBankPtr, out int out_pMemPoolId) { }

	// RVA: 0x1682640 Offset: 0x1682640 VA: 0x1682640
	public static AKRESULT UnloadBank(uint in_bankID, IntPtr in_pInMemoryBankPtr) { }

	// RVA: 0x16827E8 Offset: 0x16827E8 VA: 0x16827E8
	public static AKRESULT UnloadBank(string in_pszString, IntPtr in_pInMemoryBankPtr, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1682A34 Offset: 0x1682A34 VA: 0x1682A34
	public static AKRESULT UnloadBank(uint in_bankID, IntPtr in_pInMemoryBankPtr, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1682C58 Offset: 0x1682C58 VA: 0x1682C58
	public static void CancelBankCallbackCookie(object in_pCookie) { }

	// RVA: 0x1682CDC Offset: 0x1682CDC VA: 0x1682CDC
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, string in_pszString, AkBankContent in_uFlags) { }

	// RVA: 0x1682E80 Offset: 0x1682E80 VA: 0x1682E80
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, string in_pszString) { }

	// RVA: 0x1683010 Offset: 0x1683010 VA: 0x1683010
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, uint in_bankID, AkBankContent in_uFlags) { }

	// RVA: 0x168318C Offset: 0x168318C VA: 0x168318C
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, uint in_bankID) { }

	// RVA: 0x16832FC Offset: 0x16832FC VA: 0x16832FC
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, string in_pszString, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie, AkBankContent in_uFlags) { }

	// RVA: 0x1683518 Offset: 0x1683518 VA: 0x1683518
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, string in_pszString, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1683728 Offset: 0x1683728 VA: 0x1683728
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, uint in_bankID, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie, AkBankContent in_uFlags) { }

	// RVA: 0x1683924 Offset: 0x1683924 VA: 0x1683924
	public static AKRESULT PrepareBank(AkPreparationType in_PreparationType, uint in_bankID, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1683B0C Offset: 0x1683B0C VA: 0x1683B0C
	public static AKRESULT ClearPreparedEvents() { }

	// RVA: 0x1683C5C Offset: 0x1683C5C VA: 0x1683C5C
	public static AKRESULT PrepareEvent(AkPreparationType in_PreparationType, string[] in_ppszString, uint in_uNumEvent) { }

	// RVA: 0x16840BC Offset: 0x16840BC VA: 0x16840BC
	public static AKRESULT PrepareEvent(AkPreparationType in_PreparationType, uint[] in_pEventID, uint in_uNumEvent) { }

	// RVA: 0x1684244 Offset: 0x1684244 VA: 0x1684244
	public static AKRESULT PrepareEvent(AkPreparationType in_PreparationType, string[] in_ppszString, uint in_uNumEvent, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1684734 Offset: 0x1684734 VA: 0x1684734
	public static AKRESULT PrepareEvent(AkPreparationType in_PreparationType, uint[] in_pEventID, uint in_uNumEvent, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1684934 Offset: 0x1684934 VA: 0x1684934
	public static AKRESULT SetMedia(AkSourceSettingsArray in_pSourceSettings, uint in_uNumSourceSettings) { }

	// RVA: 0x1684AF4 Offset: 0x1684AF4 VA: 0x1684AF4
	public static AKRESULT UnsetMedia(AkSourceSettingsArray in_pSourceSettings, uint in_uNumSourceSettings) { }

	// RVA: 0x1684CB8 Offset: 0x1684CB8 VA: 0x1684CB8
	public static AKRESULT PrepareGameSyncs(AkPreparationType in_PreparationType, AkGroupType in_eGameSyncType, string in_pszGroupName, string[] in_ppszGameSyncName, uint in_uNumGameSyncs) { }

	// RVA: 0x168516C Offset: 0x168516C VA: 0x168516C
	public static AKRESULT PrepareGameSyncs(AkPreparationType in_PreparationType, AkGroupType in_eGameSyncType, uint in_GroupID, uint[] in_paGameSyncID, uint in_uNumGameSyncs) { }

	// RVA: 0x1685320 Offset: 0x1685320 VA: 0x1685320
	public static AKRESULT PrepareGameSyncs(AkPreparationType in_PreparationType, AkGroupType in_eGameSyncType, string in_pszGroupName, string[] in_ppszGameSyncName, uint in_uNumGameSyncs, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1685834 Offset: 0x1685834 VA: 0x1685834
	public static AKRESULT PrepareGameSyncs(AkPreparationType in_PreparationType, AkGroupType in_eGameSyncType, uint in_GroupID, uint[] in_paGameSyncID, uint in_uNumGameSyncs, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }

	// RVA: 0x1685A58 Offset: 0x1685A58 VA: 0x1685A58
	public static AKRESULT AddListener(GameObject in_emitterGameObj, GameObject in_listenerGameObj) { }

	// RVA: 0x1685C84 Offset: 0x1685C84 VA: 0x1685C84
	public static AKRESULT RemoveListener(GameObject in_emitterGameObj, GameObject in_listenerGameObj) { }

	// RVA: 0x1685EB0 Offset: 0x1685EB0 VA: 0x1685EB0
	public static AKRESULT AddDefaultListener(GameObject in_listenerGameObj) { }

	// RVA: 0x16860A8 Offset: 0x16860A8 VA: 0x16860A8
	public static AKRESULT RemoveDefaultListener(GameObject in_listenerGameObj) { }

	// RVA: 0x1686268 Offset: 0x1686268 VA: 0x1686268
	public static AKRESULT ResetListenersToDefault(GameObject in_emitterGameObj) { }

	// RVA: 0x1686428 Offset: 0x1686428 VA: 0x1686428
	public static AKRESULT SetListenerSpatialization(GameObject in_uListenerID, bool in_bSpatialized, AkChannelConfig in_channelConfig, float[] in_pVolumeOffsets) { }

	// RVA: 0x168663C Offset: 0x168663C VA: 0x168663C
	public static AKRESULT SetListenerSpatialization(GameObject in_uListenerID, bool in_bSpatialized, AkChannelConfig in_channelConfig) { }

	// RVA: 0x168683C Offset: 0x168683C VA: 0x168683C
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve, bool in_bBypassInternalValueInterpolation) { }

	// RVA: 0x1686A44 Offset: 0x1686A44 VA: 0x1686A44
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x1686C3C Offset: 0x1686C3C VA: 0x1686C3C
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value, GameObject in_gameObjectID, int in_uValueChangeDuration) { }

	// RVA: 0x1686E2C Offset: 0x1686E2C VA: 0x1686E2C
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value, GameObject in_gameObjectID) { }

	// RVA: 0x168700C Offset: 0x168700C VA: 0x168700C
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value) { }

	// RVA: 0x168717C Offset: 0x168717C VA: 0x168717C
	public static AKRESULT SetRTPCValue(string in_pszRtpcName, float in_value, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve, bool in_bBypassInternalValueInterpolation) { }

	// RVA: 0x16873A8 Offset: 0x16873A8 VA: 0x16873A8
	public static AKRESULT SetRTPCValue(string in_pszRtpcName, float in_value, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x16875C8 Offset: 0x16875C8 VA: 0x16875C8
	public static AKRESULT SetRTPCValue(string in_pszRtpcName, float in_value, GameObject in_gameObjectID, int in_uValueChangeDuration) { }

	// RVA: 0x16877D8 Offset: 0x16877D8 VA: 0x16877D8
	public static AKRESULT SetRTPCValue(string in_pszRtpcName, float in_value, GameObject in_gameObjectID) { }

	// RVA: 0x16879D8 Offset: 0x16879D8 VA: 0x16879D8
	public static AKRESULT SetRTPCValue(string in_pszRtpcName, float in_value) { }

	// RVA: 0x1687B68 Offset: 0x1687B68 VA: 0x1687B68
	public static AKRESULT SetRTPCValueByPlayingID(uint in_rtpcID, float in_value, uint in_playingID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve, bool in_bBypassInternalValueInterpolation) { }

	// RVA: 0x1687D28 Offset: 0x1687D28 VA: 0x1687D28
	public static AKRESULT SetRTPCValueByPlayingID(uint in_rtpcID, float in_value, uint in_playingID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x1687ED8 Offset: 0x1687ED8 VA: 0x1687ED8
	public static AKRESULT SetRTPCValueByPlayingID(uint in_rtpcID, float in_value, uint in_playingID, int in_uValueChangeDuration) { }

	// RVA: 0x1688078 Offset: 0x1688078 VA: 0x1688078
	public static AKRESULT SetRTPCValueByPlayingID(uint in_rtpcID, float in_value, uint in_playingID) { }

	// RVA: 0x1688200 Offset: 0x1688200 VA: 0x1688200
	public static AKRESULT SetRTPCValueByPlayingID(string in_pszRtpcName, float in_value, uint in_playingID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve, bool in_bBypassInternalValueInterpolation) { }

	// RVA: 0x16883E4 Offset: 0x16883E4 VA: 0x16883E4
	public static AKRESULT SetRTPCValueByPlayingID(string in_pszRtpcName, float in_value, uint in_playingID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x16885BC Offset: 0x16885BC VA: 0x16885BC
	public static AKRESULT SetRTPCValueByPlayingID(string in_pszRtpcName, float in_value, uint in_playingID, int in_uValueChangeDuration) { }

	// RVA: 0x1688784 Offset: 0x1688784 VA: 0x1688784
	public static AKRESULT SetRTPCValueByPlayingID(string in_pszRtpcName, float in_value, uint in_playingID) { }

	// RVA: 0x1688934 Offset: 0x1688934 VA: 0x1688934
	public static AKRESULT ResetRTPCValue(uint in_rtpcID, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve, bool in_bBypassInternalValueInterpolation) { }

	// RVA: 0x1688B30 Offset: 0x1688B30 VA: 0x1688B30
	public static AKRESULT ResetRTPCValue(uint in_rtpcID, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x1688D20 Offset: 0x1688D20 VA: 0x1688D20
	public static AKRESULT ResetRTPCValue(uint in_rtpcID, GameObject in_gameObjectID, int in_uValueChangeDuration) { }

	// RVA: 0x1688F00 Offset: 0x1688F00 VA: 0x1688F00
	public static AKRESULT ResetRTPCValue(uint in_rtpcID, GameObject in_gameObjectID) { }

	// RVA: 0x16890D0 Offset: 0x16890D0 VA: 0x16890D0
	public static AKRESULT ResetRTPCValue(uint in_rtpcID) { }

	// RVA: 0x1689230 Offset: 0x1689230 VA: 0x1689230
	public static AKRESULT ResetRTPCValue(string in_pszRtpcName, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve, bool in_bBypassInternalValueInterpolation) { }

	// RVA: 0x168944C Offset: 0x168944C VA: 0x168944C
	public static AKRESULT ResetRTPCValue(string in_pszRtpcName, GameObject in_gameObjectID, int in_uValueChangeDuration, AkCurveInterpolation in_eFadeCurve) { }

	// RVA: 0x168965C Offset: 0x168965C VA: 0x168965C
	public static AKRESULT ResetRTPCValue(string in_pszRtpcName, GameObject in_gameObjectID, int in_uValueChangeDuration) { }

	// RVA: 0x1689864 Offset: 0x1689864 VA: 0x1689864
	public static AKRESULT ResetRTPCValue(string in_pszRtpcName, GameObject in_gameObjectID) { }

	// RVA: 0x1689A5C Offset: 0x1689A5C VA: 0x1689A5C
	public static AKRESULT ResetRTPCValue(string in_pszRtpcName) { }

	// RVA: 0x1689BE4 Offset: 0x1689BE4 VA: 0x1689BE4
	public static AKRESULT SetSwitch(uint in_switchGroup, uint in_switchState, GameObject in_gameObjectID) { }

	// RVA: 0x1689E00 Offset: 0x1689E00 VA: 0x1689E00
	public static AKRESULT SetSwitch(string in_pszSwitchGroup, string in_pszSwitchState, GameObject in_gameObjectID) { }

	// RVA: 0x168A04C Offset: 0x168A04C VA: 0x168A04C
	public static AKRESULT PostTrigger(uint in_triggerID, GameObject in_gameObjectID) { }

	// RVA: 0x168A21C Offset: 0x168A21C VA: 0x168A21C
	public static AKRESULT PostTrigger(string in_pszTrigger, GameObject in_gameObjectID) { }

	// RVA: 0x168A410 Offset: 0x168A410 VA: 0x168A410
	public static AKRESULT SetState(uint in_stateGroup, uint in_state) { }

	// RVA: 0x168A5B4 Offset: 0x168A5B4 VA: 0x168A5B4
	public static AKRESULT SetState(string in_pszStateGroup, string in_pszState) { }

	// RVA: 0x168A790 Offset: 0x168A790 VA: 0x168A790
	public static AKRESULT SetGameObjectAuxSendValues(GameObject in_gameObjectID, AkAuxSendArray in_aAuxSendValues, uint in_uNumSendValues) { }

	// RVA: 0x168A994 Offset: 0x168A994 VA: 0x168A994
	public static AKRESULT SetGameObjectOutputBusVolume(GameObject in_emitterObjID, GameObject in_listenerObjID, float in_fControlValue) { }

	// RVA: 0x168ABB4 Offset: 0x168ABB4 VA: 0x168ABB4
	public static AKRESULT SetActorMixerEffect(uint in_audioNodeID, uint in_uFXIndex, uint in_shareSetID) { }

	// RVA: 0x168AD34 Offset: 0x168AD34 VA: 0x168AD34
	public static AKRESULT SetBusEffect(uint in_audioNodeID, uint in_uFXIndex, uint in_shareSetID) { }

	// RVA: 0x168AEB4 Offset: 0x168AEB4 VA: 0x168AEB4
	public static AKRESULT SetBusEffect(string in_pszBusName, uint in_uFXIndex, uint in_shareSetID) { }

	// RVA: 0x168B058 Offset: 0x168B058 VA: 0x168B058
	public static AKRESULT SetMixer(uint in_audioNodeID, uint in_shareSetID) { }

	// RVA: 0x168B1FC Offset: 0x168B1FC VA: 0x168B1FC
	public static AKRESULT SetMixer(string in_pszBusName, uint in_shareSetID) { }

	// RVA: 0x168B3C8 Offset: 0x168B3C8 VA: 0x168B3C8
	public static AKRESULT SetBusConfig(uint in_audioNodeID, AkChannelConfig in_channelConfig) { }

	// RVA: 0x168B544 Offset: 0x168B544 VA: 0x168B544
	public static AKRESULT SetBusConfig(string in_pszBusName, AkChannelConfig in_channelConfig) { }

	// RVA: 0x168B6E8 Offset: 0x168B6E8 VA: 0x168B6E8
	public static AKRESULT SetObjectObstructionAndOcclusion(GameObject in_EmitterID, GameObject in_ListenerID, float in_fObstructionLevel, float in_fOcclusionLevel) { }

	// RVA: 0x168B920 Offset: 0x168B920 VA: 0x168B920
	public static AKRESULT SetMultipleObstructionAndOcclusion(GameObject in_EmitterID, GameObject in_uListenerID, AkObstructionOcclusionValuesArray in_fObstructionOcclusionValues, uint in_uNumOcclusionObstruction) { }

	// RVA: 0x168BB74 Offset: 0x168BB74 VA: 0x168BB74
	public static AKRESULT StartOutputCapture(string in_CaptureFileName) { }

	// RVA: 0x168BD34 Offset: 0x168BD34 VA: 0x168BD34
	public static AKRESULT StopOutputCapture() { }

	// RVA: 0x168BEB8 Offset: 0x168BEB8 VA: 0x168BEB8
	public static AKRESULT AddOutputCaptureMarker(string in_MarkerText) { }

	// RVA: 0x168C03C Offset: 0x168C03C VA: 0x168C03C
	public static AKRESULT StartProfilerCapture(string in_CaptureFileName) { }

	// RVA: 0x168C1C0 Offset: 0x168C1C0 VA: 0x168C1C0
	public static AKRESULT StopProfilerCapture() { }

	// RVA: 0x168C30C Offset: 0x168C30C VA: 0x168C30C
	public static AKRESULT RemoveOutput(ulong in_idOutput) { }

	// RVA: 0x168C4AC Offset: 0x168C4AC VA: 0x168C4AC
	public static ulong GetOutputID(uint in_idShareset, uint in_idDevice) { }

	// RVA: 0x168C61C Offset: 0x168C61C VA: 0x168C61C
	public static ulong GetOutputID(string in_szShareSet, uint in_idDevice) { }

	// RVA: 0x168C7B8 Offset: 0x168C7B8 VA: 0x168C7B8
	public static AKRESULT SetBusDevice(uint in_idBus, uint in_idNewDevice) { }

	// RVA: 0x168C924 Offset: 0x168C924 VA: 0x168C924
	public static AKRESULT SetBusDevice(string in_BusName, string in_DeviceName) { }

	// RVA: 0x168CAD0 Offset: 0x168CAD0 VA: 0x168CAD0
	public static AKRESULT SetOutputVolume(ulong in_idOutput, float in_fVolume) { }

	// RVA: 0x168CC84 Offset: 0x168CC84 VA: 0x168CC84
	public static AKRESULT Suspend(bool in_bRenderAnyway) { }

	// RVA: 0x168CE1C Offset: 0x168CE1C VA: 0x168CE1C
	public static AKRESULT Suspend() { }

	// RVA: 0x168CF9C Offset: 0x168CF9C VA: 0x168CF9C
	public static AKRESULT WakeupFromSuspend() { }

	// RVA: 0x168D120 Offset: 0x168D120 VA: 0x168D120
	public static uint GetBufferTick() { }

	// RVA: 0x168D298 Offset: 0x168D298 VA: 0x168D298
	public static byte get_AK_INVALID_MIDI_CHANNEL() { }

	// RVA: 0x168D3EC Offset: 0x168D3EC VA: 0x168D3EC
	public static byte get_AK_INVALID_MIDI_NOTE() { }

	// RVA: 0x168D540 Offset: 0x168D540 VA: 0x168D540
	public static AKRESULT GetPlayingSegmentInfo(uint in_PlayingID, AkSegmentInfo out_segmentInfo, bool in_bExtrapolate) { }

	// RVA: 0x168D710 Offset: 0x168D710 VA: 0x168D710
	public static AKRESULT GetPlayingSegmentInfo(uint in_PlayingID, AkSegmentInfo out_segmentInfo) { }

	// RVA: 0x168D8D0 Offset: 0x168D8D0 VA: 0x168D8D0
	public static AKRESULT PostCode(AkMonitorErrorCode in_eError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID, GameObject in_gameObjID, uint in_audioNodeID, bool in_bIsBus) { }

	// RVA: 0x168DB04 Offset: 0x168DB04 VA: 0x168DB04
	public static AKRESULT PostCode(AkMonitorErrorCode in_eError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID, GameObject in_gameObjID, uint in_audioNodeID) { }

	// RVA: 0x168DD2C Offset: 0x168DD2C VA: 0x168DD2C
	public static AKRESULT PostCode(AkMonitorErrorCode in_eError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID, GameObject in_gameObjID) { }

	// RVA: 0x168DF4C Offset: 0x168DF4C VA: 0x168DF4C
	public static AKRESULT PostCode(AkMonitorErrorCode in_eError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID) { }

	// RVA: 0x168E104 Offset: 0x168E104 VA: 0x168E104
	public static AKRESULT PostCode(AkMonitorErrorCode in_eError, AkMonitorErrorLevel in_eErrorLevel) { }

	// RVA: 0x168E2AC Offset: 0x168E2AC VA: 0x168E2AC
	public static AKRESULT PostString(string in_pszError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID, GameObject in_gameObjID, uint in_audioNodeID, bool in_bIsBus) { }

	// RVA: 0x168E50C Offset: 0x168E50C VA: 0x168E50C
	public static AKRESULT PostString(string in_pszError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID, GameObject in_gameObjID, uint in_audioNodeID) { }

	// RVA: 0x168E75C Offset: 0x168E75C VA: 0x168E75C
	public static AKRESULT PostString(string in_pszError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID, GameObject in_gameObjID) { }

	// RVA: 0x168E99C Offset: 0x168E99C VA: 0x168E99C
	public static AKRESULT PostString(string in_pszError, AkMonitorErrorLevel in_eErrorLevel, uint in_playingID) { }

	// RVA: 0x168EB7C Offset: 0x168EB7C VA: 0x168EB7C
	public static AKRESULT PostString(string in_pszError, AkMonitorErrorLevel in_eErrorLevel) { }

	// RVA: 0x168ED4C Offset: 0x168ED4C VA: 0x168ED4C
	public static int GetTimeStamp() { }

	// RVA: 0x168EEC4 Offset: 0x168EEC4 VA: 0x168EEC4
	public static uint GetNumNonZeroBits(uint in_uWord) { }

	// RVA: 0x168F060 Offset: 0x168F060 VA: 0x168F060
	public static void AkGetDefaultHighPriorityThreadProperties(AkThreadProperties out_threadProperties) { }

	// RVA: 0x168F1E0 Offset: 0x168F1E0 VA: 0x168F1E0
	public static uint ResolveDialogueEvent(uint in_eventID, uint[] in_aArgumentValues, uint in_uNumArguments, uint in_idSequence) { }

	// RVA: 0x168F384 Offset: 0x168F384 VA: 0x168F384
	public static uint ResolveDialogueEvent(uint in_eventID, uint[] in_aArgumentValues, uint in_uNumArguments) { }

	// RVA: 0x168F514 Offset: 0x168F514 VA: 0x168F514
	public static AKRESULT GetDialogueEventCustomPropertyValue(uint in_eventID, uint in_uPropID, out int out_iValue) { }

	// RVA: 0x168F6AC Offset: 0x168F6AC VA: 0x168F6AC
	public static AKRESULT GetDialogueEventCustomPropertyValue(uint in_eventID, uint in_uPropID, out float out_fValue) { }

	// RVA: 0x168F844 Offset: 0x168F844 VA: 0x168F844
	public static AKRESULT GetPosition(GameObject in_GameObjectID, AkTransform out_rPosition) { }

	// RVA: 0x168FA3C Offset: 0x168FA3C VA: 0x168FA3C
	public static AKRESULT GetListenerPosition(GameObject in_uIndex, AkTransform out_rPosition) { }

	// RVA: 0x168FC1C Offset: 0x168FC1C VA: 0x168FC1C
	public static AKRESULT GetRTPCValue(uint in_rtpcID, GameObject in_gameObjectID, uint in_playingID, out float out_rValue, ref int io_rValueType) { }

	// RVA: 0x168FE14 Offset: 0x168FE14 VA: 0x168FE14
	public static AKRESULT GetRTPCValue(string in_pszRtpcName, GameObject in_gameObjectID, uint in_playingID, out float out_rValue, ref int io_rValueType) { }

	// RVA: 0x1690030 Offset: 0x1690030 VA: 0x1690030
	public static AKRESULT GetSwitch(uint in_switchGroup, GameObject in_gameObjectID, out uint out_rSwitchState) { }

	// RVA: 0x1690248 Offset: 0x1690248 VA: 0x1690248
	public static AKRESULT GetSwitch(string in_pstrSwitchGroupName, GameObject in_GameObj, out uint out_rSwitchState) { }

	// RVA: 0x1690474 Offset: 0x1690474 VA: 0x1690474
	public static AKRESULT GetState(uint in_stateGroup, out uint out_rState) { }

	// RVA: 0x169061C Offset: 0x169061C VA: 0x169061C
	public static AKRESULT GetState(string in_pstrStateGroupName, out uint out_rState) { }

	// RVA: 0x16907E8 Offset: 0x16907E8 VA: 0x16907E8
	public static AKRESULT GetGameObjectAuxSendValues(GameObject in_gameObjectID, AkAuxSendArray out_paAuxSendValues, ref uint io_ruNumSendValues) { }

	// RVA: 0x16909EC Offset: 0x16909EC VA: 0x16909EC
	public static AKRESULT GetGameObjectDryLevelValue(GameObject in_EmitterID, GameObject in_ListenerID, out float out_rfControlValue) { }

	// RVA: 0x1690BFC Offset: 0x1690BFC VA: 0x1690BFC
	public static AKRESULT GetObjectObstructionAndOcclusion(GameObject in_EmitterID, GameObject in_ListenerID, out float out_rfObstructionLevel, out float out_rfOcclusionLevel) { }

	// RVA: 0x1690E20 Offset: 0x1690E20 VA: 0x1690E20
	public static AKRESULT QueryAudioObjectIDs(uint in_eventID, ref uint io_ruNumItems, AkObjectInfoArray out_aObjectInfos) { }

	// RVA: 0x1690FD4 Offset: 0x1690FD4 VA: 0x1690FD4
	public static AKRESULT QueryAudioObjectIDs(string in_pszEventName, ref uint io_ruNumItems, AkObjectInfoArray out_aObjectInfos) { }

	// RVA: 0x16911A8 Offset: 0x16911A8 VA: 0x16911A8
	public static AKRESULT GetPositioningInfo(uint in_ObjectID, AkPositioningInfo out_rPositioningInfo) { }

	// RVA: 0x1691360 Offset: 0x1691360 VA: 0x1691360
	public static bool GetIsGameObjectActive(GameObject in_GameObjId) { }

	// RVA: 0x1691528 Offset: 0x1691528 VA: 0x1691528
	public static float GetMaxRadius(GameObject in_GameObjId) { }

	// RVA: 0x1691714 Offset: 0x1691714 VA: 0x1691714
	public static uint GetEventIDFromPlayingID(uint in_playingID) { }

	// RVA: 0x1691878 Offset: 0x1691878 VA: 0x1691878
	public static ulong GetGameObjectFromPlayingID(uint in_playingID) { }

	// RVA: 0x16919DC Offset: 0x16919DC VA: 0x16919DC
	public static AKRESULT GetPlayingIDsFromGameObject(GameObject in_GameObjId, ref uint io_ruNumIDs, uint[] out_aPlayingIDs) { }

	// RVA: 0x1691C60 Offset: 0x1691C60 VA: 0x1691C60
	public static AKRESULT GetCustomPropertyValue(uint in_ObjectID, uint in_uPropID, out int out_iValue) { }

	// RVA: 0x1691DE8 Offset: 0x1691DE8 VA: 0x1691DE8
	public static AKRESULT GetCustomPropertyValue(uint in_ObjectID, uint in_uPropID, out float out_fValue) { }

	// RVA: 0x1691F70 Offset: 0x1691F70 VA: 0x1691F70
	public static void AK_SPEAKER_SETUP_FIX_LEFT_TO_CENTER(ref uint io_uChannelMask) { }

	// RVA: 0x16920DC Offset: 0x16920DC VA: 0x16920DC
	public static void AK_SPEAKER_SETUP_FIX_REAR_TO_SIDE(ref uint io_uChannelMask) { }

	// RVA: 0x169224C Offset: 0x169224C VA: 0x169224C
	public static void AK_SPEAKER_SETUP_CONVERT_TO_SUPPORTED(ref uint io_uChannelMask) { }

	// RVA: 0x16923C0 Offset: 0x16923C0 VA: 0x16923C0
	public static byte ChannelMaskToNumChannels(uint in_uChannelMask) { }

	// RVA: 0x1692520 Offset: 0x1692520 VA: 0x1692520
	public static uint ChannelMaskFromNumChannels(uint in_uNumChannels) { }

	// RVA: 0x1692684 Offset: 0x1692684 VA: 0x1692684
	public static byte ChannelBitToIndex(uint in_uChannelBit, uint in_uChannelMask) { }

	// RVA: 0x1692830 Offset: 0x1692830 VA: 0x1692830
	public static bool HasSurroundChannels(uint in_uChannelMask) { }

	// RVA: 0x1692994 Offset: 0x1692994 VA: 0x1692994
	public static bool HasStrictlyOnePairOfSurroundChannels(uint in_uChannelMask) { }

	// RVA: 0x1692B0C Offset: 0x1692B0C VA: 0x1692B0C
	public static bool HasSideAndRearChannels(uint in_uChannelMask) { }

	// RVA: 0x1692C78 Offset: 0x1692C78 VA: 0x1692C78
	public static bool HasHeightChannels(uint in_uChannelMask) { }

	// RVA: 0x1692E18 Offset: 0x1692E18 VA: 0x1692E18
	public static uint BackToSideChannels(uint in_uChannelMask) { }

	// RVA: 0x1692FB0 Offset: 0x1692FB0 VA: 0x1692FB0
	public static uint StdChannelIndexToDisplayIndex(AkChannelOrdering in_eOrdering, uint in_uChannelMask, uint in_uChannelIdx) { }

	// RVA: 0x1693138 Offset: 0x1693138 VA: 0x1693138
	public static float get_kDefaultMaxPathLength() { }

	// RVA: 0x169328C Offset: 0x169328C VA: 0x169328C
	public static float get_kMaxDiffraction() { }

	// RVA: 0x16933DC Offset: 0x16933DC VA: 0x16933DC
	public static void set_g_SpatialAudioPoolId(int value) { }

	// RVA: 0x1693540 Offset: 0x1693540 VA: 0x1693540
	public static int get_g_SpatialAudioPoolId() { }

	// RVA: 0x1693690 Offset: 0x1693690 VA: 0x1693690
	public static int GetPoolID() { }

	// RVA: 0x1693800 Offset: 0x1693800 VA: 0x1693800
	public static AKRESULT RegisterEmitter(GameObject in_gameObjectID, AkEmitterSettings in_settings) { }

	// RVA: 0x1693A14 Offset: 0x1693A14 VA: 0x1693A14
	public static AKRESULT UnregisterEmitter(GameObject in_gameObjectID) { }

	// RVA: 0x1693C10 Offset: 0x1693C10 VA: 0x1693C10
	public static AKRESULT SetEmitterAuxSendValues(GameObject in_gameObjectID, AkAuxSendArray in_pAuxSends, uint in_uNumAux) { }

	// RVA: 0x1693E10 Offset: 0x1693E10 VA: 0x1693E10
	public static AKRESULT SetImageSource(uint in_srcID, AkImageSourceSettings in_info, uint in_AuxBusID, ulong in_roomID, GameObject in_gameObjectID) { }

	// RVA: 0x1694030 Offset: 0x1694030 VA: 0x1694030
	public static AKRESULT SetImageSource(uint in_srcID, AkImageSourceSettings in_info, uint in_AuxBusID, ulong in_roomID) { }

	// RVA: 0x16941E8 Offset: 0x16941E8 VA: 0x16941E8
	public static AKRESULT RemoveImageSource(uint in_srcID, uint in_AuxBusID, GameObject in_gameObjectID) { }

	// RVA: 0x16943CC Offset: 0x16943CC VA: 0x16943CC
	public static AKRESULT RemoveImageSource(uint in_srcID, uint in_AuxBusID) { }

	// RVA: 0x1694544 Offset: 0x1694544 VA: 0x1694544
	public static AKRESULT RemoveGeometry(ulong in_SetID) { }

	// RVA: 0x16946E8 Offset: 0x16946E8 VA: 0x16946E8
	public static AKRESULT QueryReflectionPaths(GameObject in_gameObjectID, AkVector out_listenerPos, AkVector out_emitterPos, AkReflectionPathInfoArray out_aPaths, out uint io_uArraySize) { }

	// RVA: 0x169492C Offset: 0x169492C VA: 0x169492C
	public static AKRESULT RemoveRoom(ulong in_RoomID) { }

	// RVA: 0x1694AC8 Offset: 0x1694AC8 VA: 0x1694AC8
	public static AKRESULT RemovePortal(ulong in_PortalID) { }

	// RVA: 0x1694C64 Offset: 0x1694C64 VA: 0x1694C64
	public static AKRESULT SetGameObjectInRoom(GameObject in_gameObjectID, ulong in_CurrentRoomID) { }

	// RVA: 0x1694E44 Offset: 0x1694E44 VA: 0x1694E44
	public static AKRESULT SetEmitterObstructionAndOcclusion(GameObject in_gameObjectID, float in_fObstruction, float in_fOcclusion) { }

	// RVA: 0x1695034 Offset: 0x1695034 VA: 0x1695034
	public static AKRESULT SetPortalObstructionAndOcclusion(ulong in_PortalID, float in_fObstruction, float in_fOcclusion) { }

	// RVA: 0x16951D8 Offset: 0x16951D8 VA: 0x16951D8
	public static AKRESULT GetFastPathSettings(AkInitSettings in_settings, AkPlatformInitSettings in_pfSettings) { }

	// RVA: 0x1695364 Offset: 0x1695364 VA: 0x1695364
	public static void SetErrorLogger(AkLogger.ErrorLoggerInteropDelegate logger) { }

	// RVA: 0x16954D4 Offset: 0x16954D4 VA: 0x16954D4
	public static void SetErrorLogger() { }

	// RVA: 0x1695628 Offset: 0x1695628 VA: 0x1695628
	public static void SetAudioInputCallbacks(AkAudioInputManager.AudioSamplesInteropDelegate getAudioSamples, AkAudioInputManager.AudioFormatInteropDelegate getAudioFormat) { }

	// RVA: 0x16957B4 Offset: 0x16957B4 VA: 0x16957B4
	public static AKRESULT Init(AkInitializationSettings settings) { }

	// RVA: 0x1695944 Offset: 0x1695944 VA: 0x1695944
	public static AKRESULT InitSpatialAudio(AkSpatialAudioInitSettings settings) { }

	// RVA: 0x1695AEC Offset: 0x1695AEC VA: 0x1695AEC
	public static AKRESULT InitCommunication(AkCommunicationSettings settings) { }

	// RVA: 0x1695C98 Offset: 0x1695C98 VA: 0x1695C98
	public static void Term() { }

	// RVA: 0x1695DFC Offset: 0x1695DFC VA: 0x1695DFC
	public static AKRESULT RegisterGameObjInternal(GameObject in_GameObj) { }

	// RVA: 0x1695FA8 Offset: 0x1695FA8 VA: 0x1695FA8
	public static AKRESULT UnregisterGameObjInternal(GameObject in_GameObj) { }

	// RVA: 0x1696154 Offset: 0x1696154 VA: 0x1696154
	public static AKRESULT RegisterGameObjInternal_WithName(GameObject in_GameObj, string in_pszObjName) { }

	// RVA: 0x169633C Offset: 0x169633C VA: 0x169633C
	public static AKRESULT SetBasePath(string in_pszBasePath) { }

	// RVA: 0x16964F0 Offset: 0x16964F0 VA: 0x16964F0
	public static AKRESULT SetCurrentLanguage(string in_pszAudioSrcPath) { }

	// RVA: 0x16966AC Offset: 0x16966AC VA: 0x16966AC
	public static AKRESULT LoadFilePackage(string in_pszFilePackageName, out uint out_uPackageID, int in_memPoolID) { }

	// RVA: 0x1696888 Offset: 0x1696888 VA: 0x1696888
	public static AKRESULT AddBasePath(string in_pszBasePath) { }

	// RVA: 0x1696A38 Offset: 0x1696A38 VA: 0x1696A38
	public static AKRESULT SetGameName(string in_GameName) { }

	// RVA: 0x1696BE8 Offset: 0x1696BE8 VA: 0x1696BE8
	public static AKRESULT SetDecodedBankPath(string in_DecodedPath) { }

	// RVA: 0x1696DA4 Offset: 0x1696DA4 VA: 0x1696DA4
	public static AKRESULT LoadAndDecodeBank(string in_pszString, bool in_bSaveDecodedBank, out uint out_bankID) { }

	// RVA: 0x1696F84 Offset: 0x1696F84 VA: 0x1696F84
	public static AKRESULT LoadAndDecodeBankFromMemory(IntPtr in_BankData, uint in_BankDataSize, bool in_bSaveDecodedBank, string in_DecodedBankName, bool in_bIsLanguageSpecific, out uint out_bankID) { }

	// RVA: 0x1697168 Offset: 0x1697168 VA: 0x1697168
	public static string GetCurrentLanguage() { }

	// RVA: 0x16973A0 Offset: 0x16973A0 VA: 0x16973A0
	public static AKRESULT UnloadFilePackage(uint in_uPackageID) { }

	// RVA: 0x1697538 Offset: 0x1697538 VA: 0x1697538
	public static AKRESULT UnloadAllFilePackages() { }

	// RVA: 0x1697688 Offset: 0x1697688 VA: 0x1697688
	public static AKRESULT SetObjectPosition(GameObject in_GameObjectID, float PosX, float PosY, float PosZ, float FrontX, float FrontY, float FrontZ, float TopX, float TopY, float TopZ) { }

	// RVA: 0x1697910 Offset: 0x1697910 VA: 0x1697910
	public static AKRESULT GetSourceMultiplePlayPositions(uint in_PlayingID, uint[] out_audioNodeID, uint[] out_mediaID, int[] out_msTime, ref uint io_pcPositions, bool in_bExtrapolate) { }

	// RVA: 0x1697C1C Offset: 0x1697C1C VA: 0x1697C1C
	public static AKRESULT SetListeners(GameObject in_emitterGameObj, ulong[] in_pListenerGameObjs, uint in_uNumListeners) { }

	// RVA: 0x1697E34 Offset: 0x1697E34 VA: 0x1697E34
	public static AKRESULT SetDefaultListeners(ulong[] in_pListenerObjs, uint in_uNumListeners) { }

	// RVA: 0x1697FAC Offset: 0x1697FAC VA: 0x1697FAC
	public static AKRESULT AddOutput(AkOutputSettings in_Settings, out ulong out_pDeviceID, ulong[] in_pListenerIDs, uint in_uNumListeners) { }

	// RVA: 0x1698188 Offset: 0x1698188 VA: 0x1698188
	public static void GetDefaultStreamSettings(AkStreamMgrSettings out_settings) { }

	// RVA: 0x16982F8 Offset: 0x16982F8 VA: 0x16982F8
	public static void GetDefaultDeviceSettings(AkDeviceSettings out_settings) { }

	// RVA: 0x1698468 Offset: 0x1698468 VA: 0x1698468
	public static void GetDefaultMusicSettings(AkMusicSettings out_settings) { }

	// RVA: 0x16985D8 Offset: 0x16985D8 VA: 0x16985D8
	public static void GetDefaultInitSettings(AkInitSettings out_settings) { }

	// RVA: 0x1698748 Offset: 0x1698748 VA: 0x1698748
	public static void GetDefaultPlatformInitSettings(AkPlatformInitSettings out_settings) { }

	// RVA: 0x16988C0 Offset: 0x16988C0 VA: 0x16988C0
	public static uint GetMajorMinorVersion() { }

	// RVA: 0x1698A0C Offset: 0x1698A0C VA: 0x1698A0C
	public static uint GetSubminorBuildVersion() { }

	// RVA: 0x1698B60 Offset: 0x1698B60 VA: 0x1698B60
	public static AKRESULT QueryIndirectPaths(GameObject in_gameObjectID, AkPathParams arg1, AkReflectionPathInfoArray paths, uint numPaths) { }

	// RVA: 0x1698DC8 Offset: 0x1698DC8 VA: 0x1698DC8
	public static AKRESULT QuerySoundPropagationPaths(GameObject in_gameObjectID, AkPathParams arg1, AkPropagationPathInfoArray paths, uint numPaths) { }

	// RVA: 0x1698FFC Offset: 0x1698FFC VA: 0x1698FFC
	public static AKRESULT QueryDiffractionPaths(GameObject in_gameObjectID, AkPathParams arg1, AkDiffractionPathInfoArray paths, uint numPaths) { }

	// RVA: 0x1699228 Offset: 0x1699228 VA: 0x1699228
	public static AKRESULT SetRoomPortal(ulong in_PortalID, AkTransform Transform, AkVector Extent, bool bEnabled, ulong FrontRoom, ulong BackRoom) { }

	// RVA: 0x1699460 Offset: 0x1699460 VA: 0x1699460
	public static AKRESULT SetRoom(ulong in_RoomID, AkRoomParams in_roomParams, string in_pName) { }

	// RVA: 0x1699650 Offset: 0x1699650 VA: 0x1699650
	public static AKRESULT RegisterSpatialAudioListener(GameObject in_gameObjectID) { }

	// RVA: 0x1699814 Offset: 0x1699814 VA: 0x1699814
	public static AKRESULT UnregisterSpatialAudioListener(GameObject in_gameObjectID) { }

	// RVA: 0x16999E0 Offset: 0x16999E0 VA: 0x16999E0
	public static AKRESULT SetGeometry(ulong in_GeomSetID, AkTriangleArray Triangles, uint NumTriangles, AkVertexArray Vertices, uint NumVertices, AkAcousticSurfaceArray Surfaces, uint NumSurfaces, bool EnableDiffraction, bool EnableDiffractionOnBoundaryEdges) { }

	// RVA: 0x1699C7C Offset: 0x1699C7C VA: 0x1699C7C
	public static string StringFromIntPtrString(IntPtr ptr) { }

	// RVA: 0x1699D00 Offset: 0x1699D00 VA: 0x1699D00
	public static string StringFromIntPtrWString(IntPtr ptr) { }

	// RVA: 0x1697320 Offset: 0x1697320 VA: 0x1697320
	public static string StringFromIntPtrOSString(IntPtr ptr) { }

	// RVA: 0x1699D84 Offset: 0x1699D84 VA: 0x1699D84
	private static ulong InternalGameObjectHash(GameObject gameObject) { }

	// RVA: 0x1699E40 Offset: 0x1699E40 VA: 0x1699E40
	public static void set_GameObjectHash(AkSoundEngine.GameObjectHashFunction value) { }

	// RVA: 0x1675CEC Offset: 0x1675CEC VA: 0x1675CEC
	public static ulong GetAkGameObjectID(GameObject gameObject) { }

	// RVA: 0x169A730 Offset: 0x169A730 VA: 0x169A730
	public static AKRESULT RegisterGameObj(GameObject gameObject) { }

	// RVA: 0x169A8E8 Offset: 0x169A8E8 VA: 0x169A8E8
	public static AKRESULT RegisterGameObj(GameObject gameObject, string name) { }

	// RVA: 0x169A9CC Offset: 0x169A9CC VA: 0x169A9CC
	public static AKRESULT UnregisterGameObj(GameObject gameObject) { }

	// RVA: 0x169AB84 Offset: 0x169AB84 VA: 0x169AB84
	public static AKRESULT SetObjectPosition(GameObject gameObject, Transform transform) { }

	// RVA: 0x169ADC0 Offset: 0x169ADC0 VA: 0x169ADC0
	public static AKRESULT SetObjectPosition(GameObject gameObject, Vector3 position, Vector3 forward, Vector3 up) { }

	[ObsoleteAttribute] // RVA: 0x57B06C Offset: 0x57B06C VA: 0x57B06C
	// RVA: 0x169AEF8 Offset: 0x169AEF8 VA: 0x169AEF8
	public static uint PostEvent(uint eventId, GameObject gameObject, uint flags, AkCallbackManager.EventCallback callback, object cookie, uint numSources, AkExternalSourceInfo externalSources, uint playingId) { }

	[ObsoleteAttribute] // RVA: 0x57B0A0 Offset: 0x57B0A0 VA: 0x57B0A0
	// RVA: 0x169B05C Offset: 0x169B05C VA: 0x169B05C
	public static uint PostEvent(uint eventId, GameObject gameObject, uint flags, AkCallbackManager.EventCallback callback, object cookie, uint numSources, AkExternalSourceInfo externalSources) { }

	[ObsoleteAttribute] // RVA: 0x57B0D4 Offset: 0x57B0D4 VA: 0x57B0D4
	// RVA: 0x169B20C Offset: 0x169B20C VA: 0x169B20C
	public static uint PostEvent(string eventName, GameObject gameObject, uint flags, AkCallbackManager.EventCallback callback, object cookie, uint numSources, AkExternalSourceInfo externalSources, uint playingId) { }

	[ObsoleteAttribute] // RVA: 0x57B108 Offset: 0x57B108 VA: 0x57B108
	// RVA: 0x169B370 Offset: 0x169B370 VA: 0x169B370
	public static uint PostEvent(string eventName, GameObject gameObject, uint flags, AkCallbackManager.EventCallback callback, object cookie, uint numSources, AkExternalSourceInfo externalSources) { }

	// RVA: 0x1675D98 Offset: 0x1675D98 VA: 0x1675D98
	public static void PreGameObjectAPICall(GameObject gameObject, ulong id) { }

	// RVA: 0x169B520 Offset: 0x169B520 VA: 0x169B520
	private static void PreGameObjectAPICallUserHook(GameObject gameObject, ulong id) { }

	// RVA: 0x169A80C Offset: 0x169A80C VA: 0x169A80C
	private static void PostRegisterGameObjUserHook(AKRESULT result, GameObject gameObject, ulong id) { }

	// RVA: 0x169AAA8 Offset: 0x169AAA8 VA: 0x169AAA8
	private static void PostUnregisterGameObjUserHook(AKRESULT result, GameObject gameObject, ulong id) { }

	// RVA: 0x169B6F8 Offset: 0x169B6F8 VA: 0x169B6F8
	private static void AutoRegister(GameObject gameObject, ulong id) { }

	// RVA: 0x169B628 Offset: 0x169B628 VA: 0x169B628
	private static bool IsInRegisteredList(ulong id) { }

	// RVA: 0x169B994 Offset: 0x169B994 VA: 0x169B994
	public static bool IsGameObjectRegistered(GameObject in_gameObject) { }

	// RVA: 0x169BA18 Offset: 0x169BA18 VA: 0x169BA18
	public void .ctor() { }

	// RVA: 0x169BA20 Offset: 0x169BA20 VA: 0x169BA20
	private static void .cctor() { }
}
