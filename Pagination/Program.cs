using Microsoft.EntityFrameworkCore;

using var ctx = new BloggingContext();

var someBlogs = await ctx.Blogs
    .OrderBy(b => b.Id)
    .Skip(20)
    .Take(10)
    .ToArrayAsync();

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseNpgsql("Host=localhost;Username=postgres;Password=supersecret")
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
}

public class Blog 
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateOnly LastUpdated { get; set; }
}