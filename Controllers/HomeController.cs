using System.Text.RegularExpressions;
using Faker;
using FlutterApiBlog.Data;
using FlutterApiBlog.Models;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace FlutterApiBlog.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("v1/data/refresh")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        await LoadUsers(context);
        return Ok(new { message = "Dados atualizados" });
    }

    private async Task LoadUsers(AppDbContext context)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        var gabul = new User
        {
            Id = Guid.NewGuid(),
            Name = "Gabriel Gabul",
            Image = "https://picsum.photos/200/200",
            CreatedAt = GetRandomDate(),
            Email = "gabul@balta.io",
            Password = PasswordGenerator.Generate(8),
            Bio = Lorem.Paragraph(10)
        };
        await context.Users.AddAsync(gabul);
        
        for (var i = 0; i < 28; i++)
        {
            var name = Name.FullName();
            var email = Regex.Replace(name, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled).ToLower() + "@balta.io";
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Image = "https://picsum.photos/200/200",
                CreatedAt = GetRandomDate(),
                Email = email,
                Password = PasswordGenerator.Generate(8),
                Bio = Lorem.Paragraph(10)
            };
            await context.Users.AddAsync(user);
        }

        await context.SaveChangesAsync();
    }

    DateTime GetRandomDate()
    {
        var rnd = new Random();
        return new DateTime(rnd.Next(2016, 2022), rnd.Next(1, 12), rnd.Next(1, 28));
    }
}