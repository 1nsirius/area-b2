AdAPI = {}
local this = AdAPI

function this.LoadAd(cb)
  if EjoysdkManager == nil then return end
  
  local advsdk = require 'ejoysdk_lua.vendors.advsdk'
  local vendor_name = 'GOOGLEADS'
  local data = { id = CS.FGame.AdDataManager.Instance.AdID }

  Debug.Log(CS.FGame.AdDataManager.Instance.AdID)

  advsdk.loadAd(vendor_name, data, function(succ, ...)
    -- succ 表示广告播放是否正常
    if succ then
      --成功时, 返回为cb(true, body.body, resp_chunk)
      local body=...
      local status=body.status

      --打点
      JFAPI.JFADPoint( data["id"])
      FBAPI.FBPoint("ads_click_ads")

      print('广告播放成功 status: '..tostring(status))
      cb(succ, status)
    else
      --失败时, 返回为cb(false, body.code, body.body, resp_chunk)
      local code,body=...
      local err_code = body.err_code
      local err_msg = body.err_msg

      print('广告播放失败 errcode: '..tostring(body.err_code)..' '..tostring(body.err_msg))
      cb(succ, 0)
    end
  end)
end

function this.QueryList()
  print('查询广告列表')
  if EjoysdkManager == nil then return end
  
  local advsdk = require 'ejoysdk_lua.vendors.advsdk'
  advsdk.query_list(function(succ, adlist)
    print('查询广告列表 结果: '..tostring(succ))
    if succ then
      CS.FGame.AdDataManager.Instance:LuaCallClearAds()
      local count = 0
      for _, info in pairs(adlist) do
        count = count + 1
        local statusCode = this.GetAdPreloadStatus(info.id)
        CS.FGame.AdDataManager.Instance:LuaCallAddAds(info.id, info.count_left, info.cd_left, statusCode)
      end
      print('当前广告位数量: '..tostring(count))
      PrintTable(adlist)
      CS.FGame.AdDataManager.Instance:LuaCallQueryFinish()
    end
  end)
end

function this.IsAdOK(callback)
  print('查询广告列表 with cb')

  local advsdk = require 'ejoysdk_lua.vendors.advsdk'
  advsdk.query_list(function(succ, adlist)
    if (succ and #adlist > 0) then
      local info = adlist[1]
      callback(info.count_left > 0 and info.cd_left == 0)
    else
      callback(false)
    end
  end)
end

function this.GetAdPreloadStatus(adID)
  local advsdk = require 'ejoysdk_lua.vendors.advsdk'
  local info = advsdk.get_status('GOOGLEADS', { id = CS.FGame.AdDataManager.Instance.AdID })
  if info == nil then
    return 0
  else
    return info.code or 0
  end
end