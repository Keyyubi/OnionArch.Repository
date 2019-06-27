using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sale.Service
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        T GetById(long id);
        void Update(T entity);
        void Delete(T entity);
        void Delete(long id);

        int SaveChanges();
    }
}
