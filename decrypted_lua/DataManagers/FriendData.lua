local this = class("FriendData")
local logger = Logger.new("FriendData")

StateColor = {
	OffLine = Color(0.7686275, 0.8392157, 0.8784314, 1),
	OnLine = Color(0.3019608, 0.8235294, 0.3019608, 1),
	InTeam = Color(0.7803922, 0.2705882, 0.2705882, 1),
	InMatch = Color(0.7960784, 0.6470588, 0.2470588, 1),
	InBattle = Color(0.827451, 0.3843137, 0.227451, 1),
	Other = Color(0.827451, 0.3843137, 0.227451, 1),
}

local function _AddOrUpdatePlayerInfo(...)
	PlayerBaseInfoManager.AddOrUpdate(...)
end

local function _GetWeight(data)
	local weight = string.IsNullOrEmpty(data.player_info.fbname) and 0 or -5
    if data.player_info.state == HallBattleState.InHall then 
        weight = weight + (-10)
	end

	if data.player_info.state == HallBattleState.InMatch then
		weight = weight + (30)
	end

	if data.player_info.state == HallBattleState.InBattleNotStart or data.player_info.state == HallBattleState.InBattleStarted then
		weight = weight + (50)
	end

    if data.player_info.state == HallBattleState.Offline then
        weight = weight + (100)
    end
    return weight
end

local function _comp(l, r)
    local lWeight = _GetWeight(l)
    local rWeight = _GetWeight(r)
	if lWeight == rWeight then
		return l.player_info.name > r.player_info.name
	else
		return lWeight < rWeight
	end
end

function this:ctor(...)
    self.friendIdList = {}
    self.friendList = {}
    self.fbFriendList = {}
    self.applyFriendList = {}
	self.addFriendList = {}
	self.searchPlayerInfoList = {}
end

function this:Logout()
    self.friendIdList = {}
    self.friendList = {}
    self.fbFriendList = {}
    self.applyFriendList = {}
	self.addFriendList = {}
	self.searchPlayerInfoList = {}
end

function this:ApplyAddFriendResp(player_id,succ,...)
	if succ then
		--提交添加申请 成功 + 刷新列表	
		HUDTextShower.AddNormalTextEntity(300)
	else
		local code, msg = ...
		self:ShowErrorCode(...)
	end
end

--设置好友列表 table
function this:GetFriendIdListResp(succ,...)
	if succ then
		--获取好友 id 列表 成功
		self.friendIdList = ...
		logger:Log("GetFriendIdListResp:"..table.tostring(self.friendIdList))
	else
		local code, msg = ...
		logger:Log("GetFriendIdListResp failure:","code",code,"msg",msg)
	end
end

--获取好友id列表 table
function this:GetFriendIdList()
	return self.friendIdList
end

function this:GetFriendInfoListResp(succ,...)
	if succ then	
		self.friendList = ...
		logger:Log("GetFriendInfoListResp:"..table.tostring(self.friendList))
		for _, v in ipairs(self.friendList) do
			self:TrySetFriendFBInfo(v)
			_AddOrUpdatePlayerInfo(
				v.player_id, 
				v.player_info.name, 
				v.player_info.level, 
				v.player_info.icon, 
				v.player_info.icon_url,
				v.player_info.fbname, 
				v.player_info.rank_score)
		end
		table.sort(self.friendList, _comp)
    else 
		self.friendList = {}
	end
	Message.Dispatch(MessageKey.OnRefreshFriendinfoList)
end

--获取好友列表 table
function this:GetFriendList()	
	if GameInstance.systemInfo.IsMobilePlayer() == false then
		-- 测试数据
		local result = {}
		for i=1,10 do
			local friendListElement = {
				player_id = i,
				player_info = {},
			}
			friendListElement.player_info.name = i == 2 and "" or tostring(i).."test_name"..tostring(i);
			friendListElement.player_info.fbname = nil;
			friendListElement.player_info.state = i % 8;
			friendListElement.player_info.level = 1;
			friendListElement.player_info.icon = 1;
			friendListElement.player_info.icon_url = "";
			friendListElement.player_info.rank_score = i * 1000;
			table.insert(result, friendListElement)
		end
		table.sort(result, _comp)
		for _, friend in pairs(result) do
			self:TrySetFriendFBInfo(friend)
		end
		return self:FilterNonameFriend(result)
	end

	local result = self.friendList	
	if result == nil then
		return {}
	else
		for _, friend in pairs(result) do
			self:TrySetFriendFBInfo(friend)
		end
		return self:FilterNonameFriend(result)
	end
end

function this:FilterNonameFriend(friends) 
	local newFriends = {}
	for _, friend in pairs(friends) do
		if string.IsNullOrEmpty(friend.player_info.name) == false then
			table.insert(newFriends, friend)
		end
	end
	return newFriends
end

function this:TrySetFriendFBInfo(friendInfo)
	local fbFriendInfo = self:TryGetFBFriend(friendInfo.player_id)
	if fbFriendInfo ~= nil then
		friendInfo.player_info.fbname = fbFriendInfo.player_info.fbname
		friendInfo.player_info.icon_url = fbFriendInfo.player_info.icon_url
	end
end

--接受申请好友结果回复
function this:AcceptFriendResp(player_id,succ,...)
  
	if succ then
		--同意好友申请 成功 + 刷新好友列表 + 刷新申请列表
		logger:Log("同意好友申请 成功 + 刷新好友列表 + 刷新申请列表")
		FriendAPI.GetFriendApplys()
		FriendAPI.GetFriendList()
	else
		local code, message = ...
		logger:Log('同意好友申请 失败, code: ' .. code .. ' ,msg: ' ..message)
		self:ShowErrorCode(...)
	end
end

function this:ShowErrorCode(...)
	local code, message = ...
	logger:Log("ShowErrorCode:"..code)
	if tonumber(code) == 20000 then
		logger:Log("好友已存在 ShowErrorCode:"..code)
		-----好友已存在
		HUDTextShower.AddNormalTextEntity(304)
	elseif tonumber(code) == 20002 then
		-----	已存在好友申请
		HUDTextShower.AddNormalTextEntity(306)
	elseif tonumber(code) == 20012 then
		-----	自己好友数量已达上限
		HUDTextShower.AddNormalTextEntity(302)
	elseif tonumber(code) == 20009 then
		-----	对方好友数量已达上限
		HUDTextShower.AddNormalTextEntity(307)
	elseif tonumber(code) == 20017 then
		-----	对方好友申请已达上限
		HUDTextShower.AddNormalTextEntity(303)
	elseif tonumber(code) == 20010 then
		-----	操作对象不能不能是自己
		HUDTextShower.AddNormalTextEntity(305)
	end
end

function this:GetApplyListResp(succ,...)
	
	-- local applyCount = 0
    if succ then
        logger:Log('获取好友申请列表 table 成功'..table.tostring(...))
		local list = ...
		self.applyFriendList = list
		
		for i = 1, #self.applyFriendList do
			local data = self.applyFriendList[i]
			if data ~= nil and data.player ~= nil then
				_AddOrUpdatePlayerInfo(
				data.player.player_id, 
				data.player_info.name, 
				data.player_info.level, 
				data.player_info.icon, 
				data.player_info.icon_url,
				data.player_info.fbname, 
				data.player_info.rank_score)
			end
		end	
		Message.Dispatch("GetApplyListSucc")
		-- applyCount = table.getn(self.applyFriendList)
	else
		local code, error_msg = ...
	end
			
	-- if self.DelegateGetApplyListResp ~= nil then		
	-- 	self.DelegateGetApplyListResp(succ)	
	-- end

	-- --推送是否有好友申请
	-- if applyCount > 0 then
	-- 	SDK.EjoySDKManager.Instance:OnHasFriendApply(true)	
	-- else
	-- 	SDK.EjoySDKManager.Instance:OnHasFriendApply(false)	
	-- end
end

--删除好友结果回复
function this:DeleteFriendResp(player_id,succ,...)
	if succ then
		--删除好友 成功 + 刷新列表
		FriendAPI.GetFriendList()
		ChatData:RemovePlayerChatInfo(player_id)
	else
		local code, message = ...
	end
	
	-- if self.DelegateDelFriendResp ~= nil then		
	-- 	self.DelegateDelFriendResp(player_id,succ)	
	-- end
end

--获取申请做好友的列表 table
function this:GetApplyList()
	local result = self.applyFriendList
	if result == nil then
		return {}
	else
		return result
	end
end

function this:RefuseFriendResp(player_id,succ, ...)
	if succ then
		FriendAPI.GetFriendApplys()
	else
		local code, message = ...
		logger:Log('拒绝好友申请 失败, code: ' .. code .. ' ,msg: ' ..message)
		self:ShowErrorCode(...)
	end
end

--设置查询玩家的信息 player_id, table
function this:FindPlayerInfoResp(succ,...)
	local player_id =""
	local player_info = nil
	if succ then
		logger:Log('搜索 成功')
		local player_info_list = ...	
		logger:Log("player_info_list size:"..#player_info_list)
		logger:Log("FriendData:get player_info_list succ "..table.tostring(player_info_list))
		if player_info_list ~= nil and #(player_info_list) > 0 then	
			self.searchPlayerInfoList = player_info_list		
			Message.Dispatch(MessageKey.OnSearchPlayerRet)	
			for i = 1, #(player_info_list) do
				local data = player_info_list[i]
				_AddOrUpdatePlayerInfo(
					data.player_id, 
					data.player_info.name, 
					data.player_info.level, 
					data.player_info.icon, 
					data.player_info.icon_url,
					data.player_info.fbname, 
					data.player_info.rank_score)
			end		
		else
			HUDTextShower.AddNormalTextEntity(301)
			logger:Log('搜索结果 empty ' )
		end		
	else
		local code, error_msg = ...
		logger:Log('搜索 失败, code: ' .. code .. ' ,error_msg: ' .. error_msg)
	end
end


function this:GetSearchPlayers()
	local result = self.searchPlayerInfoList
	if result == nil then
		return {}
	else
		return result
	end
end

function this:ClearSearchPlayers()
	self.searchPlayerInfoList = {};
end

function this:GetPlayerInfos(playerIds)
		local player_ids = {}
		for i=0,playerIds.Count-1 do
			table.insert(player_ids, tostring(playerIds[i]))
		end
		
		if LuaEjoySDKManager == nil then
			return
		end
		LuaEjoySDKManager.GetPlayerInfos(player_ids, function(succ, ...)
			if succ then
					local player_infos = ...
					local result = {}
					for _, player_info in pairs(player_infos) do
						-- 如果玩家不存在，那么只会返回 player id，其他字段都会返回空
						local player_id = player_info.player_id
						local server_id = player_info.server_id or '' -- 玩家服务器 id
						local detail = player_info.player_info -- 玩家具体的信息
						if detail ~= nil then
							detail.player_id = player_id
							table.insert(result, detail)
						end
					end
					-- XClient.LuaFriendDataManager.Instance:OnGetPlayerInfos(result)
			else
				local code, error_msg = ...
			end
		end)
end

function this:Recev_InfoFriendInfoChange(change_msgs)
	--log('收到好友信息更新消息 成功')
	logger:Log("Recev_InfoFriendInfoChange:"..table.tostring(change_msgs))
    for _, msg in pairs(change_msgs) do
        local player_info_list = msg.player_info_list 
        for _, player_info in pairs(player_info_list) do
			for i=1,#self.friendList do
				if self.friendList[i].player_id == player_info.player_id then
					self.friendList[i].player_info = player_info.player_info
					self.friendList[i].player_id = player_info.player_id
				end
			end

			for i=1,#self.fbFriendList do
				if self.fbFriendList[i].player_id == player_info.player_id then
					self.fbFriendList[i].player_info = player_info.player_info
					self.fbFriendList[i].player_id = player_info.player_id
				end
			end
        end
	end
	Message.Dispatch(MessageKey.OnRefreshFriendinfoList)
end

function this:Recev_InfoFriendDel(del_msgs)
	logger:Log("Recev_InfoFriendDel:"..table.tostring(del_msgs))
    for _, msg in pairs(del_msgs) do
		local player = msg.player 
        ChatData:RemovePlayerChatInfo(player.player_id)
	end
	Message.Dispatch(MessageKey.OnRefreshFriendinfoList)
end


-- 通过Id判断是不是好友
function this:IsMyFriendById(id)
	local friendTable = self:GetFriendList()
	if friendTable~= nil then
		for i=1,#friendTable,1 do
			if friendTable[i].player_id == id then
				return true
			end
		end
	end
	return false
end

function this:GetStateText(state)
	if state == HallBattleState.Offline then return GameInstance.GetString(51012), StateColor.OffLine end
	if state == HallBattleState.InHall then return GameInstance.GetString(51000), StateColor.OnLine end
    if state == HallBattleState.InTeam or state == HallBattleState.InRoom then return GameInstance.GetString(51014), StateColor.InTeam end
	if state == HallBattleState.InMatch then return GameInstance.GetString(51015), StateColor.InMatch end
    if state == HallBattleState.InBattleNotStart or state == HallBattleState.InBattleStarted then return GameInstance.GetString(51001), StateColor.InBattle end
    --return "Unknown", StateColor.Other
	return GameInstance.GetString(51012), StateColor.OffLine
end

----------------------------------------------------------- Facebook Begin -----------------------------------------------------------
-- 调用fb列表获取接口后的回调处理
function this:GetFBFriendInfoListResp(succ,...)
	if succ then
		self.fbFriendList = {}
		local tmpList = ...
		logger:Log('GetFBFriendInfoListResp 1 '..table.tostring(tmpList))
		if tmpList ~= nil then
			for i=1,table.getn(tmpList),1 do
				if tmpList[i] ~= nil then
					logger:Log('GetFBFriendInfoListResp 2 '..table.tostring(tmpList[i]))
					if tmpList[i].account_info ~= nil then
						logger:Log('GetFBFriendInfoListResp 3 '..table.tostring(tmpList[i].account_info))
						if tmpList[i].account_info.official_info ~= nil and tmpList[i].account_info.official_info.last_login_player then	
							local lastLoginPlayer = tmpList[i].account_info.official_info.last_login_player
							local fbFriendListElement = {}
							fbFriendListElement.player_info = lastLoginPlayer.player_info or {}
							fbFriendListElement.player_id = lastLoginPlayer.player_id
							fbFriendListElement.player_info.account_id = tmpList[i].account_info.account_id
							fbFriendListElement.player_info.player_id = lastLoginPlayer.player_id
							fbFriendListElement.player_info.server_id = lastLoginPlayer.server_id
							fbFriendListElement.player_info.fbid = tmpList[i].channel_ext_info.id
							fbFriendListElement.player_info.fbname = tmpList[i].channel_ext_info.name

							logger:Log('GetFBFriendInfoListResp 4 '..table.tostring(fbFriendListElement))
							table.insert(self.fbFriendList, fbFriendListElement)	

							local v = fbFriendListElement
							_AddOrUpdatePlayerInfo(
								v.player_id, 
								v.player_info.name, 
								v.player_info.level, 
								v.player_info.icon, 
								v.player_info.icon_url,
								v.player_info.fbname, 
							 	v.player_info.rank_score)
						end
					end				
				end
			end
		end
		table.sort(self.fbFriendList, _comp)
		logger:Log('GetFBFriendInfoListResp succ '..table.tostring(self.mFBList))
	else
		local code, msg = ...
		logger:Log('GetFBFriendInfoListResp failure '.. tostring(code) .. ' ,error message: ' .. msg )
	end
	Message.Dispatch(MessageKey.OnRefreshFBFriendinfoList)
end

--获取fb好友列表 table
function this:GetFBFriendList()	
	if GameInstance.systemInfo.IsMobilePlayer() == false then
		-- 测试数据
		local result = {}
		for i=1,10 do
			local friendListElement = {
				player_id = i==1 and 1 or 1000+i,
				player_info = {},
			}
			friendListElement.player_info.name = i == 2 and "" or "test_name"..tostring(i);
			friendListElement.player_info.fbname = "test_fbname_fffffffffffffxxxxxxxxxx";
			friendListElement.player_info.state = i % 3;
			friendListElement.player_info.level = 1;
			friendListElement.player_info.icon = 1;
			friendListElement.player_info.icon_url = "http://www.gaoxiaogif.com/d/file/201707/5aa5bcd5c98223436d32746e045881f1.jpg";
			friendListElement.player_info.rank_score = i;
			table.insert(result, friendListElement)
		end
		table.sort(result, _comp)
		return self:FilterNonameFriend(result)
	end

	local result = self.fbFriendList	
	if result == nil then
		result {}
	end

	--logger:Log("GetFBFriendList", table.tostring(result))
	return self:FilterNonameFriend(result)
end

function this:TryGetFBFriend(playerId)
	local fbFriends = self:GetFBFriendList()
	for _,fbFriend in pairs(fbFriends) do
		if fbFriend.player_id == playerId then
			return fbFriend
		end
	end
	return nil
end

--设置Facebook 添加好友通知
function this:Recev_FBFriendAdd(add_msgs)
	logger:Log('recev add FB friend', table.tostring(add_msgs))
	for _, add_msg in ipairs(add_msgs) do		
		local showName = add_msg.account_info.official_info.last_login_player.player_info.name				 
		local text = GameInstance.GetFormatString(57101, EVendors.FB:GetDisplayName(), showName)
		logger:Log('add FB friend '.. showName .. "   " ..text)	
    	AlertManager.Instance:ShowDlg("", text, GameInstance.GetString(53204), nil)
    end
end

--Facebook好友信息变化
function this:Recev_FBFriendChange(info_change_msgs)
	logger:Log('update FB friend list', table.tostring(info_change_msgs))	
    --更新操作
	for _, info_change_msg in ipairs(info_change_msgs) do
		local player_info = info_change_msg.account_info.official_info.last_login_player
		for i=1,#self.fbFriendList do
			if player_info ~= nil and self.fbFriendList[i].player_id == player_info.player_id then
				self.fbFriendList[i].player_info = player_info.player_info
				self.fbFriendList[i].player_id = player_info.player_id
			end
		end
	end
	--通知上层刷新
	Message.Dispatch(MessageKey.OnRefreshFBFriendinfoList)
end
----------------------------------------------------------- Facebook End -----------------------------------------------------------

--获取所有
function this:GetAllFriendList()
	local result = {}
	table.addrange(result, self:GetFBFriendList())
	for _,v in pairs(self:GetFriendList()) do
		local findIndex = table.indexOf(result,v,function(v1, v2)
			return v1.player_id == v2.player_id
		end)
		if findIndex == -1 then
			table.insert(result,v)
		end
	end
	for _,v in pairs(result) do
		_AddOrUpdatePlayerInfo(
			v.player_id, 
			v.player_info.name, 
			v.player_info.level, 
			v.player_info.icon, 
			v.player_info.icon_url,
			v.player_info.fbname, 
			v.player_info.rank_score)
	end
	table.sort(result, _comp)
	return result
end

function this:SortFriendData()
    self.data = {}
    for i, v in ipairs(self:GetFriendList()) do
        v.sortIndex = i
        table.insert(self.data, v)
    end

	table.sort(self.data, _comp)
	
	self.friendList = self.data
end


FriendData = this.new()
