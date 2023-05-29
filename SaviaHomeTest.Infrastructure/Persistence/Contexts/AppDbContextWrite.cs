using Microsoft.EntityFrameworkCore;
using SaviaHomeTest.Domain.Entities;

namespace SaviaHomeTest.Infrastructure.Persistence;

/// <summary>
/// DbContext for write database
/// </summary>
public class AppDbContextWrite : DbContext
{
    public AppDbContextWrite(DbContextOptions<AppDbContextWrite> options) : base(options) { }

    public DbSet<TaskToDo> TasksToDo { get; set; }

    /// <summary>
    /// Configures de database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskToDo>(x =>
        {
            x.Property(p => p.Description)
             .HasMaxLength(200)
             .IsRequired();

            x.Property(p => p.Priority)
             .IsRequired();

            x.Property(p => p.IsDone);
            //.HasDefaultValue(false);

            x.Property(p => p.IsDeleted);
             //.HasDefaultValue(false);
        });    
    }
}
