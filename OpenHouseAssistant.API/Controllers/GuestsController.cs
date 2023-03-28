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
    // GET: api/guests
    [HttpGet]
    public async Task<ActionResult<List<GuestModel>>> GetAll()
    {
        throw new NotImplementedException();
    }

    // GET: api/guests/{guestId}
    [HttpGet("{guestId}")]
    public async Task<ActionResult<GuestModel>> GetOne(int guestId)
    {
        throw new NotImplementedException();
    }

    // GET: api/guests/property/{propertyId}
    [HttpGet("property/{propertyId}")]
    public async Task<ActionResult<List<GuestModel>>> GetAllByProperty(int propertyId)
    {
        throw new NotImplementedException();
    }

    // GET: api/guests/open-house/{openHouseId}
    [HttpGet("open-house/{openHouseId}")]
    public async Task<ActionResult<List<GuestModel>>> GetAllByOpenHouse(int openHouseId)
    {
        throw new NotImplementedException();
    }

    // POST: api/guests
    [HttpPost]
    public async Task<ActionResult<GuestModel>> CheckIn([FromBody] GuestModel guest)
    {
        throw new NotImplementedException();
    }

    // PUT: api/guests/{guestId}
    [HttpPut("{guestId}")]
    public async Task<IActionResult> Put(int guestId, [FromBody] GuestModel guest)
    {
        throw new NotImplementedException();
    }

    // DELETE: api/guests/{guestId}
    [HttpDelete("{guestId}")]
    public async Task<IActionResult> Delete(int guestId)
    {
        throw new NotImplementedException();
    }
}
