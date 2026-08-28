--------------------------------------------------------------------------------
-- 类名称：VendorData
-- 描述：登录后 渠道相关数据
-- 作者：陆坚
-- 创建时间：2019-11-20
-- 最后修改该人：
-- 最后修改该时间：
-- 版权所有 (C)：aligames
--------------------------------------------------------------------------------

VendorData = class("VendorData", nil, {
    mRegion = "sg",
    mRegionName = nil,
    -- EVendorCls, 当前登录的渠道信息
    mLoginVendor = nil,

    -- 绑定信息
    mBindInfos = {},
})

local this = VendorData
local logger = Logger.new("VendorData")

function VendorData:SetFastLoginVendor(vendor)
    PlayerPrefs.SetString("vendordata_fastloginvendorname", vendor ~= nil and vendor.name or "")
end
function VendorData:GetFastLoginVendor()
    local vendorName = PlayerPrefs.GetString("vendordata_fastloginvendorname", "")
    logger:Log("GetFastLoginVendor from playerPrefs, vendorName", vendorName)
    if vendorName ~= "" then
        return EVendors.GetVendor(vendorName)
    end
    return nil
end

function VendorData:SetLoginVendor(region, regionName, vendor)
    logger:Log("SetLoginVendor", region, regionName, vendor ~= nil and vendor.name or nil)
    self.mRegion = region
    self.mRegionName = regionName
    self.mLoginVendor = vendor
    PlayerPrefs.SetString("vendordata_lastloginvendorregion", region ~= nil and region or "")
    PlayerPrefs.SetString("vendordata_lastloginvendorname", vendor ~= nil and vendor.name or "")
    self:SetFastLoginVendor(vendor)

    if vendor ~= nil then
        local bindInfo = self:GetBindInfo(EVendors.FB.name)
        if bindInfo ~= nil then
            local iconUrl = bindInfo.avatar
            PlayerData.Instance.IconUrl = iconUrl
        else
            PlayerData.Instance.IconUrl = ""
        end
    end
end

function VendorData:GetLoginRegionVendor()
    local region = nil
    local vendor = nil
    if self.mLoginVendor ~= nil then
        logger:Log("GetLoginRegionVendor from mLoginVendor")
        region = self.mRegion
        vendor = self.mLoginVendor
    else
        -- 从本地文件读取上次登录的vendor
        region = PlayerPrefs.GetString("vendordata_lastloginvendorregion", "")
        local vendorName = PlayerPrefs.GetString("vendordata_lastloginvendorname", "")
        logger:Log("GetLoginRegionVendor from playerPrefs, vendorName", vendorName, "region", region)
        if vendorName ~= "" then
            local tmpVendor = EVendors.GetVendor(vendorName)
            if tmpVendor ~= nil then
                vendor = tmpVendor
            end
        end
    end

    logger:Log("GetLoginRegionVendor vendorName", vendor ~= nil and vendor.name or "nil", "region", region)
    return region, vendor
end

function VendorData:AddBindInfo(vendorName, uname, uavatar)
    local vendor = EVendors.GetVendor(vendorName)
    if vendor == nil then
        logger:LogError("AddBindInfo failure, vendorName", vendorName)
        return
    end

    self.mBindInfos[vendorName] = {
        vendor = vendor,
        name = uname,
        avatar = uavatar,
    }
    PlayerData.Instance:AddBindedVendor(vendorName, uname, uavatar)
end

function VendorData:GetBindInfo(vendorName)
    return self.mBindInfos[vendorName]
end

function VendorData:GetRegionName()
    return string.IsNullOrEmpty(self.mRegionName) == false and self.mRegionName or ""
end

function GetLuaVendorNames()
    local vendorNames = {}
    if CSharpAPI.GetDevType() == 1 then
        vendorNames = {"AGST", "FB", "GOOGLE", "QOOKKA"}
    elseif CSharpAPI.GetDevType() == 2  then
        vendorNames = {"QOOKKA"}
    else
        vendorNames = {"AGST", "FB", "GOOGLE", "APPLE", "QOOKKA"}
    end
    return vendorNames
end

function GetLuaBindVendorNames()
    local vendorNames = {}
    if CSharpAPI.GetDevType() == 1 then
        vendorNames = {"FB", "GOOGLE", "QOOKKA"}
    elseif CSharpAPI.GetDevType() == 2  then
        vendorNames = {"QOOKKA"}
    else
        vendorNames = {"FB", "GOOGLE", "APPLE", "QOOKKA"}
    end
    return vendorNames
end