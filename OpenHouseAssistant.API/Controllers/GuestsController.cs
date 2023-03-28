using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.API.Controllers;

[Route("api/guests")]
[ApiController]
[Authorize]
public class GuestsController : ControllerBase
{
    private readonly IGuestData _data;

    public GuestsController(IGuestData data)
    {
        _data = data;
    }

    private string GetUserId()
    {
        string output = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        return output;
    }

    // GET: api/guests
    [HttpGet]
    public async Task<ActionResult<List<GuestModel>>> GetAll()
    {
        try
        {
            var output = await _data.GetAllAssigned(GetUserId());
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/guests/{guestId}
    [HttpGet("{guestId}")]
    public async Task<ActionResult<GuestModel>> GetOne(int guestId)
    {
        try
        {
            var output = await _data.GetOneAssigned(GetUserId(), guestId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/guests/property/{propertyId}
    [HttpGet("property/{propertyId}")]
    public async Task<ActionResult<List<GuestModel>>> GetAllByProperty(int propertyId)
    {
        try
        {
            var output = await _data.GetAllAssignedByProperty(GetUserId(), propertyId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/guests/open-house/{openHouseId}
    [HttpGet("open-house/{openHouseId}")]
    public async Task<ActionResult<List<GuestModel>>> GetAllByOpenHouse(int openHouseId)
    {
        try
        {
            var output = await _data.GetAllAssignedByOpenHouse(GetUserId(), openHouseId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/guests
    [HttpPost]
    public async Task<ActionResult<GuestModel>> CheckIn([FromBody] GuestCheckInModel guestCheckIn)
    {
        try
        {
            var output = await _data.CheckIn(GetUserId(), guestCheckIn);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/guests/{guestId}
    [HttpPut("{guestId}")]
    public async Task<IActionResult> Put(int guestId, [FromBody] GuestModel guest)
    {
        try
        {
            await _data.Update(GetUserId(), guestId, guest);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/guests/{guestId}
    [HttpDelete("{guestId}")]
    public async Task<IActionResult> Delete(int guestId)
    {
        try
        {
            await _data.Delete(GetUserId(), guestId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/guests/{guestId}/open-house/{openHouseId}
    [HttpDelete("{guestId}/open-house/{openHouseId}")]
    public async Task<IActionResult> RemoveFromOpenHouse(int guestId, int openHouseId)
    {
        try
        {
            await _data.RemoveFromOpenHouse(GetUserId(), guestId, openHouseId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
