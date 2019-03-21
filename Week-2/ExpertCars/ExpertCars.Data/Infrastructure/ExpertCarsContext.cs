using ExpertCars.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCars.Data.Infrastructure
{
  public class ExpertCarsContext : DbContext
  {
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
        @"Server=(localdb)\mssqllocaldb;Database=ExpertCars;Trusted_Connection=True");
    }


  }
}
