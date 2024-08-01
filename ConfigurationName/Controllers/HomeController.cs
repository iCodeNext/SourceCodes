using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationName.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class HomeController(IOptions<Settings> settings) : ControllerBase
{
    private readonly Settings _settings = settings.Value;

    [HttpGet]
    public IActionResult Index()
    {
        return Ok($"Hello From iCodeNext! {_settings.Sms_Rest_Uri1}");
    }
}
