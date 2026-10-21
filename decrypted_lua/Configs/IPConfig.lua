-- Local SDK-login server list for no-iptables builds.
local ip = "127.0.0.1"

local function get_dynamic_server_ip()
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
                local host_match = clean_no_proto:match("^([^:/%s]+)")
                if host_match and host_match ~= "" and host_match:match("^%d+%.%d+%.%d+%.%d+$") then
                    return host_match
                end
            end
        end
    end
    return nil
end

local detected = get_dynamic_server_ip()
if detected then
    ip = detected
end

IPConfig = {
    {"64044", ip .. ":12000", "f2ustest", "ustest", "f2ustest", ip},
}

local this = IPConfig
local mapValues={['name']=1,['ipAddress']=2,['sdkServerName']=3,['sdkRegion']=4,['sdkServerId']=5,['pingIp']=6,}
local meta = {}
meta.__index = function ( table, key )
    return rawget(table,mapValues[key])
end
for k, v in pairs(this) do
    setmetatable(v, meta)
end
