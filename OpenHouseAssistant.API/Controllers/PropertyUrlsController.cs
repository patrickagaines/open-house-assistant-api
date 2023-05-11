using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenHouseAssistant.Library.DataAccess;

namespace OpenHouseAssistant.API.Controllers;

[Route("api/property-urls")]
[ApiController]
[Authorize]
public class PropertyUrlsController : ControllerBase
{
    private readonly IPropertyUrlData _data;

    public PropertyUrlsController(IPropertyUrlData data)
    {
        _data = data;
    }

    // GET: api/property-urls/{propertyId}
    [HttpGet("{propertyId}")]
    public async Task<ActionResult<string>> GetOne(int propertyId)
    {
        try
        {
            var output = await _data.GetOneByPropertyId(propertyId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/property-urls/{propertyId}
    [HttpPut("{propertyId}")]
    public async Task<IActionResult> Put(int propertyId, [FromBody] string propertyUrl)
    {
        try
        {
            await _data.Update(propertyId, propertyUrl);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
