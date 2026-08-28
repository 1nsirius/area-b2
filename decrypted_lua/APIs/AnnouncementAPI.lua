AnnouncementAPI = {}
local this = AnnouncementAPI

--[[获取公告]]
function this.GetAnnouncement()
    local test = not (GameInstance.systemInfo:IsMobilePlayer() and GameInstance.appSetting.useSDKLogin)
    if test then
        --local anns = '{"hash": "ccbbe873c5625bb351b3da92dfbb90b4", "anns": [{"Primer field": "", "_type": "F2_activity", "_mtime": "1576074487", "Order field": "1", "_uuid": "5def0b6eda294e000a808762", "_tags": null, "value": {"status": "111", "content": "11111\n1231\n<color=red>fsfs</color>", "title": "111"}, "_version": "5df0fcf7da294e000a80879b", "_order_field_value": "1"}], "args": {"LANG": "en", "ZONE": "CN"}, "time": 1576074503}'
        --AnnouncementData:OnSuccReceive(anns)
    else
        local ejoysdk = require 'ejoysdk_lua.ejoysdk'
        local EL = require "ejoysdk_lua.ejoysdk_launcher"
        -- local initialized = EjoysdkManager.initialized 
        -- if initialized == false then
        --     EjoysdkManager:Init(function(succ)
        --     end, nil)
        -- end
        local langtag = LanguageManager.Instance:GetString(2)
        ejoysdk.CONFIG.set_config('lang', langtag)
        EL.ticket_detail("F2_activity", nil, nil, function(succ, anns)
            print("<color=red>EL.ticket_detail</color> succ:", succ,", anns:", anns)
            if succ then
                -- 获取公告内容成功, anns为包含公告内容的json字符串
                AnnouncementData:OnSuccReceive(anns)
            else
                -- 获取公告ticket失败
            end
        end)
    end
end