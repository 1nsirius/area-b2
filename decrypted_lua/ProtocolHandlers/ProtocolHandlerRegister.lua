require "ProtocolParser"
require "ProtocolHandlers/LobbyProtocolHandler"
require "ProtocolHandlers/BattleProtocolHandler"

ProtocolHandlerRegister = {}
local this = ProtocolHandlerRegister


function this.RegisterProtocols()
   ProtocolParser.RegisterProtocol(LobbyProtocolHandler)
   ProtocolParser.RegisterProtocol(BattleProtocolHandler)
end