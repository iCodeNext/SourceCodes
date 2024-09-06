using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationName.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class HomeController(IOptions<Settings> options) : ControllerBase
{
    Settings settings = options.Value;
    [HttpGet]
    public IActionResult Index()
    {
       // settings.Id = 5666;
        return Ok($"Hello From iCodeNext! {settings.Id}");
    }
}
