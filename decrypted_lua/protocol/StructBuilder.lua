--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion


StructBuilder = class("StructBuilder")
local this = StructBuilder

function this:ctor(pkg)
	self.pkg = pkg
	local coroutine_wrap = coroutine.wrap(function(...) 
		self.pkg:Parse(...)
	end)

	self.wrap = coroutine_wrap
end

function this:Resume()
	self.wrap()
end

function this:ResumeNull()
	self.wrap(nil)
end

function this:ResumeBool(val)
	self.wrap(val)
end

function this:ResumeDouble(val)
	self.wrap(val)
end

function this:ResumeString(val)
	self.wrap(val)
end