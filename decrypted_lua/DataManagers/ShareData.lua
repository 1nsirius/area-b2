--------------------------------------------------------------------------------
-- 类名称：ShareData
-- 描述：分享相关
-- 作者：陆坚
-- 创建时间：2020-1-11
-- 最后修改该人：
-- 最后修改该时间：
-- 版权所有 (C)：aligames
--------------------------------------------------------------------------------

EShareType = {
    None               = "None",
    -- 干员获得
    CharacterGet       = "CharacterGet",
    -- 结算
    BattleResult       = "BattleResult",
    -- MVP
    Mvp                = "Mvp",
    -- 段位
    Rank               = "Rank",
    -- 获得其他礼包
    UnlockGift         = "UnlockGift",
    -- 获得皮肤套装
    UnlockSkin         = "UnlockSkin",
}

ShareData = class("ShareData", nil, {
    mType = EShareType.None,
    mParams = {
        -- 干员获得 -> 干员id
        characterId = nil,
        -- 结算
        battleEndTime = nil,
        ourPlayerScoreDatas = nil,
        otherPlayerScoreDatas = nil,
        -- 段位
        rankScore = nil, 
        rankStar = nil,
        -- 获得其他礼包
        giftBagId = nil,
        giftBundleId = nil,
        -- 获得皮肤套装 
        skinBagId = nil, 
        skinSuitId = nil,
    },
    mCloseListener = nil,
})

local this = ShareData
local logger = Logger.new("ShareData")

-- 打开分享ui
-- @type: 具体的分享类型，1.干员获得 2.结算 3.MVP 4.段位
function this:OpenSharePanel(type, params, closeListener)
    logger:Log("OpenSharePanel", type, params)
    self.mType = type
    self.mParams = params
    self.mCloseListener = closeListener

    UiMgr:ShowUi(LuaPanelNames.SharePanel, UILayer.Up)
end

function OpenShareBattleResult(battleEndTime, ourPlayerScoreDatas, otherPlayerScoreDatas, closeListener)
    ShareData:OpenSharePanel(
        EShareType.BattleResult,
        {
            battleEndTime = battleEndTime,
            ourPlayerScoreDatas = ourPlayerScoreDatas,
            otherPlayerScoreDatas = otherPlayerScoreDatas,
        },
        closeListener
    )
end

function OpenShareMvp(closeListener)
    ShareData:OpenSharePanel(
        EShareType.Mvp,
        {
        },
        closeListener
    )
end

function OpenShareRank(rankScore, rankStar, closeListener)
    ShareData:OpenSharePanel(
        EShareType.Rank,
        {
            rankScore = rankScore,
            rankStar = rankStar,
        },
        closeListener
    )
end

-- 今天是否分享过
function IsShareRewarded()
    local uid = PlayerData.Instance.Uid
    local globalStatData = PlayerGlobalStatData.Get(uid)
    local lastDays = math.floor(globalStatData:GetVal(RoleStatsInfo.last_share_ts)/(3600*24))
    local days = math.floor(ServerTimeManager.Instance.ServerTick/(3600*24))
     --logger:Log("IsShareRewarded", days, lastDays)
    return days == lastDays
end

-- 分享到fb timeline获得奖励
function this:SendShareTimeline()
    SendMsgHelp.SendShareReq(0)
    if IsShareRewarded() == false then
        logger:Log("SendShareReq")
        local uid = PlayerData.Instance.Uid
        PlayerGlobalStatData.Update(uid, tostring(RoleStatsInfo.last_share_ts), ServerTimeManager.Instance.ServerTick)
    end
end