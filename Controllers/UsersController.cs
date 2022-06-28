using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Domain.Handlers.Users;
using WebApi.Helpers;
using WebApi.Interfaces;
using WebApi.Models.Users;
using WebApi.Services;

namespace WebApi.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private readonly AppSettings _appSettings;

    public UsersController(
        IUserService userService,
        IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
     {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register([FromServices] IMediator mediator,
                                  [FromBody] RegisterRequest command)
    {
        return Ok(mediator.Send(command));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromServices] IMediator mediator, 
                                [FromQuery] int id, 
                                [FromBody] UpdateRequest command)
    {
        command.Id = id;
        mediator.Send(command);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }
}