using System.Text.Json;
using ODataSelectQueryOptionIssue.Models;
using Microsoft.EntityFrameworkCore;

namespace ODataSelectQueryOptionIssue.Data
{
public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    _ = modelBuilder.Entity<Machine>().Property(e => e.MachineTags).HasConversion(
    //        d => JsonSerializer.Serialize(d, (JsonSerializerOptions?)null),
    //        e => JsonSerializer.Deserialize<List<string>>(e, (JsonSerializerOptions?)null));

    //    base.OnModelCreating(modelBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Machine>().Property(e => e.MachineTags).HasConversion(
            d => d != null ? string.Join(',', d) : null,
            e => !string.IsNullOrEmpty(e) ? e.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Machine> Machines { get; set; }
}
}
