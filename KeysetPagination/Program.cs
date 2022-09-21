using Microsoft.EntityFrameworkCore;
using MR.EntityFrameworkCore.KeysetPagination;

using var ctx = new BloggingContext();

var keysetContext = ctx.Blogs
    .KeysetPaginate(
        blog => blog.Ascending(entity => entity.LastUpdated).Ascending(entity => entity.Id));

var blogs = await keysetContext.Query
    .Take(10)
    .ToListAsync();

keysetContext.EnsureCorrectOrder(blogs);

var lastItem = blogs[9];

keysetContext = ctx.Blogs
    .KeysetPaginate(
        blog => blog.Ascending(entity => entity.LastUpdated).Ascending(entity => entity.Id),
        KeysetPaginationDirection.Forward,
        lastItem);

blogs = await keysetContext.Query
    .Take(10)
    .ToListAsync();

keysetContext.EnsureCorrectOrder(blogs);

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