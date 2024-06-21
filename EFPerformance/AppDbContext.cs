using EFPerformance.CompiledModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPerformance;
internal class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            //.UseModel(AppDbContextModel.Instance)
            //.EnableServiceProviderCaching(false)
            .UseSqlServer("Server=DESKTOP-TVCSFN3\\MHA;Database=EFCoreExamples;Trusted_Connection=True;Encrypt=false");
            //.EnableSensitiveDataLogging()
            //.UseLazyLoadingProxies()
            //.LogTo(Console.WriteLine, LogLevel.Information);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    public virtual ICollection<Tag> Tags { get; set; }
}

public class Tag
{
    public int Id { get; set; }
    public string Title { get; set; }

    public int PostId { get; set; }
    [ForeignKey(nameof(PostId))]
    public virtual Post Post { get; set; }
}