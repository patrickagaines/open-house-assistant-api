using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.Library.DataAccess
{
    public class GuestData : IGuestData
    {
        private readonly ISqlDataAccess _sql;

        public GuestData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<List<GuestModel>> GetAllAssigned(string userId)
        {
            return await _sql.LoadData<GuestModel, dynamic>("dbo.spGuests_GetAllAssigned",
                new { UserId = userId },
                "Default");
        }

        public async Task<GuestModel?> GetOneAssigned(string userId, int guestId)
        {
            var results = await _sql.LoadData<GuestModel, dynamic>("dbo.spGuests_GetOneAssigned",
                new { UserId = userId, GuestId = guestId },
                "Default");

            return results.FirstOrDefault();
        }

        public async Task<List<GuestModel>> GetAllAssignedByProperty(string userId, int propertyId)
        {
            return await _sql.LoadData<GuestModel, dynamic>("dbo.spGuests_GetAllAssignedByProperty",
                new { UserId = userId, PropertyId = propertyId },
                "Default");
        }

        public async Task<List<GuestModel>> GetAllAssignedByOpenHouse(string userId, int openHouseId)
        {
            return await _sql.LoadData<GuestModel, dynamic>("dbo.spGuests_GetAllAssignedByOpenHouse",
                new { UserId = userId, OpenHouseId = openHouseId },
                "Default");
        }

        public async Task<GuestModel> CheckIn(string userId, GuestCheckInModel guestCheckIn)
        {
            var results = await _sql.LoadData<GuestModel, dynamic>("dbo.spGuests_CheckIn",
                new
                {
                    UserId = userId,
                    OpenHouseId = guestCheckIn.OpenHouseId,
                    PropertyId = guestCheckIn.PropertyId,
                    FirstName = guestCheckIn.FirstName,
                    LastName = guestCheckIn.LastName,
                    PhoneNumber = guestCheckIn.PhoneNumber,
                    EmailAddress = guestCheckIn.EmailAddress
                },
                "Default");

            return results.First();
        }

        public Task Update(string userId, int guestId, GuestModel guest)
        {
            return _sql.SaveData<dynamic>("dbo.spGuests_Update",
                new
                {
                    UserId = userId,
                    GuestId = guestId,
                    FirstName = guest.FirstName,
                    LastName = guest.LastName,
                    PhoneNumber = guest.PhoneNumber,
                    EmailAddress = guest.EmailAddress
                },
                "Default");
        }

        public Task Delete(string userId, int guestId)
        {
            return _sql.SaveData<dynamic>("dbo.spGuests_Delete",
                new { UserId = userId, GuestId = guestId },
                "Default");
        }

        public Task RemoveFromOpenHouse(string userId, int guestId, int openHouseId)
        {
            return _sql.SaveData<dynamic>("dbo.spGuests_RemoveFromOpenHouse",
                new
                {
                    UserId = userId,
                    GuestId = guestId,
                    OpenHouseId = openHouseId
                },
                "Default");
        }
    }
}

