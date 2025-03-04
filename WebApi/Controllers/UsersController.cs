using Core.BusinessLogic;
using Core.DB;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    ApplicationContext _context;
    private readonly ILogger<UsersController> _logger;
    private IUsersService _usersService;

    public UsersController(ILogger<UsersController> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
        _usersService = new UsersService(_context);
    }

    [HttpPost]
    [Route("create")]
    public async Task<int> CreateUserAsync(NewUser user)
    {
        var id = await _usersService.CreateUserAsync(user);
        return id;
    }

    [HttpGet]
    [Route("login")]
    public async Task<int> LogInAsync(string email, string password)
    {
        var id = await _usersService.LogInAsync(email, password);
        return id;
    }

    [HttpGet]
    [Route("info/{id}")]
    public async Task<User> GetUserInfoAsync(int id)
    {
        var user = await _usersService.GetUserInfoAsync(id);
        return user;
    }

    [HttpPut]
    [Route("info")]
    public async Task UpdateUserInfoAsync(User user)
    {
        await _usersService.UpdateUserInfoAsync(user);
    }
}
