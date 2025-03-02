using Core.BusinessLogic;
using Core.DB;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
