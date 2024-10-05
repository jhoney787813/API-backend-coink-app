using Application.Users.Create;
using Application.Users.Delete;
using Application.Users.GetAll;
using Application.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Backend.Coink.App.Controllers;
[Tags("Users")]
[ApiController]
[Route("api/[controller]")]
public class DeleteUserEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteUserEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpDelete("{identification}")]
    public async Task<IActionResult> DeleteUser(string identification)
    {
        var deleteUserCommand = new DeleteUserCommand(identification);
        await _mediator.Send(deleteUserCommand);
        return Ok();
    }
}