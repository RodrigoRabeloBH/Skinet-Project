using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skinet.Model;

namespace Skinet.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasColumnType("varchar(180)").HasMaxLength(180);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
            builder.HasOne(p => p.TierPrice).WithMany().HasForeignKey(p => p.TierPriceId);
        }
    }
}