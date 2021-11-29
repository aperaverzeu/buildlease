using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class OrderBuilder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder .ToTable("Order")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.CustomerId)
                    .IsRequired();

            builder .Property(e => e.SerializedCustomerInfo)
                    .IsRequired(false)
                    .HasDefaultValue(string.Empty)
                    .HasMaxLength(int.MaxValue);

            builder .Property(e => e.Status)
                    .IsRequired();

            builder .HasOne<Customer>(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
