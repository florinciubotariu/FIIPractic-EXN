using Microsoft.EntityFrameworkCore;
using System;

namespace ExpertCars.Data.Infrastructure
{

  public interface IUnitOfWork : IDisposable
  {
    DbContext Context { get; }
    void Commit();
  }
}
//https://pastebin.com/bs17nJFT