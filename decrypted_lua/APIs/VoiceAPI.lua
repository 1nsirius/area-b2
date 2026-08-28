VoiceAPI = {}
local this = VoiceAPI
local logger = Logger.new("VoiceAPI")

--[[设置扬声器的状态, 听或不听所有语音, 开关当前玩家的喇叭]]
function this.EnableLoudspeaker(enable)
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:mute_remote_all(enable == false)
    EjoysdkManager:GetVoiceModule():enable_volume_indication(enable and 400 or 0)
end

--[[设置麦克风的状态, 开关当前玩家的麦克风]]
function this.EnableMicrophone(enable)
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:mute_local(enable == false)
end

--[[调整声音播放音量]]
function this.AdjustVoicePlayingVolume(volume)
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:adjust_playing_volume(volume)
end

--[[调节麦克风录音音量]]
function this.AdjustVoiceRecordVolume(volume)
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:adjust_record_volume(volume)
end

--[[静音其他玩家
player_id的类型是字符串
]]
function this.MuteRemotePlayer(player_id, mute)
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:mute_remote(player_id,mute)
end

--[[检查麦克风的使用权限]]
function this.CheckMicrophonePermission(callback)
    if EjoysdkManager == nil then callback(true) return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:CheckMicrophonePermission(callback)
end

--[[获取当前语音模块的状态]]
function this.GetCurVoiceState()
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    return voiceModule:GetCurVoiceState()
end

--[[尝试加入语音通道]]
function this.JoinChannel()
    if EjoysdkManager == nil then
        VoiceAPI:OnJoinChannel(1, PlayerData.Instance.Uid, 0, nil)
        return
    end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:join_channel()
end

--[[主动离开语音频道]]
function this.LeaveChannel()
    if EjoysdkManager == nil then
        VoiceAPI:OnSelfLeaved()
        return
    end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:leave_channel()
end

--[[获取当前语音频道id]]
function this.GetCurrentVoiceChannel()
    if EjoysdkManager == nil then return 1 end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    return voiceModule:GetCurJoinedVoiceChannelId()
end

--[[大局结束]]
function this.ClearData()
    if EjoysdkManager == nil then return end
    local voiceModule = EjoysdkManager:GetVoiceModule()
    voiceModule:ClearAllData()
end

-------------------------- 回调 ------------------------------
function this:OnVoiceChannelCreated(channel_id)
    logger:Log("OnVoiceChannelCreated", channel_id)
    CSharpAPI.OnVoiceChannelCreated()
end

function this:OnJoinChannel(channel_id, uid, errorCode, errorMsg)
    logger:Log("OnJoinChannel", channel_id, uid, errorCode, errorMsg)
    if errorCode ~= 0 then
        CSharpAPI.OnSelfLeaved()
        if EjoysdkManager ~= nil then
            EjoysdkManager:GetVoiceModule():enable_volume_indication(0)
        end
        return 
    end

    CSharpAPI.OnUserJoined(uid)
    if EjoysdkManager ~= nil then
        EjoysdkManager:GetVoiceModule():enable_volume_indication(400)
    end
end
function this:OnConnectionInterrupt()
    logger:Log("OnConnectionInterrupt")
    CSharpAPI.OnSelfLeaved()
end
function this:OnConnectionLost()
    logger:Log("OnConnectionLost")
    CSharpAPI.OnSelfLeaved()
end
function this:OnConnectionBanned()
    logger:Log("OnConnectionBanned")
    CSharpAPI.OnSelfLeaved()
end
function this:OnRejoinChannelSucc(channel_id, uid)
    logger:Log("OnRejoinChannelSucc", channel_id, uid)
    VoiceAPI:OnJoinChannel(channel_id, uid, 0, nil)
end

-- 其他玩家进入语音频道
function this:OnUserJoined(uid)
    logger:Log("OnUserJoined", uid)
    CSharpAPI.OnUserJoined(uid)
end

function this:OnUserLeaved(uid)
    logger:Log("OnUserLeaved", uid)
    CSharpAPI.OnUserLeaved(uid)
end

function this:OnSelfLeaved()
    logger:Log("OnSelfLeaved")
    CSharpAPI.OnSelfLeaved()
end

function this:OnVolumeIndication(uid, volume) 
    --logger:Log("OnVolumeIndication", uid, volume)
    CSharpAPI.OnVolumeIndication(uid, volume)
end