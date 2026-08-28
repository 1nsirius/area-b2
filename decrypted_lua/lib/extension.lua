function table.indexOf(t, element, compare)
    for i=1,#t do
        local find = false
        if compare == nil then
          find = t[i] == element
        else
          find = compare(t[i], element)
        end
        if find == true then
            return i
        end
    end
    return -1
end

function table.addrange(t1, t2)
  for i=1,#t2 do
    table.insert(t1, t2[i])
  end
  return t1
end

function table.insertSort(t, element, compare)
  if #t <= 0 then
    table.insert(t, element)
    return
  end
  for i=1,#t do 
    local compareE = t[i]
    local result = compare(compareE, element)
    if result == true then
      table.insert(t, i, element)
      return 
    end
  end
  table.insert(t, element)
end

function table.copyfields(source, target, override)
    for k,v in pairs(source) do
        local targetV = rawget(target, k)
        if targetV == nil or override == true then
            target[k] = v
        end
    end 
end

function table.tostring(tt, indent, done)
    if tt == nil then return "nil" end
    done = done or {}
    indent = indent or 0
    if type(tt) == "table" then
      local sb = {}
      for key, value in pairs (tt) do
        table.insert(sb, string.rep (" ", indent)) -- indent it
        if type (value) == "table" and not done[value] then
          done[value] = true
          table.insert(sb, key .. " = {\n");
          table.insert(sb, table.tostring(value, indent + 2, done))
          table.insert(sb, string.rep (" ", indent)) -- indent it
          table.insert(sb, "}\n");
        elseif "number" == type(key) then
          table.insert(sb, tostring(value).."("..type(value)..")".."\n")
        else
          table.insert(sb, tostring(key).."="..tostring(value).."("..type(value)..")".."\n")
         end
      end
      return table.concat(sb)
    else
      return tt .. "\n"
    end
end

function table.shift(t)
    if #t <= 0 then
        return nil
    end

    local result = t[1]
    for i=1,#t do
        if i==#t then
            t[i] = nil
            break
        end
        t[i] = t[i+1]
    end
    return result
end

function table.getn(t)
    local n = 0
    for k,_ in pairs(t) do
      n = n+1
    end
    return n
end
