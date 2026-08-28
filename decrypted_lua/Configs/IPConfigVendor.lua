-- Local SDK-login server list for no-iptables builds.
local ip = "192.168.1.9"
if CS and CS.UnityEngine and CS.UnityEngine.Application then
    local path = CS.UnityEngine.Application.persistentDataPath .. "/File/dev_hotupdate.txt"
    local f = io.open(path, "r")
    if f then
        local content = f:read("*a")
        f:close()
        if content then
            local parsed_ip = content:match("http://([^/:]+)")
            if parsed_ip then
                ip = parsed_ip
            end
        end
    end
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