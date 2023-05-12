using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public interface IRemoteCheckInData
{
    Task CheckIn(GuestCheckInModel guestCheckIn);
    Task<string?> GetRedirectUrlByPropertyId(int propertyId);
}