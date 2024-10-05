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
public class GetAllUsersEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public GetAllUsersEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var result = await _mediator.Send(query);
        if (result.Any())
            return Ok(result);

        return NoContent();
    }
}