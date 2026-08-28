LanguageAPI={}
local this = LanguageAPI


function this.GetMapName(mapId)
    
    local t = type(mapId)
    
    if t ~= 'number' then
        return nil
    end

    local name_lang_index = TableData.maps[mapId].name_lang_index
    return LanguageMgrInst:GetString(name_lang_index)
end