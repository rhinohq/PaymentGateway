using System;
using Microsoft.EntityFrameworkCore;

using PaymentGateway.Data;

namespace PaymentGateway.Server.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

        public StoreDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                    "DataSource=store.db", b => b.MigrationsAssembly("PaymentGateway.Server"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}
