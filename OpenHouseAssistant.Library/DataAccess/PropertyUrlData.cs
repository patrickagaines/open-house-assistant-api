namespace OpenHouseAssistant.Library.DataAccess;

public class PropertyUrlData : IPropertyUrlData
{
    private readonly ISqlDataAccess _sql;

    public PropertyUrlData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<string?> GetOneByPropertyId(int propertyId)
    {
        var results = await _sql.LoadData<string, dynamic>("dbo.spPropertyUrls_GetOneByPropertyId",
            new { PropertyId = propertyId },
            "Default");

        return results.FirstOrDefault();
    }

    public Task Update(int propertyId, string propertyUrl)
    {
        return _sql.SaveData<dynamic>("dbo.spPropertyUrls_Update",
            new { PropertyId = propertyId, PropertyUrl = propertyUrl },
            "Default");
    }
}

