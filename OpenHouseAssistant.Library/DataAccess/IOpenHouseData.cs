using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public interface IOpenHouseData
{
    Task<OpenHouseModel> Create(string userId, OpenHouseModel openHouse);
    Task Delete(string userId, int openHouseId);
    Task<List<OpenHouseModel>> GetAllAssigned(string userId);
    Task<List<OpenHouseModel>> GetAllAssignedByProperty(string userId, int propertyId);
    Task<OpenHouseModel?> GetOneAssigned(string userId, int openHouseId);
    Task Update(string userId, int openHouseId, OpenHouseModel openHouse);
}