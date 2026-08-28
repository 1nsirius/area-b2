--------------------------------------------------------------------------------
-- 类名称：EnlistData
-- 描述：招募相关
-- 作者：陆坚
-- 创建时间：2020-1-19
-- 最后修改该人：
-- 最后修改该时间：
-- 版权所有 (C)：aligames
--------------------------------------------------------------------------------

EnlistData = class("EnlistData", nil, {
    -- 当前玩家的招募码
    mEnlistCode = nil,
    -- 当前玩家的招募者id
    mEnlisterUid = nil,
    -- 当前玩家招募的数量
    mEnlisteeNum = 0,

    -- 获取数据回调
    mQueryListener = nil,
})

local this = EnlistData
local logger = Logger.new("EnlistData")

function this:SyncChanged()
    Message.Dispatch(MessageKey.EnlistSyncChanged)	
end

function this:Ask(callback)
    self.mQueryListener = function ()
        callback()
        self.mQueryListener = nil 
    end
    SendMsgHelp.SendQueryRecruitInfo()
end

-- 打开发送招募ui
function this:OpenSendEnlistPanel()
    logger:Log("OpenSendEnlistPanel")
    UiMgr:ShowUi(LuaPanelNames.EnlistPanel, UILayer.Up, function(ctrl)
        ctrl:initSendEnlist()
    end)
end

-- 打开绑定招募ui
function this:OpenBindEnlistPanel()
    logger:Log("OpenBindEnlistPanel")
    UiMgr:ShowUi(LuaPanelNames.EnlistPanel, UILayer.Up, function(ctrl)
        ctrl:initBindEnlist()
    end)
end
