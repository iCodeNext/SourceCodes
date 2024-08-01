using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationName.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class HomeController() : ControllerBase
{

    [HttpGet]
    public IActionResult Index()
    {
        return Ok($"Hello From iCodeNext!");
    }
}
