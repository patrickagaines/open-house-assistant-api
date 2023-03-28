using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess;

public class OpenHouseData : IOpenHouseData
{
    private readonly ISqlDataAccess _sql;

    public OpenHouseData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public Task<List<OpenHouseModel>> GetAllAssigned(string userId)
    {
        return _sql.LoadData<OpenHouseModel, dynamic>("dbo.spOpenHouses_GetAllAssigned",
            new { UserId = userId },
            "Default");
    }

    public async Task<OpenHouseModel?> GetOneAssigned(string userId, int openHouseId)
    {
        var results = await _sql.LoadData<OpenHouseModel, dynamic>("dbo.spOpenHouses_GetOneAssigned",
            new { UserId = userId, OpenHouseId = openHouseId },
            "Default");

        return results.FirstOrDefault();
    }

    public Task<List<OpenHouseModel>> GetAllAssignedByProperty(string userId, int propertyId)
    {
        return _sql.LoadData<OpenHouseModel, dynamic>("dbo.spOpenHouses_GetAllAssignedByProperty",
            new { UserId = userId, PropertyId = propertyId },
            "Default");
    }

    public async Task<OpenHouseModel> Create(string userId, OpenHouseModel openHouse)
    {
        var results = await _sql.LoadData<OpenHouseModel, dynamic>("dbo.spOpenHouses_Create",
            new
            {
                UserId = userId,
                Date = openHouse.Date,
                StartTime = openHouse.StartTime,
                EndTime = openHouse.EndTime,
                PropertyId = openHouse.PropertyId,
                StreetAddress = openHouse.StreetAddress,
                UnitNumber = openHouse.UnitNumber,
                City = openHouse.City,
                State = openHouse.State,
                ZipCode = openHouse.ZipCode

            },
            "Default");

        return results.First();
    }

    public Task Update(string userId, int openHouseId, OpenHouseModel openHouse)
    {
        return _sql.SaveData<dynamic>("dbo.spOpenHouses_Update",
            new
            {
                OpenHouseId = openHouseId,
                UserId = userId,
                Date = openHouse.Date,
                StartTime = openHouse.StartTime,
                EndTime = openHouse.EndTime
            },
            "Default");
    }

    public Task Delete(string userId, int openHouseId)
    {
        return _sql.SaveData<dynamic>("dbo.spOpenHouses_Delete",
            new { UserId = userId, OpenHouseId = openHouseId },
            "Default");
    }
}

