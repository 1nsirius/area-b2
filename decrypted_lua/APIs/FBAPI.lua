FBAPI = {}
local this = FBAPI

--firebase打点
function this.FBCommitSend(event_name, params)
    if EjoysdkManager == nil then return end
    --firebase
    FBAPI.FireBasePoint(event_name , params)
    --appsflyer
    FBAPI.AppsflyerPoint(event_name , params)
    --facebook
    FBAPI.FacebookPoint(event_name , params)
end


--firebase
function this.FireBasePoint(event_name, params)
    print ("-------------------------------- FB Start------------------------------------")
    local FB  = require 'ejoysdk_lua.vendors.firebase'
    if event_name == "ads_paid_success" then
        if params.payAmt ~= nil then 
            params.fb_revenue = params.payAmt
            params.price = params.payAmt
            params.value = params.payAmt
        end
        if params.currency ~= nil then
            params.fb_currency = params.currency
            params.fb_content_type = params.currency
        end
        if params.property ~= nil then 
            params.fb_content_id = params.property
            params.product_id = params.property
            params.id = params.property
        end
        params.free_trial = 0 

        --fb 的标准事件在发一次
        print("==Pay FB Point")
        FB.commit_event("in_app_purchase", params)
        print(table.tostring(params))

    --https://developers.facebook.com/docs/app-events/reference#standard-events-3
    -- 完成注册事件  
    elseif event_name == "ads_account_success" then 
        FB.commit_event("Complete Registration", params)
        print(table.tostring(params))
    -- 新手引导完成   
    elseif event_name == "ads_tutorial_completed" then 
        FB.commit_event("Complete Tutorial", params)
        print(table.tostring(params))
    -- 升级
    elseif event_name == "ads_levelup_5" or event_name == "ads_levelup_3" then 
        FB.commit_event("Achieve Level", params)
        print(table.tostring(params))
    end

    
    print(table.tostring(params))
    print ("-------------------------------- FB End------------------------------------")

    FB.commit_event(event_name, params)
end



--facebook 
function this.FacebookPoint()
    local FaceBook  = require 'ejoysdk_lua.vendors.facebook'

end

--appsflyer 
function this.AppsflyerPoint(event_name , params)
    --增加AF打点，
    print ("-------------------------------- AF Start------------------------------------")
    local EST = require 'ejoysdk_lua.vendors.appsflyer'
    if event_name == "ads_paid_success" then   --n 
        if params.payAmt ~= nil then 
            params.af_revenue = params.payAmt  --/ 100 
            params.af_price = params.af_revenue
            params.payAmt = params.af_revenue
        end
        if params.currency ~= nil then
            params.af_currency = params.currency
            params.af_content_type = params.currency
        end
        if params.property ~= nil then 
            params.af_content_id = params.property
        end
        params.af_quantity = 1 
        print(table.tostring(params))
    end

    EST.commit_event(event_name, params)

    print("#########FBCommitSend##### AF 打点已上传平台########代码： " ..event_name)
    print ("-------------------------------- AF end------------------------------------")
end


--fb 打点
function this.FBPoint(event_name)
	if this.CheckJFOpen(event_name) == false then
		return 
	end
	print(" Lua 客户端faerbace 打点 fb event_name : " .. event_name)
	local msg = {}
	this.SetMsgBaseInfo(msg, event_name)

	msg.adsId = adsId

	print(table.tostring(msg))
	this.FBCommitSend(event_name , msg)
end

--fb 充值成功 打点
--@param currency 	货币类型
--@param payAmt 	付费金额
--@param property 	商品编码
function this.FBPaySucPoint(event_name , currency , payAmt , property )
	if this.CheckJFOpen(event_name) == false then
		return 
	end
	print(" Lua 客户端faerbace 打点 fb event_name : " .. event_name )
	
	local msg = {}
	this.SetMsgBaseInfo(msg, event_name)
	msg.currency = ""
	msg.payAmt = ""
	msg.property = ""

	if currency ~= nil then 
        print ("FBPaySucPoint -- currency 货币类型 : " .. currency)
		msg.currency = currency
	end

	if payAmt ~= nil then 
        print ("FBPaySucPoint -- payAmt  （show_money） 付款金额 : " .. payAmt)
		msg.payAmt = payAmt
	end
	
	if property ~= nil then 
        print ("FBPaySucPoint -- property 付款编码: " .. property)
		msg.property = property
	end

	print(table.tostring(msg))
	this.FBCommitSend(event_name , msg)

end

function this.CheckJFOpen(code)
	return true 
end


function this.SetMsgBaseInfo(msg , code )
	msg.servername = ""
	msg.accountId = ""

	if PlayerData.Instance.SDKServerName ~= nil then 
		msg.servername = PlayerData.Instance.SDKServerName
	end

	if EjoysdkManager ~= nil then 
		local E = require 'ejoysdk_lua.ejoysdk'

		local gangplankModule = EjoysdkManager:GetGangplankModule()
		if gangplankModule ~= nil and gangplankModule:GetAccountId() ~= nil then 
    		msg.accountId = gangplankModule:GetAccountId()
    	end
	end

	if code ~= FB_EVENT.ads_account_success then 
		msg.roleId = "" 
		msg.roleName = "" 

		if PlayerData.Instance.Uid ~= nil then 
			msg.roleId = PlayerData.Instance.Uid
		end

		if PlayerData.Instance.Name ~= nil then 
			msg.roleName = PlayerData.Instance.Name
		end

	end

	if code == FB_EVENT.ads_levelup_3 or code == FB_EVENT.ads_levelup_5 then 
		msg.level = "" 
		if PlayerData.Instance.Level ~= nil then 
			msg.level = PlayerData.Instance.Level
		end
	end

end