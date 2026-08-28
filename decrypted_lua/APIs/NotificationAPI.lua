NotificationAPI = {}
local this = NotificationAPI

--新建本地推送
--title     本地推送标题，string 类型
--content   本地推送内容，string 类型
--calendar  本地推送时间，table 类型。目前只支持延后设置的形式
--          calendar.day    推送延后的天数
--          calendar.hour   推送延后的小时
--          calendar.minute 推送延后的分钟
--          calendar.second 推送延后的秒数
--ext       扩展字段，table 类型，以 key : value 的格式写入
--config    额外设置，目前支持以下
--          notify_id                   本地推送的 id，string 类型，默认可不填
--          notify_in_foreground        应用在前台是否显示通知，boolean 类型，默认为 false
--          android_channel_id          安卓 8.0 以上的推送 channel id，默认可不填
--          android_channel_name        安卓 8.0 以上的推送 channel name，默认可不填
--          android_channel_description 安卓 8.0 以上的推送描述，默认可不填
function this._Add(title, content, calendar, ext, config)
    if GameInstance.systemInfo:IsMobilePlayer() == false then
        return -1
    end

    ejoysdk_push = require 'ejoysdk_lua.push.ejoysdk_push'
    ejoysdk_push.max_local_push_notifyids = 20 -- 缓存的notify id数量，不适宜设置过大

    if calendar ~= nil then
        print("after "..tostring(calendar.day).."days "..tostring(calendar.hour).."hours "..tostring(calendar.minute).."minutes "..tostring(calendar.second).."seconds")
    end

    if config == nil then
        config = {}
    end
    --Tag:中台说，不设置false，不能取消推送
    config["updateable"] = false

    local notify_id = ejoysdk_push.add_local_notification(title, content, calendar, ext, config)
    return notify_id
end

--新建本地推送,(C#端调用)
function this.AddLocalNotification(title, content, calendar, ext, config)
    if GameInstance.systemInfo:IsMobilePlayer() == false then
        return -1
    end
    
    local calendarTable = {}
    if calendar ~= nil then
        calendarTable["day"] = calendar.mDay or 0
        calendarTable["hour"] = calendar.mHour or 0
        calendarTable["minute"] = calendar.mMinute or 0
        calendarTable["second"] = calendar.mSecond or 0
    end
    
    local configTable = {}
    if config ~= nil then
        configTable["notify_id"] = config.mNotifyId
        configTable["notify_in_foreground"] = config.mNotifyInForeground
        configTable["android_channel_id"] = config.mAndroidChannelId
        configTable["android_channel_name"] = config.mAndroidChannelName
        configTable["android_channel_description"] = config.mAndroidChannelDescription
    end
    
    return this._Add(title, content, calendarTable, ext, configTable)
end


--移除本地推送
function this.RemoveLocalNotification(notify_id)
    if GameInstance.systemInfo:IsMobilePlayer() == false then
        return false
    end
    
    print("RemoveLocalNotification : "..notify_id)
    ejoysdk_push = require 'ejoysdk_lua.push.ejoysdk_push'
    ejoysdk_push.remove_local_notification(notify_id)
end

--移除所有本地推送
function this.RemoveAllLocalNotification()
    if GameInstance.systemInfo:IsMobilePlayer() == false then
        return false
    end
    
    print("RemoveAllLocalNotification!")
    ejoysdk_push = require 'ejoysdk_lua.push.ejoysdk_push'
    ejoysdk_push.remove_all_local_notification()
end

--初始化语言
function this.SetLanguage()
    if GameInstance.systemInfo:IsMobilePlayer() == false then
        return false
    end

    local E = require "ejoysdk_lua.ejoysdk" 
    local langtag = LanguageManager.Instance:GetString(2)
    E.CONFIG.set_config('lang', langtag)
    print('language set finish '..langtag)
end