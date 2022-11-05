using FlutterApiBlog.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase("app"));
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();