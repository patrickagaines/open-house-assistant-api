namespace OpenHouseAssistant.Library.DataAccess;

public interface IPropertyUrlData
{
    Task<string?> GetOneByPropertyId(int propertyId);
    Task Update(int propertyId, string propertyUrl);
}