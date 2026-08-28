--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

require 'protocol/ProtocolBuilder'

local this = class("ProtocolFactory")

protocol_factory = this.new()

function this:NewPkg(pid, parser)
	if(self[pid] == nil) then
		print ("error! not regist pkg id : " .. pid)
		return nil
	else
		return self[pid].new(parser)
	end
end

-- 全局静态函数, 供c#使用
function NewBuilder(pid, parser)
	return ProtocolBuilder.new( protocol_factory:NewPkg(pid, parser))
end