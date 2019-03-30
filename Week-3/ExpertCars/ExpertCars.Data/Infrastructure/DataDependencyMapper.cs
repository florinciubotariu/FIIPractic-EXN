using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertCars.Data.Infrastructure
{
  public static class DataDependencyMapper
  {
    public static void RegisterDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
    {
      serviceCollection.AddDbContext<ExpertCarsContext>(x=> x.UseSqlServer(configuration.GetConnectionString("Database")));
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
  }
}
