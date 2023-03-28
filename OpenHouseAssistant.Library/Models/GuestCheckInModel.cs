namespace OpenHouseAssistant.Library.Models;

#nullable disable

public class GuestCheckInModel
{
    public int OpenHouseId { get; set; }
    public int PropertyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
}

