using Application.Users.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Tags("Users")]
[ApiController]
public class CreateUserEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateUserEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Permite el registro de un nuevo usuario
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(CreateUserCommandResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiVersion}/user")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand CreateUserCommand)
    {
        var result = await _mediator.Send(CreateUserCommand);
        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Error);
    }
}