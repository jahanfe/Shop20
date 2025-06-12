using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.DbContext;

public class ApplicationDbContext :Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Children)
            .WithOne(c => c.Parent)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false) // ParentId is nullable
            .OnDelete(DeleteBehavior.Restrict); // Prevent cyclic deletion issues, or choose Cascade
    }
}
