using Microsoft.EntityFrameworkCore;
using Workaholic.ProductService.Domain;

namespace Workaholic.ProductService.Repository;

public partial class UdemyUnitTestDBContext : DbContext
{
    // public UdemyUnitTestDBContext()
    // {
    // }

    public UdemyUnitTestDBContext(DbContextOptions<UdemyUnitTestDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}