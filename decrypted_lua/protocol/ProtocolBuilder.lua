--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion
require 'protocol/StructBuilder'

ProtocolBuilder = class("ProtocolBuilder", StructBuilder)
local this = ProtocolBuilder

function this:Process()
	self.pkg:Process()
end