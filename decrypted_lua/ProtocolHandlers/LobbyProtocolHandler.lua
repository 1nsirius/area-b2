LobbyProtocolHandler = {}
local this = LobbyProtocolHandler
local logger = Logger.new("LobbyProtocolHandler")

function this.active_role(errorcode)
    local msg = StateMessage.new(MessageType.ACTIVE_ROLE)
    msg.errorcode = errorcode
    logger:Log("active_role", msg)
    HandleFSMMsg(msg)
end

--Be kickout
function this.rsp_kickout(param)
    Debug.LogWarning("Player was kicked out!")
    NetworkManager:Close(LinkID.Lobby)
end

--Join room failed
function this.RspJoinSpecifyRoomFailed(param)

end


--Player craete or enter room , specifily for user
function this.rsp_room_entered(param)
    GameInstance.user.Session:OnPlayerJoinOrCreateRoom(param)
end

--Other player enter room 
function this.rsp_room_player_entered(param)
    GameInstance.user.Session:OnPlayerEnterRoom(param)
end

-- Player leavedRspGameStage
function this.rsp_room_player_leaved(param)
     GameInstance.user.Session:OnPlayerLeaveRoom(param)
end

--Room owner chanded
function this.rsp_room_owner_changed(param)
     GameInstance.user.Session:OnRoomOwnerChanged(param)
end

--Player change camp successful
function this.RspChangeCampSuccess(param)
    GameInstance.user.Session:OnPlayerChangeCamp(param)
end

-- 房间内换位置
function this.RspPosChangeNotify(netData)
    GameInstance.user.Session:OnPosChange(netData)
end

--Player change camp failure
function this.RspChangeCampFailure(param)
    --TODO:
end

--fafag
function this.RspBattleInfo(param)
    Debug.Log("RspBattleInfo is receive!")
    local msg = StateMessage.new(MessageType.TRY_TO_CONNECT_TO_BATTLE_SERVER)
    msg.battle_id = param.data.battle_id
    local ip_port =  param.data.ip_port
    if ip_port == nil then
        Debug.LogError("RspBattleInfo error, ip_port is nil")
        return 
    end

    print(string.format("ip_port : %s , battle_id : %d ", ip_port, msg.battle_id))
    local idx = string.find(ip_port,":")
    local ip = string.sub(ip_port,1,idx-1)
    local port = tonumber(string.sub(ip_port,idx+1))

    msg.ip = ip
    msg.port = port
    HandleFSMMsg(msg)
end

--Load Map
function this.rsp_room_loading(param)
    --TODO:
    local msg = StateMessage.new(MessageType.LOAD_MAP)
    msg.param = param
    HandleFSMMsg(msg)
end

--Load Map
function this.RspGameStage(param)
    GameInstance.user.Session:OnGameStageSync(param)
end

function this.RspRoomStart(param)
    local msg = StateMessage.new(MessageType.SELECT_CHARACTER)
    HandleFSMMsg(msg)
    
    Debug.Log("RspRoomStart!!")
end

function this.RspMatchBattleState(param)
    local msgType = MessageType.LOBBY_BeginMatch;
    if not param.data.InMatch  then
        msgType = MessageType.LOBBY_EndMatch;
    end

    HandleFSMMsg(StateMessage.new(msgType))
end

function this.RspOnLineNumber(param)
    local msg = { }
    msg.msgType = RoomCtrlEventType.PlayerNumber
    msg.matchNumber = param.data.MatchPlayerNumber
    msg.battleNumber = param.data.BattlePlayerNumber
    UiMgr:Send(LuaPanelNames.HallPanel, msg)
end

function this.ForceToLobby()
    local uid = PlayerData.Instance.Uid
    local baseData  = PlayerBaseData.Get(uid)
    if IsNil(baseData) or string.IsNullOrEmpty(baseData.Name) then
        local msg = StateMessage.new(MessageType.ForceToNaming)
        HandleFSMMsg(msg)
    else
        local msg = StateMessage.new(MessageType.ForceToLobby)
        HandleFSMMsg(msg)
    end
    --local playerName = PlayerBaseData
end

function this.ForceToNaming()
    local msg = StateMessage.new(MessageType.ForceToNaming)
    HandleFSMMsg(msg)
end

--更新金币
function this.UpdateGold(gold)
    local msg = {}
    msg.gold = gold
    msg.msgType = RoomCtrlEventType.GoldRefresh
    LobbyProtocolHandler.RefreshMoney(msg)
end
--更新钻石
function this.UpdateDiamond(diamond)
    local msg = {}
    msg.diamond = diamond
    msg.msgType = RoomCtrlEventType.GoldDiamond
    LobbyProtocolHandler.RefreshMoney(msg)
end
function this.RefreshMoney(msg)
    UiMgr:Send(LuaPanelNames.HallPanel, msg)
    UiMgr:Send(LuaPanelNames.RechargePanel, msg)
    UiMgr:Send(LuaPanelNames.OpenBoxPanel, msg) 
    this._SendStore(msg)
end

function this._SendStore(msg)
    UiMgr:Send(LuaPanelNames.StorePanel, msg)
    UiMgr:Send(LuaPanelNames.StoreGiftPanel, msg)
    UiMgr:Send(LuaPanelNames.StoreSkinSuitPanel, msg)
    UiMgr:Send(LuaPanelNames.StoreSkinHeadPanel, msg)
    UiMgr:Send(LuaPanelNames.StoreSkinBodyPanel, msg)
    UiMgr:Send(LuaPanelNames.StoreWeaponPTPanel, msg)
    UiMgr:Send(LuaPanelNames.StoreSalePanel, msg)
    UiMgr:Send(LuaPanelNames.StoreWeaponGJPanel, msg)
end

-- @fixItem, 运营配置折扣物品(页面顶部显示)
-- @randomItems, 其他多个随机的折扣物品
function this.GetStoreSales(refreshTime, fixItem, randomItems)
    StoreData:ResetDiscountItems(refreshTime, fixItem, randomItems) 
    local msg = {}
    msg.msgType = StoreMsgType.SyncStoreSales
    this._SendStore(msg)
end

--获取所有商城物品
function this.GetStoreItems(items , storeType)
    -- print("Lua 收到商城道具刷新消息 " .. storeType)
    if storeType == StoreType.Box then return end
    local msg = {}
    msg.msgType = StoreMsgType.GetStoreItems
    msg.storeType = storeType
    msg.items = items 
    StoreData:ResetStoreItems(storeType, items)
    UiMgr:Send(LuaPanelNames.HallPanel, msg)
    this._SendStore(msg)
    print(" get_store_items : ")
    print(table.tostring(msg))
end

--购买，或者解锁成功
function this.BuyStoreItemResponder(itemId, errorcode, itemIdType)
    -- print("Lua 收到商城购买返回")
    local msg = {}
    msg.msgType = StoreMsgType.BuyItemRes
    msg.itemId = itemId 
    StoreData:OnBuySuccess(itemId, itemIdType)
    this._SendStore(msg)
    UiMgr:HideUi(LuaPanelNames.WaitPktPanel)
end

function this.BuyItemError(itemId, errorcode, itemIdType)
    -- print("Lua 收到商城购买失败")
    local msg = {}
    msg.msgType = StoreMsgType.Error
    msg.itemId = itemId 
    msg.errorcode = errorcode
    CS.FGame.ErrorCodeHelper.HandErrorCode(errorcode)
    this._SendStore(msg)
    UiMgr:HideUi(LuaPanelNames.WaitPktPanel)
end

--[[
function this.GetWarehouseSkins(msgResponder)
    print("Lua 收到获取仓库的皮肤列表")
    local msg = {}
    msg.msgType = WarehouseRspType.GetSkins
    msg.msgResponder = msgResponder
    UiMgr:Send(LuaPanelNames.WarehousePanel, msg)
end

function this.UseSkinResponder(msgResponder)
    print("Lua 收到使用皮肤返回")
end

function this.AddSkinResponder(msgResponder)
    print("Lua 收到添加皮肤返回")
    local msg = {}
    msg.msgType = WarehouseRspType.AddSkinsRsp
    msg.msgResponder = msgResponder
    UiMgr:Send(LuaPanelNames.WarehousePanel, msg)
end]]

function this.SaveWeaponConfig(msgResponder)
    print("Lua 收到保存武器返回")
end

--获取所有货币道具信息
function this.GetRechargeItems(items)
    print("Lua 收到货币道具信息返回")
    local msg = {}
    msg.items = items 
    msg.msgType = RestoreType.GetServerData
    UiMgr:Send(LuaPanelNames.RechargePanel, msg)
end

--获取所有货币道具信息
function this.UpdateRechargeItems(items)
    print("Lua 货币道具购买成功返回")
    local msg = {}
    msg.items = items 
    msg.msgType = RestoreType.UpdateRechargeNotify
    UiMgr:Send(LuaPanelNames.RechargePanel, msg)
end

function this.client_get_rank_award_req(param)
    print("Lua 收到获取段位奖励结果成功, errorCode:"..param.data.errorcode)
end

function this.RspChooseMap(mapId,modeId)
    local msg = {}
    msg.msgType = RoomCtrlEventType.OnRoomOwnerSelectedModeAndMap
    msg.modeId = modeId
    msg.mapId = mapId
    UiMgr:Send(LuaPanelNames.RoomPanel, msg)
end

function this.OpenUnlockPanel(charId, closeCallback , targetLevel )
    UiMgr:ShowUi(LuaPanelNames.StoreUnLockSucPanel, UILayer.Up , function(ui)
        ui:SetCloseCallBack(closeCallback)
        ui:SetData(charId , targetLevel)
    end)
end

function this.CloseUnlockPanel()
    UiMgr:RemoveUi(LuaPanelNames.StoreUnLockSucPanel)
end

    
function this.OnGetRewardNotify(type, list)
    local msg = {}
    msg.msgType = MessageKey.OnGetRewardNotify
    msg.type = type
    UiMgr:Send(LuaPanelNames.BoxRewardPanel, msg)
    CommonRewardData.OnGetRewardNotify(type, list)
end

--获取礼包价格
function this.OnGetNotififyItem(list)
    StoreData.SetGiftPrice(list)
end

function this.OnQueryRecruitInfo(code, recruiterUid, recruiteeCount)
    logger:Log("OnQueryRecruitInfo", code, recruiterUid, recruiteeCount)
    EnlistData.mEnlistCode = code
    EnlistData.mEnlisterUid = recruiterUid
    EnlistData.mEnlisteeNum = recruiteeCount
    EnlistData:SyncChanged()
    if EnlistData.mQueryListener ~= nil then
        EnlistData.mQueryListener(EnlistData)
    end
end

function this.OnAcceptRecruit(errorCode, recruiterUid, recruiterName)
    logger:Log("OnAcceptRecruit", errorCode, recruiterUid, recruiterName)
    if errorCode ~= 0 then
		ErrorCodeHelper.HandErrorCode(errorCode);
        return 
    end

    UiMgr:RemoveUi(LuaPanelNames.EnlistPanel)
    HUDTextShowerHelper.AddNormalTextEntity(856, nil, recruiterName)
    EnlistData.mEnlisterUid = recruiterUid
    EnlistData:SyncChanged()
end

-- 通知有新的徒弟(Recruitee)
function this.OnNotifyNewRecruitee(recruiteeUid, recruiteeName)
    logger:Log("OnNotifyNewRecruitee", recruiteeUid, recruiteeName)
    EnlistData.mEnlisteeNum = EnlistData.mEnlisteeNum + 1
    EnlistData:SyncChanged()
end

this.msgDir =
{
    --["load_role"] = this.load_role,
    ["create_role"] = this.create_role,
    ["active_role"] = this.active_role,
    ["rsp_kickout"] = this.rsp_kickout,
    ["RspJoinSpecifyRoomFailed"] = this.RspJoinSpecifyRoomFailed,
    ["rsp_room_entered"] = this.rsp_room_entered,
    ["rsp_room_player_entered"] = this.rsp_room_player_entered,
    ["rsp_room_player_leaved"] = this.rsp_room_player_leaved,
    ["rsp_room_owner_changed"] = this.rsp_room_owner_changed,
    ["RspChangeCampSuccess"] = this.RspChangeCampSuccess,
    ["RspPosChangeNotify"] = this.RspPosChangeNotify,
    ["RspChangeCampFailure"] = this.RspChangeCampFailure,
    ["RspBattleInfo"] = this.RspBattleInfo,
    ["rsp_room_loading"] = this.rsp_room_loading,
    ["RspGameStage"] = this.RspGameStage,
    ["RspRoomStart"] = this.RspRoomStart,
    ["RspMatchBattleState"] = this.RspMatchBattleState,
    ["RspOnLineNumber"] = this.RspOnLineNumber,
    ["ForceToLobby"] = this.ForceToLobby,
    ["ForceToNaming"] = this.ForceToNaming,
    ["UpdateGold"] = this.UpdateGold,
    ["UpdateDiamond"] = this.UpdateDiamond,
    ["GetStoreItems"] = this.GetStoreItems,
    ["GetStoreSales"] = this.GetStoreSales,
    ["BuyStoreItemResponder"] = this.BuyStoreItemResponder,
    ["BuyItemError"] = this.BuyItemError,
    ["BuyStoreItemResponder"] = this.BuyStoreItemResponder,
    ["GetRechargeItems"] = this.GetRechargeItems,
    ["GetWarehouseSkins"] = this.GetWarehouseSkins,
    ["UseSkinResponder"] = this.UseSkinResponder,
    ["AddSkinResponder"] = this.AddSkinResponder,
    ["SaveWeaponConfig"] = this.SaveWeaponConfig,
    ["client_get_rank_award_req"] = this.client_get_rank_award_req,
    ["RspChooseMap"] = this.RspChooseMap,
    ["OpenUnlockPanel"] = this.OpenUnlockPanel,
    ["CloseUnlockPanel"] = this.CloseUnlockPanel,
    ["OnGetRewardNotify"] = this.OnGetRewardNotify,
    ["UpdateRechargeItems"] = this.UpdateRechargeItems,
    ["OnQueryRecruitInfo"] = this.OnQueryRecruitInfo,
    ["OnAcceptRecruit"] = this.OnAcceptRecruit,
    ["OnNotifyNewRecruitee"] = this.OnNotifyNewRecruitee,
    ["OnGetNotififyItem"] = this.OnGetNotififyItem,


};