using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ResultPattern.Api;

[ApiController]
public class SimpleController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    public IActionResult Add()

}
