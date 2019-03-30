using Microsoft.EntityFrameworkCore;
using System;

namespace ExpertCars.Data.Infrastructure
{

  public interface IUnitOfWork : IDisposable
  {
    ExpertCarsContext Context { get; }
    void Commit();
  }
}