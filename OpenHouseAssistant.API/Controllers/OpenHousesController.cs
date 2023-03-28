using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.API.Controllers;

[Route("api/open-houses")]
[ApiController]
[Authorize]
public class OpenHousesController : ControllerBase
{
    private readonly IOpenHouseData _data;

    public OpenHousesController(IOpenHouseData data)
    {
        _data = data;
    }

    private string GetUserId()
    {
        string output = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        return output;
    }

    // GET: api/open-houses
    [HttpGet]
    public async Task<ActionResult<List<OpenHouseModel>>> GetAll()
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

    // GET: api/open-houses/{openHouseId}
    [HttpGet("{openHouseId}")]
    public async Task<ActionResult<OpenHouseModel>> GetOne(int openHouseId)
    {
        try
        {
            var output = await _data.GetOneAssigned(GetUserId(), openHouseId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/open-houses/property/{propertyId}
    [HttpGet("property/{propertyId}")]
    public async Task<ActionResult<List<OpenHouseModel>>> GetAllByProperty(int propertyId)
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

    // POST: api/open-houses
    [HttpPost]
    public async Task<ActionResult<OpenHouseModel>> Post([FromBody] OpenHouseModel openHouse)
    {
        try
        {
            var output = await _data.Create(GetUserId(), openHouse);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/open-houses/{openHouseId}
    [HttpPut("{openHouseId}")]
    public async Task<IActionResult> Put(int openHouseId, [FromBody] OpenHouseModel openHouse)
    {
        try
        {
            await _data.Update(GetUserId(), openHouseId, openHouse);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/open-houses/{openHouseId}
    [HttpDelete("{openHouseId}")]
    public async Task<IActionResult> Delete(int openHouseId)
    {
        try
        {
            await _data.Delete(GetUserId(), openHouseId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
