using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class ProductOrderBuilder : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder .ToTable("ProductOrder")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.OrderId)
                    .IsRequired();

            builder .Property(e => e.ProductId)
                    .IsRequired();

            builder .Property(e => e.Count)
                    .IsRequired();

            builder .Property(e => e.SerializedProductFullView)
                    .IsRequired()
                    .HasDefaultValue(string.Empty)
                    .HasMaxLength(int.MaxValue);

            builder .HasOne<Order>(po => po.Order)
                    .WithMany(o => o.ProductOrders)
                    .HasForeignKey(po => po.OrderId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder .HasOne<Product>(po => po.Product)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(po => po.ProductId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
