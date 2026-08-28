--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

-- lua端消息系统
-- c#端只能调用Dispatch,不能调用Regist和Remove
-- 事件key为字符串（函数名）， 回调参数listener为对象。 listener[key](listener, params)
local this = {}

local _listeners = {}

local function _FindIndex(listenerList, listener)
    for i = 1, #listenerList do
        if listenerList[i] == listener then
            return i
        end
    end

    return -1
end

local function _Regist(eventName, listener)
    if type(listener) ~= "table" then
        Debug.LogError("MsgMgr listener参数必须是对象（table）")
        return
    end

    local cbList = _listeners[eventName]
    if cbList == nil then
        _listeners[eventName] = { listener }
    else
        table.insert(cbList, listener)
    end
end

local function _Remove(eventName, listener)
    local cbList = _listeners[eventName]

    if cbList == nil then
        return
    end

    local index = _FindIndex(cbList, listener)

    if (index <= 0) then
        return
    end

    table.remove(cbList, index)
end

local function _Dispatch(eventName, ...)
    local cbList = _listeners[eventName]

    if cbList == nil then
        return
    end

    local callResult = 0
    for i = 1, #cbList do
        local listener = cbList[i]
        local cb = listener[eventName]
        if (cb ~= nil) then
            cb(listener, ...)
        else
            Debug.LogError("注册了监听，但未找到监听函数："..eventName)
        end
        callResult = i
    end
    if callResult ~= #cbList then
        Debug.LogError("丢失了注册函数回调..")
    end
end

-- 静态函数，注册消息处理
-- listener必须是table
-- eventName 即为key，也为回调函数名
function this.Regist(eventName, listener)
    _Regist(eventName, listener)
end

-- 静态函数，撤销消息处理
-- listener必须是table
-- eventName 即为key，也为回调函数名
function this.Remove(eventName, listener)
    _Remove(eventName, listener)
end

-- 静态函数，派发消息
-- eventName 即为key，也为回调函数名
function this.Dispatch(eventName, ...)
    _Dispatch(eventName, ...)
end

function this:ClearAll()
    this = {}
    _listeners = {}
end

-- c#端调用
function DispatchMessage(eventName, ...)
    local params = ...

    if params == nil or params.Length == 0 then
        -- 无参
        _Dispatch(eventName)
        return
    end

    -- c# 变长参数被作为object[]数组传入到lua
    -- 这里需要将object[] 转换成lua变长参数
    local n = params.Length
    local list = {}
    for i = 0, n - 1 do
        table.insert(list, params[i])
    end
    
    _Dispatch(eventName, table.unpack(list))
end

Message = this
