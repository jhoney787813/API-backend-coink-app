using Application.Users.Command.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Backend.Coink.App.Controllers;
[Tags("Users")]
[ApiController]
public class DeleteUserEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteUserEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Permite la eliminación de un usuario parando la cédula como parametro
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(DeleteUserCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiVersion}/user/{identification}")]
    [HttpDelete()]
    public async Task<IActionResult> DeleteUser(string identification)
    {
        var deleteUserCommand = new DeleteUserCommand(identification);
        await _mediator.Send(deleteUserCommand);
        return Ok();
    }
}