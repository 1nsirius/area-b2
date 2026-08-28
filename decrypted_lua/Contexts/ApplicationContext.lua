local appContext = {}

local M = appContext

M.serviceContainer = nil

function M.Init()
    local serviceLocator = require 'Common.ServiceLocator.ServiceLocator'
    local locatorProvider = require 'Common.ServiceLocator.ServiceProvider'
    serviceLocator.SetLocatorProvider(locatorProvider)

    M.serviceContainer = serviceLocator.Current()
end

function M.GetContainer()
    return M.serviceContainer
end

return M