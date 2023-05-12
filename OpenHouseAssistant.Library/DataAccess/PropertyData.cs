using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public class PropertyData : IPropertyData
{
    private readonly ISqlDataAccess _sql;

    public PropertyData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public Task<List<PropertyModel>> GetAllAssigned(string userId)
    {
        return _sql.LoadData<PropertyModel, dynamic>("dbo.spProperties_GetAllAssigned",
            new { UserId = userId },
            "Default");
    }

    public async Task<PropertyWithUrlModel?> GetOneAssigned(string userId, int propertyId)
    {
        var results = await _sql.LoadData<PropertyWithUrlModel, dynamic>("dbo.spProperties_GetOneAssigned",
            new { UserId = userId, PropertyId = propertyId },
            "Default");

        return results.FirstOrDefault();
    }

    public async Task<PropertyModel> Create(string userId, PropertyModel property)
    {
        var results = await _sql.LoadData<PropertyModel, dynamic>("dbo.spProperties_Create",
            new
            {
                UserId = userId,
                StreetAddress = property.StreetAddress,
                UnitNumber = property.UnitNumber,
                City = property.City,
                State = property.State,
                ZipCode = property.ZipCode
            },
            "Default");

        return results.First();
    }

    public Task Update(string userId, int propertyId, PropertyModel property)
    {
        return _sql.SaveData<dynamic>("dbo.spProperties_Update",
            new
            {
                PropertyId = propertyId,
                UserId = userId,
                StreetAddress = property.StreetAddress,
                UnitNumber = property.UnitNumber,
                City = property.City,
                State = property.State,
                ZipCode = property.ZipCode
            },
            "Default");
    }

    public Task Delete(string userId, int propertyId)
    {
        return _sql.SaveData<dynamic>("dbo.spProperties_Delete",
            new { UserId = userId, PropertyId = propertyId },
            "Default");
    }
}   

