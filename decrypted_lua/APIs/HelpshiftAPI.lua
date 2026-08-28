HelpshiftAPI = {}
local this = HelpshiftAPI

--[[开启hs]]
function this.FAQ(tags)
    if EjoysdkManager == nil then return end

    --print(tags)
    local HS = require 'ejoysdk_lua.vendors.helpshift'
    local Tags = {"login","hall","loading"}

    tags = tags or Tags
    local value = tags
    if type(tags) == "string" then
      value = {}
      table.insert(value,tags)
    end

    local meta_data = nil
    local info = GameInstance:GetPlayerInfo()
    if info == nil then
      meta_data = {
        account = "",
        playid = "",
        playname = "",
        servername = ""
      }
    end

    if meta_data == nil then
      meta_data = {
        account = info.account_id or "",
        playid = info.player_id or "",
        playname = info.player_name or "",
        servername = info.server_id or "",
      }
    end

    PrintTable(meta_data)
    HS.show_faq(value, nil, meta_data)
end