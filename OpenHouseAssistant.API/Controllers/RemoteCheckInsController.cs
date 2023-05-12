using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.API.Controllers;

[Route("api/remote-check-ins")]
[ApiController]
public class RemoteCheckInsController : ControllerBase
{
    private readonly IRemoteCheckInData _data;

    public RemoteCheckInsController(IRemoteCheckInData data)
    {
        _data = data;
    }

    // GET: api/remote-check-ins/{propertyId}
    [HttpGet("{propertyId}")]
    public async Task<ActionResult<RemoteCheckInInfoModel>> GetInfo(int propertyId)
    {
        try
        {
            var output = await _data.GetRemoteCheckInInfo(propertyId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/remote-check-ins
    [HttpPost]
    public async Task<IActionResult> CheckIn([FromBody] GuestCheckInModel guestCheckIn)
    {
        try
        {
            await _data.CheckIn(guestCheckIn);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
