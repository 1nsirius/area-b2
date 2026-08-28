require 'lib.extension'

local clone = function(object)
    local lookup_table = {}
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end
        local new_table = {}
        lookup_table[object] = new_table
        for key, value in pairs(object) do
            new_table[_copy(key)] = _copy(value)
        end
        return setmetatable(new_table, getmetatable(object))
    end
    return _copy(object)
end

--Create an class.
function class(classname, super, current)
    local superType = type(super)
    ---@class Class
    local cls

    if superType ~= "function" and superType ~= "table" then
        superType = nil
        super = nil
    end

    -- __ctype = 1 : c++ object
    -- __ctype = 2 : lua object
    if superType == "function" or (super and super.__ctype == 1) then
        -- inherited from native C++ Object
        cls = current ~= nil and current or {}

        if superType == "table" then
            -- copy fields from super
            for k,v in pairs(super) do cls[k] = v end

            -- __create is c++ object construCtor function
            cls.__create = super.__create
            cls.super    = super
        else
            cls.__create = super
        end

        cls.ctor    = function() end
        cls.__cname = classname
        cls.cname = classname
        cls.__ctype = 1

        function cls.new(...)
            local instance = cls.__create(...)
            -- copy fields from class to native object
            for k,v in pairs(cls) do instance[k] = v end
            instance.class = cls
            instance:ctor(...)
            return instance
        end

    else
        -- inherited from Lua Object
        if super then
            cls = clone(super)
            if current ~= nil then
                for k,v in pairs(current) do 
                    if type(v) ~= "function" then
                        cls[k] = v
                    end
                end
            end
            cls.super = super
        else
            cls = current ~= nil and current or {}
            cls.ctor = function() end
        end

        cls.__cname = classname
        cls.cname = classname
        cls.__ctype = 2 -- lua
        cls.__index = cls

        function cls.new(...)
            local instance = setmetatable({}, cls)
            instance.class = cls
            instance:ctor(...)
            return instance
        end
    end

    return cls
end

-- 日志输出工具，方便添加调试逻辑
Logger = class("Logger", nil, {
    mTag = "Tag",
    mStacktrace = false,
})
function Logger:ctor(tag, stacktrace)
    self.mTag = tag
    self.mStacktrace = stacktrace
end
function Logger:_Log(...)
    local msg = "["..self.mTag.."] "
    local paramsNum = select('#', ...)
    for i=1,paramsNum do
        msg = msg..self:_ToString(select(i, ...))..";"  
    end
    return msg
end
function Logger:_ToString(obj)
    if obj == "" then
        return "string.empty"
    end
    if obj == nil then
        return "nil"
    end
    if type(obj) == "function" then
        return "function"
    end
    if type(obj) == "table" then
        return table.tostring(obj)
    end
    return tostring(obj)
end
function Logger:Log(...)
    if self.mStacktrace == true then
        print("Log "..debug.traceback())
    end
    Debug.Log(self:_Log(...))
end
function Logger:LogError(...)
    if self.mStacktrace == true then
        print("LogError "..debug.traceback())
    end
    Debug.LogError(self:_Log(...))
end
function Logger:LogWarningRed(...)
    if self.mStacktrace == true then
        print("LogError "..debug.traceback())
    end
    Debug.LogWarningRed(self:_Log(...))
end