--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

local all_obj = {}

setmetatable(all_obj, { __mode = "kv" })

function debug_record(o)
	if(_debug) then
		all_obj[o] = true
	end
end

local function find_intable(t, o, r)
	if(t==nil) then return end

	if(r[t])then
		return
	end

	r[t] = true

	for k, v in pairs(t) do
		if(k == o) then
			print("find", k)
			return
		elseif(v == o) then
			print("find", v)
			return
		end


		if(type(k) == "table") then
			find_intable(k, o, r)
		end

		if(type(v)=="table")then
			find_intable(v, o, r)
		end
	end
end

local function find_global(o)
	if(o==nil) then
		return
	end

	find_intable(_G, o, {})
end

function debug_print_all()
	if not _debug then 
		return
	end

	local cnt = 0
	for	v,b in pairs(all_obj) do
		cnt = cnt + 1
		if(type(v)=="function") then
			print("function : ", pcall(v))
		elseif(v.GetType) then
			print("monoType : ", v:GetType(), type(v))
		elseif(v.cls) then
			print("luaObj : cls name ", v.cls.name)
		elseif(v.name) then
			print("luaObj : obj name ", v.name)
		elseif(type(v)=="table") then
			print("↓↓↓↓↓↓↓begin table↓↓↓↓↓↓↓")
			for k1, v1 in pairs(v) do
				print(k1, v1)
			end
			print("↑↑↑↑↑↑↑end table↑↑↑↑↑↑↑↑↑")
		else 
			print("unknow : ", v)
		end

		find_global(v)

	end

	print("all cnt : "..cnt)
end