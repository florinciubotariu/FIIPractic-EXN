using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpertCars.Data.Infrastructure
{
  public interface IRepository<T> where T : class
  {
    IQueryable<T> Query();
    IQueryable<T> Query(Expression<Func<T, bool>> expression);
    IEnumerable<T> Get();
    IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
  }
}
