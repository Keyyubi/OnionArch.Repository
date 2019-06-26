using System;
using Microsoft.EntityFrameworkCore;

namespace Sale.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }


        public int Commit()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
