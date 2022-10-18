using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

const int page = 3;
const int pageSize = 10;

using var ctx = new BloggingContext();

var someBlogs = await ctx.Blogs
    .OrderBy(b => b.Id)
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToArrayAsync();

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseNpgsql("Host=localhost;Username=postgres;Password=supersecret")
            .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted, })
            .EnableSensitiveDataLogging();
}

public class Blog 
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateOnly LastUpdated { get; set; }
}