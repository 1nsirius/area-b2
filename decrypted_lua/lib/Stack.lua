--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion


Stack = class("Stack")

local this = Stack

function this:ctor()
	self.list = LinkedList.new()
end

function this:Push(v)
	self.list:AddLast(v)
end

function this:Pop()
	local ret = self:Peek()
	self.list:RemoveLast()
	return ret
end

function this:Peek()
	return self.list:GetLast()
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