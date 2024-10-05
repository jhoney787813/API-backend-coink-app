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
public class GetByIdEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public GetByIdEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{identification}")]
    public async Task<IActionResult> GetById(string identification)
    {
        var query = new GetUserByIdQuery(identification);
        var result = await _mediator.Send(query);
        if (result is null || result == default)
            return NotFound();

        return Ok(result);
    }

}