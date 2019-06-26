using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sale.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        T Get(Expression<Func<T, bool>> predicate);
        T GetById(long id);
        IEnumerable<T> GetAll(params string[] navigations);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        void Update(T entity);

        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
    }
}
