ChatAPI = {}
local this = ChatAPI

--[[发送群组消息]]
function this.SendGroupText(msg, group_id)
    local chatModule = EjoysdkManager:GetChatModule()
    chatModule:SendGroupText(msg, group_id)
end

--[[发送自定义消息]]
function this.SendCustomMsg(custom)
    local chatModule = EjoysdkManager:GetChatModule()
    chatModule:SendCustomMsg(custom)
end