using FlutterApiBlog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterApiBlog.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    [HttpGet("v1/posts/me")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var posts = await context.Posts.FirstOrDefaultAsync(x => x.Author != null && x.Author.Email == "gabul@balta.io");
        return Ok(posts);
    }

    [HttpGet("v1/posts")]
    public async Task<IActionResult> GetAllAsync([FromServices] AppDbContext context)
    {
        var posts = await context.Posts.ToListAsync();
        return Ok(posts);
    }
}