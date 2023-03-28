namespace OpenHouseAssistant.Library.Models;

#nullable disable

public class OpenHouseModel
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int PropertyId { get; set; }
    public string StreetAddress { get; set; }
    public string UnitNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}

