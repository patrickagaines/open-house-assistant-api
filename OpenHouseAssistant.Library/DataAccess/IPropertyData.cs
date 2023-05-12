using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public interface IPropertyData
{
    Task<List<PropertyModel>> GetAllAssigned(string userId);
    Task<PropertyWithUrlModel?> GetOneAssigned(string userId, int propertyId);
    Task<PropertyModel> Create(string userId, PropertyModel property);
    Task Update(string userId, int propertyId, PropertyModel property);
    Task Delete(string userId, int propertyId);
}