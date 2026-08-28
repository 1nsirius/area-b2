--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

LinkedList = class("LinkedList")

local this = LinkedList

function this:ctor()
	self:Clear()
end

function this:Insert2Empty(v)
	local new_node = {pre = nil, v = v, next = nil} 
	self.head_node = new_node
	self.rear_node = new_node
	self.count = self.count + 1
end

function this:AddFirst(v)
	if(self.head_node == nil) then
		self:Insert2Empty(v)
	else
		self:AddBefore(self.head_node, v)
	end
end

function this:AddLast(v)
	if(self.rear_node == nil) then
		self:Insert2Empty(v)
	else
		self:AddAfter(self.rear_node, v)
	end
end

function this:AddBefore(node, v)
	if(not node) then error('LinkedList.AddBefroe argument is null') end
	local new_node = { pre = node.pre, v = v, next = node}
	if(node == self.head_node) then 
		self.head_node = new_node
	else
		node.pre.next = new_node 
	end
	node.pre = new_node
	self.count = self.count + 1
end

function this:AddAfter(node, v)
	if(not node) then error('LinkedList.AddAfter argument is null') end
	local new_node = {pre = node, v = v, next = node.next}
	if(node == self.rear_node) then
		self.rear_node = new_node
	else
		node.next.pre = new_node
	end
	node.next = new_node
	self.count = self.count + 1
end

function this:Clear()
	self.head_node = nil
	self.rear_node = nil
	self.count = 0
end

function this:RemoveFirst()
	if(self.head_node == nil) then return end

	if(self.head_node == self.rear_node) then 
		self:Clear()
	else
		self.head_node = self.head_node.next
		self.head_node.pre = nil
		self.count = self.count - 1
	end
end

function this:RemoveLast()
	if(self.head_node == nil)then return end

	if(self.head_node == self.rear_node) then
		self:Clear()
	else
		self.rear_node = self.rear_node.pre
		self.rear_node.next = nil
		self.count = self.count - 1
	end
end

function this:RemoveNode(node)
	if(not self.head_node) then return end

	if(self.head_node == self.rear_node) then
		self:Clear()
	elseif(self.head_node == node) then
		self:RemoveFirst()
	elseif(self.rear_node == node) then
		self:RemoveLast()
	else
		node.pre.next = node.next
		node.next.pre = node.pre
		self.count = self.count - 1
	end
end

function this:Remove(v)
	local crt = self.head_node

	while(crt ~= nil) do
		if(v == crt.v) then
			self:RemoveNode(crt)
			return
		end
		crt = crt.next
	end
end

function this:Foreach(func)
	self:Foreach_Endable(function(...)
		func(...)
	end)
end

function this:Foreach_Endable(func)
	if(func == nil) then return end

	local crt = self.head_node

	local _end = false

	while(crt ~= nil and not _end) do
		_end = func(crt.v)
		crt = crt.next
	end
end

function this:GetFirst()
	if(self.head_node == nil) then 
		return nil 
	else
		return self.head_node.v
	end
end

function this:GetLast()
	if(self.rear_node == nil) then 
		return nil 
	else
		return self.rear_node.v
	end
end

function this:Count()
	return self.count
end