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
        protected readonly ApplicationDbContext Context;
        private DbSet<TEntity> Table;

        public Repository(ApplicationDbContext _context)
        {
            Context = _context;
            Table = Context.Set<TEntity>();
        }

        // Create
        public void Add(TEntity entity)
        {
            Table.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Table.AddRange(entities);
        }


        // Read
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table.AsEnumerable();
        }

        public TEntity GetById(long id)
        {
            return Table.Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return Table.Where(where).AsEnumerable();
        }


        // Update
        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }


        // Delete
        public void Delete(TEntity entity)
        {
            TEntity existing = Table.Find(entity);
            if (existing != null)
                Table.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = Table.Where(where).AsEnumerable<TEntity>();
            Table.RemoveRange(objects);
        }

        public void Delete(long id)
        {
            TEntity obj = GetById(id);
            Table.Remove(obj);
        }
    }
}
