using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Skinet.Model;
using Skinet.Model.OrderAggregate;

namespace Skinet.Data
{
    public class SkinetContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<TierPrice> TierPrice { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }

        public SkinetContext(DbContextOptions<SkinetContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data source=skinet.db");
            optionsBuilder.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=Skinet.db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
