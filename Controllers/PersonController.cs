using Microsoft.AspNetCore.Mvc;

namespace ArchitectureTest.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete()
    {
        return Ok();
    }
}
