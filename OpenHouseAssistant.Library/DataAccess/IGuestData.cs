using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public interface IGuestData
{
    Task<GuestModel> CheckIn(string userId, GuestCheckInModel guestCheckIn);
    Task Delete(string userId, int guestId);
    Task<List<GuestModel>> GetAllAssigned(string userId);
    Task<List<GuestModel>> GetAllAssignedByOpenHouse(string userId, int openHouseId);
    Task<List<GuestModel>> GetAllAssignedByProperty(string userId, int propertyId);
    Task<GuestModel?> GetOneAssigned(string userId, int guestId);
    Task RemoveFromOpenHouse(string userId, int guestId, int openHouseId);
    Task Update(string userId, int guestId, GuestModel guest);
}