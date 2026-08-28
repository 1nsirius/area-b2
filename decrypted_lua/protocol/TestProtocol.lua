--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

require "protocol/ProtocolBuilder"
require "protocol/ProtocolFactory"
require "Protocol/TestSubStruct"

TestProtocol = class("TestProtocol")
local this = TestProtocol

this.pID = 1

protocol_factory[this.pID] = this

function this:ctor(parser)
	self.parser = parser
end

function this:Parse()
	self.parser:RequireOptations(1)
	coroutine.yield()
	-- string
	self.parser:RequireString()
	self.name = coroutine.yield()
	-- 自定义结构
	self.subData = TestSubStruct.new(self.parser)
	self.parser:RequireStruct(StructBuilder.new(self.subData))
	coroutine.yield()

	-- u32
	self.parser:RequireU32()
	self.age = coroutine.yield()

	-- 数组
	self.parser:RequireU32()
	local n = coroutine.yield()
	self.arr = {}
	for i=1, n, 1 do
		self.parser:RequireU32()
		table.insert(self.arr, coroutine.yield() )
	end

	-- optation
	if(self.parser:CheckOptation(1)) then
		-- 解析子结构
	end
	
	-- 通知c#解析结束
	self.parser:RequireFinish()
end

-- 非自动生成代码
function this:Process()
	print_table(self)
end

