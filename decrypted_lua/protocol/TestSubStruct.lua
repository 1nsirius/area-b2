--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

TestSubStruct = class("TestSubStruct")
local this = TestSubStruct

function this:ctor(parser)
	self.parser = parser
end

function this:Parse()
	self.parser:RequireString()
	self.name = coroutine.yield()
	self.parser:RequireU32();
	self.age = coroutine.yield()
	self.parser:RequireFinish()
end