using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.Models;

namespace OpenHouseAssistant.API.Controllers;

[Route("api/properties")]
[ApiController]
[Authorize]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyData _data;

    public PropertiesController(IPropertyData data)
    {
        _data = data;
    }

    private string GetUserId()
    {
        string output = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        return output;
    }

    // GET: api/properties
    [HttpGet]
    public async Task<ActionResult<List<PropertyModel>>> GetAll()
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

    // GET: api/properties/{propertyId}
    [HttpGet("{propertyId}")]
    public async Task<ActionResult<PropertyModel>> GetOne(int propertyId)
    {
        try
        {
            var output = await _data.GetOneAssigned(GetUserId(), propertyId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/properties
    [HttpPost]
    public async Task<ActionResult<PropertyModel>> Post([FromBody] PropertyModel property)
    {
        try
        {
            var output = await _data.Create(GetUserId(), property);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/properties/{propertyId}
    [HttpPut("{propertyId}")]
    public async Task<IActionResult> Put(int propertyId, [FromBody] PropertyModel property)
    {
        try
        {
            await _data.Update(GetUserId(), propertyId, property);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/properties/{propertyId}
    [HttpDelete("{propertyId}")]
    public async Task<IActionResult> Delete(int propertyId)
    {
        try
        {
            await _data.Delete(GetUserId(), propertyId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
