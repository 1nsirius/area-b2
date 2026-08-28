--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

Queue = class("Queue")

local this = Queue

function this:ctor()
	self.list = LinkedList.new()
end

function this:Enqueue(v)
	self.list:AddLast(v)
end

function this:Dequeue()
	local ret = self.list:GetFirst()
	self.list:RemoveFirst()
	return ret
end

function this:Count()
	return self.list:Count()
end

function this:Clear()
	self.list:Clear()
end

function this:Foreach(func)
	self.list:Foreach(func)
end