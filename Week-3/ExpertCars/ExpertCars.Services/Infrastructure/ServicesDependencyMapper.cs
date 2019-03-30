using ExpertCars.Data.Infrastructure;
using ExpertCars.Services.Common.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertCars.Services.Infrastructure
{
  public static class ServicesDependencyMapper
  {
    public static void RegisterDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
    {
      DataDependencyMapper.RegisterDependencies(serviceCollection, configuration);

      serviceCollection.AddScoped<IUserService, UserService>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
    }
  }
}
