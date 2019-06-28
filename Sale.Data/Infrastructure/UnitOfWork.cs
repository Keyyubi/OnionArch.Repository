using System;
using Microsoft.EntityFrameworkCore;

namespace Sale.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }


        public int Commit()
        {
            // A transaction can be used in here liked below
            // Or loggin can be done here
            // using (var transaction = Context.Database.BeginTransaction()
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
