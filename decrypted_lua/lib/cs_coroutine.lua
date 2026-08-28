--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

local util = require "xlua/util"
cs_coroutine = class('cs_coroutine')
local Holder = 	CS.XLuaExten.IEnumeratorHolder
local runnerType = typeof(CS.XLuaExten.Coroutine_Runner)

local this = cs_coroutine

function this:ctor(name)
	local gameobject = GameObject(name)
	gameobject:GetOrAddComponent(typeof(DontDestoryOnLoadComp))
	self.runner = gameobject:AddComponent(runnerType)
end

function this:start(func, ...)
	local holder = Holder(util.cs_generator(func, ...))
	self.runner:StartCoroutine(holder)
	return holder
end

function this:stop(holder)
	self.runner:StopCoroutine(holder)
end

CsCoroutine = cs_coroutine.new('Coroutine_Runner')
