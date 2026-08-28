--region *.lua
--Date
--此文件由[BabeLua]插件自动生成



--endregion

local function print_table_recur(t, prefix, record)

	if(type(t) ~= 'table')then
		return
	end

	if(record[t]) then return end
	record[t] = true

	for k, v in pairs(t) do
		if(type(v) == 'table') then
			print(prefix, k, ' : ')
			print_table_recur(v, prefix .. '\t', record)
		else
			print(prefix, k, v)
		end
	end
end



function print_table(t)
	print '------------begin-------------'
	print_table_recur(t, '', {})
	print '------------end---------------'
end


local function create_wrap(o, func)
	return function(...)
		func(o, ...)
	end
end

function del_wrap(o, func)
	if(o.dels == nil) then
		o.dels = {}
		local wrap = create_wrap(o, func)
		o.dels[func] = wrap 
		return wrap
	end

	local wrap = o.dels[func]
	if(not wrap)then
		wrap = create_wrap(o, func)
		o.dels[func] = wrap
	end

	return wrap
end