using HelloDotnet.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Vehicle> Vehicles { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>()
      .Property(u => u.Id)
      .HasDefaultValueSql("gen_random_uuid()");

    modelBuilder.Entity<Vehicle>()
      .Property(v => v.Id)
      .HasDefaultValueSql("gen_random_uuid()");
  }
}