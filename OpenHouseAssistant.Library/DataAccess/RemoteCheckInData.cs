using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public class RemoteCheckInData : IRemoteCheckInData
{
    private readonly ISqlDataAccess _sql;

    public RemoteCheckInData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<RemoteCheckInInfoModel?> GetRedirectUrlByPropertyId(int propertyId)
    {
        var results = await _sql.LoadData<RemoteCheckInInfoModel, dynamic>("dbo.spRemoteCheckIns_GetRemoteCheckInInfo",
            new { PropertyId = propertyId },
            "Default");

        return results.FirstOrDefault();
    }

    public Task CheckIn(GuestCheckInModel guestCheckIn)
    {
        return _sql.SaveData<dynamic>("dbo.spRemoteCheckIns_CheckIn",
            new
            {
                OpenHouseId = guestCheckIn.OpenHouseId,
                PropertyId = guestCheckIn.PropertyId,
                FirstName = guestCheckIn.FirstName,
                LastName = guestCheckIn.LastName,
                PhoneNumber = guestCheckIn.PhoneNumber,
                EmailAddress = guestCheckIn.EmailAddress
            },
            "Default");
    }
}

