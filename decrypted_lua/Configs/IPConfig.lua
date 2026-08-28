-- Local lobby endpoint for no-iptables builds.
IPConfig = {
    {"64044","192.168.1.9:12000","f2ustest","ustest","f2ustest","192.168.1.9"},
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