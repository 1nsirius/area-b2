-- Local SDK-login server list for no-iptables builds.
local ip = "127.0.0.1"
local custom_port = nil

local function get_dynamic_server_info()
    local candidates = {}
    if CS and CS.UnityEngine and CS.UnityEngine.Application then
        table.insert(candidates, CS.UnityEngine.Application.persistentDataPath .. "/File/local_server_ip.txt")
        table.insert(candidates, CS.UnityEngine.Application.persistentDataPath .. "/File/dev_hotupdate.txt")
    end
    table.insert(candidates, "/sdcard/Android/data/com.qookka.areaf2/files/File/local_server_ip.txt")
    table.insert(candidates, "/storage/emulated/0/Android/data/com.qookka.areaf2/files/File/local_server_ip.txt")

    for _, path in ipairs(candidates) do
        local f = io.open(path, "r")
        if f then
            local raw = f:read("*a")
            f:close()
            if type(raw) == "string" then
                local clean = raw:match("^%s*(.-)%s*$")
                local clean_no_proto = clean:gsub("^https?://", "")
                local host_match, port_match = clean_no_proto:match("^([^:/%s]+):?(%d*)$")
                if host_match and host_match ~= "" then
                    local p = (port_match ~= "" and port_match ~= nil) and tonumber(port_match) or nil
                    return host_match, p
                end
            end
        end
    end
    return nil, nil
end

local detected_ip, detected_port = get_dynamic_server_info()
if detected_ip then
    ip = detected_ip
end
if detected_port then
    custom_port = detected_port
    pcall(function()
        local ec = require 'ejoysdk_lua.ejoysdk_config'
        if ec and ec.EJOYSDK_CONFIG then
            ec.EJOYSDK_CONFIG.CUSTOM_PORT = custom_port
            if ec.update_ejoysdk_service then
                ec.update_ejoysdk_service()
            end
        end
    end)
end

IPConfigVendor = {
    {"64044", ip .. ":12000", "f2ustest", "ustest", "f2ustest", ip},
}

local this = IPConfigVendor
local mapValues={['name']=1,['ipAddress']=2,['sdkServerName']=3,['sdkRegion']=4,['sdkServerId']=5,['pingIp']=6,}
local meta = {}
meta.__index = function ( table, key )
    return rawget(table,mapValues[key])
end
for k, v in pairs(this) do
    setmetatable(v, meta)
end
