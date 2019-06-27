using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Sale.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Injection
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create
        public void Add(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Context.Set<TEntity>().AddRange(entities);
        }


        // Read
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(params string[] navigations)
        {
            return _unitOfWork.Context.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetById(long id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _unitOfWork.Context.Set<TEntity>().Where(where).AsEnumerable();
        }


        // Update
        public void Update(TEntity entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<TEntity>().Attach(entity);
        }


        // Delete
        public void Delete(TEntity entity)
        {
            TEntity existing = _unitOfWork.Context.Set<TEntity>().Find(entity);
            if (existing != null)
                _unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = _unitOfWork.Context.Set<TEntity>().Where(where).AsEnumerable<TEntity>();
            _unitOfWork.Context.Set<TEntity>().RemoveRange(objects);
        }

        public void Delete(long id)
        {
            TEntity obj = GetById(id);
            _unitOfWork.Context.Set<TEntity>().Remove(obj);
        }
    }
}
