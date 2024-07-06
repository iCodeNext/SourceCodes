using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultPattern.Application.Features.UserManagement;

namespace ResultPattern.Api;

[ApiController]
[Route("api/[controller]/[action]")]
public class SimpleController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Add(CreateUserCommand command)
    {
        return Ok(await _sender.Send(command));
    }
}
