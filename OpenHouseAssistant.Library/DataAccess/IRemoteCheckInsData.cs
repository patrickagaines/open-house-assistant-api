using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public interface IRemoteCheckInsData
{
    Task CheckIn(GuestCheckInModel guestCheckIn);
    Task<string?> GetRedirectUrlByPropertyId(int propertyId);
}