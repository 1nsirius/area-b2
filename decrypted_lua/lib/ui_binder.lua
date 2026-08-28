--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

if(_debug) then
	require 'lib/debug_utils'
end

-- 将comp_tree中的view注入到crt_ctrl
--function inject_view_recur(crt_ctrl, comp_tree)
--	crt_ctrl.mono = comp_tree.mono
--	crt_ctrl:setCallBack(comp_tree.mono)
--	local view = crt_ctrl.view
--	for name, child in pairs(comp_tree.comp_table) do
--		if(child.is_tree) then
--			local comp_cls_name = child.comp_name..'_comp_cls';
--			require('view.'..comp_cls_name)
--			local comp_ctrl = _G[comp_cls_name]:new()
--			view[name] = comp_ctrl
--			inject_view_recur(comp_ctrl, child)
--		else
--			view[name] = child
--			if(debug)then
--				debug_record(child)
--			end
--		end
--	end
--end

-- 绑定lua_ui_ctrl 与 LuaComponent脚本
function new_ui_ctrl(name, go, uri)
	local ctrl_cls = name.."Ctrl"
	require ('UI/Ctrls/'..ctrl_cls)
	local uiCtrl =_G[ctrl_cls]:new()

    local viewName = name.."Panel"
	require ('UI/Views/'..viewName)
	uiCtrl.view = _G[viewName]:new()
	if(_debug) then
		debug_record(uiCtrl)
	end
    
    uiCtrl.uri = uri
	uiCtrl.gameObject = go
	uiCtrl:awake(go)
	-- 放棄該方案，改用直接生成view代碼
--	local comp_tree ={}
--	mono:GetCompTree(comp_tree, function(t, n) 
--		local sub_table = {}
--		t[n] = sub_table
--		return sub_table
--	end)
--	inject_view_recur(uiCtrl,comp_tree)
	return uiCtrl	
end