
using Application.Users.Query.GetAll;
using Application.Users.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Tags("Users")]
[ApiController]
public class GetByIdEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public GetByIdEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Permite consultar la información de un usuario pasando la cédula como parametro ¿
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(GetUserByIdQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiVersion}/user/{identification}")]
    [HttpGet]
    public async Task<IActionResult> GetById(string identification)
    {
        var query = new GetUserByIdQuery(identification);
        var result = await _mediator.Send(query);
        if (result is null || result == default)
            return NotFound();

        return Ok(result);
    }

}