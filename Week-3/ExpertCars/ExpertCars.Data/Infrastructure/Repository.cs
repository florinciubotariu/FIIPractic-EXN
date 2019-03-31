using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpertCars.Data.Infrastructure
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<T> dbSet;
    public Repository(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      dbSet = unitOfWork.Context.Set<T>();
    }

    public IQueryable<T> Query()
    {
      return dbSet.AsQueryable();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> expression)
    {
      return dbSet.Where(expression).AsQueryable();
    }

    public void Add(T entity)
    {
      dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
      T existing = dbSet.Find(entity);
      if (existing != null) dbSet.Remove(existing);
    }

    public IEnumerable<T> Get()
    {
      return dbSet.AsEnumerable<T>();
    }

    public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
      return dbSet.Where(predicate).AsEnumerable<T>();
    }

    public void Update(T entity)
    {
      dbSet.Attach(entity);
      _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
    }
  }
}