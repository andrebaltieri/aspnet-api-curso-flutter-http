using FlutterApiBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace FlutterApiBlog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
}