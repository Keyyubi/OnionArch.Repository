using System;
using Microsoft.EntityFrameworkCore;

namespace Sale.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        int Commit();
    }
}
