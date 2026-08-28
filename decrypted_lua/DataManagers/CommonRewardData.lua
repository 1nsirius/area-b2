local this = {}

local cacheQueue = Queue.new()
local CRH = require("Helpers.CommonRewardHelper")
local BRH = require("Helpers.BoxRewardHelper")
local BURH = require("Helpers.BundleRewardHelper")

local function Wrap(type, list)
    local res = 
    {
        type = type,
        list = list
    }
    return res
end

local function GetOne()
    if CommonRewardData.inLobbyStateNormal then
        if cacheQueue:Count() > 0 then
            return cacheQueue:Dequeue()
        else
            return nil
        end
    else
        this.Clear()
        return nil
    end
end

local function Check()
    if CRH.IsIdle() and BRH.IsIdle() and BURH.IsIdle() then
        local wrap = GetOne()
        if wrap ~= nil then
            if wrap.type == 0 then
                CRH.Handle(wrap.list)
            elseif wrap.type == 1 then
                BRH.Handle(wrap.list)
            elseif wrap.type == 2 then
                BURH.Handle(wrap.list)
            else
                Check()
            end
        end
    end
end

local cb = function ()
    Check()
end

CRH.RegisterCallback(cb)
BRH.RegisterCallback(cb)
BURH.RegisterCallback(cb)

function this.Clear()
    cacheQueue:Clear()
end

function this.OnGetRewardNotify(type, list)
    print("OnGetRewardNotify")
    UiMgr:HideUi(LuaPanelNames.WaitPktPanel)
    if CommonRewardData.inLobbyStateNormal then
        cacheQueue:Enqueue(Wrap(type, list))
        Check()
    end
end

this.inLobbyStateNormal = false

CommonRewardData = this
