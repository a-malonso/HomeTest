using Microsoft.EntityFrameworkCore;
using SaviaHomeTest.Domain.Entities;

namespace SaviaHomeTest.Infrastructure.Persistence;

/// <summary>
/// DbContext for read database
/// </summary>
public class AppDbContextRead : DbContext
{
    public AppDbContextRead(DbContextOptions<AppDbContextRead> options) : base(options) { }

    public DbSet<TaskToDo> TasksToDo { get; set; }

    /// <summary>
    /// Configures the database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskToDo>(x =>
        {
            x.HasQueryFilter(x => !x.IsDeleted);

            x.Property(p => p.Description)
             .HasMaxLength(200)
             .IsRequired();

            x.Property(p => p.Priority)
             .IsRequired();

            x.Property(p => p.IsDone)
             .HasDefaultValue(false);

            x.Property(p => p.IsDeleted)
             .HasDefaultValue(false);
        });
    }
}
