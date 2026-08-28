--跑马灯，实时通知数据
local RealtimeNoticeInfo = {
	id = 1,				--唯一ID，如果中台不下发，自己维护
	type = 1,			--1、仅在主界面显示   2、在主界面、匹配界面和局内显示
	content = "",		--内容
	timeStamp = 0,		--时间戳，单位秒
	loop = false,		--是否循环
	loopTimes = 3		--剩余次数
}
RealtimeNoticeInfo.__index = RealtimeNoticeInfo

function RealtimeNoticeInfo:new(id, type, content, timeStamp, loop, loopTimes)
    local res = {}
	res.__index = res
	setmetatable(res, RealtimeNoticeInfo)
	res.id = id
    res.type = type or 1
	res.content = content or ""
    res.timeStamp = timeStamp or 0
    res.loop = loop or false
	res.loopTimes = loopTimes or 0
    return res
end

local this = class("RealtimeNoticeData")

function this:ctor(...)
	--首次列表，里面所有项只会播放一次，如果有循环项则扔进下面的循环列表
	self.normalList = {}
	--循环列表
	self.loopList = {}
end

local function SendOnNewRealtimeNoticeInfoMessage()
	Message.Dispatch(MessageKey.OnNewRealtimeNoticeInfo)
end

function this:GenerateTestData()
	--self:AddToNormalList(RealtimeNoticeInfo:new(1,1,'[{"key":"zh-hans","value":"哦哦"},{"key":"en","value":"haha"}]'
	--,1,true,-1))
	-- self:AddToNormalList(RealtimeNoticeInfo:new(2,2,"测试跑马灯2，类型2，时间戳2，循环3次，AJDGJDJDGJD"
	-- ,2,true,3))
	-- self:AddToNormalList(RealtimeNoticeInfo:new(3,1,"测试跑马灯3，类型1，时间戳3，循环3次，AJDGJD3673567GSDFGJDGJD"
	-- ,3,true,3))
	-- self:AddToNormalList(RealtimeNoticeInfo:new(4,2,"测试跑马灯4，类型2，时间戳4，不循环，AJDGJDJDSD554764FGSDFSDFGSDFGSDFGSDFGSDGJD"
	-- ,4,false,0))
	SendOnNewRealtimeNoticeInfoMessage()
end

function this:OnReceivedMsg(msg)
	print("msg == nil", msg == nil)
	print("msg.content == nil", msg.content == nil)
	print("msg.content.data == nil", msg.content.data == nil)
	if msg == nil or msg.content == nil or msg.content.data == nil then
		return
	end
	local data = msg.content.data
	print("msg.msg_id",msg.msg_id)
	for _,v in pairs(self.normalList) do
		if v.id == msg.msg_id then
			print("已有相同msg_id: ",msg.msg_id)
			return
		end
	end
	for _,v in pairs(self.loopList) do
		if v.id == msg.msg_id then
			print("已有相同msg_id: ",msg.msg_id)
			return
		end
	end
	print("data.type",data.type)
	print("data.content",data.content)
	print("msg.ts",msg.ts)
	print("data.loop",data.loop)
	print("data.loopTimes",data.loopTimes)
	local info = RealtimeNoticeInfo:new(msg.msg_id, data.type, data.content, msg.ts, data.loop, data.loopTimes)
	self:AddToNormalList(info)
	SendOnNewRealtimeNoticeInfoMessage()
end


local function _compareInfo(info1, info2)
	if info1.type ~= info2.type then
		return info1.type > info2.type
	else
		return info1.timeStamp < info2.timeStamp
	end
end

function this:AddToNormalList(info)
	table.insert(self.normalList, info) 
	table.sort(self.normalList, _compareInfo)
end

function this:AddToLoopList(info)
	table.insert(self.loopList, info)
end

local function _CheckType(info, type)
	if type == nil then
		return true
	end
	if info.type == type then
		return true
	end
	return false
end

--先不从列表移除，除非调用方再次调用PlayComplete，再执行删除操作
--type设为nil则是拿所有类型
function this:GetOne(type)
	local info = nil
	if #self.normalList > 0 then
		for i=1,#self.normalList do 
			info = self.normalList[i]
			if info ~= nil and _CheckType(info, type) then
				return info
			end
		end
	end
	if #self.loopList > 0 then
		for i=1,#self.loopList do 
			info = self.loopList[i]
			if info ~= nil and _CheckType(info, type) then
				return info
			end
		end
	end
	return info
end

--调用方成功播放完成必须调用
function this:PlayComplete(id)
	local info = nil
	for i=#self.normalList,1,-1 do 
		if self.normalList[i] ~= nil and self.normalList[i].id == id then
			info = self.normalList[i]
			table.remove(self.normalList, i)
		end
	end
	if info ~= nil then
		--在非循环列表里
		if info.loop then
			if info.loopTimes > 1 then
				info.loopTimes = info.loopTimes - 1
				self:AddToLoopList(info)
			elseif info.loopTimes < 0 then	--小于0则为无限循环
				self:AddToLoopList(info)
			end
		end
	else
		--在循环列表里
		for i=#self.loopList,1,-1 do 
			if self.loopList[i] ~= nil and self.loopList[i].id == id then
				info = self.loopList[i]
				table.remove(self.loopList, i)
			end
		end
		if info ~= nil then
			if info.loopTimes > 1 then
				info.loopTimes = info.loopTimes - 1
				self:AddToLoopList(info)
			elseif info.loopTimes < 0 then	--小于0则为无限循环
				self:AddToLoopList(info)
			end
		end
	end
end

RealtimeNoticeData = this.new()