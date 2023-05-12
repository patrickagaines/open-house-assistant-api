using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public class RemoteCheckInsData : IRemoteCheckInsData
{
    private readonly ISqlDataAccess _sql;

    public RemoteCheckInsData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<string?> GetRedirectUrlByPropertyId(int propertyId)
    {
        var results = await _sql.LoadData<string, dynamic>("dbo.spRemoteCheckIns_GetRedirectUrlByPropertyId",
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

