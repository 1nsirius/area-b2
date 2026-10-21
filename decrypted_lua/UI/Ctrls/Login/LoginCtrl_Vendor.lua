--------------------------------------------------------------------------------
-- 类名称：LoginCtrl_Vendor
-- 描述：登录界面逻辑（mobile下登录，使用渠道fb,google,dingding,.etc）
-- 作者：陆坚
-- 创建时间：2019-11-12
-- 最后修改该人：
-- 最后修改该时间：
-- 版权所有 (C)：aligames
--------------------------------------------------------------------------------

require "lib/class"

local this = LoginCtrl
local logger = Logger.new("LoginCtrl_Vendor")

local function AF2DiagLog(message)
	local text = "[AF2DIAG] " .. tostring(message)
	if _ejoysdk ~= nil and _ejoysdk.log ~= nil then
		_ejoysdk.log(text)
	else
		Debug.Log(text)
	end
end

-- 当前登录流程状态
this.mState = nil

local BaseState = class("BaseState", nil, { mLoginCtrl = nil })
function BaseState:ctor(loginCtrl)
    self.mLoginCtrl = loginCtrl
end
function BaseState:OnEnter() end
function BaseState:OnExit() end

-- States
local AcquireState = nil
local LoginWithTokenState = nil

-- 1. 玩家可以点击按钮Acquire
AcquireState = class("AcquireState", BaseState)
function AcquireState:OnEnter(...)
    local view = self.mLoginCtrl.view
    local doVendorLogin = function(region, vendorName)
        local vendor = EVendors.GetVendor(vendorName)
        local module = EjoysdkManager:GetGangplankModule()
        view:AlertWaiting(true)            
        module:AcquireGameToken(region, vendorName, function (token, code, msg, create_new_account, bind_guest)
            logger:Log("AcquireState callback, code", code, "type", type(code))
            view:AlertWaiting(false)            

            -- 已有未绑定的游客账号，提示是否要绑定第三方，绑定后游客的游戏数据自动绑定到第三方账号，并删除游客账号信息
            if code == 2001000 then
                logger:Log("AcquireState AlertGusestBindMsg")
                view:AlertGuestBindMsg(vendor, function (result)
                    if result == true then
                        bind_guest()
                    else
                        create_new_account()
                    end
                    view:AlertWaiting(true)            
                end)
                return
            end

            if code ~= 0 then
                logger:Log("AcquireState Failure")
                -- 失败
                view:AlertMsg(code)
                return
            end
            
            -- 获取token成功进入选择大区流程
            self.mLoginCtrl:ChangeState(LoginWithTokenState)
        end)
    end
    local vendorLogin = function(region, vendorName)
        if vendorName == "FB" then
            local vendorModels = LoginCtrl.CreateVendorModels()
            for i=1,#vendorModels do
                if view[vendorModels[i].btnName] then view[vendorModels[i].btnName].gameObject:SetActive(false) end
                if view[vendorModels[i].btnMoreName] then view[vendorModels[i].btnMoreName].gameObject:SetActive(false) end
            end
            if view.objMoreVendors then view.objMoreVendors:SetActive(false) end

            -- Back button to return to vendor selection
            if view.btnMore then
                view.btnMore.gameObject:SetActive(true)
                local txt = view.btnMore.gameObject:GetComponentInChildren(typeof(CS.UnityEngine.UI.Text))
                if txt then txt.text = "Back" end
                view.btnMore.onClick:RemoveAllListeners()
                view.btnMore.onClick:AddListener(function()
                    for j=1,#vendorModels do
                        if view[vendorModels[j].btnName] then view[vendorModels[j].btnName].gameObject:SetActive(true) end
                    end
                    if view.inputName then view.inputName.gameObject:SetActive(false) end
                    if view.btnLogin then view.btnLogin.gameObject:SetActive(false) end
                    if txt then txt.text = "More" end
                    view.btnMore.onClick:RemoveAllListeners()
                    view.btnMore.onClick:AddListener(function()
                        if view.objMoreVendors then
                            local active = view.objMoreVendors.activeSelf
                            view.objMoreVendors:SetActive(not active)
                        end
                    end)
                end)
            end

            if view.inputName then
                view.inputName.gameObject:SetActive(true)
                pcall(function()
                    if view.inputName.placeholder ~= nil then
                        local placeholderText = view.inputName.placeholder:GetComponent(typeof(CS.UnityEngine.UI.Text))
                        if placeholderText ~= nil then
                            placeholderText.text = "Enter nickname"
                        else
                            view.inputName.placeholder.text = "Enter nickname"
                        end
                    end
                    local phChild = view.inputName.transform:Find("Placeholder")
                    if phChild ~= nil then
                        local txt = phChild:GetComponent(typeof(CS.UnityEngine.UI.Text))
                        if txt ~= nil then txt.text = "Enter nickname" end
                    end
                end)

                local lastNick = ""
                pcall(function()
                    lastNick = CS.UnityEngine.PlayerPrefs.GetString("LastLoginNickname", "")
                end)
                if lastNick ~= nil and lastNick ~= "" then
                    view.inputName.text = lastNick
                else
                    view.inputName.text = ""
                end
            end

            if view.btnLogin then
                view.btnLogin.gameObject:SetActive(true)
                view.btnLogin.onClick:RemoveAllListeners()
                view.btnLogin.onClick:AddListener(function()
                    local serverModel = self.mLoginCtrl:GetSelectServerModel()
                    if serverModel == nil then
                        return 
                    end
                    local accountName = view.inputName and view.inputName.text or ""
                    if accountName == nil or accountName == "" then
                        pcall(function()
                            accountName = CS.UnityEngine.PlayerPrefs.GetString("LastLoginNickname", "")
                        end)
                        if accountName == nil or accountName == "" then
                            accountName = "Player_" .. tostring(math.random(1000, 9999))
                        end
                        if view.inputName then
                            view.inputName.text = accountName
                        end
                    end
                    pcall(function()
                        CS.UnityEngine.PlayerPrefs.SetString("LastLoginNickname", accountName)
                        CS.UnityEngine.PlayerPrefs.Save()
                    end)
                    view:AlertWaiting(true)
                    LoginCtrl.RecordLastVendor("0", serverModel.name, "FB")
                    GameInstance:SetCurSdkServerName(serverModel.sdkServerName)
                    self.mLoginCtrl.mGameToken = accountName

                    local doAcquireAndLogin = function()
                        local module = EjoysdkManager:GetGangplankModule()
                        if module ~= nil and module.AcquireGameToken ~= nil and EjoysdkManager:IsInitialized() then
                            local acquireCalled = false
                            local res = pcall(function()
                                module:AcquireGameToken(serverModel.sdkRegion or "ustest", "guest", function(token, code, msg)
                                    if not acquireCalled then
                                        acquireCalled = true
                                        view:AlertWaiting(false)
                                        self.mLoginCtrl:DoLogin()
                                    end
                                end)
                            end)
                            if not res then
                                view:AlertWaiting(false)
                                self.mLoginCtrl:DoLogin()
                            else
                                local E = require 'ejoysdk_lua.ejoysdk'
                                if E ~= nil and E.Timer ~= nil then
                                    E.Timer.once(3, function()
                                        if not acquireCalled then
                                            acquireCalled = true
                                            view:AlertWaiting(false)
                                            self.mLoginCtrl:DoLogin()
                                        end
                                    end)
                                end
                            end
                        else
                            view:AlertWaiting(false)
                            self.mLoginCtrl:DoLogin()
                        end
                    end

                    if EjoysdkManager:IsInitialized() == false then
                        EjoysdkManager:Init(function(succ)
                            doAcquireAndLogin()
                        end, serverModel.sdkRegion or "ustest")
                    else
                        doAcquireAndLogin()
                    end
                end)
            end
            return
        end

        view:AlertWaiting(true)
        EjoysdkManager:Init(function(succ)
            view:AlertWaiting(false)
            if succ == false then
                view:AlertMsg(-1)
                return
            end
            doVendorLogin(region, vendorName)
        end, region)
    end

    -- 显示当前可以进入的渠道登录按钮、并排序
    local vendorModels = LoginCtrl.CreateVendorModels()
    local moreVisible = false
    for i=1,#vendorModels do
        local vendorModel = vendorModels[i]
        local index = vendorModel.sortIndex
        if index <= 2 then
            LoginCtrl.LoginBtnWidget.new(
                view[vendorModel.btnName],
                self.mLoginCtrl,
                vendorModel.vendor,
                function (vendor) 
                    if self.mLoginCtrl:GetSelectServerModel() == nil then
                        return 
                    end
                    local serverModel = self.mLoginCtrl:GetSelectServerModel()
                    vendorLogin(serverModel.sdkRegion, vendor.name) 
                end,
                index
            )
        else
            moreVisible = true
            LoginCtrl.LoginBtnWidget.new(
                view[vendorModel.btnMoreName],
                self.mLoginCtrl,
                vendorModel.vendor,
                function (vendor) 
                    if self.mLoginCtrl:GetSelectServerModel() == nil then
                        return 
                    end
                    view.objMoreVendors:SetActive(false)
                    local serverModel = self.mLoginCtrl:GetSelectServerModel()
                    vendorLogin(serverModel.sdkRegion, vendor.name) 
                end,
                index
            )
        end
    end
    view.btnMore.gameObject:SetActive(moreVisible)

    -- 服务器列表
    self.mLoginCtrl.mServerModels = self.mLoginCtrl.CreateServerModelsByIPConfigVendor()
    view:RefreshDropServer(self.mLoginCtrl, self.mLoginCtrl.mServerModels, self.mLoginCtrl:GetLastLoginServerIndex())

    -- 显示所有可以登录的渠道按钮
    view:RefreshBtns()

    -- 隐藏输入账号和直接进入按钮（直到玩家点击FB）
    if view.inputName then view.inputName.gameObject:SetActive(false) end
    if view.btnLogin then view.btnLogin.gameObject:SetActive(false) end

    -- 快速登录禁用，确保每次进入都能看到完整的授权界面
    local enableFastLogin = false
    local fastLoginVendor = VendorData:GetFastLoginVendor()
    local lastLoginRegion, _ = VendorData:GetLoginRegionVendor()
    if enableFastLogin == true and fastLoginVendor ~= nil then
        logger:Log("AcquireState fast login, vendorName", fastLoginVendor.name, "region", lastLoginRegion)
        self.mLoginCtrl:CheckAgreement(function()
            vendorLogin(lastLoginRegion, fastLoginVendor.name)
        end)
    end
end

-- 2. Acquire完成进入游戏
LoginWithTokenState = class("LoginWithTokenState", BaseState)
function LoginWithTokenState:OnEnter(...)
    local view = self.mLoginCtrl.view
    local module = EjoysdkManager:GetGangplankModule()

    local index = view.dropServer.value
    local serverModel = self.mLoginCtrl.mServerModels[index+1]
	if serverModel == nil and self.mLoginCtrl.mServerModels ~= nil and #self.mLoginCtrl.mServerModels > 0 then
		AF2DiagLog("LoginWithTokenState selected server is nil; fallback to first server model")
		view.dropServer.value = 0
		serverModel = self.mLoginCtrl.mServerModels[1]
	end
	if serverModel == nil then
		AF2DiagLog("LoginWithTokenState failed: no server model available")
		view:AlertWaiting(false)
		view:AlertMsg(-1)
		return
	end
    local sdkServerName = serverModel.sdkServerName
    AF2DiagLog(string.format("LoginWithTokenState server name->%s sdkServerName->%s ip->%s port->%s",
		tostring(serverModel.name),
		tostring(sdkServerName),
		tostring(serverModel.ip),
		tostring(serverModel.port)))
    
    LoginDataIns.serverNameId = serverModel.name

    -- 开始准备进入游戏服
    view:AlertWaiting(true)
    module:Login(sdkServerName, function (game_token, secret, pid, code, msg)
		AF2DiagLog(string.format("LoginWithTokenState module login callback code->%s pid->%s tokenEmpty->%s msg->%s",
			tostring(code),
			tostring(pid),
			tostring(game_token == nil or game_token == ""),
			tostring(msg)))
        if code ~= 0 then
            -- 失败
            view:AlertWaiting(false)
            view:AlertMsg(code)
            return
        end

        -- 进入游戏
	    LoginCtrl.RecordLastVendor(module:GetAcquiredRegion(), serverModel.name, module:GetAcquiredVendorName())
        GameInstance:SetCurSdkServerName(sdkServerName)
        self.mLoginCtrl.mGameToken = game_token
        self.mLoginCtrl:DoLogin()
    end)
end

function this:onOpen()
    self:TurnOnLoginMusic()

    -- 界面第一次打开
    self:ChangeState(AcquireState, false)
end

function this:onclose()
    -- 关闭公告
    UiMgr:RemoveUi(LuaPanelNames.BillboardForLoginPanel)

	AlertManager.Instance:CloseDlg()
    self.view:AlertWaiting(false)            
    self:ChangeState(nil)
    if self.mLoginBackground ~= nil then
        -- self.mLoginBackground:Enable(false)
		self.mLoginBackground = nil
    end
end

function this:ChangeState(stateCls, ...)
    local preState = nil
    local nextState = stateCls ~= nil and stateCls.cname or nil
    if self.mState ~= nil then
        preState = self.mState.cname
        self.mState:OnExit()
    end

    logger:Log("ChangeState pre", preState, "next", nextState)
    if stateCls == nil then return end

    self.mState = stateCls.new(self)
    self.mState:OnEnter(...)
end

function this:OnMsg(...)
    local key = ...
    if key == "CancelQueue" then
        self:CancelQueue()
    end
end

function this:CancelQueue()
    AlertManager.Instance:CloseDlg()
    self.view:AlertWaiting(false)
    self:ChangeState(AcquireState, false)
end
