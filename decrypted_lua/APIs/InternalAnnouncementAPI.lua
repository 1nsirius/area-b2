InternalAnnouncementAPI = {}
local this = InternalAnnouncementAPI

function this.IsTest()
    return not (GameInstance.systemInfo:IsMobilePlayer() and GameInstance.appSetting.useSDKLogin)
end

--[[获取公告]]
function this.GetAnnouncement()
    if InternalAnnouncementAPI.IsTest() then
        local anns = '{"hash": "a846ddcab524a462711a53bd66a52532", "anns": [{"Primer field": "\\u516c\\u544a3\\u56fe\\u6587\\u6df7\\u6392", "_type": "internal_notice", "_mtime": "1581392054", "Order field": "3", "_uuid": "5e4220b6ef8df300188fdf0a", "_tags": null, "value": {"status": "hot", "content": {"text": "\\u516c\\u544a3\\u56fe\\u6587\\u6df7\\u6392", "image": "http://file.elecfans.com/web1/M00/8E/0E/pIYBAFysRjqAF2jZAAFTn97W36E192.jpg", "textAlignment": 4, "textPosY": 0, "textPosX": 0}, "contentType": "combine", "pop": 3, "title": "纯本地测试公告"}, "_version": "5e4220b6ef8df300188fdf09", "_order_field_value": "3"}, {"Primer field": "\\u516c\\u544a2\\u56fe\\u7247", "_type": "internal_notice", "_mtime": "1581392007", "Order field": "2", "_uuid": "5e422087ef8df300188fdf06", "_tags": null, "value": {"status": "new", "content": {"text": "111", "image": "http://a3.att.hudong.com/68/61/300000839764127060614318218_950.jpg", "textAlignment": 0, "textPosY": 0, "textPosX": 0}, "contentType": "image", "pop": 3, "title": "纯本地测试公告"}, "_version": "5e422087ef8df300188fdf05", "_order_field_value": "2"}, {"Primer field": "f2\\u5c40\\u5185\\u516c\\u544a", "_type": "internal_notice", "_mtime": "1581390400", "Order field": "1", "_uuid": "5e421946ef8df3000ec1424e", "_tags": null, "value": {"status": "new", "content": {"text": "\\u516c \\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\\u544a\\u6d4b\\u8bd58\\u4e2a\\u5b57\nqerqwerqw\nqwerqwer\ndsfsdfh\nsdfhsdfhd\nfasdfasfasf\nasdfafasdf\nadfasdfadsg\ntrktrjtrjyr\nfasfasdaf\nafasdfs", "textAlignment": 0, "textPosY": 0, "textPosX": 0}, "contentType": "text", "pop": 5, "title": "纯本地测试公告"}, "_version": "5e421a40ef8df3000ec14250", "_order_field_value": "1"}], "args": {"LANG": "zh-hans", "ZONE": "CN"}, "time": 1581392321}'
        --local anns = '{"hash": "a846ddcab524a462711a53bd66a52532", "anns": [], "args": {"LANG": "zh-hans", "ZONE": "CN"}, "time": 1581392321}'
        InternalAnnouncementData.OnSuccReceive(anns)
    else
        local ejoysdk = require 'ejoysdk_lua.ejoysdk'
        local EL = require "ejoysdk_lua.ejoysdk_launcher"
        local langtag = LanguageManager.Instance:GetString(2)
        ejoysdk.CONFIG.set_config('lang', langtag)
        EL.ticket_detail("internal_notice", nil, nil, function(succ, anns)
            print("<color=red>EL.ticket_detail</color> succ:", succ,", anns:", anns)
            if succ then
                -- 获取公告内容成功, anns为包含公告内容的json字符串
                InternalAnnouncementData.OnSuccReceive(anns)
            else
                InternalAnnouncementData.OnFailReceive()
            end
        end)
    end
end

