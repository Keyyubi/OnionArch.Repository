using System;
using Microsoft.EntityFrameworkCore;

namespace Sale.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }
        int Commit();
    }
}
