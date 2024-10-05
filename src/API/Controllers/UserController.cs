using Application.Users.Create;
using Application.Users.Delete;
using Application.Users.GetAll;
using Application.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var query = new GetAllUsersQuery();
        var result = await _mediator.Send(query);
        if (result.Any())
            return Ok(result);

        return NoContent();
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

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateUserCommand CreateUserCommand)
    {
        var result = await _mediator.Send(CreateUserCommand);
        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{identification}")]
    public async Task<IActionResult> DeleteCustomer(string identification)
    {
        var deletecustomerCommand = new DeleteUserCommand(identification);
        await _mediator.Send(deletecustomerCommand);
        return Ok();
    }
}