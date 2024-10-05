using Application.Users.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Tags("Users")]
[ApiController]
public class GetAllUsersEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public GetAllUsersEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Permite consultar la lista de todos los usuarios existentes
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(GetAllUsersQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiVersion}/user")]
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