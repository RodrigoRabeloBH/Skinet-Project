using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skinet.Model.OrderAggregate;

namespace Skinet.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(s => s.Status).HasConversion(o => o.ToString(), o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o));
            builder.Property(o => o.Subtotal).HasColumnType("decimal(18,2)");
            builder.Property(o => o.Total).HasColumnType("decimal(18,2)");
            builder.HasMany(o => o.OrderItems).WithOne(io => io.Order).HasForeignKey(io => io.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}