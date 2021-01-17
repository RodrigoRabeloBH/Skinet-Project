using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Skinet.Model;
using Skinet.Model.OrderAggregate;

namespace Skinet.Data
{
    public class SkinetContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<TierPrice> TierPrices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        public SkinetContext(DbContextOptions<SkinetContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
