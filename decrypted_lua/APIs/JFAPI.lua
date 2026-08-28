JFAPI = {}
local this = JFAPI

--serverName 与serverID的调整，保证与公司规范保持一致，
--serverName取值Admin平台的服务器名称字段，serverId取值服务器字段。


--经分打点
function this.JFCommitSend(event_name, params)
    if EjoysdkManager == nil then return end
    local JF  = require 'ejoysdk_lua.vendors.jf'
    JF.commit_event(event_name, params)
    print("#########JFCommitSend#####经分已上传平台########代码： " ..event_name)
end

function this.JFGetEvnInfo()
	if EjoysdkManager == nil then return nil end
	local stat = require 'ejoysdk_lua.ejoysdk_stat'

	local ejoysdk = require 'ejoysdk_lua.ejoysdk'

    local channel = stat.env_info()

    local get_pkg_info = ejoysdk.get_pkg_info()

    if channel ~= nil then 
    	--------------accInfo--------------------
    	if channel.accInfo == nil then channel.accInfo = {} end
    	if channel.accInfo.chuid == nil then channel.accInfo.chuid = "" end
    	if channel.accInfo.chUserType == nil then 
    		channel.accInfo.chUserType = "ALIGAMES"
    	end
		
    	if channel.accInfo.accountId == nil then 
    		channel.accInfo.accountId = ""
    		local gangplankModule = EjoysdkManager:GetGangplankModule()
			if gangplankModule ~= nil and gangplankModule:GetAccountId() ~= nil then 
	    		channel.accInfo.accountId = gangplankModule:GetAccountId()
	    	end
    	end

    	--------------devInfo---------------------
    	if channel.devInfo == nil then	channel.devInfo = {}	end
    	if channel.devInfo.brand == nil then channel.devInfo.brand = "" end
    	if channel.devInfo.model == nil then channel.devInfo.model = "" end
    	if channel.devInfo.uuid == nil then channel.devInfo.uuid = ""  end
    	if channel.devInfo.os == nil then channel.devInfo.os = ""  end
    	if channel.devInfo.utdid == nil then channel.devInfo.utdid = ""  end
    	if channel.devInfo.appVer == nil then channel.devInfo.appVer = ""  end
    	if channel.devInfo.pkgName == nil then channel.devInfo.pkgName = ""  end
    	if channel.devInfo.subCh == nil then channel.devInfo.subCh = ""  end
    	if channel.devInfo.ch == nil then channel.devInfo.ch = ""  end

    	PlayerData.Instance.env_info = table.tostring(channel)

    	if PlayerData.Instance.envInfo == nil then
    		PlayerData.Instance.envInfo = {}
    	end
    	
    	PlayerData.Instance.envInfo.accountId = channel.accInfo.accountId
    	PlayerData.Instance.envInfo.chUserType = channel.accInfo.chUserType
    	PlayerData.Instance.envInfo.chuid = channel.accInfo.chuid

    	PlayerData.Instance.envInfo.subCh = channel.chInfo.subCh
    	-- PlayerData.Instance.envInfo.ch = channel.chInfo.ch

    	PlayerData.Instance.envInfo.appVer = channel.gmInfo.appVer
    	PlayerData.Instance.envInfo.pkgName = channel.gmInfo.pkgName

    	-- PlayerData.Instance.envInfo.brand = channel.devInfo.brand
    	PlayerData.Instance.envInfo.utdid = channel.devInfo.utdid
    	PlayerData.Instance.envInfo.uuid = channel.devInfo.uuid
    	-- PlayerData.Instance.envInfo.model = channel.devInfo.model
    	PlayerData.Instance.envInfo.android = channel.devInfo.os

    	if get_pkg_info ~= nil then 
    		PlayerData.Instance.envInfo.brand = get_pkg_info.brand
    		PlayerData.Instance.envInfo.model = get_pkg_info.model
    	end
    	PlayerData.Instance.envInfo.ch = ejoysdk.get_channel()

    	print("========================JF LUA STAT===============================")
    	print("brand " .. PlayerData.Instance.envInfo.brand )
    	print("model " .. PlayerData.Instance.envInfo.model )
    	print("CH : " .. PlayerData.Instance.envInfo.ch)
    	

    end
end


--更新事件经分打点
--@param jf_code  例如 ： client_app_updatevcstart
function this.JFUpdateEventPoint(jf_code)
	if this.CheckJFOpen(jf_code) == false then
		return 
	end
	
	print(" Lua 更新事件经分打点 jf_code : " .. jf_code)
	local msg = {}
	this.SetMsgBaseInfo(msg, jf_code , JF_TYPE.Update)
	msg.localDns = VersionManager:GetDNSHostName()				--本地DNS
	msg.serverIp = VersionManager:GetUpdateIP()					--更新服务器IP

	if 	jf_code == "client_app_updaterfstart" or 
		jf_code == "client_app_updaterfretry" or 
		jf_code == "client_app_updaterfsuccess" or 
		jf_code == "client_app_updaterffailed" then 
		--目标游戏版本号
		msg.tarVer = ""
		if VersionManager.ServerVersion:ToString() ~= nil then
			msg.tarVer = VersionManager.ServerVersion:ToString()
		end
	end
	msg.msg = ""
	-- print(table.tostring(msg))
	this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end

--用户行为经分打点
function this.JFUserActionPoint(jf_code)
	if this.CheckJFOpen(jf_code) == false then
		return 
	end
	print(" Lua 用户行为经分打点 jf_code : " .. jf_code)
	local msg = {}
	this.SetMsgBaseInfo(msg, jf_code, JF_TYPE.Action)

	msg.battleId = 0

	-- print(table.tostring(msg))
	this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end

--商品查看经分打点
function this.JFShopItemViewPoint(jf_code)
	-- if this.CheckJFOpen(jf_code) == false then
	-- 	return 
	-- end	
	-- -- print(" Lua 商品查看经分打点 jf_code : " .. jf_code)
	-- local msg = {}
	-- this.SetMsgBaseInfo(msg, jf_code, JF_TYPE.ShopView)

	-- msg.presentStore = JF_STORE_TYPE
	-- msg.saleID = JF_STORE_VIEW_SALEID
	-- msg.stayTime = JF_STORE_STAYTIME

	-- print(table.tostring(msg))
	-- this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end

--点击广告经分打点
function this.JFSharePoint(jf_code , sharetype)
	print(" Lua 点击广告经分打点 jf_code : " .. jf_code)
	local msg = {}
	this.SetMsgBaseInfo(msg, jf_code, JF_TYPE.Social)

	msg.sharetype = sharetype

	-- print(table.tostring(msg))
	this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end



--点击广告经分打点
function this.JFADLoadPoint(adsId)
	local jf_code = "client_ads_load" 
	print(" Lua 广告加载完毕 jf_code : " .. jf_code)
	local msg = {}
	this.SetMsgBaseInfo(msg, jf_code, JF_TYPE.Ad)

	msg.adsId = adsId

	-- print(table.tostring(msg))
	this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end



--点击广告经分打点
function this.JFADPoint(adsId)
	local jf_code = "client_ads_click" 
	if this.CheckJFOpen(jf_code) == false then
		return 
	end	
	print(" Lua 商品查看经分打点 jf_code : " .. jf_code)
	local msg = {}
	this.SetMsgBaseInfo(msg, jf_code, JF_TYPE.Ad)

	msg.adsId = adsId

	-- print(table.tostring(msg))
	this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end

--客户端报错经分打点
function this.JFClientErrorPoint(jf_code , msgError )
	if this.CheckJFOpen(jf_code) == false then
		return 
	end
	-- print(" Lua 客户端报错经分打点 jf_code : " .. jf_code)
	local msg = {}
	this.SetMsgBaseInfo(msg, jf_code, JF_TYPE.Error)

	--todo 
	msg.msg = ""
	msg.battleId = "" 

	if msgError ~= nil then 
		msg.msg = msgError
	end

	-- print(table.tostring(msg))
	this.JFCommitSend(this.GetEventTypeName(jf_code) , msg)
end

--切分code
function this.SplitCode(jf_code,  level)
	local startIndex = 1 + (level - 1) * 2 
	local endIndex = startIndex + 1 
	local result = string.sub(jf_code ,startIndex , endIndex )
	return result
 end

--获取event_name   例如 client_app_updaterfstart   --- > client.app.updaterfstart
function this.GetEventTypeName(jf_code)
	return string.gsub(jf_code , "_" , ".")
end

function this.SetMsgBaseInfo(msg , code , jf_type )
	if jf_type ~= JF_TYPE.Update then 
		msg.roleName = ""
		msg.roleId = ""
		msg.serverName = ""
		msg.serverId = ""
		msg.roleLevel = ""

		if PlayerData.Instance.Name ~= nil then 
			msg.roleName = PlayerData.Instance.Name
		end
		if PlayerData.Instance.Uid ~= nil then 
			msg.roleId = PlayerData.Instance.Uid
		end
		if PlayerData.Instance.SDKServerName ~= nil then 
			msg.serverName = PlayerData.Instance.SDKServerName
		end
		if PlayerData.Instance.SDKServerId ~= nil then 
			msg.serverId = PlayerData.Instance.SDKServerId
		end
	
		if PlayerData.Instance.Level ~= nil then 
			msg.roleLevel = PlayerData.Instance.Level
		end
	end

	msg.runingId = ""
	msg.appVer = ""
	msg.accountId = ""

	msg.f2_ts = CS.FCommon.Utility.GetTimeStamp()

	-- print(" ############## 时间戳 : " .. msg.f2_ts)

	for k,v in pairs(JF_CODE) do
		if k == code then 
			msg.code = v
			msg.code1 = this.SplitCode(v, 1)
			msg.code2 = this.SplitCode(v, 2)
			msg.code3 = this.SplitCode(v, 3)
			msg.code4 = this.SplitCode(v, 4)
		end
	end

	if EjoysdkManager ~= nil then 
		local E = require 'ejoysdk_lua.ejoysdk'
		--游戏启动ID
		if E.get_game_id() ~= nil then 
			msg.runingId = E.get_game_id()
		end							

		----当前前游戏版本
		if E.Sysinfo.app_version_name() ~= nil then 
			msg.appVer = E.Sysinfo.app_version_name()	

			if msg.appVer ~= nil then 
				print("===============>>> 客户端传入的AppVer : " .. msg.appVer)	
			end		
		end



		local gangplankModule = EjoysdkManager:GetGangplankModule()
		-- print("======================###################=============================")
		-- print(gangplankModule)
		-- print(gangplankModule:GetAccountId())
		if gangplankModule ~= nil and gangplankModule:GetAccountId() ~= nil then 
    		msg.accountId = gangplankModule:GetAccountId()
    	end

    	if msg.accountId == nil or msg.accountId == "" then
    		local stat = require 'ejoysdk_lua.ejoysdk_stat'
    		local channel = stat.env_info()
    		if channel ~= nil and channel.accInfo ~= nil and channel.accInfo.accountId ~= nil then 
    			msg.accountId = channel.accInfo.accountId
    		end
    	end

    	-- for k,v in pairs(msg) do
    	-- 	print(k, table.tostring(v))
    	-- end

	end

	
end

function this.CheckJFOpen(code)
	if CS.EjoySDKJF.OpenJF == false then 
		print("Lua 经分总开关已关闭")
		return false
	end

	local jf_switch = CS.EjoySDKJF.CheckOpen(code) 

	if jf_switch == false then 
		print(" Lua 单条经分开关已经关闭 code : " .. code)
	end

	return jf_switch 
end

function this.GetJFCodeName(key)
	for k,v in pairs(JF_CODE) do
		if k == key then 
			return tostring(k)
		end
	end
	return ""
end