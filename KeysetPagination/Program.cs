using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MR.EntityFrameworkCore.KeysetPagination;

using var ctx = new BloggingContext();

var keysetContext = ctx.Blogs
    .KeysetPaginate(
        blog => blog.Ascending(entity => entity.LastUpdated).Ascending(entity => entity.Id));

var blogs = await keysetContext.Query
    .Take(10)
    .ToListAsync();

keysetContext.EnsureCorrectOrder(blogs);

var reference = blogs[blogs.Count - 1];

keysetContext = ctx.Blogs
    .KeysetPaginate(
        blog => blog.Ascending(entity => entity.LastUpdated).Ascending(entity => entity.Id),
        KeysetPaginationDirection.Forward,
        reference);

blogs = await keysetContext.Query
    .Take(10)
    .ToListAsync();

keysetContext.EnsureCorrectOrder(blogs);

var hasNext = await keysetContext.HasNextAsync(blogs);

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