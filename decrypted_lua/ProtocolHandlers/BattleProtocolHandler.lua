BattleProtocolHandler = {}
local this = BattleProtocolHandler


--function this.RspBattleResult(netData)
--    local msg = StateMessage.new(MessageType.GAME_BATTLE_RESULT)
--    msg.netData = netData
--    HandleFSMMsg(msg)
--end


--function this.RspBattleFinalResult(netData)
--    local msg = StateMessage.new(MessageType.GAME_BATTLE_RESULT)
--    msg.netData = netData
--    HandleFSMMsg(msg)
--end

function this.RspVoiceChannel(netData)
--    Debug.Log("RspVoiceChannel is invoke! Channel id->"..tostring(netData.data.channel_id))
--    if GameInstance.systemInfo:IsMobilePlayer() then
--        EjoysdkManager:GetVoiceModule():BeginJoinVoiceChanel(netData.data.channel_id)
--    end
end

this.msgDir =
{
    --["RspBattleResult"] = this.RspBattleResult,
    --["RspBattleFinalResult"] = this.RspBattleFinalResult,
    ["RspVoiceChannel"] = this.RspVoiceChannel,
};