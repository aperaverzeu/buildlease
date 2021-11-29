using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class AddressBuilder : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder .ToTable("Address")
                    .HasKey(e => e.Id);

            builder .Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder .Property(e => e.CustomerId)
                    .IsRequired();

            builder .Property(e => e.Priority)
                    .IsRequired();

            builder .Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(20);

            builder .Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

            builder .Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

            builder .Property(e => e.Building)
                    .IsRequired()
                    .HasMaxLength(100);

            builder .Property(e => e.Office)
                    .IsRequired()
                    .HasMaxLength(100);

            builder .HasOne<Customer>(a => a.Customer)
                    .WithMany(c => c.Addresses)
                    .HasForeignKey(a => a.CustomerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
