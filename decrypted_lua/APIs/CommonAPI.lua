CommonAPI = {}
local this = CommonAPI

function this.ClearGamePlayModeUIState()
    local serviceContainer = Context.GetServiceContainer()
    local lobbyContex = serviceContainer.GetInstance(ServiceNames.LobbyStateService)
    lobbyContex.SetGamePlayModeUIOpend(false)
end
