
namespace ExpertCars.Data.Infrastructure
{
  public class UnitOfWork : IUnitOfWork
  {
    public ExpertCarsContext Context { get; }

    public UnitOfWork(ExpertCarsContext context)
    {
      Context = context;
    }
    public void Commit()
    {
      Context.SaveChanges();
    }

    public void Dispose()
    {
      Context.Dispose();
    }
  }
}
