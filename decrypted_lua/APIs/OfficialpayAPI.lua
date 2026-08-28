OfficialpayAPI = {}
local this = OfficialpayAPI

--设置状态(游戏各个阶段)
function this.SetPlayerState(playerstate)
	if EjoysdkManager == nil then return end
    local officialpayModule = EjoysdkManager:GetOfficialPayModule()
    officialpayModule:SetPlayerState(playerstate)
end

--支付接口
--product_id 商品ID   for exsample : local product_id = 'sgzzlb_rechage_30'
--count		 商品数量
function this.Pay(product_id , count , show_money)
	if EjoysdkManager == nil then return end

	local _,lastVendor = VendorData:GetLoginRegionVendor()
	-- 游客风险提示
	if lastVendor ~= nil then 
		if lastVendor == EVendors.AGST then
	        HUDTextShower.AddNormalTextEntity(701)
	        return
	    end
	end
    

    local officialpayModule = EjoysdkManager:GetOfficialPayModule()
	officialpayModule:Pay(product_id , count , show_money) 
end


--获取商品列表
function this.GetProductList(cb)
	if EjoysdkManager == nil then 
		cb(true , this.GetTestProductListData())
		return 
	end

	local _,lastVendor = VendorData:GetLoginRegionVendor()
	-- 游客风险提示
	if lastVendor ~= nil then 
		if lastVendor == EVendors.AGST then
	        -- HUDTextShower.AddNormalTextEntity(701)
	        -- return
	    end
	end

	
    local officialpayModule = EjoysdkManager:GetOfficialPayModule()
	officialpayModule:GetProductList(cb ) 
end


--商品列表假数据
function this.GetTestProductListData()
	local result = {}
	print(" ######### 货币假数据")
	-- product_info = 
	-- {
	-- 	"local_money":{},
	-- 	"money":1, 				-- 商品价格
	-- 	"money_type":"CNY", 	-- 货币类型
	-- 	"product_desc":"商品描述", 
	-- 	"product_id":"test1", 	-- 商品 id
	-- 	"product_type":1,		-- 商品类型"tags":{} 
	-- }

	local dat = {}	dat.local_money = {}	dat.money = 1	dat.money_type = "BR" dat.product_desc = "商品描述"
	dat.product_id = "com.f2test.xh0.99.google"  dat.show_money = 3 dat.product_type = 1 table.insert(result , dat)
	
	local dat = {}	dat.local_money = {}	dat.money = 6	dat.money_type = "CNY" dat.product_desc = "商品描述"
	dat.product_id = "com.f2test.xh9.99.google"  dat.show_money = 3 dat.product_type = 1 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 45	dat.money_type = "BR" dat.product_desc = "商品描述"
	dat.product_id = "com.f2test.xh2.99.google"  dat.show_money = 3 dat.product_type = 1 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 68	dat.money_type = "CNY" dat.product_desc = "商品描述"
	dat.product_id = "com.f2test.xh4.99.google"  dat.show_money = 3 dat.product_type = 1 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 118	dat.money_type = "CNY" dat.product_desc = "商品描述"
	dat.product_id = "5" dat.product_type = 1  dat.show_money = 3 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 198	dat.money_type = "cny" dat.product_desc = "商品描述"
	dat.product_id = "6" dat.product_type = 1  dat.show_money = 3 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 198	dat.money_type = "CN" dat.product_desc = "商品描述"
	dat.product_id = "7" dat.product_type = 1  dat.show_money = 3 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 198	dat.money_type = "CNY" dat.product_desc = "商品描述"
	dat.product_id = "8" dat.product_type = 1  dat.show_money = 3 table.insert(result , dat)

	local dat = {}	dat.local_money = {}	dat.money = 198	dat.money_type = "CNY" dat.product_desc = "商品描述"
	dat.product_id = "9" dat.product_type = 1  dat.show_money = 3 table.insert(result , dat)


	return result 
end