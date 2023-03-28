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
    private string GetUserId()
    {
        string output = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        return output;
    }

    // GET: api/OpenHouses
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET: api/OpenHouses/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/OpenHouses
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/OpenHouses/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/OpenHouses/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
