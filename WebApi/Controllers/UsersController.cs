using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("create")]
    public int CreateUser(NewUser user)
    {
        var id = 1;
        return id;
    }

    [HttpGet]
    [Route("login")]
    public int LogIn(string email, string password)
    {
        var id = 1;
        return id;
    }

    [HttpGet]
    [Route("info/{id}")]
    public User GetUserInfo(int id)
    {
        var user = new User();
        return user;
    }

    [HttpPut]
    [Route("info")]
    public void UpdateUserInfo(User user)
    {
    }
}
