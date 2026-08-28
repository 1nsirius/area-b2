local MsgInfo = {
    mIsSelf = false,
	mIsVoice = false,
    mName 		= "Tom",
    mMsg 		= "This Is Default",
    mPlyerID 	= "0",	
	-- mPortraitId	= "0",
	mIconId	= "0",
	mLevel		= "0",
}
MsgInfo.__index = MsgInfo

function MsgInfo:new(isself,isvoice, name, text, playerid, iconId, level)
    local o = {}
    setmetatable(o,MsgInfo)
    o.mIsSelf = isself
	o.mIsVoice = isvoice
    o.mName = name
    o.mMsg = text
	o.mPlyerID = playerid
	o.mIconId = iconId
	o.mLevel = level
    return o
end

-- 聊天记录池
local ChatPoolInfo = {
	  mHaveUnReadMsg = 0,
      mFriendID = "default",
	  mMsgList = {},
}
ChatPoolInfo.__index = ChatPoolInfo

function ChatPoolInfo:new(id, list)
    local p = {}
    setmetatable(p,ChatPoolInfo)
	p.mFriendID = id
	p.mMsgList = list
    return p
end


local this = class("ChatData")

function this:ctor(...)
    self.testMsgList = {}

    -- 当前聊天对象的频道id :好友id  , 世界频道: 0
	self.mCurtChatPlayer_Id = "world"
	self.mCurGroupId = nil
	self.mMaxShowMsgInBox = 100
	self.mMaxShowFriendMsgInBox = 30
	self.mPlayerChatList = {}
	self.talkName = "world"
	self.ShowChatViewFriendId = nil
	self.lastTalkMsg = nil
	self.mLastSendToWorld = 0
	self.RankMax = math.modf(TableData.massive[2804].value1)
    self.RankMaxStar = math.modf(TableData.massive[2805].value1)
end

function this:SetLastSendToWorldTime(value)
	self.mLastSendToWorld = value
end

function this:GetLastSendToWorldTime()
	return self.mLastSendToWorld
end


-- 设置当前频道id:好友id  , 世界频道: "world",开房间:"room"
function this:SetCutChannelId(cId, name)
	self.mCurtChatPlayer_Id = cId
	self.talkName = name
	self:ReadChannelMsg(cId)
	Message.Dispatch(MessageKey.RefreshRedPoint)
	--频道回复
end

function this:GetCurTalkName()
	return self.talkName
end

function this:GetLastTalkMsg()
	return self.lastTalkMsg
end

-- 获取当前频道id:好友id  , 世界频道: 0
function this:GetCutChannelId()		
	return self.mCurtChatPlayer_Id	
end

function this:OnReceivedMsg(msg)
	if msg.src_info == nil or msg.src_info.player_info == nil then
		return
	end
    local scr_name 		= msg.src_info.player_info.name
    local scr_fbname 		= msg.src_info.player_info.fbname
    local scr_level 		= msg.src_info.player_info.level
    local scr_icon		= msg.src_info.player_info.icon
    local scr_icon_url		= msg.src_info.player_info.icon_url
	local msg_data 		= msg.content.data
	local session_id    = msg.session_id
	local msg_id 		= msg.msg_id
    local scr_user_id   = msg.src_info.user_id	
    

    local isFriend = false
    local channel
    if string.find(session_id,"group_world") then
        channel = session_id
		table.insert( self.testMsgList, msg )  -- for test
		local msg_total = table.getn(self.testMsgList)
		if msg_total > self.mMaxShowMsgInBox then -- 上限100 条记录	
		    local tempTable = {}						
			for i ,v in ipairs(self.testMsgList) do
				local delta = msg_total - i
				if delta <  self.mMaxShowMsgInBox then
					table.insert(tempTable , v)
				end
			end
		    self.testMsgList = tempTable
		end
		if msg ~= nil and msg.content.type == "text" then
			self.lastTalkMsg = "<b>"..msg.src_info.player_info.name.."</b>".."："..msg.content.data
		elseif msg ~= nil and msg.content.type == "client_custom" then
			self.lastTalkMsg = "<b>"..msg.src_info.player_info.name.."</b>".."："..ChatData:GetRecruitText(msg.content.data.type, msg.content.data.curNum, msg.content.data.rankmin, msg.content.data.rankmax)
		end
	elseif string.find(session_id,"group_") then
		channel = session_id
    else
        channel = scr_user_id
        isFriend = true
	end
	
	Debug.Log("OnReceivedMsg groupid:"..channel)

	local chatMsgList = self:GetPlayerChatMsgList(channel)
	self:AddMsg(msg, chatMsgList, isFriend)
	
	Message.Dispatch(MessageKey.OnReceivedMsg)

	PlayerBaseInfoManager.AddOrUpdate(
		scr_user_id, 
		scr_name, 
		scr_level, 
		scr_icon, 
		scr_icon_url,
		scr_fbname, 
		msg.src_info.player_info.rank_score)

end

function this:GetTestMsgList() 
    if self.testMsgList ~= nil then
        return self.testMsgList
    else
        return nil
    end
end

function this:AddLocalMsg(msg, channel)
    local ChatMsgList = self:GetPlayerChatMsgList(channel)	

	if ChatMsgList ~= nil then 			
		table.insert(ChatMsgList.mMsgList, msg)
		local msg_total = table.getn(ChatMsgList.mMsgList)
		if msg_total > self.mMaxShowFriendMsgInBox then -- 上限30条记录	
		    local tempTable = {}						
			for i ,v in ipairs(ChatMsgList.mMsgList) do
				local delta = msg_total - i
				if delta <  self.mMaxShowFriendMsgInBox then
					table.insert(tempTable , v)
				end
			end			
		    ChatMsgList.mMsgList = tempTable
		end 	
		succ = true
		Message.Dispatch(MessageKey.OnReceivedMsg)
	else
        succ = false
	end		
end

function this:HaveUnReadMsg()
	local num = 0
	for i=1,#self.mPlayerChatList do
		if self.mPlayerChatList[i].mHaveUnReadMsg then
			num = num + self.mPlayerChatList[i].mHaveUnReadMsg
		end
	end
	return num	
end

function this:ChannelHaveUnReadMsg(channel)
	local ChatMsgList = self:GetPlayerChatMsgList(channel)	
	if ChatMsgList ~= nil then
		return ChatMsgList.mHaveUnReadMsg
	end
	return 0
end

function this:ReadChannelMsg(channel)
	local ChatMsgList = self:GetPlayerChatMsgList(channel)	
	if ChatMsgList ~= nil then
		ChatMsgList.mHaveUnReadMsg = 0
	end
end

function this:AddMsg(msg, ChatMsgList, isFriend)
    local succ = false
	if ChatMsgList ~= nil then 			
		table.insert(ChatMsgList.mMsgList, msg) 	
		local msg_total = table.getn(ChatMsgList.mMsgList)
		if msg_total > self.mMaxShowFriendMsgInBox then -- 上限30条记录	
		    local tempTable = {}						
			for i ,v in ipairs(ChatMsgList.mMsgList) do
				local delta = msg_total - i
				if delta <  self.mMaxShowFriendMsgInBox then
					table.insert(tempTable , v)
				end
			end			
		    ChatMsgList.mMsgList = tempTable
		end 	
		succ = true
		if isFriend == true then
			ChatMsgList.mHaveUnReadMsg = ChatMsgList.mHaveUnReadMsg + 1
			if ChatMsgList.mHaveUnReadMsg > self.mMaxShowFriendMsgInBox then
				ChatMsgList.mHaveUnReadMsg = self.mMaxShowFriendMsgInBox
			end
		end	
	else
        succ = false
	end		
end


-- function this:AddMsg(isself,isvoice, name, text,playerid,iconId,level,ChatMsgList)
--     local succ = false
-- 	if ChatMsgList ~= nil then 
-- 		local msg = MsgInfo:new(isself,isvoice, name, text,playerid,iconId,level)			
-- 		table.insert(ChatMsgList.mMsgList, msg) 	
--         succ = true
--         Debug.Log("chatMsgList AddMsg succ.  src_user_id="..playerid)			
-- 	else
-- 		succ = false
-- 	end		
-- end

function this:PushToMsgList(isself,isvoice, name, text,playerid,iconId,level,ChatMsgList)
	if ChatMsgList ~= nil then
		local msg = MsgInfo:new(isself,isvoice, name, text,playerid,iconId,level)				
		table.insert(ChatMsgList.mMsgList, msg) 
		local msg_total = table.getn(ChatMsgList.mMsgList)
		if msg_total > self.mMaxShowMsgInBox then -- 上限100 条记录	
		    local tempTable = {}						
			for i ,v in ipairs(ChatMsgList.mMsgList) do
				local delta = msg_total - i
				if delta <  self.mMaxShowMsgInBox then
					table.insert(tempTable , v)
				end
			end			
		    ChatMsgList.mMsgList = tempTable
		end		       							
	end	
end

function this:CreatFriendChannel(friendID)	
	local cList = {}
	local cInfo = ChatPoolInfo:new(friendID, cList)
	table.insert(self.mPlayerChatList, cInfo) 
	return cInfo	
end

function this:GetPlayerChatMsgList(channelId)
	local playerChatList = self:GetPlayerChatInfo(channelId)
	if playerChatList == nil then
		playerChatList = self:CreatFriendChannel(channelId)
	end	
	return playerChatList
end

--获取 好友聊天 历史列表
function this:GetPlayerChatInfo(channelId)
	for i=1,#self.mPlayerChatList do
		if self.mPlayerChatList[i].mFriendID ==  channelId then
			return self.mPlayerChatList[i]
		end
	end	
	return nil	
end

function this:RemovePlayerChatInfo(channelId)
	Debug.Log('RemovePlayerChatInfo channelId'..channelId)
	local tempTable = {}
	for i=1,#self.mPlayerChatList do
		if self.mPlayerChatList[i].mFriendID ~=  channelId then
			table.insert(tempTable, self.mPlayerChatList[i])
			Debug.Log('live channelId'..self.mPlayerChatList[i].mFriendID)
		end
	end
	self.mPlayerChatList = tempTable;
	Message.Dispatch(MessageKey.RefreshRedPoint)
end

function this:OnCreateGroup(group_id)
	self.mCurGroupId = group_id
end

function this:GetCurGroupId()
	return self.mCurGroupId
end


function this:GetRecruitText(type, curnum, rankmin, rankmax)
	if type == 2 then
		return GameInstance.GetFormatString(TableData.game_mode[type].recruit_text_id, self:GetTextByRankId(rankmin, rankmax), curnum)
	else
		return GameInstance.GetFormatString(TableData.game_mode[type].recruit_text_id, curnum)
	end
end

function this:GetTextByRankId(min, max)
    local ret = ""
    for id = min, math.min(max, self.RankMax - 1) do
        local record = TableData.rank_big[id]
        if record == nil then
            Debug.LogError(string.format("TableData.rank_big[%d] = nil", id))
        else
            ret = ret .. LanguageMgrInst:GetString(record.limit_language_id) .. " "
        end
    end

    local l, r = math.max(self.RankMax, min), max
    if l <= r then
        -- 1-25, 26-50, 51-75, 76-100
        local minStar = (l - self.RankMax) * self.RankMaxStar + 1
        local maxStar = (r + 1 - self.RankMax) * self.RankMaxStar
        if minStar == 1 then minStar = 0 end -- 1特殊处理成0
        local record = TableData.rank_big[self.RankMax]
        ret = ret .. LanguageMgrInst:GetFormatString(record.limit_language_id, tostring(minStar), tostring(maxStar))
    end
    
    return ret
end


ChatData = this.new()