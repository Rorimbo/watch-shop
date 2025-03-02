using Core.BusinessLogic;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private IUsersService _usersService = new UsersService();

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("create")]
    public int CreateUser(NewUser user)
    {
        var id = _usersService.CreateUser(user);
        return id;
    }

    [HttpGet]
    [Route("login")]
    public int LogIn(string email, string password)
    {
        var id = _usersService.LogIn(email, password);
        return id;
    }

    [HttpGet]
    [Route("info/{id}")]
    public User GetUserInfo(int id)
    {
        var user = _usersService.GetUserInfo(id);
        return user;
    }

    [HttpPut]
    [Route("info")]
    public void UpdateUserInfo(User user)
    {
        _usersService.UpdateUserInfo(user);
        return;
    }
}
