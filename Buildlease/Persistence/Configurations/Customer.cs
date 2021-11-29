using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Configurations
{
    class CustomerBuilder : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder .ToTable("Customer")
                    .HasKey(e => e.UserId);

            builder .Property(e => e.UserId)
                    .IsRequired();

            builder .Property(e => e.CompanyName)
                    .IsRequired(false)
                    .HasMaxLength(100);

            builder .Property(e => e.RepresentativeName)
                    .IsRequired(false)
                    .HasMaxLength(100);

            builder .Property(e => e.ContactInfo)
                    .IsRequired(false)
                    .HasMaxLength(1000);

            builder .HasOne(c => c.ApplicationUser)
                    .WithOne()
                    .HasForeignKey<Customer>(c => c.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
