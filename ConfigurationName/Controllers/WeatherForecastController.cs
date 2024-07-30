using Microsoft.AspNetCore.Mvc;

namespace ConfigurationName.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class Home : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello From iCodeNext!");
    }
}
