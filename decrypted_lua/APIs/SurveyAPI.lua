SurveyAPI = {}
local this = SurveyAPI

--[[
id_list = 
{
  id_list_unit,
  id_list_unit,
  id_list_unit,
  ..... 
}

id_list_unit = 
{
  name: string
  rank: string
  desc: string
  catalogue: string
  resource_id: string
}

desc 字符串示例:
{
  item1 = 1001,
  count1 = 50,
  item2 = 1002,
  count2 = 7,
  levellimit = 3
}
]]

--[[获取问卷列表]]
function this.GetSurveyList(cbsuccess, cbfail)
  if EjoysdkManager == nil then return end
  EjoysdkManager:GetSurveyModule():GetSurveyList(cbsuccess, cbfail)
end

function this.OpenSurvey(resourceID, cbsuccess, cbfail)
  if EjoysdkManager == nil then return end
  EjoysdkManager:GetSurveyModule():OpenSurvey(resourceID, cbsuccess, cbfail)
end

function this.GetParsedSurveyList(cbsuccess, cbfail)
  local successHandler = function(id_list)
    local parsed = {}
    for i = 1, #id_list do
      local info = this.ParseSurvey(id_list[i])
      if info ~= nil then
        table.insert(parsed, info)
      end
    end
    --parsed表额外排序
    local sorted = {}
    while (#parsed > 0) do
      local minrank = 9999
      local minrankID = -1
      for k, v in pairs(parsed) do
        if v.rank < minrank then
          minrank = v.rank
          minrankID = k
        end
      end
      table.insert(sorted, 1, parsed[minrankID])
      table.remove(parsed, minrankID)
    end
    parsed = sorted

    if cbsuccess ~= nil then
      cbsuccess(parsed)
    end
  end

  this.GetSurveyList(successHandler, cbfail)
end

function this.HasNewSurvey(cbresult)
  local cbs = function (id_list)
    if cbresult ~= nil then
      if id_list == nil or #id_list == 0 then
        print('[Survey]no new survey')
        cbresult(false)
      else
        print('[Survey]new survey')
        cbresult(true)
      end
    end
  end

  local cbf = function()
    if cbresult ~= nil then
      cbresult(false)
    end
  end

  this.GetParsedSurveyList(cbs, cbf)
end



-----------------------------------------------------------------
function this.ParseSurvey(survey)
  if this.IsFinish(survey.resource_id) then
    return
  end

  local params = this.ParseDesc(survey.desc)
  if params ~= nil then
    local info = {}
    info.name = tostring(survey.name)
    info.resid = tostring(survey.resource_id)
    info.rank = tonumber(survey.rank)

    info.item1 = tonumber(params.item1) or 0
    info.count1 = tonumber(params.count1) or 0
    info.item2 = tonumber(params.item2) or 0
    info.count2 = tonumber(params.count2) or 0
    info.levellimit = tonumber(params.levellimit) or 0
    return info
  else
    Debug.Log('问卷描述数据格式有误')
    return nil
  end
end

function this.ParseDesc(desc)
  local str = string.gsub(desc, '\r\n', '')
  str = string.gsub(str, '\n', '')
  str = string.gsub(str, ' ', '')
  local group = this.Split(str, ',')
  local params = {}
  for i = 1, #group do
    if string.find(group[i], '=') ~= nil then
      local pair = this.Split(group[i], '=')
      if #pair == 2 then
        params[pair[1]] = pair[2]
      end
    end
  end
  return params
end

function this.Split(input, delimiter)
    input = tostring(input)
    delimiter = tostring(delimiter)
    if (delimiter=='') then return false end
    local pos,arr = 0, {}
    for st,sp in function() return string.find(input, delimiter, pos, true) end do
        table.insert(arr, string.sub(input, pos, st - 1))
        pos = sp + 1
    end
    table.insert(arr, string.sub(input, pos))
    return arr
end

function this.IsFinish(resourceID)
  if this.surveyDict == nil then
    return false
  end
  if this.surveyDict[resourceID] == nil then
    return false
  else
    return true
  end
end

function this.OnFinish(resourceID)
  if this.surveyDict == nil then
    this.surveyDict = {}
  end
  this.surveyDict[resourceID] = true
end
-----------------------------------------------------------------