local JSON = require 'ejoysdk_lua.ejoysdk_json'
local this = {}
this.inLobbyStateNormal = false
this.enableAutoPop = true

function this.OnSuccReceive(anns)
    if InternalAnnouncementData.anns ~= anns then
        InternalAnnouncementData.anns = anns
        Message.Dispatch(MessageKey.OnGetInternalAnnouncement)
    end
    if InternalAnnouncementData.enableAutoPop == true then
        if UiMgr:IsOpen(LuaPanelNames.BillboardForHallPanel) == false and InternalAnnouncementData.inLobbyStateNormal and InternalAnnouncementData.ValidAnns(anns) then
            UiMgr:ShowUi(LuaPanelNames.BillboardForHallPanel, UILayer.Up)
        else
            InternalAnnouncementData.ClearAutoPopState()
        end
    end
end

function this.OnFailReceive()
    InternalAnnouncementData.ClearAutoPopState()
end

--清除自动弹，除非客户端关了再开不然就再也不会自动弹了
function this.ClearAutoPopState()
    if InternalAnnouncementData.enableAutoPop == true then
        CS.FGame.ActivityDataManager.Instance.AutoPopEnabled = true
    end
    InternalAnnouncementData.enableAutoPop = false
end

function this.PrepareAutoPop()
    print("<color=red>PrepareAutoPop</color>")
    if CS.FGuidance.ExecuteOperationManager.Instance.IsGuiding then
        CS.FGame.ActivityDataManager.Instance.AutoPopEnabled = true
        return
    end
    if InternalAnnouncementData.enableAutoPop == false then
        CS.FGame.ActivityDataManager.Instance.AutoPopEnabled = true
        return
    end
    InternalAnnouncementAPI.GetAnnouncement()
end

function this.ValidAnns(anns)
    if anns ~= nil and type(anns) == "string" then
		print("局内公告内容: "..anns)
		anns = string.gsub(anns, "Order field", "Order_field")
		anns = '['..anns.."]"
		anns = JSON:decode(anns)
		if anns ~= nil and anns[1] ~= nil then
            anns = anns[1].anns
        else
            anns = nil
        end
        if anns ~= nil and type(anns) == "table" and #anns > 0 then
            local maxPopCount = 0
            for i=1,#anns do
                if anns[i] ~= nil and anns[i].value ~= nil and anns[i].value.pop ~= nil and type(anns[i].value.pop) == "number" then
                    if maxPopCount < anns[i].value.pop then
                        maxPopCount = anns[i].value.pop
                    end
                end
            end
            if InternalAnnouncementData._CheckPopCount(maxPopCount) then
                return true
            else
                return false
            end
        end
    end
    return false
end

function this._CheckPopCount(maxPopCount)
    local lastPopDate = PlayerPrefs.GetString("InternalAnnouncementAutoPopDate", "")
    local hasPopCount = PlayerPrefs.GetInt("InternalAnnouncementAutoPopCount", 0)
    local currentDate = Utility.GetDelayedDateDisplay(ServerTimeManager.Instance:GetServerGameTime(), 4, 0, 0)
    print("<color=red>lastPopDate: "..lastPopDate..", currentDate: "..currentDate..", hasPopCount: "..hasPopCount..", maxPopCount: "..maxPopCount, "</color>")
    if lastPopDate ~= currentDate then
        hasPopCount = 0
        if hasPopCount >= maxPopCount then
            PlayerPrefs.SetString("InternalAnnouncementAutoPopDate", currentDate)
            PlayerPrefs.SetInt("InternalAnnouncementAutoPopCount", hasPopCount)
            return false
        else
            hasPopCount = hasPopCount + 1
            PlayerPrefs.SetString("InternalAnnouncementAutoPopDate", currentDate)
            PlayerPrefs.SetInt("InternalAnnouncementAutoPopCount", hasPopCount)
            return true
        end
    else
        if hasPopCount >= maxPopCount then
            return false
        else
            hasPopCount = hasPopCount + 1
            PlayerPrefs.SetInt("InternalAnnouncementAutoPopCount", hasPopCount)
            return true
        end
    end
end

InternalAnnouncementData = this 
