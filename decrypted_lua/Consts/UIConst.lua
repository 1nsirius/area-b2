

RoomCtrlEventType=
{
    OtherPlayerJoinRoom = 1,--
    PlayerLeaveRoom = 2,--
    RoomOwnerWasChanged =3,
    PlayerCampChanged = 4,
    BeginMatch = 5, -- 开始匹配
    EndMatch = 6, -- 结束匹配
    PlayerNumber = 7, -- 在线人数
    --ChangeNameSucc = 8,--改名成功
    GoldRefresh = 9,
    GoldDiamond = 10,
    OnRoomOwnerSelectedModeAndMap = 11,
    OnRoomEnterDataRet = 12,

}

WeaponCfgType = 
{
    Shield = 5 
}

ShowPanelType = 
{
    Default = 0,    --默认
    OpenBox = 1,    --军需
    Warehouse = 2,  --仓库
    Store = 3,      --商城
    Mvp = 4,        --mvp
}

GiftOpenType = 
{
    info = 0 ,
    hero = 1, 
    other = 2 ,
}


UIOpenType =
{
    FPControl = 0,--主角控制界面
    WatchBattle = 1,--观战界面
    MiniCar = 2,--小车界面
    SurveillanceCam= 3,--摄像机界面
}

UIConst = 
{
    offensiveColor = Color32(8,116,204,255),
    defensiveColor = Color32(255, 108, 0, 255),
    concentricWriteColor = Color.white,
    concentricRedColor = Color.red,
    concentricGreenColor = Color.green,
}

NetDisconnectedCtrlEventType=
{
    LobbyServerOnDisconnected = 1,--
    BattleServerOnDisconnected = 2,--
}

StoreMsgType=
{
    GetStoreItems = 1,  --获取商城道具列表
    BuyItemRes = 2 ,    --商城购买道具反馈
    SyncStoreSales = 3, --折扣列表变化通知
    Error = 7,
}

--商城类型
StoreType = 
{
    Sale = 0,           --每日折扣

    Character = 1,      --商城角色
    Suit = 2,           --套装
    Head = 3,           --头部
    Body = 4,           --身体
    WeaponPT = 5,       --武器喷涂
    Equipment = 8,      --装备喷涂
    Bundle = 7,         --礼包
    WeaponGJ = 6,       --武器挂件
    Box = 9,            --军需(宝箱)
    Item = 10,          

    Attachment = 11,
    WeaponSkin = 12, 
    Pendant = 13,
    Skin = 99,           --商城皮肤大类
    Sight = 100 ,       --望远镜
}

BagPath = 
{
	[1] = 'UI/BattleUI/currency/',
	[2] = 'UI/BattleUI/PlayerIcons/',
	[3] = 'UI/BattleUI/Skin/Suit/',
	[4] = 'UI/BattleUI/Skin/Weapon/',
	[5] = 'UI/BattleUI/Skin/Pendant/',
	[6] = 'UI/BattleUI/Box/',
	[7] = 'UI/BattleUI/Box/',
	[8] = 'UI/BattleUI/HeadFrame/',
	[9] = 'UI/BattleUI/mix/',
	[10] = 'UI/BattleUI/currency/',
	[11] = 'UI/BattleUI/PlayerIcons/',
	[12] = 'UI/BattleUI/Skin/Head/',
	[13] = 'UI/BattleUI/Skin/Body/',
}

--BagType
BagType = 
{
    Money = 1, 
    Hero = 2, 
    HeroSkin = 3, 
    WeaponSkin = 4, 
    WeaponGJ = 5, 
    Box = 6, 
    GiftBox = 7, 
    Head = 8 , 
    Func = 9 , 
    ActiveDB = 10,
    HeadLine = 11 , 
    HeadSkin = 12, 
    BodySkin = 13, 
}

-- 1,4  突击步枪   2003
-- 2    冲锋枪      2004
-- 3    霰弹枪    2005
-- 5    轻机枪   2006
-- 6,7  手枪    2007
-- 8    盾牌    2008
---- 3,4,6,7 喷子和手枪
WeaponType = 
{
    -- 主武器
    FIRST = -2,
    -- 副武器
    SECOND = -1,
    -- 突击步枪
    TJBQ = 1, 
    -- 冲锋枪
    CFQ = 2 , 
    -- 散弹枪
    XDQ = 3, 
    -- 精确射手步枪
    JQSSBQ = 4,
    -- 轻机枪
    QJQ = 5,
    -- 手枪
    SQ = 6, 
    -- 冲锋手枪
    CFSQ = 7,
    -- 盾牌
    DP = 8,
}


--货币界面
RestoreType = 
{
    GetServerData = 1,  --获取服务器货币
    UpdateRechargeNotify = 2,  --获取购买成功
}

MoneyType=
{
    Diamond = 1,
    Gold = 2,
}

MailMsgType = 
{
    MailList = 1,
    OperateMail = 2,
    DeleteAllReadMail = 3,
    GetAllReward = 4,
    NewMailNotify = 5,
    DeleteMailNotify = 6,
}

RealtimeNoticeMode = 
{
    Unactive = 0,       --不显示
    Hall = 1,           --在主界面显示
    MatchRoom = 2,      --在匹配界面
    Room = 3,           --在开房间界面
    Battle = 4,         --在战斗中
}

WarehouseToggle = 
{
    Character_Select = 1, 
    Game_Items = 2 ,
    New_Items = 3,  
}

UnlockCharacterIds = {}

WarehouseSettingToggle = 
{
    --lv1 
    BasicSetting = 1 ,              --基础配置
    SkinSetting = 2,                --皮肤
    WeaponPTSetting = 3,            --武器喷涂
    EquipmentPTSetting = 4,         --装备喷涂
    WeaponGJSetting = 5,            --武器挂件

    --lv2 
    BasicSetting_Equipment = 11,    --装备配置
    BasicSetting_Character = 12,    --干员信息

    SkinSetting_EquipmentTao = 21,  --套装
    SkinSetting_Head = 22,          --头部皮肤
    SkinSetting_Body = 23,          --身体皮肤

    WeaponPTSetting_Main = 31,      --主要武器
    WeaponPTSetting_Main_1 = 311,
    WeaponPTSetting_Sub = 32,       --次要武器
    WeaponPTSetting_Sub_1 = 321, 

    EquipmentPTSetting_Main = 41,   --主要装备
    EquipmentPTSetting_Sub = 42,    --次要装备

    WeaponGJSetting_Main = 51,      --主要武器
    WeaponGJSetting_Main_1 = 511,
    WeaponGJSetting_Sub = 52,       --次要武器
    WeaponGJSetting_Sub_1 = 521,
}

WarehouseRspType = 
{
    GetSkins = 1, 
    AddSkinsRsp = 2, 
    UpdateSkins = 3, 
}


Show3DType = 
{
    Character = 1, 
    Weapon = 2, 
}

--皮肤类型
SkinType = 
{
    Suit = 1, 
    Head = 2,
    Body = 3,
    WeaponSkin = 4, 
    Pendant = 5, 
    Sight = 6 ,       --望远镜
}
RankMsgType = 
{
    GetRankReward = 1,
}


rarityType = 
{
    Write = 1, 
    Green = 2,
    Blue =3, 
    Purple = 4, 
    Orange = 5
}

RoomSettingConst = 
{
    RANDOM_MODE_ID = 10000,
    RANDOM_MAP_ID = 10000,
}

OpenBoxType = 
{
    All = 0,
    Suit = 1,
    Weapon = 2,
    Gold = 3,
}