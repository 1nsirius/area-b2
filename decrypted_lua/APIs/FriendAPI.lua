---@class FriendAPI
FriendAPI = {}
local this = FriendAPI
local logger = Logger.new("FriendAPI")

--[[获取好友列表]]
function this.GetFriendList()
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:GetFriendList()
  FriendAPI.GetFBFriendList()
end

--[[获取FB好友列表]]
function this.GetFBFriendList()
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:GetFBFriendList()
end

--[[获取好友申请待处理列表]]
function this.GetFriendApplys()
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:GetFriendApplys()
end

--[[获取玩家信息]]
function this.GetPlayerInfo(player_id)
  if EjoysdkManager == nil then return end
  local chatModule = EjoysdkManager:GetChatModule()
  chatModule:GetPlayerInfo(player_id)
end

--[[申请添加玩家好友]]
function this.ApplyAddFriend(player_id,apply_content)
  logger:Log("ApplyAddFriend player_id"..player_id)
  if tonumber(player_id) == tonumber(GameInstance.user:GetUserID()) then
      HUDTextShower.AddNormalTextEntity(305)
      return
  end
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:ApplyAddFriend(player_id,apply_content)
end

--[[同意添加玩家好友]]
function this.AcceptFriendApply(player_id)
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:AcceptFriendApply(player_id)
end

--[[拒绝添加玩家好友]]
function this.RefuseFriend(player_id)
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:RefuseFriend(player_id)
end

--[[删除玩家好友]]
function this.DeleteFriend(player_id)
  if EjoysdkManager == nil then return end
  local friendModule = EjoysdkManager:GetFriendModule()
  friendModule:DeleteFriend(player_id)
end

-- 通过Id判断是不是好友
function this.IsMyFriendById(id)
	return FriendData:IsMyFriendById(tostring(id))
end

