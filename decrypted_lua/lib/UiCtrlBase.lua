require "lib/class"

-- 适配新ui系统, 请优先使用新Ui系统基类(BaseUiCtrlr)
UiCtrlBase = class("UiCtrlBase", BaseUiCtrlr)
local this = UiCtrlBase

function this:OnCreate(...)
    self.cb = ...
end

function this:OnBindTransform()
    require('UI/Views/' .. self.uiData.name)
    self.gameObject = self.root.gameObject
    self.view = _G[self.uiData.name].new()
    self:awake(self.gameObject)

    if self.cb ~= nil then
        self.cb(self)
    end
    
    if self.onOpen ~= nil then
        self:onOpen()
    end
end

function this:OnShow()
    if self.onenable ~= nil then
        self:onenable()
    end
end

function this:OnTick()
    if self.update ~= nil then
        self:update()
    end
end

function this:OnHide()
    if self.ondisable ~= nil then
        self:ondisable()
    end
end

function this:OnDestroy()
    if self.onclose ~= nil then
        self:onclose()
    end

    if (self.view ~= nil) then
        self.view:OnDestroy()
        self.view = nil
    end
    
    if self.onrelease ~= nil then
        self:onrelease()
    end
    
    self.gameObject = nil
end

