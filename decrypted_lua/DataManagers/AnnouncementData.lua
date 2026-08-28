local this = {}

function this:OnSuccReceive(anns)
    if self.anns ~= anns then
        self.anns = anns
        Message.Dispatch(MessageKey.OnGetAnnouncement)
    end
end

AnnouncementData = this 
