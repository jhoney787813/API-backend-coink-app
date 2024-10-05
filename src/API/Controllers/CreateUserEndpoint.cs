using Application.Users.Create;
using Application.Users.Delete;
using Application.Users.GetAll;
using Application.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Tags("Users")]
[ApiController]
[Route("api/[controller]")]
public class CreateUserEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateUserEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand CreateUserCommand)
    {
        var result = await _mediator.Send(CreateUserCommand);
        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Error);
    }
}