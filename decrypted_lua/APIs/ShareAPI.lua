ShareAPI = {}
local this = ShareAPI
local logger = Logger.new("ShareAPI")

-- [组队界面] 发送房间邀请信息到第三方应用，其他玩家通过点击分享信息拉起应用进入房间
-- @rootType: 0.组队 1.自定义
function this.ShareH5ToInviteRoom(roomID, roomType)
    logger:Log("ShareH5ToInviteRoom roomID", roomID, "roomType", roomType)

    if EjoysdkManager == nil then return end
    local shareModule = EjoysdkManager:GetShareModule()

    -- AndroidManifest中的scheme配置
    local region = VendorData.mRegion
    local scheme = "com.qookka.areaf2"
    local ios_scheme = "com.qookka.areaf2"
    local android_scheme = "com.qookka.areaf2"

    local contentUrl = 
                        "https://sea-res-mcd.ejoy.com/area_f2_h5/"..region.."/index.html?" ..
                        "package=" .. scheme .. "&" ..
                        "ios_scheme=" .. ios_scheme .. "&" ..
                        "android_scheme=" .. android_scheme .. "&" ..
                        "path=" .. "share" .. "&" ..
                        "roomid=" .. tostring(roomID) .. "&" ..
                        "roomType=".. tostring(roomType)
    local imageUrl = "https://sea-res-mcd.ejoy.com/vagary/resource/image/messengerpic0.png"
    local title = GameInstance.GetString(60103)
    local message = GameInstance.GetFormatString(
        56102,
        GameInstance.GetString(VendorData:GetRegionName()),
        contentUrl
    )
    shareModule:ShareH5ToMessenger(
        EVendors.SYSTEM.name,
        contentUrl,
        imageUrl,
        title,
        message,
        nil
    ) 
end

-- [组队界面] 游戏进入lobby时检查玩家是否通过第三方邀请信息拉起的应用，如果是进入该房间
-- @return: room_id, room_type
function this.CheckBeShareH5ToInviteRoom()
    logger:Log("CheckBeShareH5ToInviteRoom")

    if EjoysdkManager == nil then return nil end
    local room_id = nil
    local room_type = nil

    local shareModule = EjoysdkManager:GetShareModule()
    local onShareUrl = shareModule:GetSchemeUrl()
    if onShareUrl ~= nil then
        -- 解析字符串，获取room_id
        room_id = CommonUtility.GetUrlParam(onShareUrl, "roomid")
        room_type = CommonUtility.GetUrlParam(onShareUrl, "roomType")
        if room_id ~= nil or room_type ~= nil then
            shareModule:ConsumeSchemeUrl("ShareAPI.CheckBeShareH5ToInviteRoom") 
        end
    end

    logger:Log("CheckBeShareH5ToInviteRoom room_id", room_id, "room_type", room_type)
    room_id = room_id ~= nil and tonumber(room_id) or nil
    room_type = room_type ~= nil and tonumber(room_type) or nil
    return room_id, room_type
end

-- [招募界面] 游戏进入lobby时检查玩家是否通过第三方招募信息拉起的应用，如果是接受招募
-- @return: enlist_code 
function this.CheckBeShareH5ToEnlist()
    logger:Log("CheckBeShareH5ToEnlist")

    if EjoysdkManager == nil then return nil end
    local enlist_code = nil

    local shareModule = EjoysdkManager:GetShareModule()
    local onShareUrl = shareModule:GetSchemeUrl()
    if onShareUrl ~= nil then
        -- 解析字符串，获取room_id
        enlist_code = CommonUtility.GetUrlParam(onShareUrl, "enlistCode")
        if enlist_code ~= nil then
            shareModule:ConsumeSchemeUrl("ShareAPI.CheckBeShareH5ToEnlist") 
        end
    end

    logger:Log("CheckBeShareH5ToEnlist enlist_code", enlist_code)
    return enlist_code 
end

-- [好友界面] 邀请好友进入游戏
function this.ShareH5ToInviteGame()
    logger:Log("ShareH5ToInviteGame")

    if EjoysdkManager == nil then return end
    local shareModule = EjoysdkManager:GetShareModule()

    -- AndroidManifest中的scheme配置
    local region = VendorData.mRegion
    local scheme = "com.qookka.areaf2"
    local ios_scheme = "com.qookka.areaf2"
    local android_scheme = "com.qookka.areaf2"

    local contentUrl = 
                        "https://sea-res-mcd.ejoy.com/area_f2_h5/"..region.."/index.html?" ..
                        "package=" .. scheme .. "&" ..
                        "ios_scheme=" .. ios_scheme .. "&" ..
                        "android_scheme=" .. android_scheme .. "&" ..
                        "path=" .. "share"
    local imageUrl = "https://sea-res-mcd.ejoy.com/vagary/resource/image/messengerpic0.png"
    local title = GameInstance.GetString(60103)
    local message = GameInstance.GetFormatString(
        56002,
        GameInstance.GetString(VendorData:GetRegionName()),
        contentUrl
    )
    shareModule:ShareH5ToMessenger(
        EVendors.SYSTEM.name,
        contentUrl,
        imageUrl,
        title,
        message,
        nil
    ) 
end

-- [招募界面] 招募好友进入游戏
function this.GetShareH5ToEnlistGameUrl(enlistCode)
    local region = VendorData.mRegion
    local scheme = "com.qookka.areaf2"
    local ios_scheme = "com.qookka.areaf2"
    local android_scheme = "com.qookka.areaf2"
    return 
                        "https://sea-res-mcd.ejoy.com/area_f2_h5/"..region.."/recruit.html?" ..
                        "package=" .. scheme .. "&" ..
                        "ios_scheme=" .. ios_scheme .. "&" ..
                        "android_scheme=" .. android_scheme .. "&" ..
                        "path=" .. "share" .. "&" ..
                        "enlistCode=" .. tostring(enlistCode)
end
function this.ShareH5ToEnlistGame(enlistCode)
    logger:Log("ShareH5ToEnlistGame")

    if EjoysdkManager == nil then return end
    local shareModule = EjoysdkManager:GetShareModule()

    -- AndroidManifest中的scheme配置
    local contentUrl = this.GetShareH5ToEnlistGameUrl(enlistCode)
    local imageUrl = "https://sea-res-mcd.ejoy.com/vagary/resource/image/messengerpic0.png"
    local title = GameInstance.GetString(60103)
    local message = GameInstance.GetFormatString(
        56002,
        GameInstance.GetString(VendorData:GetRegionName()),
        contentUrl
    )
    shareModule:ShareH5ToMessenger(
        EVendors.SYSTEM.name,
        contentUrl,
        imageUrl,
        title,
        message,
        nil
    ) 
end

-- [分享界面] 分享截图到fb timeline
function this.SharePictureToTimeline(rectTransform, screenshotCallback, callback)
    logger:Log("SharePictureToTimeline")  

    CommonUtility.CaptureScreen(
        rectTransform,
        function (filePath)
            if screenshotCallback ~= nil then screenshotCallback() end
            if EjoysdkManager == nil then
                if callback ~= nil then callback() end
                return
            end 
            
            local title = ""
            local msg = ""
            local shareModule = EjoysdkManager:GetShareModule()
            logger:Log("SharePictureToTimeline filePath", filePath)  
            shareModule:SharePictureToTimeline(
                EVendors.FB.name,
                filePath,
                title,
                msg,
                function (result)
                    if callback ~= nil then
                        callback(result)
                    end
                end)
        end
    )
end