using System;
using Microsoft.EntityFrameworkCore;
using Sale.Data.Model;

namespace Sale.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Model.Sale> Sales { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            // Some changes can be applied in here before creating tables.
            base.OnModelCreating(modelBuilder);
        }
    }
}
