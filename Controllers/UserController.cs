using FlutterApiBlog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterApiBlog.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("v1/users/me")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email == "gabul@balta.io");
        return Ok(user);
    }

    [HttpGet("v1/users")]
    public async Task<IActionResult> GetAllAsync([FromServices] AppDbContext context)
    {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }
}