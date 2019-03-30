using ExpertCars.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCars.Data.Infrastructure
{
  /// <summary>
  /// From your Expert Network buddies.
  /// Open a CMD inside ExpertCars.Data folder and run the following commands:
  /// dotnet ef migrations add "Migration Name" --startup-project "..\ExpertCars.Web\ExpertCars.Web.csproj"
  /// dotnet ef database update --startup-project "..\ExpertCars.Web\ExpertCars.Web.csproj"
  /// </summary>
  public class ExpertCarsContext : DbContext
  {
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public ExpertCarsContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //->https://www.learnentityframeworkcore.com/configuration/fluent-api
    {
      modelBuilder.Entity<User>().Property(x => x.Email).HasColumnType("nvarchar(30)");
      modelBuilder.Entity<User>().Property(x => x.Name).HasColumnType("nvarchar(50)");

      modelBuilder.Entity<Vehicle>().Property(x => x.VIN).HasColumnType("varchar(17)");
    }
  }
}